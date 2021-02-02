﻿// <auto-generated />
using System;
using CandyShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CandyShop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210131230117_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CandyShop.Models.Admin", b =>
                {
                    b.Property<int>("adminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("adminId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("CandyShop.Models.Employee", b =>
                {
                    b.Property<int>("employeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("employeeId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("CandyShop.Models.EmployeeTransactionViewModel", b =>
                {
                    b.Property<int>("employeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeTransactionViewModelId")
                        .HasColumnType("int");

                    b.Property<int>("employeeId1")
                        .HasColumnType("int");

                    b.Property<int?>("transactionId")
                        .HasColumnType("int");

                    b.HasKey("employeeId");

                    b.HasIndex("employeeId1");

                    b.HasIndex("transactionId");

                    b.ToTable("EmployeeTransactionViewModels");
                });

            modelBuilder.Entity("CandyShop.Models.EmployeeWorkTrackerViewModel", b =>
                {
                    b.Property<int>("employeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeWorkTrackerViewModelId")
                        .HasColumnType("int");

                    b.Property<int>("employeeId1")
                        .HasColumnType("int");

                    b.Property<int?>("hoursTrackertrackerId")
                        .HasColumnType("int");

                    b.Property<int>("trackerId")
                        .HasColumnType("int");

                    b.HasKey("employeeId");

                    b.HasIndex("employeeId1");

                    b.HasIndex("hoursTrackertrackerId");

                    b.ToTable("EmployeeWorkTrackerViewModels");
                });

            modelBuilder.Entity("CandyShop.Models.Manager", b =>
                {
                    b.Property<int>("managerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("managerId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("CandyShop.Models.StoreProduct", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeTransactionViewModelemployeeId")
                        .HasColumnType("int");

                    b.Property<int>("QTY")
                        .HasColumnType("int");

                    b.Property<string>("category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<string>("productName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("supplierDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("transactionId")
                        .HasColumnType("int");

                    b.HasKey("productId");

                    b.HasIndex("EmployeeTransactionViewModelemployeeId");

                    b.HasIndex("transactionId");

                    b.ToTable("StoreProduct");
                });

            modelBuilder.Entity("CandyShop.Models.Transaction", b =>
                {
                    b.Property<int>("transactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<bool>("isComplete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.Property<double>("totalCost")
                        .HasColumnType("float");

                    b.HasKey("transactionId");

                    b.HasIndex("employeeId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("CandyShop.Models.TransactionProducts", b =>
                {
                    b.Property<int>("transactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("transactionId1")
                        .HasColumnType("int");

                    b.Property<int>("transactionProductId")
                        .HasColumnType("int");

                    b.HasKey("transactionId");

                    b.HasIndex("productId");

                    b.HasIndex("transactionId1");

                    b.ToTable("TransactionProducts");
                });

            modelBuilder.Entity("CandyShop.Models.WorkHoursTracker", b =>
                {
                    b.Property<int>("trackerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("breakEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("breakStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("clockIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("clockOut")
                        .HasColumnType("datetime2");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<double>("hoursWorked")
                        .HasColumnType("float");

                    b.HasKey("trackerId");

                    b.HasIndex("employeeId");

                    b.ToTable("WorkHoursTrackers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "2da92661-625b-4b90-812f-09672272c47a",
                            ConcurrencyStamp = "79d26dec-035c-43c3-a7a2-6e17b058d620",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "8e6c0856-6943-4b0d-b4d7-79e7d0458723",
                            ConcurrencyStamp = "d5cec77e-2566-41c9-bf6a-3d1069c0f40a",
                            Name = "Manager",
                            NormalizedName = "MGR"
                        },
                        new
                        {
                            Id = "f74a3869-77b0-441a-abb0-78e2486aee36",
                            ConcurrencyStamp = "f0ff93cb-396a-4d5a-95d2-6bbfbd0ef0b6",
                            Name = "Employee",
                            NormalizedName = "EMP"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CandyShop.Models.Admin", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("CandyShop.Models.Employee", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("CandyShop.Models.EmployeeTransactionViewModel", b =>
                {
                    b.HasOne("CandyShop.Models.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CandyShop.Models.Transaction", "transaction")
                        .WithMany()
                        .HasForeignKey("transactionId");
                });

            modelBuilder.Entity("CandyShop.Models.EmployeeWorkTrackerViewModel", b =>
                {
                    b.HasOne("CandyShop.Models.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CandyShop.Models.WorkHoursTracker", "hoursTracker")
                        .WithMany()
                        .HasForeignKey("hoursTrackertrackerId");
                });

            modelBuilder.Entity("CandyShop.Models.Manager", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("CandyShop.Models.StoreProduct", b =>
                {
                    b.HasOne("CandyShop.Models.EmployeeTransactionViewModel", null)
                        .WithMany("listOfProducts")
                        .HasForeignKey("EmployeeTransactionViewModelemployeeId");

                    b.HasOne("CandyShop.Models.Transaction", null)
                        .WithMany("products")
                        .HasForeignKey("transactionId");
                });

            modelBuilder.Entity("CandyShop.Models.Transaction", b =>
                {
                    b.HasOne("CandyShop.Models.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CandyShop.Models.TransactionProducts", b =>
                {
                    b.HasOne("CandyShop.Models.StoreProduct", "product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CandyShop.Models.Transaction", "transaction")
                        .WithMany()
                        .HasForeignKey("transactionId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CandyShop.Models.WorkHoursTracker", b =>
                {
                    b.HasOne("CandyShop.Models.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}