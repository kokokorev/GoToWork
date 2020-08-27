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
<<<<<<< HEAD
}
=======
}
>>>>>>> c5de45aa0e96dc1a2a07dfc76df7593ac57c8152
