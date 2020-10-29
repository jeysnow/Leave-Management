using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Data
{
    public class LeaveAllocation
    {
        [Key]
        public int LeaveAllocationId { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        
        public string EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }
        
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
