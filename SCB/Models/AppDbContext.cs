using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SCB.Models.InfraBaseModels;

namespace SCB.Models
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<LinkRolesMenu> LinkRolesMenus { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

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

            modelBuilder.Entity<Menu>().Property(p => p.MenuId).ValueGeneratedNever();

            modelBuilder.Entity<Menu>().HasData(new Menu{ MenuId = 1, Name = "میزکار",Icon = "fa fa-dashboard",Url = "/",ParentId = 0,});

            modelBuilder.Entity<Menu>().HasData(new Menu{ MenuId = 2, Name = " کاربران",Icon = "fa fa-users",Url = "#",ParentId = 0,});
            modelBuilder.Entity<Menu>().HasData(new Menu{ MenuId = 3, Name = "کاربر جدید", Icon = "fa fa-plus", ParentId = 2, Url = "/Users/Create"});
            modelBuilder.Entity<Menu>().HasData(new Menu { MenuId = 4, Name = "مدیریت کاربران", Icon = "fa fa-users", ParentId = 2, Url = "/Users/Index" });

            modelBuilder.Entity<Menu>().HasData(new Menu { MenuId = 5, Name = "مشاغل", Icon = "fa fa-lock", ParentId = 0, Url = "#" });
            modelBuilder.Entity<Menu>().HasData(new Menu { MenuId = 6, Name = " شغل جدید", Icon = "fa fa-lock", ParentId = 5, Url = "/Roles/Create" });
            modelBuilder.Entity<Menu>().HasData(new Menu { MenuId = 7, Name = "مدیریت مشاغل", Icon = "fa fa-lock", ParentId = 5, Url = "/Roles/Index" });

            modelBuilder.Entity<Company>().HasData(new Company()
            {
                CompanyId = 1,
                CompanyName = "SCB",
                CompanyAddress = "Iran",
                PhoneNumber = "09186620474",
                FaxNumber = "09186620474",
                Email = "fm708801@gmail.com",
                Website = "www.trustedapp.ir",

            });

            modelBuilder.Entity<Role>().HasData(new Role{RoleId = 1, Title = "مدیر سیستم",Description = "مدیر سیستم و برنامه نویس",});

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                FullName = "Administrator",
                Email = "fm708801@gmail.com",
                Password = "708801298",
                CompanyId = 1,
                RoleId = 1,
                PhoneNumber = "09186620474",
                PhoneSuccess = true,
                EmailSuccess = true,
            });

            modelBuilder.Entity<LinkRolesMenu>().HasData(new LinkRolesMenu {Id = 1, RoleId = 1, MenuId = 2, });
            modelBuilder.Entity<LinkRolesMenu>().HasData(new LinkRolesMenu {Id = 2, RoleId = 1, MenuId = 3, });
            modelBuilder.Entity<LinkRolesMenu>().HasData(new LinkRolesMenu {Id = 3, RoleId = 1, MenuId = 4, });
            modelBuilder.Entity<LinkRolesMenu>().HasData(new LinkRolesMenu {Id = 4, RoleId = 1, MenuId = 5, });
            modelBuilder.Entity<LinkRolesMenu>().HasData(new LinkRolesMenu {Id = 5, RoleId = 1, MenuId = 6, });
            modelBuilder.Entity<LinkRolesMenu>().HasData(new LinkRolesMenu { Id = 6, RoleId = 1, MenuId = 7, });
        }
    }
}
