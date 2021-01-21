using Service.Data;
using Service.Model.CustomerModels;
using Service.Model.MachineModels;
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
            using (var ctx = new ApplicationDbContext())
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
                    CustomerId = query.CustomerId,
                    CompanyName = query.CompanyName,
                    City = query.City,
                    State = query.State,
                    Address = query.Address,
                    ServiceContract = query.ServiceContract,
                    MachineId = query.MachineId
                };
            }
        }
        //READ SINGLE BY COMPANY NAME
        public CustomerDetails GetCustomerIdByCompanyName(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Customers
                                .Single(e => e.CompanyName == id);
                return new CustomerDetails
                {
                   CustomerId = query.CustomerId
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
            
            //loop with serial number to find a matching number, than find id in that match, assign match
           using (var ctx = new ApplicationDbContext())
           {
                var _listOfMachine = new MachineService();
                int newMachineId = 1;
                foreach (var prop in ctx.Machines)
                {
                    if (model.MachineId == prop.SerialNumber)
                    {
                      newMachineId = _listOfMachine.GetMachineBySerialNumber(prop.SerialNumber).MachineId;
                 

                    
                     
                    };
                
                } 
                    var entity = new Customer()
                        {
                            CompanyName = model.CompanyName,
                            City = model.City,
                            State = model.State,
                            Address = model.Address,
                            ServiceContract = model.ServiceContract,
                            MachineId = newMachineId
                        };
                     ctx.Customers.Add(entity);
                        return ctx.SaveChanges() == 1;
           }
            
        }
        //EDIT
        public bool EditCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers
                                .Single(e => e.CustomerId == model.CustomerId);

                entity.CompanyName = model.CompanyName;
                entity.City = model.City;
                entity.State = model.State;
                entity.Address = model.Address;
                entity.ServiceContract = model.ServiceContract;
                entity.MachineId = model.MachineId;

                return ctx.SaveChanges() == 1;
            }
        }
        //Delete
        public bool DeleteCustomer(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers
                                .Single(e => e.CustomerId == id);

                ctx.Customers.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
