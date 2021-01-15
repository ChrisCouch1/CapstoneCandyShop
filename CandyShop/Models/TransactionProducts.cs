using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class TransactionProducts
    {
        public int transactionId { get; set; }
        public Transaction transaction { get; set; }
        public int productId { get; set; }
        public StoreProduct product { get; set; }
    }
}
