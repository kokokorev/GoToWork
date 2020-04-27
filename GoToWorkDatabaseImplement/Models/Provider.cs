using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoToWorkDatabaseImplement.Models
{
    public class Provider
    {
        public int Id { get; set; }
        [Required] public string FIO { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [ForeignKey("PartId")] public List<Part> Part { get; set; }
        [ForeignKey("RequestId")] public virtual List<Request> Request { get; set; }
    }
}