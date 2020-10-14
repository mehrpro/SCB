using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCB.Models;

namespace SCB.Controllers
{
    public class RolesController : Controller
    {
        AppDbContext db = new AppDbContext();
        public async Task<IActionResult> Index()
        {
            return View(await db.Roles.ToListAsync());
        }
    }
}
