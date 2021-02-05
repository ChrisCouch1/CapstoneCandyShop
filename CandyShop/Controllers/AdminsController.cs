using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandyShop.Data;
using CandyShop.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CandyShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admins
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var admin = _context.Admin.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            if (admin == null)
            {
                return View(nameof(Create));
            }

            return View(admin);
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var admin = _context.Admin.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            admin = await _context.Admin
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.adminId == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin); ;
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                admin.IdentityUserId = userId;

                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", admin.IdentityUserId);
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", admin.IdentityUserId);
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Admin admin)
        {
            if (id != admin.adminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.adminId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", admin.IdentityUserId);
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admin
                .Include(a => a.IdentityUser)
                .FirstOrDefaultAsync(m => m.adminId == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.Admin.FindAsync(id);
            _context.Admin.Remove(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
            return _context.Admin.Any(e => e.adminId == id);
        }

        public ActionResult InventoryLevels()
        {
            var itemList = _context.StoreProduct.OrderBy(p => p.productName).ToList();
            var names = new List<string>();
            var quantities = new List<int>();
            foreach (var item in itemList)
            {
                names.Add(item.productName);
                quantities.Add(item.QTY);
            }
            ViewBag.NAMES = names;
            ViewBag.QTY = quantities;
            return View();
        }

        public ActionResult SalesByItem(DateTime? fromDate, DateTime? toDate)
        {
            var itemList = _context.StoreProduct.OrderBy(p => p.productName).ToList();
            var names = new List<string>();
            var numberSold = new List<int>();
            if(fromDate != null && toDate != null)
            {
                foreach (var item in itemList)
                {
                    names.Add(item.productName);
                    var transactions = _context.TransactionProducts.Where(tp => tp.product == item && tp.transaction.timestamp <= toDate && tp.transaction.timestamp >= fromDate).ToList();
                    numberSold.Add(transactions.Count);
                }
            }
            else
            {
                foreach(var item in itemList)
                {
                    names.Add(item.productName);
                    var transactions = _context.TransactionProducts.Where(tp => tp.product == item).ToList();
                    numberSold.Add(transactions.Count);
                }
            }
            
            ViewBag.NAMES = names;
            ViewBag.SALES = numberSold;
            return View();
        }

        public ActionResult SalesByCategory(DateTime? fromDate, DateTime? toDate)
        {
            var categoryList = _context.StoreProduct.OrderBy(p => p.category).ToList();
            var names = new List<string>();
            var numberSold = new List<int>();
            if (fromDate != null && toDate != null)
            {
                foreach (var item in categoryList)
                {
                    if (!names.Contains(item.category))
                    {
                        names.Add(item.category);
                        var transactions = _context.TransactionProducts.Where(tp => tp.product.category == item.category && tp.transaction.timestamp <= toDate && tp.transaction.timestamp >= fromDate).ToList();
                        numberSold.Add(transactions.Count);
                    }
                }
            }

            else
            {
                foreach (var item in categoryList)
                {
                    if (!names.Contains(item.category))
                    {
                        names.Add(item.category);
                        var transactions = _context.TransactionProducts.Where(tp => tp.product.category == item.category).ToList();
                        numberSold.Add(transactions.Count);
                    }
                }
            }
            ViewBag.NAMES = names;
            ViewBag.SALES = numberSold;
            return View();
        }
    }
}
