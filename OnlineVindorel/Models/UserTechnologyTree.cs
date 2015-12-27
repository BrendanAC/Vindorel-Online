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

        public int ECONOMY_Obey { get; set; }
        public int ECONOMY_SafeRoad { get; set; }

        public int CULTURE_Morale { get; set; }
        public int CULTURE_BTimeReduction { get; set; }

        public int MILITARY_Power { get; set; }
        public int MILITARY_Defence { get; set; }



        public string UserID { get; set; }
        public virtual Account User{ get; set; }
    }
}
