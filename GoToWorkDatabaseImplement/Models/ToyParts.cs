using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
