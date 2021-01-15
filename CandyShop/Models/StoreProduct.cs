using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class StoreProduct
    {
        [Key]
        public int productId { get; set; }
        public string category { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public int QTY { get; set; }
        public double price { get; set; }
        public string supplierDetails { get; set; }
    }
}
