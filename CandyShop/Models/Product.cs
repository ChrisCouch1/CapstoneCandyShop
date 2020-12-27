using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        
        [ForeignKey("Category")]
        public int categoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int QTY { get; set; }
        public int price { get; set; }
    }
}
