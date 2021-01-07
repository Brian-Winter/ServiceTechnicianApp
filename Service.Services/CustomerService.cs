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
        public CustomerDetails GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Customers
                                .Single(e => e.CustomerId == id);
                return new CustomerDetails
                {
                    CompanyName = query.CompanyName,
                    City = query.City,
                    State = query.State,
                    Address = query.Address,
                    ServiceContract = query.ServiceContract,
                    MachineId = query.MachineId
                };
            }
        }
        //READ ALL BY SERVICE CONTRACT TRUE
        public IEnumerable<CustomerDetails> GetCustomersByContract()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Customers
                                .Where(e => e.ServiceContract == true)
                                .Select(
                                    e => new CustomerDetails
                                    {
                                        CompanyName = e.CompanyName,
                                        City = e.City,
                                        State = e.State,
                                        Address = e.Address,
                                        ServiceContract = e.ServiceContract,
                                        MachineId = e.MachineId
                                    }

                                );
                return query.ToArray();
            }
        }
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
