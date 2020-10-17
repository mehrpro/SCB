using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCB.Models;
using SCB.Models.InfraBaseModels;

namespace SCB.Controllers
{
    public class RolesController : Controller
    {
        AppDbContext _context = new AppDbContext();


        // GET: Roles  رفتن به لیست مجوزهای صادره
        [AuthorizedAction]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roles.ToListAsync());
        }

        //   مجوز جدید
        [AuthorizedAction]
        public IActionResult Create()
        {
            return View();
        }

        //  ثبت مجوز جدید
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Description")] Role roles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roles);
        }

        // ویرایش مجوز
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _context.Roles.SingleOrDefaultAsync(m => m.RoleId == id);
            if (roles == null)
            {
                return NotFound();
            }

            DataSet ds = new DataSet();
            List<string> menusId = _context.LinkRolesMenus.Where(s => s.RoleId == id).Select(s => s.MenuId.ToString()).ToList();
            ds = ToDataSet(_context.Menus.ToList());
            DataTable table = ds.Tables[0];
            DataRow[] parentMenus = table.Select("ParentId = 0");

            var sb = new StringBuilder();
            string unorderedList = GenerateUL(parentMenus, table, sb, menusId);
            ViewBag.menu = unorderedList;

            return View(roles);
        }

        // ثبت و ذخیره مجوز ویرایش شده
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,Title,Description")] Role roles)
        {
            if (id != roles.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesExists(roles.RoleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(roles);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _context.Roles
                .SingleOrDefaultAsync(m => m.RoleId == id);
            if (roles == null)
            {
                return NotFound();
            }

            return View(roles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            foreach (var role in _context.LinkRolesMenus.Where(s => s.RoleId == id))
            {
                _context.LinkRolesMenus.Remove(role);
            }
            await _context.SaveChangesAsync();

            var roles = await _context.Roles.SingleOrDefaultAsync(m => m.RoleId == id);
            _context.Roles.Remove(roles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id, List<int> roles)
        {
            var temp = _context.LinkRolesMenus.Where(s => s.RoleId == id);
            foreach (var item in temp)
            {
                _context.LinkRolesMenus.Remove(item);
            }

            foreach (var role in roles)
            {
                _context.LinkRolesMenus.Add(new LinkRolesMenu { MenuId = role, RoleId = id });
            }

            _context.SaveChanges();

            return Json(new { status = true, message = "Successfully Updated Role!" });
        }

        private bool RolesExists(int id)
        {
            return _context.Roles.Any(e => e.RoleId == id);
        }










        private string GenerateUL(DataRow[] omenu, DataTable table, StringBuilder sb, List<string> menus_id)
        {
            if (omenu.Length > 0)
            {
                foreach (DataRow dr in omenu)
                {
                    string id = dr["MenuId"].ToString();
                    string handler = dr["Url"].ToString();
                    string menuText = dr["Name"].ToString();
                    string icon = dr["Icon"].ToString();

                    string pid = dr["MenuId"].ToString();
                    string parentId = dr["ParentId"].ToString();

                    string status = (menus_id.Contains(id)) ? "Checked" : "";

                    DataRow[] subMenu = table.Select(String.Format("ParentId = '{0}'", pid));
                    if (subMenu.Length > 0 && !pid.Equals(parentId))
                    {//ایجاد زیر منو کومبو باکس
                        string line = String.Format(@"<li class=""has""><input type=""checkbox"" name=""subdomain[]"" id=""{5}"" value=""{1}"" {4}><label>> {1}</label>", handler, menuText, icon, "target", status, id);
                        sb.Append(line);

                        var subMenuBuilder = new StringBuilder();
                        sb.AppendLine(String.Format(@"<ul>"));
                        sb.Append(GenerateUL(subMenu, table, subMenuBuilder, menus_id));
                        sb.Append("</ul>");
                    }
                    else
                    {
                        string line = String.Format(@"<li class=""""><input type=""checkbox"" name=""subdomain[]"" id=""{5}"" value=""{1}"" {4}><label>{1}</label>", handler, menuText, icon, "target", status, id);
                        sb.Append(line);
                    }
                    sb.Append("</li>");
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
    }
}
