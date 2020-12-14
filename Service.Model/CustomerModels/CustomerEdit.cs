using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.CustomerModels
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public bool ServiceContract { get; set; }
        public int MachineId { get; set; }
    }
}
