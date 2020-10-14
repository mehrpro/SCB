using Microsoft.EntityFrameworkCore.Migrations;

namespace SCB.Migrations
{
    public partial class DBCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 250, nullable: false),
                    CompanyAddress = table.Column<string>(maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: false),
                    FaxNumber = table.Column<string>(maxLength: 11, nullable: true),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    Website = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "LinkRolesMenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false),
                    MenusMenuId = table.Column<int>(nullable: true),
                    RolesRoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkRolesMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkRolesMenus_Menus_MenusMenuId",
                        column: x => x.MenusMenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinkRolesMenus_Roles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 16, nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: false),
                    PhoneSuccess = table.Column<bool>(nullable: false),
                    EmailSuccess = table.Column<bool>(nullable: false),
                    RolesRoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "CompanyAddress", "CompanyName", "Email", "FaxNumber", "PhoneNumber", "Website" },
                values: new object[] { 1, "Iran", "SCB", "fm708801@gmail.com", "09186620474", "09186620474", "www.trustedapp.ir" });

            migrationBuilder.InsertData(
                table: "LinkRolesMenus",
                columns: new[] { "Id", "MenuId", "MenusMenuId", "RoleId", "RolesRoleId" },
                values: new object[,]
                {
                    { 1, 2, null, 1, null },
                    { 2, 3, null, 1, null },
                    { 3, 4, null, 1, null },
                    { 4, 5, null, 1, null },
                    { 5, 6, null, 1, null },
                    { 6, 7, null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Icon", "Name", "ParentId", "Url" },
                values: new object[,]
                {
                    { 1, "fa fa-dashboard", "میزکار", 0, "/" },
                    { 2, "fa fa-users", " کاربران", 0, "#" },
                    { 3, "fa fa-plus", "کاربر جدید", 2, "/Users/Create" },
                    { 4, "fa fa-users", "مدیریت کاربران", 2, "/Users/Index" },
                    { 5, "fa fa-lock", "مشاغل", 0, "#" },
                    { 6, "fa fa-lock", " شغل جدید", 5, "/Roles/Create" },
                    { 7, "fa fa-lock", "مدیریت مشاغل", 5, "/Roles/Index" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description", "Title" },
                values: new object[] { 1, "مدیر سیستم و برنامه نویس", "مدیر سیستم" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CompanyId", "Email", "EmailSuccess", "FullName", "Password", "PhoneNumber", "PhoneSuccess", "RoleId", "RolesRoleId" },
                values: new object[] { 1, 1, "fm708801@gmail.com", true, "Administrator", "708801298", "09186620474", true, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_LinkRolesMenus_MenusMenuId",
                table: "LinkRolesMenus",
                column: "MenusMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkRolesMenus_RolesRoleId",
                table: "LinkRolesMenus",
                column: "RolesRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesRoleId",
                table: "Users",
                column: "RolesRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkRolesMenus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
