using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Climbing4Everyone2._0.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Nickname{ get; set; }
        public string Country{ get; set; }
        public string City{ get; set; }
    }
}
