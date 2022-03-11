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
    public class EditModel : PageModel
    {
        private ApplicationDbContext _dataBase;

        public EditModel(ApplicationDbContext db)
        {
            _dataBase = db;
        }

        [BindProperty]
        public Route Route { get; set; }

        public async Task OnGet(int id)
        {
            Route = await _dataBase.ClimbingRoute.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var RouteFromDb = await _dataBase.ClimbingRoute.FindAsync(Route.ID);
                RouteFromDb.RouteName = Route.RouteName;
                RouteFromDb.RouteDifficulty = Route.RouteDifficulty;
                RouteFromDb.RockName = Route.RockName;
                RouteFromDb.RegionName = Route.RegionName;
                RouteFromDb.ApproachTime = Route.ApproachTime;
                RouteFromDb.RockHeight = Route.RockHeight;
                RouteFromDb.RockExposure = Route.RockExposure;
                RouteFromDb.FloorUnder = Route.FloorUnder;
                RouteFromDb.RouteFormations = Route.RouteFormations;
                RouteFromDb.RoutesOnRock = Route.RoutesOnRock;
                RouteFromDb.Description = Route.Description;
                RouteFromDb.IsShared = Route.IsShared;
                RouteFromDb.MapLink = Route.MapLink;

                await _dataBase.SaveChangesAsync();

                return RedirectToPage("MyList");
            }
            return RedirectToPage();
        }
    }
}