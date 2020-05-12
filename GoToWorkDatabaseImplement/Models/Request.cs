using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoToWorkBusinessLogic.Enums;

namespace GoToWorkDatabaseImplement.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int? ProviderId { get; set; }
        public string ProviderFIO { get; set; }
        [Required] public string PartType { get; set; }
        [Required] public string PartColor { get; set; }
        [Required] public int PartCount { get; set; }
        [Required] public RequestStatus RequestStatus { get; set; }
        public DateTime? DateExecution { get; set; }
        public Provider Provider { get; set; }
    }
}
