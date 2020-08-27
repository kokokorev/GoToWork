using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoToWorkBusinessLogic.BindingModels;
<<<<<<< HEAD
using GoToWorkBusinessLogic.Enums;
using GoToWorkBusinessLogic.Interfaces;
using GoToWorkBusinessLogic.ViewModels;
using GoToWorkDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
=======
using GoToWorkBusinessLogic.Interfaces;
using GoToWorkBusinessLogic.ViewModels;
using GoToWorkDatabaseImplement.Models;
>>>>>>> c5de45aa0e96dc1a2a07dfc76df7593ac57c8152

namespace GoToWorkDatabaseImplement.Implements
{
    public class PartLogic : IPartLogic
    {
        public void CreateOrUpdate(PartBindingModel model)
        {
            using (var context = new GoToWorkDatabase())
            {
                Part element;

                if (model.Id.HasValue)
                {
                    element = context.Parts.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = context.Parts.FirstOrDefault(rec => rec.PartType == model.PartType && rec.PartColor == model.PartColor && rec.PartStatus == model.PartStatus);
                    if (element == null)
                    {
                        element = new Part();
                        context.Parts.Add(element);
                    }
                }

                element.ProviderId = model.ProviderId == null ? element.ProviderId : (int)model.ProviderId;
                element.ProviderFIO = model.ProviderFIO;
                element.PartType = model.PartType;
                element.PartColor = model.PartColor;
                element.PartCount = model.PartCount;
                element.PartStatus = model.PartStatus;
                element.DateRecieve = model.DateRecieve;
                element.DateTransfer = model.DateTransfer;
                context.SaveChanges();
            }
        }
        public void Delete(PartBindingModel model)
        {
            using (var context = new GoToWorkDatabase())
            {
                Part element = context.Parts.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Parts.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<PartViewModel> Read(PartBindingModel model)
        {
            using (var context = new GoToWorkDatabase())
            {
                return context.Parts.Where(rec => model == null || (rec.Id == model.Id) || (rec.PartStatus == model.PartStatus) || (rec.PartType == model.PartType && rec.PartColor == model.PartColor && rec.PartStatus == model.PartStatus))
                    .Select(rec => new PartViewModel
                    {
                        Id = rec.Id,
                        ProviderId = rec.ProviderId,
                        ProviderFIO = rec.ProviderFIO,
                        PartType = rec.PartType,
                        PartColor = rec.PartColor,
                        PartCount = rec.PartCount,
                        PartStatus = rec.PartStatus,
                        DateRecieve = rec.DateRecieve,
                        DateTransfer = rec.DateTransfer
                    }).ToList();
            }
        }
    }
}