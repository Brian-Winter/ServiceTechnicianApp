using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.CustomerModels
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public bool ServiceContract { get; set; }
        [Display(Name = "Machine Serial Number")]
        public int MachineId { get; set; }
    }
}
