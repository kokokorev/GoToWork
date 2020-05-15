using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.Interfaces;
using GoToWorkBusinessLogic.ViewModels;
using GoToWorkDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace GoToWorkDatabaseImplement.Implements
{
    public class ToyLogic : IToyLogic
    {
        public void CreateOrUpdate(ToyBindingModel model)
        {
            using (var context = new GoToWorkDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Toy element = context.Toys.FirstOrDefault(rec => rec.ToyName == model.ToyName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть игрушка с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Toys.FirstOrDefault(rec => rec.Id == model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Toy();
                            context.Toys.Add(element);
                        }
                        element.ToyName = model.ToyName;
                        element.DateCreate = DateTime.Now;
                        context.SaveChanges();

                        if (model.Id.HasValue)
                        {
                            var ToyParts = context.ToyParts.Where(rec => rec.ToyId == model.Id.Value).ToList();
                        }
                        foreach (var pc in model.ToyParts)
                        {
                            context.ToyParts.Add(new ToyParts
                            {
                                ToyId = element.Id,
                                PartId = pc.Key,
                                PartCount = pc.Value.Item3
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(ToyBindingModel model)
        {
            using (var context = new GoToWorkDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.ToyParts.RemoveRange(context.ToyParts.Where(rec => rec.ToyId == model.Id));
                        Toy element = context.Toys.FirstOrDefault(rec => rec.Id == model.Id);

                        if (element != null)
                        {
                            context.Toys.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<ToyViewModel> Read(ToyBindingModel model)
        {
            using (var context = new GoToWorkDatabase())
            {
                return context.Toys.Where(rec => model == null || rec.Id == model.Id).ToList().Select(rec => new ToyViewModel
                {
                    Id = rec.Id,
                    ToyName = rec.ToyName,
                    DateCreate = rec.DateCreate,
                    ToyParts = context.ToyParts.Include(recPC => recPC.Part).Where(recPC => recPC.ToyId == rec.Id).ToDictionary(recPC => recPC.PartId, recPC => (recPC.Part?.PartType, recPC.Part?.PartColor, recPC.PartCount))
                }).ToList();
            }
        }
    }
}