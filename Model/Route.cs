using Climbing4Everyone2._0.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Climbing4Everyone.Model
{
    public class Route
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string RouteName { get; set; }
        [Required]
        public string RouteDifficulty { get; set; }
        [Required]
        public string RockName { get; set; }
        [Required]
        public string RegionName { get; set; }
        [Required]
        public int ApproachTime { get; set; }
        [Required]
        public int RockHeight { get; set; }
        [Required]
        public string RockExposure { get; set; }
        [Required]
        public string FloorUnder { get; set; }
        [Required]
        public string RouteFormations { get; set; }
        [Required]
        public int RoutesOnRock { get; set; }
        public string Description { get; set; }
        public string MapLink { get; set; }
        public bool IsShared { get; set; }

        [Display(Name = "ApplicationUser")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser AppUser { get; set; }

        public Route()
        {
            IsShared = false;
        }
    }  

}