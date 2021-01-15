using Service.Data;
using Service.Model.ServiceFormModels;
using Service.Model.MachineModels;
using Service.Model.MachinePartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Service.Services
{
    public class ServiceFormService
    {
        CustomerService _listOfCustomers = new CustomerService();
        MachineService _listOfMachines = new MachineService();
        PartService _listOfParts = new PartService();
        private readonly Guid _userId;
        public ServiceFormService(Guid userId)
        {
            _userId = userId;
        }
        public ServiceFormService() { }
        //READ ALL
       
        public IEnumerable<ServiceFormListAll> ViewAllForms()
        {
            using( var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .ServiceForms
                                .Select(
                                    e => new ServiceFormListAll
                                {
                                    CustomerId = e.CustomerId,
                                    Completed = e.Completed,
                                    UserId = e.UserId,
                                    MachineId = e.MachineId,
                                    MachinePartId = e.MachinePartId

                        
                                 }
                );
                return query.ToArray();
            }
        }
        //READ SINGLE
        public ServiceFormDetails GetFormById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .ServiceForms
                                .Single(e => e.FormId == id);
                return new ServiceFormDetails
                {
                    CustomerId = query.CustomerId,
                    StartTime = query.StartTime,
                    FinishTime = query.FinishTime,
                    Completed = query.Completed,
                    MeterReadOne = query.MeterReadOne,
                    MeterReadTwo = query.MeterReadTwo,
                    CostDue = query.CostDue,
                    UserId = query.UserId,
                    MachineId = query.MachineId,
                    MachinePartId = query.MachinePartId

                };

            }
        }
        private int FindMachineId(long serialNumber)
        {
            using(var ctx = new ApplicationDbContext())
            {
              
                int machineId = 1;
                foreach ( var prop in ctx.Machines)
                {
                    if(serialNumber == prop.SerialNumber)
                    {
                        machineId = _listOfMachines.GetMachineBySerialNumber(prop.SerialNumber).MachineId;
                    }
                }
                return machineId;
            }
        }
        private int FindPartId(string partNumber)
        {
            using(var ctx = new ApplicationDbContext())
            {
               
                int partId = 1;
                foreach (var prop in ctx.MachineParts)
                {
                    if(partNumber == prop.PartNumber)
                    {
                        partId = _listOfParts.GetMachinePartByPartNumber(prop.PartNumber).MachinePartId;
                    }
                }
                return partId;
            }
        }
        private int FindCustomerId(string companyName)
        {
            using(var ctx = new ApplicationDbContext())
            {
               
                int customerId = 1;
                foreach(var prop in ctx.Customers)
                {
                    if(companyName == prop.CompanyName)
                    {
                        customerId = _listOfCustomers.GetCustomerIdByCompanyName(prop.CompanyName).CustomerId;
                    }
                }
                return customerId;
            }
        }
        //CREATE
        public bool CreateServiceForm(ServiceFormCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
               
                var entity = new ServiceForm()
                {
                    CustomerId = FindCustomerId(model.CustomerId),
                    StartTime = model.StartTime,
                    FinishTime = model.FinishTime,
                    Completed = model.Completed,
                    MeterReadOne = model.MeterReadOne,
                    MeterReadTwo = model.MeterReadTwo,
                    CostDue = model.CostDue,
                    UserId = _userId,
                    MachinePartId = FindPartId(model.MachinePartId),
                    MachineId = FindMachineId(model.MachineId)

                };
                ctx.ServiceForms.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //EDIT
        //DELETE


    }
}
