using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
=======
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
>>>>>>> c5de45aa0e96dc1a2a07dfc76df7593ac57c8152

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
<<<<<<< HEAD
}
=======
}
>>>>>>> c5de45aa0e96dc1a2a07dfc76df7593ac57c8152
