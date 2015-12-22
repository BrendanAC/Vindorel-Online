using System;
using System.Collections.Generic;

namespace VindorelOnline.Models
{
    public partial class TownBuildings
    {
        public int BuildingsID { get; set; }
        public int BattleCamp { get; set; }
        public int CityWall { get; set; }
        public int Farm { get; set; }
        public int HutHouse { get; set; }
        public int IronMine { get; set; }
        public int MeatCamp { get; set; }
        public int SlaveMine { get; set; }
        public int TechnologyCamp { get; set; }
        public int TownCenter { get; set; }
        public int TownID { get; set; }
        public int TradeHouse { get; set; }
        public int Warehouse { get; set; }
        public int WoodCutterCamp { get; set; }
        public int WoodCutterHut { get; set; }
        public int WoodHouse { get; set; }

        public virtual Towns Town { get; set; }
    }
}
