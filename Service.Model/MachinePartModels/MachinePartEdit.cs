using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.MachinePartModels
{
    public class MachinePartEdit
    {
       
        public string PartName { get; set; }
        public string PartNumber { get; set; }
        public decimal Cost { get; set; }
        public int NumberInStock { get; set; }
        public bool AvailableToOrder { get; set; }
    }
}
