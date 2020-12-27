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
        public int workWeek { get; set; }
        
        [ForeignKey("User")]
        public int userId { get; set; }
        public int hoursWorked { get; set; }
    }
}
