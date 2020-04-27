using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GoToWorkDatabaseImplement.Models
{
    public class ToyParts
    {
        public int Id { get; set; }
        public int ToyId { get; set; }
        public int PartId { get; set; }
        [Required] public int PartCount { get; set; }
        public virtual Part Part { get; set; }
        public virtual Toy Toy { get; set; }
    }
}