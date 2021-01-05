using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
   public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public bool ServiceContract { get; set; }
        //[ForeignKey(nameof(Machine))]
        //public int MachineId { get; set; }
        //public virtual Machine Machine { get; set; }

    }
}
