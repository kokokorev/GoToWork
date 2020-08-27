using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.Enums;
using GoToWorkBusinessLogic.Interfaces;

namespace GoToWorkBusinessLogic.BusinessLogics
{
    public class PartStatusLogic
    {
        private readonly IPartLogic partLogic;

        public PartStatusLogic(IPartLogic partLogic)
        {
            this.partLogic = partLogic;
        }

        public void ChangePartStatus(ChangePartStatusBindingModel model)
        {
            var part = partLogic.Read(new PartBindingModel
            {
                Id = model.PartId,
                PartStatus = PartStatus.Костыль
            })?.FirstOrDefault();

            if (part == null)
            {
                throw new Exception("Деталь не найдена");
            }

            if (part.PartCount - model.PartCount >= 0)
            {
                partLogic.CreateOrUpdate(new PartBindingModel
                {
                    Id = part.Id,
                    ProviderId = part.ProviderId,
                    ProviderFIO = part.ProviderFIO,
                    PartType = part.PartType,
                    PartColor = part.PartColor,
                    PartCount = model.PartCount,
                    PartStatus = PartStatus.Убыл,
                    DateRecieve = part.DateRecieve,
                    DateTransfer = DateTime.Now
                });

                partLogic.CreateOrUpdate(new PartBindingModel
                {
                    ProviderId = part.ProviderId,
                    ProviderFIO = part.ProviderFIO,
                    PartType = part.PartType,
                    PartColor = part.PartColor,
                    PartCount = part.PartCount - model.PartCount,
                    PartStatus = PartStatus.Прибыл,
                    DateRecieve = part.DateRecieve
                });

            }
            else
            {
                throw new Exception("Не хватает деталей");
            }
        }
    }
}
