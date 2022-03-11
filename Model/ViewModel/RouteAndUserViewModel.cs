using Climbing4Everyone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Climbing4Everyone2._0.Model.ViewModel
{
    public class RouteAndUserViewModel
    {
        public ApplicationUser UserObj { get; set; }
        public IEnumerable<Route> Routes{ get; set; }
    }
}
