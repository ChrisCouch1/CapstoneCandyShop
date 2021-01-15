using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandyShop.Data;
using CandyShop.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Stripe;

namespace CandyShop.Controllers
{
    //[Authorize(Roles = "Admin, Manager, Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public ActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            var viewModel = _context.EmployeeTransactionViewModels.Where(vm => vm.employee == employee).FirstOrDefault();
            if (employee == null)
            {
                return RedirectToAction("Create");
            }
            if (viewModel == null)
            {
                viewModel = new EmployeeTransactionViewModel();
                viewModel.employee = employee;
            }
            List<StoreProduct> productList = _context.StoreProduct.ToList();
            viewModel.listOfProducts = productList;

            return View(viewModel);
        }
        public ActionResult TimePunch(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            if (employee == null)
            {
                return RedirectToAction("Create");
            }
            return RedirectToAction("TimePunch");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PunchIn(Employee employee)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentEmployee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            DateTime punch = new DateTime();
            punch = DateTime.Now;
            if (currentEmployee == null)
            {
                return RedirectToAction("Create");
            }
                    
            _context.Update(currentEmployee);
            _context.SaveChanges();
            return RedirectToAction("TimePunch");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PunchOut(Employee employee)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentEmployee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            DateTime punch = new DateTime();
            punch = DateTime.Now;
            if (currentEmployee == null)
            {
                return RedirectToAction("Create");
            }
            
            _context.Update(currentEmployee);
            _context.SaveChanges();
            return RedirectToAction("TimePunch");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BeginBreak(Employee employee)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentEmployee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            DateTime punch = new DateTime();
            punch = DateTime.Now;
            if (currentEmployee == null)
            {
                return RedirectToAction("Create");
            }
            
            _context.Update(currentEmployee);
            _context.SaveChanges();
            return RedirectToAction("TimePunch");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EndBreak(Employee employee)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentEmployee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            DateTime punch = new DateTime();
            punch = DateTime.Now;
            if (currentEmployee == null)
            {
                return RedirectToAction("Create");
            }
            
            _context.Update(currentEmployee);
            _context.SaveChanges();
            return RedirectToAction("TimePunch");
        }
        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            employee = await _context.Employee
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.employeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/ProductDetails/5
        public ActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var product = _context.StoreProduct.Where(p => p.productId ==
            id).SingleOrDefault();
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;

                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.employeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.employeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.employeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult CartList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            var viewModel = _context.EmployeeTransactionViewModels.Where(vm => vm.employee == employee).FirstOrDefault();
            var transaction = _context.Transaction.Where(t => t.employeeId == employee.employeeId && t.isComplete == false).FirstOrDefault();
            var productList = _context.TransactionProducts.Where(tp => tp.transactionId == transaction.transactionId).ToList();
            viewModel.transaction = transaction;
            foreach(TransactionProducts tp in productList)
            {
                var product = _context.StoreProduct.Where(p => p.productId == tp.productId).FirstOrDefault();
                viewModel.transaction.products.Add(product);
            }
            
            return View(viewModel);

        }
        
        public ActionResult AddToCart(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            StoreProduct product = _context.StoreProduct.Where(p => p.productId == id).SingleOrDefault();
            var viewModel = _context.EmployeeTransactionViewModels.Where(vm => vm.employeeId == employee.employeeId).FirstOrDefault();
            var transaction = _context.Transaction.Where(t => t.employeeId == employee.employeeId && t.isComplete == false).FirstOrDefault();
            if(viewModel == null)
            {
                viewModel = new EmployeeTransactionViewModel();
                viewModel.employee = employee;
            }
            if(transaction != null)
            {
                var transactionproducts = _context.TransactionProducts.Where(tp => tp.transaction == transaction).ToList();
                foreach (TransactionProducts tp in transactionproducts)
                {
                    var productInTransaction = _context.StoreProduct.Where(p => p.productId == tp.productId).FirstOrDefault();
                    transaction.products.Add(product);
                }
                if (transaction.products.Contains(product))
                {
                    product.QTY++;
                    viewModel.transaction = transaction;
                    _context.Transaction.Update(viewModel.transaction);
                }
                else
                {
                    product.QTY = 1;
                    transaction.products.Add(product);
                    viewModel.transaction = transaction;
                    _context.Transaction.Update(viewModel.transaction);
                }
                
            }
            if(transaction == null)
            {
                var newTransaction = new Transaction();                
                newTransaction.timestamp = DateTime.Now;
                newTransaction.isComplete = false;
                newTransaction.products = new List<StoreProduct>();
                product.QTY = 1;                
                newTransaction.products.Add(product);
                TransactionProducts transactionProducts = new TransactionProducts();
                transactionProducts.transaction = newTransaction;
                transactionProducts.product = product;
                newTransaction.employee = employee;
                newTransaction.employeeId = employee.employeeId;
                viewModel.transaction = newTransaction;
                _context.Transaction.Update(newTransaction);
                _context.TransactionProducts.Update(transactionProducts);
            }
            
            _context.Employee.Update(viewModel.employee);
            _context.EmployeeTransactionViewModels.Update(viewModel);
            _context.SaveChanges();
            return View(viewModel);
        }

        public ActionResult RemoveFromCart(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            var viewModel = _context.EmployeeTransactionViewModels.Where(vm => vm.employee == employee).FirstOrDefault();
            var transaction = _context.Transaction.Where(t => t.employeeId == employee.employeeId && t.isComplete == false).FirstOrDefault();
            var productList = _context.TransactionProducts.Where(tp => tp.transactionId == transaction.transactionId).ToList();
            viewModel.transaction = transaction;
            foreach (TransactionProducts tp in productList)
            {
                var product = _context.StoreProduct.Where(p => p.productId == tp.productId).FirstOrDefault();
                viewModel.transaction.products.Add(product);
            }
            var productToRemove = _context.StoreProduct.Where(p => p.productId == id).SingleOrDefault();
            viewModel.transaction.products.Remove(productToRemove);
            _context.Update(viewModel);
            _context.SaveChanges();
            return View(viewModel);
        }

        public ActionResult PurchaseCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            var viewModel = _context.EmployeeTransactionViewModels.Where(vm => vm.employee == employee).FirstOrDefault();
            foreach(StoreProduct product in viewModel.transaction.products)
            {
                viewModel.transaction.totalCost += (product.price * product.QTY);
            }
            return View(viewModel);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.employeeId == id);
            
        }
    }
}
