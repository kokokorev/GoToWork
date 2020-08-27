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
    public class Provider
    {
        public int Id { get; set; }
        [Required] public string FIO { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [ForeignKey("PartId")] public List<Part> Part { get; set; }
        [ForeignKey("RequestId")] public virtual List<Request> Request { get; set; }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> c5de45aa0e96dc1a2a07dfc76df7593ac57c8152
