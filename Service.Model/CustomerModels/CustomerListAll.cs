using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.CustomerModels
{
    public class CustomerListAll
    {
       public int CustomerId { get; set; }
       [Display(Name = "Company")]
       public string CompanyName { get; set; }
       public string City { get; set; }
       public string State { get; set; }
       public string Address { get; set; }


    }
}
