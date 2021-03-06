﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.ServiceFormModels
{
    public class ServiceFormDetails
    {
        public int FormId { get; set; }
        [Display(Name = "Arrival Time")]
        public DateTime StartTime { get; set; }
        [Display(Name = "Departure Time")]
        public DateTime FinishTime { get; set; }
        [Display(Name = "Meter A")]
        public long MeterReadOne { get; set; }
        [Display(Name = "Meter B")]
        public long MeterReadTwo { get; set; }
        [Display(Name = "Problem Resolved")]
        public bool Completed { get; set; }
        [Display(Name = "Amount Due on Completion")]
        public decimal CostDue { get; set; }
        [Display(Name = "Service Technician")]
        public Guid UserId { get; set; }
        [Display(Name = "Machine Name")]
        public int MachineId { get; set; }
        [Display(Name = "Parts")]
        public int MachinePartId { get; set; }
        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }
    }
}
