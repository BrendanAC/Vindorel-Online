using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineVindorel.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Account : IdentityUser
    {
        public Account()
        {
            Towns = new HashSet<Towns>();
            GameSettings = new HashSet<UserGameSettings>();
        }
       
        public virtual ICollection<Towns> Towns { get; set; }
        public virtual ICollection<UserGameSettings> GameSettings { get; set; }
    }
}
