﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Models
{
    public class LeaveHistoryVM
    {
        public int LeaveHitoryId { get; set; }

        
        public EmployeeVM RequestingEmployee { get; set; }
        public string RequestingEmployeeId { get; set; }

        
        public EmployeeVM AprovedBy { get; set; }
        public string AprovedById { get; set; }

        
        public DetailsLeaveTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }

        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
    }
}
