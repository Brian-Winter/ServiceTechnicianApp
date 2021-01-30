using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.MachinePartModels
{
    public class MachinePartListAll
    {
        public int MachinePartId { get; set; }
        [Display(Name = "Part Name")]
        public string PartName { get; set; }
        [Display(Name = "Part Number")]
        public string PartNumber { get; set; }
        public decimal Cost { get; set; }
        
    }
}
