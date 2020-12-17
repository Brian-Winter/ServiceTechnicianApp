using Service.Data;
using Service.Model.MachineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MachineService
    {

        //Read All
        public IEnumerable<MachineListAll> GetAllMachines()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Machines
                                .Select(
                                    e => new MachineListAll
                                    {
                                        MachineId = e.MachineId,
                                        MachineName = e.MachineName,
                                        SerialNumber = e.SerialNumber,
                                        NumberOfDrawers = e.NumberOfDrawers,
                                        Color = e.Color
                                    }
                                );
                return query.ToArray();
            }
        }
        //Read Single
        public MachineDetail GetMachineById(int id)
        {

        }
        //Create

        //Edit


    }
}
