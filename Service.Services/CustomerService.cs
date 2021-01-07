using Service.Data;
using Service.Model.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CustomerService
    {
        //READ ALL
        public IEnumerable<CustomerListAll> ViewAllCustomers()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Customers
                                .Select(
                                    e => new CustomerListAll
                                    {
                                        CustomerId = e.CustomerId,
                                        CompanyName = e.CompanyName,
                                        City = e.City,
                                        State = e.State,
                                        Address = e.Address
                                    }

                                );
                return query.ToArray();
            }
        }
        //READ SINGLE

        //CREATE
       public bool CreateCustomer(CustomerCreate model)
        {
            var entity = new Customer()
            {
                CompanyName = model.CompanyName,
                City = model.City,
                State = model.State,
                Address = model.Address,
                ServiceContract = model.ServiceContract,
                MachineId = model.MachineId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
