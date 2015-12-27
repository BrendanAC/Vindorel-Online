using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVindorel.Models
{
    public class Mission
    {
        [Key]
        public int MissionID { get; set; }

        public int TownFrom { get; set; }

        public string TownFromGod { get; set; }
        public string TownToGod { get; set; }

        public int TownTo { get; set; }

        public int MissionType { get; set; }

        public int Army_Bowman { get; set; }

        public int Army_Swordman { get; set; }

        public int Army_Rider { get; set; }

        public DateTime Time { get; set; }

        public int TownId { get; set; }
        public Towns Town { get; set; }

    }
}
