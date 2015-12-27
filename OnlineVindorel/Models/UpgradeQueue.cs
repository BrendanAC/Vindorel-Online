using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVindorel.Models
{
    public class UpgradeQueue
    {
        [Key]
        public int UpgradeID { get; set; }

        public int BuildingINDEX { get; set; }

        public DateTime ProductionTime { get; set; }
        

        public int TownID { get; set; } 
        public Towns Town { get; set; }
    }
}
