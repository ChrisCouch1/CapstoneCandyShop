using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class Supplier
    {
        [Key]
        public int supplierId { get; set; }

        [ForeignKey("Product")]
        public int productId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string url { get; set; }
        public string details { get; set; }
    }
}
