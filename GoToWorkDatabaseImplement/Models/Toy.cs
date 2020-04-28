using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoToWorkDatabaseImplement.Models
{
    public class Toy
    {
        public int Id { get; set; }
        [Required]
        public string ToyName { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public virtual List<ToyParts> ToyParts { get; set; }
    }
}
