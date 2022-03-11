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

namespace Climbing4Everyone.Pages.RouteList
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private ApplicationDbContext _dataBase;

        public DetailsModel(ApplicationDbContext db)
        {
            _dataBase = db;
        }

        public Route Route { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Route = await _dataBase.ClimbingRoute.FindAsync(id);

            if (Route == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}