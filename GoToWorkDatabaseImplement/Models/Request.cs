using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
=======
using System.ComponentModel.DataAnnotations;
using System.Text;
>>>>>>> c5de45aa0e96dc1a2a07dfc76df7593ac57c8152
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
<<<<<<< HEAD
}
=======
}
>>>>>>> c5de45aa0e96dc1a2a07dfc76df7593ac57c8152
