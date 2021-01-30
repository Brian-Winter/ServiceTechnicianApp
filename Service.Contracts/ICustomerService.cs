using Service.Model.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICustomerService
    {
        IEnumerable<CustomerListAll> ViewAllCustomers();
        IEnumerable<CustomerDetails> GetCustomersByContract();
        CustomerDetails GetCustomerById(int id);
        CustomerDetails GetCustomerIdByCompanyName(string id);
        bool CreateCustomer(CustomerCreate model);
        bool EditCustomer(CustomerEdit model);
        bool DeleteCustomer(int id);
    }
}
