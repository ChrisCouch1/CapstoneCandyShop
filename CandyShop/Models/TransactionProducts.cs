using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class TransactionProducts
    {
        [Key]
        public int transactionProductId { get; set; }
        public int transactionId { get; set; }
        public Transaction transaction { get; set; }
        public int productId { get; set; }
        public StoreProduct product { get; set; }
    }
}
