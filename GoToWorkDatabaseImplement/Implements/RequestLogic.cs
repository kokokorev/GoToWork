using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.Enums;
using GoToWorkBusinessLogic.Interfaces;
using GoToWorkBusinessLogic.ViewModels;
using GoToWorkDatabaseImplement.Models;

namespace GoToWorkDatabaseImplement.Implements
{
    public class RequestLogic : IRequestLogic
    {
        public void CreateOrUpdate(RequestBindingModel model)
        {
            using (var context = new GoToWorkDatabase())
            {
                Request element;
                if (model.Id.HasValue)
                {
                    element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Request();
                    context.Requests.Add(element);
                }

                element.ProviderId = model.ProviderId == null ? element.ProviderId : (int)model.ProviderId;
                element.ProviderFIO = model.ProviderFIO;
                element.PartType = model.PartType;
                element.PartColor = model.PartColor;
                element.PartCount = model.PartCount;
                element.RequestStatus = model.RequestStatus;
                element.DateExecution = model.DateExecution;
                context.SaveChanges();
            }
        }
        public void Delete(RequestBindingModel model)
        {
            using (var context = new GoToWorkDatabase())
            {
                Request element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Requests.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<RequestViewModel> Read(RequestBindingModel model)
        {
            using (var context = new GoToWorkDatabase())
            {
                return context.Requests.Where(rec => model == null || rec.Id == model.Id).Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    ProviderFIO = rec.ProviderFIO,
                    PartType = rec.PartType,
                    PartColor = rec.PartColor,
                    PartCount = rec.PartCount,
                    RequestStatus = rec.RequestStatus,
                    DateExecution = rec.DateExecution
                }).ToList();
            }
        }
    }
}