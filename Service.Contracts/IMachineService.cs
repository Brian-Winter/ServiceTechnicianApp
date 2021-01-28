using Service.Model.MachineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMachineService
    {
        IEnumerable<MachineListAll> GetAllMachines();
        bool CreateMachine(MachineCreate model);
        bool EditMachine(MachineEdit model);
        bool DeleteMachine(int id);
    }
}
