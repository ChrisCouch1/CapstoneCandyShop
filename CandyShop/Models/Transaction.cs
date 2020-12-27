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

        [ForeignKey("User")]
        public int userId { get; set; }

        public List <Product> products { get; set; } 
        public int totalCost { get; set; }

    }
}
