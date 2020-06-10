using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.BusinessLogics;
using GoToWorkBusinessLogic.Enums;
using GoToWorkBusinessLogic.Interfaces;
using GoToWorkBusinessLogic.ViewModels;
using GoToWorkDatabaseImplement.Models;
using GoToWorkRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GoToWorkRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IPartLogic _part;
        private readonly IRequestLogic _request;
        private readonly ReportLogic _report;
        private readonly BackUpAbstractLogic _backUpAbstractLogic;
        public MainController(IPartLogic part, IRequestLogic request, ReportLogic report, BackUpAbstractLogic backUpAbstractLogic)
        {
            _part = part;
            _request = request;
            _report = report;
            _backUpAbstractLogic = backUpAbstractLogic;
        }

        [HttpGet]
        public List<PartModel> GetPartList() => _part.Read(null)?.Select(rec => PartConvert(rec)).ToList();
        [HttpGet]
        public PartModel GetPart(string partType, string partColor, PartStatus partStatus) => PartConvert(_part.Read(new PartBindingModel { PartType = partType, PartColor = partColor, PartStatus = partStatus })?.FirstOrDefault());
        [HttpGet]
        public List<RequestModel> GetRequestList() => _request.Read(null)?.Select(rec => RequestConvert(rec)).ToList();
        [HttpPost]
        public void OrderPart(PartBindingModel model) => _part.CreateOrUpdate(model);
        [HttpPost]
        public void ChangeRequestStatus(RequestBindingModel model) => _request.CreateOrUpdate(model);
        [HttpPost]
        public void CreateExcelReport(ReportBindingModel model) => _report.SaveToExcelFile(model);
        [HttpPost]
        public void CreatePdfReport(ReportBindingModel model) => _report.SaveToPdfFile(model);
        [HttpPost]
        public void CreateBackup(BackupBindingModel model) => _backUpAbstractLogic.CreateProviderArchive(model);
        private PartModel PartConvert(PartViewModel model)
        {
            if (model != null)
            {
                return new PartModel
                {
                    Id = model.Id,
                    ProviderId = model.ProviderId,
                    ProviderFIO = model.ProviderFIO,
                    PartType = model.PartType,
                    PartColor = model.PartColor,
                    PartCount = model.PartCount,
                    PartStatus = model.PartStatus,
                    DateRecieve = model.DateRecieve,
                    DateTransfer = model.DateTransfer
                };
            }
            else
            {
                return null;
            }
        }

        private RequestModel RequestConvert(RequestViewModel model)
        {
            if (model == null) return null;

            return new RequestModel
            {
                Id = model.Id,
                ProviderId = model.ProviderId,
                ProviderFIO = model.ProviderFIO,
                PartType = model.PartType,
                PartColor = model.PartColor,
                PartCount = model.PartCount,
                RequestStatus = model.RequestStatus,
                DateExecution = model.DateExecution
            };
        }
    }
}