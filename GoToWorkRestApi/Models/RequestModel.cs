using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoToWorkBusinessLogic.Enums;

namespace GoToWorkRestApi.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public int? ProviderId { get; set; }
        public string? ProviderFIO { get; set; }
        public string PartType { get; set; }
        public string PartColor { get; set; }
        public int PartCount { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public DateTime? DateExecution { get; set; }
    }
}
