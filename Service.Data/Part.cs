using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
   public class Part
    {
        [Key]
        public int PartId { get; set; }
        [Required]
        public string PartNumber { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public int NumberInStock { get; set; }
        [Required]
        public bool AvailableToOrder { get; set; }
        [ForeignKey(nameof(Machine))]
        public int MachineId { get; set; }
        public virtual Machine Machine { get; set; }
    }
}
