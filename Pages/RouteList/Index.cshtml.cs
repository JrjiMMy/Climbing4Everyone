using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Climbing4Everyone.Model;
using Climbing4Everyone2._0.Data;
using Climbing4Everyone2._0.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Climbing4Everyone.Pages.RouteList
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dataBase;

        public IndexModel(ApplicationDbContext db)
        {
            _dataBase = db;
        }

        public IList<Route> Routes { get; set; }

        public async Task OnGet()
        {
            Routes = await _dataBase.ClimbingRoute.Where(r => r.IsShared == true).ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var Route = await _dataBase.ClimbingRoute.FindAsync(id);
            if (Route == null)
            {
                return NotFound();
            }

            _dataBase.ClimbingRoute.Remove(Route);
            await _dataBase.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}