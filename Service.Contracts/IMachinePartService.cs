
using Service.Model.MachinePartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMachinePartService
    {
        IEnumerable<MachinePartListAll> GetPartsList();
        MachinePartDetail GetMachinePartById(int id);
        MachinePartDetail GetMachinePartByPartNumber(string partNumber);
        bool CreatePart(MachinePartCreate model);
        bool EditMachinePart(MachinePartEdit model);
        bool UpdateQuantityInStock(int model);


    }
}
