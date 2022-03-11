using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dataBase;

        private string UserId { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _dataBase = db;
        }

        [BindProperty]
        public Route Route { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                Route.UserId = UserId;
                await _dataBase.ClimbingRoute.AddAsync(Route);
                await _dataBase.SaveChangesAsync();
                return RedirectToPage("MyList");
            }

            else
            {
                return Page();
            }
        }
    }
}