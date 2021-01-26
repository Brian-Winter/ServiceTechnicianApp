using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.ServiceFormModels
{
    public class ServiceFormEdit
    {
        public int FormId { get; set; }
        [Display(Name = "Problem Resolved")]
        public bool Completed { get; set; }
        [Display(Name = "Arrival Time")]
        public DateTime StartTime { get; set; }
        [Display(Name = "Departure Time")]
        public DateTime FinishTime { get; set; }
        [Display(Name = "Meter A")]
        public long MeterReadOne { get; set; }
        [Display(Name = "Meter B")]
        public long MeterReadTwo { get; set; }
        [Display(Name = "Amount Due on Completion")]
        public decimal CostDue { get; set; }
        [Display(Name = "Machine Name ")]
        public int MachineId { get; set; }
        [Display(Name = "Part Used")]
        public int MachinePartId { get; set; }
        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }
    }
}
