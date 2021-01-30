using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.MachineModels
{
    public class MachineDetail
    {
        
        public int MachineId { get; set; }
        [Display(Name = "Machine Name")]
        public string MachineName { get; set; }
        public long SerialNumber { get; set; }
        [Display(Name = "Drawers")]
        public int NumberOfDrawers { get; set; }
        public bool Color { get; set; }
    }
}
