using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class DailySalesTracker
    {
        [Key]
        public DateTime date { get; set; }
        public List <Transaction> HourlyTransactions { get; set; }
        public List <List<Transaction>> DailyTransactions { get; set; }
    }
}
