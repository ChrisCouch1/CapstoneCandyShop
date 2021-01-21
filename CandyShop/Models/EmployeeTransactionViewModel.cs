using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class EmployeeTransactionViewModel
    {
        public int EmployeeTransactionViewModelId { get; set; }
        public int employeeId { get; set; }
        public Employee employee { get; set; }
        public int? transactionId { get; set; }
        public Transaction transaction { get; set; }
        public List<StoreProduct> listOfProducts { get; set; }
    }
}
