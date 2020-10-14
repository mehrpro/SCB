﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCB.Models;

namespace SCB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201014191959_DBCreate2")]
    partial class DBCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SCB.Models.InfraBaseModels.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("FaxNumber")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            CompanyAddress = "Iran",
                            CompanyName = "SCB",
                            Email = "fm708801@gmail.com",
                            FaxNumber = "09186620474",
                            PhoneNumber = "09186620474",
                            Website = "www.trustedapp.ir"
                        });
                });

            modelBuilder.Entity("SCB.Models.InfraBaseModels.LinkRolesMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.ToTable("LinkRolesMenus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            MenuId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 3,
                            MenuId = 4,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 4,
                            MenuId = 5,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 5,
                            MenuId = 6,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 6,
                            MenuId = 7,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("SCB.Models.InfraBaseModels.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            MenuId = 1,
                            Icon = "fa fa-dashboard",
                            Name = "میزکار",
                            ParentId = 0,
                            Url = "/"
                        },
                        new
                        {
                            MenuId = 2,
                            Icon = "fa fa-users",
                            Name = " کاربران",
                            ParentId = 0,
                            Url = "#"
                        },
                        new
                        {
                            MenuId = 3,
                            Icon = "fa fa-plus",
                            Name = "کاربر جدید",
                            ParentId = 2,
                            Url = "/Users/Create"
                        },
                        new
                        {
                            MenuId = 4,
                            Icon = "fa fa-users",
                            Name = "مدیریت کاربران",
                            ParentId = 2,
                            Url = "/Users/Index"
                        },
                        new
                        {
                            MenuId = 5,
                            Icon = "fa fa-lock",
                            Name = "مشاغل",
                            ParentId = 0,
                            Url = "#"
                        },
                        new
                        {
                            MenuId = 6,
                            Icon = "fa fa-lock",
                            Name = " شغل جدید",
                            ParentId = 5,
                            Url = "/Roles/Create"
                        },
                        new
                        {
                            MenuId = 7,
                            Icon = "fa fa-lock",
                            Name = "مدیریت مشاغل",
                            ParentId = 5,
                            Url = "/Roles/Index"
                        });
                });

            modelBuilder.Entity("SCB.Models.InfraBaseModels.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Description = "مدیر سیستم و برنامه نویس",
                            Title = "مدیر سیستم"
                        });
                });

            modelBuilder.Entity("SCB.Models.InfraBaseModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailSuccess")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<bool>("PhoneSuccess")
                        .HasColumnType("bit");

                    b.Property<int?>("RoleId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CompanyId = 1,
                            Email = "fm708801@gmail.com",
                            EmailSuccess = true,
                            FullName = "Administrator",
                            Password = "708801298",
                            PhoneNumber = "09186620474",
                            PhoneSuccess = true,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("SCB.Models.InfraBaseModels.LinkRolesMenu", b =>
                {
                    b.HasOne("SCB.Models.InfraBaseModels.Menu", "Menus")
                        .WithMany("LinkRolesMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SCB.Models.InfraBaseModels.Role", "Roles")
                        .WithMany("LinkRolesMenus")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SCB.Models.InfraBaseModels.User", b =>
                {
                    b.HasOne("SCB.Models.InfraBaseModels.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SCB.Models.InfraBaseModels.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}