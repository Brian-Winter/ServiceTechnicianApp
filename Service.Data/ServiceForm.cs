using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    public class ServiceForm
    {
        [Key]
        public int FormId { get; set; }
        public bool Completed { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime FinishTime { get; set; }
        [Required]
        public long MeterReadOne { get; set; }
        public long MeterReadTwo { get; set; }
        public decimal CostDue { get; set; }
        public Guid UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey(nameof(Machine))]
        public int MachineId { get; set; }
        public virtual Machine Machine { get; set; }
        [ForeignKey(nameof(MachinePart))]
        public int MachinePartId { get; set; }
        public virtual MachinePart MachinePart { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
