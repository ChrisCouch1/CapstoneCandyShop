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
using Stripe.Infrastructure;
using CandyShop.API_Keys;

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
            var tracker = _context.WorkHoursTrackers.Where(t => t.employeeId == employee.employeeId && t.clockIn.Day == DateTime.Today.Day).FirstOrDefault();
            var TimePunchesForToday = _context.EmployeeWorkTrackerViewModels.Where(t => t.employeeId == id && t.hoursTracker.clockIn.Day == DateTime.Today.Day).FirstOrDefault();
            if (employee == null)
            {
                return RedirectToAction("Create");
            }
            if (TimePunchesForToday == null)
            {
                TimePunchesForToday = new EmployeeWorkTrackerViewModel();
                TimePunchesForToday.employee = employee;
                var newTracker = new WorkHoursTracker();
                newTracker.employeeId = employee.employeeId;
                TimePunchesForToday.hoursTracker = newTracker;

            }
            if(TimePunchesForToday != null)
            {
                TimePunchesForToday.hoursTracker = tracker;
            }
            return View(TimePunchesForToday);
        }

        public ActionResult PunchIn(EmployeeWorkTrackerViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentEmployee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            var TimePunchesForToday = model;

            if (currentEmployee == null)
            {
                return RedirectToAction("Create");
            }
            if (TimePunchesForToday == null)
            {
                TimePunchesForToday = new EmployeeWorkTrackerViewModel();
                var newTracker = new WorkHoursTracker();
                newTracker.employee = currentEmployee;
                TimePunchesForToday.employee = currentEmployee;
                TimePunchesForToday.hoursTracker = newTracker;
                _context.WorkHoursTrackers.Add(newTracker);
                
            }
            if (TimePunchesForToday != null)
            {
                var tracker = new WorkHoursTracker();
                TimePunchesForToday.hoursTracker = tracker;
                TimePunchesForToday.hoursTracker.employeeId = currentEmployee.employeeId;
                _context.WorkHoursTrackers.Add(tracker);

            }
            ;
            TimePunchesForToday.employee = currentEmployee;            
            TimePunchesForToday.hoursTracker.clockIn = DateTime.Now;
            _context.EmployeeWorkTrackerViewModels.Update(TimePunchesForToday);
            _context.Employee.Update(currentEmployee);
            _context.SaveChanges();
            return View(TimePunchesForToday);
             
        }
        public ActionResult PunchOut(EmployeeWorkTrackerViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentEmployee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            var TimePunchesForToday = model;
            var tracker = _context.WorkHoursTrackers.Where(t => t.employeeId == currentEmployee.employeeId && t.clockIn.Day == DateTime.Today.Day).FirstOrDefault();
            tracker.employeeId = currentEmployee.employeeId;
            TimePunchesForToday.employeeId = currentEmployee.employeeId;
            TimePunchesForToday.trackerId = tracker.trackerId;
            TimePunchesForToday.hoursTracker = tracker;
            if (currentEmployee == null)
            {
                return RedirectToAction("Create");
            }
            TimePunchesForToday.hoursTracker.clockOut = DateTime.Now;
            _context.EmployeeWorkTrackerViewModels.Update(TimePunchesForToday);
            _context.WorkHoursTrackers.Update(tracker);
            _context.Employee.Update(currentEmployee);
            _context.SaveChanges();
            return View(TimePunchesForToday);
        }
        public ActionResult BeginBreak(EmployeeWorkTrackerViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentEmployee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            var TimePunchesForToday = model;
            var tracker = _context.WorkHoursTrackers.Where(t => t.employeeId == currentEmployee.employeeId && t.clockIn.Day == DateTime.Today.Day).FirstOrDefault();
            tracker.employeeId = currentEmployee.employeeId;
            TimePunchesForToday.employeeId = currentEmployee.employeeId;
            TimePunchesForToday.trackerId = tracker.trackerId;
            TimePunchesForToday.hoursTracker = tracker;
            if (currentEmployee == null)
            {
                return RedirectToAction("Create");
            }
            TimePunchesForToday.hoursTracker.breakStart = DateTime.Now;
            _context.EmployeeWorkTrackerViewModels.Update(TimePunchesForToday);
            _context.WorkHoursTrackers.Update(tracker);
            _context.Employee.Update(currentEmployee);
            _context.SaveChanges();
            return View(TimePunchesForToday);
        }
        public ActionResult EndBreak(EmployeeWorkTrackerViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentEmployee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            var TimePunchesForToday = model;
            var tracker = _context.WorkHoursTrackers.Where(t => t.employeeId == currentEmployee.employeeId && t.clockIn.Day == DateTime.Today.Day).FirstOrDefault();
            tracker.employeeId = currentEmployee.employeeId;
            TimePunchesForToday.employeeId = currentEmployee.employeeId;
            TimePunchesForToday.trackerId = tracker.trackerId;
            TimePunchesForToday.hoursTracker = tracker;
            if (currentEmployee == null)
            {
                return RedirectToAction("Create");
            }
            TimePunchesForToday.hoursTracker.breakEnd = DateTime.Now;
            var updatedHoursTracker = TimePunchesForToday.hoursTracker;
            _context.EmployeeWorkTrackerViewModels.Update(TimePunchesForToday);
            _context.WorkHoursTrackers.Update(tracker);
            _context.Employee.Update(currentEmployee);
            _context.SaveChanges();
            return View(TimePunchesForToday);
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
            var productList = _context.TransactionProducts.Where(tp => tp.transaction == transaction).ToList();
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
            var transaction = _context.Transaction.Where(t => t.employee == employee && t.isComplete == false).FirstOrDefault();
            if(viewModel == null)
            {
                viewModel = new EmployeeTransactionViewModel();
                viewModel.employee = employee;
            }
            if(transaction != null && transaction.isComplete == false)
            {
                var transactionproducts = _context.TransactionProducts.Where(tp => tp.transactionId == transaction.transactionId).ToList();
                foreach (TransactionProducts tp in transactionproducts)
                {
                    var productInTransaction = _context.StoreProduct.Where(p => p.productId == tp.productId).FirstOrDefault();
                    transaction.products.Add(productInTransaction);
                    
                }               
                transaction.products.Add(product);
                TransactionProducts transaction1 = new TransactionProducts();
                transaction1.transaction = transaction;
                transaction1.product = product;
                _context.TransactionProducts.Update(transaction1);                         
                viewModel.transaction = transaction;
                _context.Transaction.Update(transaction);
                
            }
            if(transaction == null || transaction.isComplete == true)
            {
                transaction = new Transaction();
                transaction.timestamp = DateTime.Now;
                transaction.isComplete = false;
                transaction.products = new List<StoreProduct>();               
                transaction.products.Add(product);
                TransactionProducts transactionProducts = new TransactionProducts();                
                transactionProducts.product = product;
                transaction.employee = employee;
                transaction.employeeId = employee.employeeId;
                viewModel.transaction = transaction;
                transactionProducts.transaction = transaction;
                _context.TransactionProducts.Update(transactionProducts);
                _context.Transaction.Add(transaction);
                
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
            var TPtoRemove = _context.TransactionProducts.Where(tp => tp.transaction == transaction && tp.productId == id).FirstOrDefault();
            _context.TransactionProducts.Remove(TPtoRemove);
            _context.Update(viewModel);
            _context.SaveChanges();
            return View(viewModel);
        }

        public ActionResult CashPurchase()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            var viewModel = _context.EmployeeTransactionViewModels.Where(vm => vm.employee == employee).FirstOrDefault();
            var transaction = _context.Transaction.Where(t => t.employeeId == employee.employeeId && t.isComplete == false).FirstOrDefault();
            var productList = _context.TransactionProducts.Where(tp => tp.transaction == transaction).ToList();
            viewModel.transaction = transaction;
            foreach (TransactionProducts tp in productList)
            {
                var product = _context.StoreProduct.Where(p => p.productId == tp.productId).FirstOrDefault();
                viewModel.transaction.products.Add(product);
            }
            foreach (StoreProduct product in viewModel.transaction.products)
            {
                viewModel.transaction.totalCost += product.price;
                product.QTY--;
            }
            return View(viewModel);
        }
        //public ActionResult CreditPurchase()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var employee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
        //    var viewModel = _context.EmployeeTransactionViewModels.Where(vm => vm.employee == employee).FirstOrDefault();
        //    var transaction = _context.Transaction.Where(t => t.employeeId == employee.employeeId && t.isComplete == false).FirstOrDefault();
        //    var productList = _context.TransactionProducts.Where(tp => tp.transaction == transaction).ToList();
        //    viewModel.transaction = transaction;
        //    foreach (TransactionProducts tp in productList)
        //    {
        //        var product = _context.StoreProduct.Where(p => p.productId == tp.productId).FirstOrDefault();
        //        viewModel.transaction.products.Add(product);
        //    }
        //    foreach (StoreProduct product in viewModel.transaction.products)
        //    {
        //        viewModel.transaction.totalCost += product.price;

        //    }
        //    Keys key = new Keys();
        //    StripeConfiguration.SetApiKey(key.testKey);
        //}

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.employeeId == id);
            
        }
    }
}
