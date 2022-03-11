using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Climbing4Everyone.Model;
using Climbing4Everyone2._0.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Climbing4Everyone2._0.Model;

namespace Climbing4Everyone.Pages.RouteList
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private ApplicationDbContext _dataBase;

        public DeleteModel(ApplicationDbContext db)
        {
            _dataBase = db;
        }

        [BindProperty]
        public Route Route { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Route = await _dataBase.ClimbingRoute
                .Include(n => n.AppUser).FirstOrDefaultAsync(m => m.ID == id);

            if (Route == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Route = await _dataBase.ClimbingRoute.FindAsync(id);

            if (Route != null)
            {
                _dataBase.ClimbingRoute.Remove(Route);
                await _dataBase.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}