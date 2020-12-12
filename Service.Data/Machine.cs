using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }
        [Required]
        public long SerialNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int NumberOfDrawers { get; set; }
        [Required]
        public int SpeedPerMinute { get; set; }
        [Required]
        public bool Color { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }
}
