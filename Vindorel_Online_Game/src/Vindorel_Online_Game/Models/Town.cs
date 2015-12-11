using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vindorel_Online_Game.Models
{
    public class Town
    {
        public int TownId { get; set; }

        public string TownName { get; set; }

        public int x { get; set; }
        public int y { get; set; }

        public int TownWood { get; set; }

        public int TownIron { get; set; }

        public int TownFood { get; set; }

        public int TownGold { get; set; }

        public int CulturePoint { get; set; }

        public int ArmyId { get; set; }

        public int PopId { get; set; }

        public int TechTreeId { get; set; }

        public int ExpPoint { get; set; }

        public int Level { get; set; }

        public int KarmaPoint { get; set; }

        public string Building1 { get; set; }

        public int Building1_Level { get; set; }

        public string Building2 { get; set; }

        public int Building2_Level { get; set; }

        public string Building3 { get; set; }

        public int Building3_Level { get; set; }

        public string Building4 { get; set; }

        public int Building4_Level { get; set; }

        public string Building5 { get; set; }

        public int Building5_Level { get; set; }

        public string Building6 { get; set; }

        public int Building6_Level { get; set; }

        public string Building7 { get; set; }

        public int Building7_Level { get; set; }

        public string Building8 { get; set; }

        public int Building8_Level { get; set; }

        public string Building9 { get; set; }

        public int Building9_Level { get; set; }

        public string Building10 { get; set; }

        public int Building10_Level { get; set; }

        public int UserId { get; set; }

        //Navigation Property
            
        public UserAccount UserAccount { get; set; }

    }
}
