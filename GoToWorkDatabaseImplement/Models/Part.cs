using GoToWorkBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoToWorkDatabaseImplement.Models
{
    public class Part
    {
        public int Id { get; set; }
        [Required]
        public int ProviderId { get; set; }
        [Required]
        public string ProviderFIO { get; set; }
        [Required]
        public string PartType { get; set; }
        [Required]
        public string PartColor { get; set; }
        [Required]
        public int PartCount { get; set; }
        [Required]
        public PartStatus PartStatus { get; set; }
        public DateTime DateRecieve { get; set; }
        public DateTime? DateTransfer { get; set; }
        [ForeignKey("PartId")]
        public virtual List<ToyParts> ToyParts { get; set; }
        public Provider Provider { get; set; }
    }
}
