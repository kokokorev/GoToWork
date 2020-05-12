using System;
using System.Collections.Generic;
using System.Text;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.Enums;
using GoToWorkBusinessLogic.Interfaces;
using GoToWorkBusinessLogic.ViewModels;

namespace GoToWorkBusinessLogic.BusinessLogics
{
    public class AddPartlogic
    {
        private readonly IPartLogic partLogic;

        public AddPartlogic(IPartLogic partLogic)
        {
            this.partLogic = partLogic;
        }

        public void AddPart(PartBindingModel model)
        {
            var parts = partLogic.Read(null);
            PartViewModel part = null;

            foreach (var p in parts)
            {
                if (p.PartType == model.PartType && p.PartColor == model.PartColor && p.PartStatus == model.PartStatus)
                {
                    part = p;
                    break;
                }
            }

            if (part != null)
            {
                partLogic.CreateOrUpdate(new PartBindingModel
                {
                    Id = part.Id,
                    PartType = part.PartType,
                    PartColor = part.PartColor,
                    PartCount = part.PartCount + model.PartCount,
                    PartStatus = part.PartStatus,
                    DateRecieve = part.DateRecieve
                });
            }
            else
            {
                partLogic.CreateOrUpdate(new PartBindingModel
                {
                    PartType = model.PartType,
                    PartColor = model.PartColor,
                    PartCount = model.PartCount,
                    PartStatus = PartStatus.Прибыл,
                    DateRecieve = DateTime.Now
                });
            }
        }
    }
}
