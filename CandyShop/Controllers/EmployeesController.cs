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

namespace CandyShop.Controllers
{
    [Authorize(Roles = "Admin, Manager, Employee")]
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
            if (employee == null)
            {
                return RedirectToAction("Create");
            }
            List<Product> productList = _context.Product.ToList();          

            return View(productList);
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
            currentEmployee.clockIn = punch;          
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
            currentEmployee.clockOut = punch;
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
            currentEmployee.breakStart = punch;
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
            currentEmployee.breakEnd = punch;
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
                .FirstOrDefaultAsync(m => m.userId == id);
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
            
            var product = _context.Product.Where(p => p.productId ==
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
            if (id != employee.userId)
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
                    if (!EmployeeExists(employee.userId))
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
                .FirstOrDefaultAsync(m => m.userId == id);
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
            var cartList = employee.cart.ToList();
            return View(nameof(CartList));

        }
        
        public ActionResult AddToCart(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            Product product = _context.Product.Where(p => p.productId == id).SingleOrDefault();
            if (employee.cart == null)
            {
                employee.cart = new List<Product>();
                employee.cart.Add(product);
            }
            else
            {
                employee.cart.Add(product);
            }
            _context.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            var product = _context.Product.Where(p => p.productId == productId).SingleOrDefault();
            employee.cart.Remove(product);
            
            _context.SaveChanges();
            return View(nameof(CartList));
        }

        public ActionResult PurchaseCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(i => i.IdentityUserId == userId).FirstOrDefault();
            Transaction transaction = new Transaction();
            transaction.products = employee.cart;
             
            foreach(var product in employee.cart)
            {
                transaction.totalCost += product.price;
            }
            return View(transaction);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.userId == id);
            
        }
    }
}
