using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CandyShop.Models;

namespace CandyShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "Manager",
                NormalizedName = "MGR"
            },
            new IdentityRole
            {
                Name = "Employee",
                NormalizedName = "EMP"
            }
            );
            
            base.OnModelCreating(builder);
            builder.Entity<EmployeeTransactionViewModel>()
            .HasKey(e => new { e.employeeId });

            base.OnModelCreating(builder);
            builder.Entity<TransactionProducts>()
            .HasKey(t => new { t.transactionId });
        }
        public DbSet<CandyShop.Models.Employee> Employee { get; set; }
        public DbSet<CandyShop.Models.Manager> Manager { get; set; }
        public DbSet<CandyShop.Models.Admin> Admin { get; set; }
        public DbSet<CandyShop.Models.StoreProduct> StoreProduct { get; set; }
        public DbSet<CandyShop.Models.Transaction> Transaction { get; set; }
        public DbSet<CandyShop.Models.TransactionProducts> TransactionProducts { get; set; }
        public DbSet<CandyShop.Models.EmployeeTransactionViewModel> EmployeeTransactionViewModels { get; set; }
        public DbSet<CandyShop.Models.WorkHoursTracker> WorkHoursTrackers { get; set; }
        public DbSet<CandyShop.Models.EmployeeWorkTrackerViewModel> EmployeeWorkTrackerViewModels { get; set; }
    }
}
