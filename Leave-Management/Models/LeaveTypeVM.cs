using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Models
{
    public class DetailsLeaveTypeVM
    {
        
        public int LeaveTypeId { get; set; }
        
        public string name { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class CreateLeaveTypeVM
    {
        
        [Required]
        public string name { get; set; }
        
    }
}
