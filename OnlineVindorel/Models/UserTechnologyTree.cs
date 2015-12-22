using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVindorel.Models
{
    public class UserTechnologyTree
    {
        [Key]
        public int TechnologyID { get; set; }
    
        public int EconomyLevel { get; set; }
        public int CultureLevel { get; set; }
        public int MilitaryLevel { get; set; }

        public string userId { get; set; }
        public virtual Account User { get; set; }
    }
}
