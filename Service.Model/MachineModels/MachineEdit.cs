using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.MachineModels
{
   public class MachineEdit
    {
        public int MachineId { get; set; }
        public long SerialNumber { get; set; }
        [Display(Name = "Machine Name")]
        public string MachineName { get; set; }
        [Range(1, 4, ErrorMessage = "Please enter a valid number of drawers.")]
        public int NumberOfDrawers { get; set; }
        [Display(Name = "Prints Per Minute By D-Size")]
        public int SpeedPerMinute { get; set; }
        public bool Color { get; set; }
        public decimal Cost { get; set; }
    }
}
