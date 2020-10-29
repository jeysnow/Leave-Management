using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Data
{
    public class LeaveType
    {
        [Key]
        public int LeaveTypeId { get; set; }
        [Required]
        public string name { get; set; }
        public DateTime DateCreated { get; set; }

    }

    
}
