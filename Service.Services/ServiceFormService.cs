using Service.Data;
using Service.Model.ServiceFormModels;
using Service.Model.MachineModels;
using Service.Model.MachinePartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ServiceFormService
    {
        private readonly Guid _userId;
        public ServiceFormService(Guid userId)
        {
            _userId = userId;
        }
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
        private long FindSerialNumber(long serialNumber)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var _listOfMachines = new MachineService();
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
        private string FindPartNumber(string partNumber)
        {

        }
        //CREATE
        public bool CreateServiceForm(ServiceFormCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var _listOfParts = new PartService();
                var _listOfMachines = new MachineService();
            }
        }
        //EDIT
        //DELETE


    }
}
