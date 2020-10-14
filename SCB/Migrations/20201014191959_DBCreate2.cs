using Microsoft.EntityFrameworkCore.Migrations;

namespace SCB.Migrations
{
    public partial class DBCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkRolesMenus_Menus_MenusMenuId",
                table: "LinkRolesMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkRolesMenus_Roles_RolesRoleId",
                table: "LinkRolesMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Company_CompanyId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolesRoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolesRoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_LinkRolesMenus_MenusMenuId",
                table: "LinkRolesMenus");

            migrationBuilder.DropIndex(
                name: "IX_LinkRolesMenus_RolesRoleId",
                table: "LinkRolesMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "RolesRoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MenusMenuId",
                table: "LinkRolesMenus");

            migrationBuilder.DropColumn(
                name: "RolesRoleId",
                table: "LinkRolesMenus");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkRolesMenus_MenuId",
                table: "LinkRolesMenus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkRolesMenus_RoleId",
                table: "LinkRolesMenus",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkRolesMenus_Menus_MenuId",
                table: "LinkRolesMenus",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkRolesMenus_Roles_RoleId",
                table: "LinkRolesMenus",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkRolesMenus_Menus_MenuId",
                table: "LinkRolesMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkRolesMenus_Roles_RoleId",
                table: "LinkRolesMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_LinkRolesMenus_MenuId",
                table: "LinkRolesMenus");

            migrationBuilder.DropIndex(
                name: "IX_LinkRolesMenus_RoleId",
                table: "LinkRolesMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.AddColumn<int>(
                name: "RolesRoleId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenusMenuId",
                table: "LinkRolesMenus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolesRoleId",
                table: "LinkRolesMenus",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesRoleId",
                table: "Users",
                column: "RolesRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkRolesMenus_MenusMenuId",
                table: "LinkRolesMenus",
                column: "MenusMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkRolesMenus_RolesRoleId",
                table: "LinkRolesMenus",
                column: "RolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkRolesMenus_Menus_MenusMenuId",
                table: "LinkRolesMenus",
                column: "MenusMenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkRolesMenus_Roles_RolesRoleId",
                table: "LinkRolesMenus",
                column: "RolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Company_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolesRoleId",
                table: "Users",
                column: "RolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
