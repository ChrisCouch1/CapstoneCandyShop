using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class WorkHoursTracker
    {
        [Key]
        public int trackerId { get; set; }

        [ForeignKey("Employee")]
        public int employeeId { get; set; }
        public Employee employee { get; set; }
        public DateTime breakStart { get; set; }
        public DateTime breakEnd { get; set; }
        public DateTime clockIn { get; set; }
        public DateTime clockOut { get; set; }        
        public int hoursWorked { get; set; } //Calculate for each work period, minus break times.
    }
}
