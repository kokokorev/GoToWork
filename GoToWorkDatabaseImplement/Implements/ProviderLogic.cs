using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.Interfaces;
using GoToWorkBusinessLogic.ViewModels;
using GoToWorkDatabaseImplement.Models;

namespace GoToWorkDatabaseImplement.Implements
{
    public class ProviderLogic : IProviderLogic
    {
        public void CreateOrUpdate(ProviderBindingModel model)
        {
            using (var context = new GoToWorkDatabase())
            {
                Provider element = context.Providers.FirstOrDefault(rec => rec.Email == model.Email && rec.Id != model.Id);

                if (element != null)
                {
                    throw new Exception("Уже есть поставщик с такой почтой");
                }

                if (model.Id.HasValue)
                {
                    element = context.Providers.FirstOrDefault(rec => rec.Id == model.Id);

                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Provider();
                    context.Providers.Add(element);
                }

                element.FIO = model.FIO;
                element.Password = model.Password;
                element.Email = model.Email;

                context.SaveChanges();
            }
        }

        public void Delete(ProviderBindingModel model)
        {
            using (var context = new GoToWorkDatabase())
            {
                Provider element = context.Providers.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Providers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ProviderViewModel> Read(ProviderBindingModel model)
        {
            using (var context = new GoToWorkDatabase())
            {
                return context.Providers
                .Where(
                    rec => model == null
                    || rec.Id == model.Id
                    || rec.Email == model.Email && rec.Password == model.Password
                )
                .Select(rec => new ProviderViewModel
                {
                    Id = rec.Id,
                    FIO = rec.FIO,
                    Email = rec.Email,
                    Password = rec.Password
                })
                .ToList();
            }
        }
    }
}