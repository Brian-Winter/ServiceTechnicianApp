using Service.Model.MachineModels;
using Service.Model.ServiceFormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceFormService
    {
        IEnumerable<ServiceFormListAll> ViewAllForms();
        ServiceFormDetails GetFormById(int id);
        bool CreateServiceForm(ServiceFormCreate model);
        bool EditServiceForm(ServiceFormEdit model);
        bool DeleteServiceForm(int id);


    }
}
