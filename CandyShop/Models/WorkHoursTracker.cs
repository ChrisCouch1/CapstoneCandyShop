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
        public DateTime workWeek { get; set; } //change to DateTime, make a timestamp for each clockin time.
        
        [ForeignKey("User")]
        public int userId { get; set; }
        public int hoursWorked { get; set; } //Calculate for each work period, minus break times.
    }
}
