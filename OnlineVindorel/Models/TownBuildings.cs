using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVindorel.Models
{
    public class TownBuildings
    {
        [Key]
        public int BuildingsID { get; set; }

        public int TownCenter { get; set; }
        public int CityWall { get; set; }

        public int TechnologyCamp { get; set; }
        public int TradeHouse { get; set; }
        public int Warehouse { get; set; }
        public int Temple { get; set; }
        public int Barracks { get; set; }

        public int Farm { get; set; }
        public int MeatCamp { get; set; }
        public int Mine { get; set; }
        public int WoodCutterHut { get; set; }
        public int TaxHouse { get; set; }

        public int TownID { get; set; }
        public virtual Towns Town { get; set; }
    }
}
