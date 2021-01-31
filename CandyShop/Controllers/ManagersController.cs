﻿using System;
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
   //[Authorize(Roles = "Admin, Manager")]
    public class ManagersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Managers
        public ActionResult Index()
        {
            var productList = _context.StoreProduct.ToList();
            
            return View(productList);
        }

        // GET: Managers/Details/5
        public ActionResult Details()
        {            
            return View("Details");
        }

        // GET: Managers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Managers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Manager manager)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                manager.IdentityUserId = userId;
                _context.Add(manager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", manager.IdentityUserId);
            return View(manager);
        }

        // GET: Managers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = _context.EmployeeWorkTrackerViewModels.Where(vm => vm.EmployeeWorkTrackerViewModelId == id).FirstOrDefault();
            var employee = _context.Employee.Where(e => e.employeeId == viewModel.employeeId).FirstOrDefault();
            var hoursTracker = _context.WorkHoursTrackers.Where(t => t.trackerId == viewModel.trackerId).FirstOrDefault();
            viewModel.hoursTracker = hoursTracker;
            viewModel.employee = employee;
            return View(viewModel);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = _context.EmployeeWorkTrackerViewModels.Where(vm => vm.EmployeeWorkTrackerViewModelId == id).FirstOrDefault();
            var employee = _context.Employee.Where(e => e.employeeId == viewModel.employeeId).FirstOrDefault();
            var hoursTracker = _context.WorkHoursTrackers.Where(t => t.trackerId == viewModel.trackerId).FirstOrDefault();
            viewModel.hoursTracker = hoursTracker;
            viewModel.employee = employee;
            if (id != viewModel.EmployeeWorkTrackerViewModelId)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoursTracker);
                    _context.Update(viewModel);
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;                    
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(viewModel);
        }

        // GET: Managers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Manager
                .Include(m => m.IdentityUser)
                .FirstOrDefaultAsync(m => m.managerId == id);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manager = await _context.Manager.FindAsync(id);
            _context.Manager.Remove(manager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagerExists(int id)
        {
            return _context.Manager.Any(e => e.managerId == id);
        }

        // GET: Managers/EditProduct/5
        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productEdit = await _context.StoreProduct.FindAsync(id);
            if (productEdit == null)
            {
                return NotFound();
            }

            return View(productEdit);
        }

        // POST: Managers/EditProduct/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, StoreProduct product)
        {
            if (id != product.productId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(EditProduct));
            }

            return View(product);
        }

        // GET: Managers/CreateProduct
        public IActionResult CreateProduct()
        {
            ViewData["CreateProduct"] = new SelectList(_context.StoreProduct, "Id", "Id");
            return View();
        }

        // POST: Managers/CreateProduct
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(StoreProduct product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CreateProduct));
            }
            ViewData["CreateProduct"] = new SelectList(_context.StoreProduct, "Id", "Id", product.productId);
            return View(product);
        }

        // GET: Managers/DeleteProduct/5
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.StoreProduct
                .Include(p => p.productId)
                .FirstOrDefaultAsync(p => p.productId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Managers/DeleteProduct/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductConfirmed(int id)
        {
            var product = await _context.StoreProduct.FindAsync(id);
            _context.StoreProduct.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CreateProduct));
        }

        public ActionResult EmployeeListView()
        {
            var employeeList = _context.Employee.ToList();
            return View(employeeList);
        }

        public ActionResult EditList(int id)
        {
            var viewModelList = _context.EmployeeWorkTrackerViewModels.Where(vm => vm.employeeId == id).ToList();
            foreach(EmployeeWorkTrackerViewModel viewModel in viewModelList)
            {
                var employee = _context.Employee.Where(e => e.employeeId == viewModel.employeeId).FirstOrDefault();
                viewModel.employee = employee;
                var hoursTracker = _context.WorkHoursTrackers.Where(t => t.trackerId == viewModel.trackerId).FirstOrDefault();
                viewModel.hoursTracker = hoursTracker;
            }
            return View(viewModelList);
        }
    }

}
