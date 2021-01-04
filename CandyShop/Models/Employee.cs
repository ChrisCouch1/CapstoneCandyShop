using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class Employee : User
    {
        [Key]
        public int userId { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public string name { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public DateTime breakStart { get; set; }
        public DateTime breakEnd { get; set; }
        public DateTime clockIn { get; set; }
        public DateTime clockOut { get; set; }
    }
}
