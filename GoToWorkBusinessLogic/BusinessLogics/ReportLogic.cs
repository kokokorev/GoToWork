using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.HelperModels;
using GoToWorkBusinessLogic.Interfaces;
using GoToWorkBusinessLogic.ViewModels;

namespace GoToWorkBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IPartLogic partLogic;
        public ReportLogic(IPartLogic partLogic)
        {
            this.partLogic = partLogic;
        }

        public void SaveToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(model);

            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = model.Email,
                FileName = model.FileName
            });
        }

        public void SaveToPdfFile(ReportBindingModel model)
        {
            if (model.dates != null)
            {
                SaveToPdf.CreateDoc(model);
            }
            else
            {
                model.PartDict = partLogic.Read(null);
                SaveToPdf.CreateDoc(model);
            }

            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = model.Email,
                FileName = model.FileName
            });
        }
    }
}
