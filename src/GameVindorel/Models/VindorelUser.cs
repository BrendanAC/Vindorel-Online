using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using VindorelOnline.Models;

namespace GameVindorel.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class VindorelUser : IdentityUser
    {

        public VindorelUser()
        {
            Towns = new HashSet<Towns>();
           
        }
        
        
        public double SpeedBuildMultiplier { get; set; }
        public double SpeedTradeMultiplier { get; set; }
        public double SpeedTrainMultiplier { get; set; }
        public string UserJob { get; set; }
        public string UserRace { get; set; }
        public virtual ICollection<Towns> Towns { get; set; }


    }
}
