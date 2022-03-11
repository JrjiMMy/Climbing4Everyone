using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Climbing4Everyone2._0.Data;
using Climbing4Everyone2._0.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Climbing4Everyone2._0.Controllers
{
    [Route("api/Route")]
    [ApiController]
    public class RouteController : Controller
    {

        private readonly ApplicationDbContext _dataBase;

        public RouteController(ApplicationDbContext db)
        {
            _dataBase = db;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.AdminEndUser)]
        public IActionResult GetAll()
        {
            return Json(new { data = _dataBase.ClimbingRoute.ToList() });
        }

        [HttpGet]
        [Route("GetShared")]
        public IActionResult GetShared()
        {
            return Json(new { data = _dataBase.ClimbingRoute.Where(r => r.IsShared == true).ToList() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var routeFromDb = await _dataBase.ClimbingRoute.FirstOrDefaultAsync(u => u.ID == id);
            if (routeFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _dataBase.ClimbingRoute.Remove(routeFromDb);
            await _dataBase.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}