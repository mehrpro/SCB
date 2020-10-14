﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SCB.Models;
using SCB.Models.InfraBaseModels;

namespace SCB.Controllers
{
    public class AccountController : Controller
    {
        AppDbContext db = new AppDbContext();
        public IActionResult Login()
        {
            return View();
        }

        public ActionResult Validate(User admin)
        {
            var user = db.Users.FirstOrDefault(s => s.Email == admin.Email);
            if (user != null)
            {
                if (user.Password == admin.Password)
                {
                    HttpContext.Session.SetString("email", user.Email);
                    HttpContext.Session.SetInt32("id", user.UserId);
                    HttpContext.Session.SetInt32("role_id", (int)user.RoleId);
                    HttpContext.Session.SetString("name", user.FullName);

                    var roleId = (int)HttpContext.Session.GetInt32("role_id");
                    List<Menu> menus = db.LinkRolesMenus.Where(s => s.RoleId == roleId).Select(s => s.Menus).ToList();

                    DataSet ds = new DataSet();
                    ds = ToDataSet(menus);
                    DataTable table = ds.Tables[0];
                    DataRow[] parentMenus = table.Select("ParentId = 0");

                    var sb = new StringBuilder();
                    string menuString = GenerateUL(parentMenus, table, sb);
                    HttpContext.Session.SetString("menuString", menuString);
                    HttpContext.Session.SetString("menus", JsonConvert.SerializeObject(menus));

                    return Json(new { status = true, message = "Login Successfull!" });
                }
                else
                {
                    return Json(new { status = true, message = "Invalid Password!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Invalid Email!" });
            }
        }

        private string GenerateUL(DataRow[] menu, DataTable table, StringBuilder sb)
        {
            if (menu.Length > 0)
            {
                foreach (DataRow dr in menu)
                {
                    string url = dr["Url"].ToString();
                    string menuText = dr["Name"].ToString();
                    string icon = dr["Icon"].ToString();

                    if (url != "#")
                    {
                        string line = String.Format(@"<li><a href=""{0}""> {1}</a></li>", url, menuText, icon);
                        sb.Append(line);
                    }

                    string pid = dr["MenuId"].ToString();
                    string parentId = dr["ParentId"].ToString();

                    DataRow[] subMenu = table.Select(String.Format("ParentId = '{0}'", pid));
                    if (subMenu.Length > 0 && !pid.Equals(parentId))
                    {
                        string line = String.Format(@"<li><a href=""#""><i class=""{0}""></i> {1} <span class=""fa fa-chevron-down""></span>
                            </a><ul class=""nav child_menu"">", icon, menuText);
                        var subMenuBuilder = new StringBuilder();
                        sb.AppendLine(line);
                        sb.Append(GenerateUL(subMenu, table, subMenuBuilder));
                        sb.Append("</ul></li>");
                    }
                }
            }
            return sb.ToString();
        }

        public DataSet ToDataSet<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dataTable);
            return ds;
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
