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
        }
        public DbSet<CandyShop.Models.Employee> Employee { get; set; }
        public DbSet<CandyShop.Models.Manager> Manager { get; set; }
        public DbSet<CandyShop.Models.Admin> Admin { get; set; }
    }
}
