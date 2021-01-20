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
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .ServiceForms
                                .Single(e => e.FormId == id);

                return new ServiceFormDetails
                {
                    
                    StartTime = query.StartTime,
                    FinishTime = query.FinishTime,
                    Completed = query.Completed,
                    MeterReadOne = query.MeterReadOne,
                    MeterReadTwo = query.MeterReadTwo,
                    CostDue = query.CostDue,
                    MachineId = query.MachineId

                };

            }
        }
        public ServiceFormDisplayDetails GetFormForDetails(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .ServiceForms
                                .Single(e => e.FormId == id);

                return new ServiceFormDisplayDetails
                {

                    StartTime = query.StartTime,
                    FinishTime = query.FinishTime,
                    Completed = query.Completed,
                    MeterReadOne = query.MeterReadOne,
                    MeterReadTwo = query.MeterReadTwo,
                    CostDue = query.CostDue,
                    MachineId = FindMachineName(query.MachineId),
                    MachinePartId = FindPartName(query.MachinePartId),
                    CustomerId = FindCustomerId(query.CustomerId),
                    UserId = query.UserId

                };

            }
        }
        //Display Machine Name
        private string FindMachineName(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {

                string machineName = "";
                foreach (var prop in ctx.Machines)
                {
                    if (id == prop.MachineId)
                    {
                        machineName = _listOfMachines.GetMachineById(prop.MachineId).MachineName;
                    }
                }
                return machineName;
            }
        }
        //Find Machine Id by SerialNumber to Save 
        //This allows the user to always use a serial number 
        //versus looking up a spefic Id of a machine
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
        private string FindPartName(int partId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                string partName = "";
                foreach (var prop in ctx.MachineParts)
                {
                    if (partId == prop.MachinePartId)
                    {
                        partName = _listOfParts.GetMachinePartById(prop.MachinePartId).PartName;
                    }
                }
                return partName;
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
        
       private string FindCustomerId(int companyId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                string customerName = "";
                foreach (var prop in ctx.Customers)
                {
                    if (companyId == prop.CustomerId)
                    {
                        customerName = _listOfCustomers.GetCustomerById(prop.CustomerId).CompanyName;
                    }
                }
                return customerName;
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
                _listOfParts.UpdateQuantityInStock(FindPartId(model.MachinePartId));
                ctx.ServiceForms.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //EDIT
        public bool EditServiceForm(ServiceFormEdit model)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .ServiceForms
                                .Single(e => e.FormId == model.FormId);
                entity.Completed = model.Completed;
                entity.StartTime = model.StartTime;
                entity.FinishTime = model.FinishTime;
                entity.MeterReadOne = model.MeterReadOne;
                entity.MeterReadTwo = model.MeterReadTwo;
                entity.CostDue = model.CostDue;
                entity.MachineId = model.MachineId;
                entity.MachinePartId = model.MachinePartId;
                entity.CustomerId = model.CustomerId;

                return ctx.SaveChanges() == 1;
            }
        }
        //DELETE
        public bool DeleteServiceForm(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ServiceForms
                                .Single(e => e.FormId == id);

                ctx.ServiceForms.Remove(entity);

                return ctx.SaveChanges() == 1;


            }
        }
    }
}
