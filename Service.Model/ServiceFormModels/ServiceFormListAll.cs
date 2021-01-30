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
        [Display(Name = "Machine Name ")]
        public int MachineId { get; set; }
        [Display(Name = "Part Used")]
        public int MachinePartId { get; set; }
        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }
    }
}
