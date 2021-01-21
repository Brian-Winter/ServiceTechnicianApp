using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.ServiceFormModels
{
    public class ServiceFormListAll
    {
        public int FormId { get; set; }
        [Display(Name = "Problem Resolved")]
        public bool Completed { get; set; }
        [Display(Name = "Service Technician")] 
        public Guid UserId { get; set; }
        public int MachineId { get; set; }
        public int MachinePartId { get; set; }
        public int CustomerId { get; set; }
    }
}
