using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.MachinePartModels
{
    public class MachinePartCreate
    {
        [Display(Name = "Part Name")]
        public string PartName { get; set; }
        [Display(Name = "Part Number")]
        public string PartNumber { get; set; }
        public decimal Cost { get; set; }
        [Display(Name = "Current # in Stock")]
        public int NumberInStock { get; set; }
        [Display(Name = "Product Available")]
        public bool AvailableToOrder { get; set; }
    }
}
