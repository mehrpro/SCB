using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SCB.Models.InfraBaseModels;

namespace SCB.Models
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<LinkRolesMenus> LinkRolesMenus { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Companys> Companys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=.;Initial Catalog=SCB_DB;user id=sa;password=sa123sa;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Menus>().Property(p => p.Id).ValueGeneratedNever();

            modelBuilder.Entity<Menus>().HasData(new Menus{Id = 1, Name = "میزکار",Icon = "fa fa-dashboard",Url = "/",ParentId = 0,});

            modelBuilder.Entity<Menus>().HasData(new Menus{ Id = 2, Name = " کاربران",Icon = "fa fa-users",Url = "#",ParentId = 0,});
            modelBuilder.Entity<Menus>().HasData(new Menus{ Id = 3, Name = "کاربر جدید", Icon = "fa fa-plus", ParentId = 2, Url = "/Users/Create"});
            modelBuilder.Entity<Menus>().HasData(new Menus { Id = 4, Name = "مدیریت کاربران", Icon = "fa fa-users", ParentId = 2, Url = "/Users/Index" });

            modelBuilder.Entity<Menus>().HasData(new Menus { Id = 5, Name = "مشاغل", Icon = "fa fa-lock", ParentId = 0, Url = "#" });
            modelBuilder.Entity<Menus>().HasData(new Menus { Id = 6, Name = " شغل جدید", Icon = "fa fa-lock", ParentId = 5, Url = "/Roles/Create" });
            modelBuilder.Entity<Menus>().HasData(new Menus { Id = 7, Name = "مدیریت مشاغل", Icon = "fa fa-lock", ParentId = 5, Url = "/Roles/Index" });

            modelBuilder.Entity<Companys>().HasData(new Companys
            {
                CompanyName = "SCB",
                CompanyAddress = "Iran",
                PhoneNumber = "09186620474",
                FaxNumber = "09186620474",
                Email = "fm708801@gmail.com",
                Website = "www.trustedapp.ir"
            });

            modelBuilder.Entity<Roles>().HasData(new Roles{Title = "مدیر سیستم",Description = "مدیر سیستم و برنامه نویس",});

            modelBuilder.Entity<Users>().HasData(new Users
            {
                FullName = "Administrator",
                Email = "fm708801@gmail.com",
                Password = "708801298",
                CompanyId = 1,
                RoleId = 1,
                PhoneNumber = "09186620474",
                PhoneSuccess = true,
                EmailSuccess = true,
            });

            modelBuilder.Entity<LinkRolesMenus>().HasData(new LinkRolesMenus {RoleId = 1, MenuId = 2,});
            modelBuilder.Entity<LinkRolesMenus>().HasData(new LinkRolesMenus { RoleId = 1, MenuId = 3, });
            modelBuilder.Entity<LinkRolesMenus>().HasData(new LinkRolesMenus { RoleId = 1, MenuId = 4, });
            modelBuilder.Entity<LinkRolesMenus>().HasData(new LinkRolesMenus { RoleId = 1, MenuId = 5, });
            modelBuilder.Entity<LinkRolesMenus>().HasData(new LinkRolesMenus { RoleId = 1, MenuId = 6, });
            modelBuilder.Entity<LinkRolesMenus>().HasData(new LinkRolesMenus { RoleId = 1, MenuId = 7, });
        }
    }
}
