using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class EmployeeWorkTrackerViewModel
    {
        [Key]
        public int EmployeeWorkTrackerViewModelId { get; set; }
        public int employeeId { get; set; }
        public Employee employee { get; set; }
        public int trackerId { get; set; }
        public WorkHoursTracker hoursTracker { get; set; }
    }
}
