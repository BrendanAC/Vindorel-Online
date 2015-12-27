using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVindorel.Models
{
    public class TownArmy
    {
        [Key]
        public int TownArmyID { get; set; }

        public int Bowman { get; set; }
        public int Rider { get; set; }
        public int Swordman { get; set; }

        public int TownId { get; set; }
        public virtual Towns Town { get; set; }
    }
}
