using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoToWorkBusinessLogic.Enums;

namespace GoToWorkRestApi.Models
{
    public class PartModel
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public string ProviderFIO { get; set; }
        public string PartType { get; set; }
        public string PartColor { get; set; }
        public int PartCount { get; set; }
        public PartStatus PartStatus { get; set; }
        public DateTime DateRecieve { get; set; }
        public DateTime? DateTransfer { get; set; }
    }
}
