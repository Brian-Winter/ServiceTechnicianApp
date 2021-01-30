using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }
        public long SerialNumber { get; set; }
        [Required]
        public string MachineName { get; set; }
        [Required]
        public int NumberOfDrawers { get; set; }
        [Required]
        public int SpeedPerMinute { get; set; }
        [Required]
        public bool Color { get; set; }
        public decimal Cost { get; set; }
        //[ForeignKey(nameof(MachinePart))]
        //public List<string> PartNumber { get; set; }
        //public MachinePart MachinePart {get; set; }
    }
}
