using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class Transaction
    {
        [Key]
        public int transactionId { get; set; }

        [ForeignKey("Employee")]
        public int employeeId { get; set; }
        public Employee employee { get; set; }
        public List <StoreProduct> products { get; set; } 
        public double totalCost { get; set; }
        public DateTime timestamp { get; set; }
        public bool isComplete { get; set; }

    }
}
