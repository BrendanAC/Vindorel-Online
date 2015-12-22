using GameVindorel.Models;
using System;
using System.Collections.Generic;

namespace VindorelOnline.Models
{
    public partial class Towns
    {
        public Towns()
        {
            TownBuildings = new HashSet<TownBuildings>();
            TownPopulations = new HashSet<TownPopulations>();
        }

        public int TownID { get; set; }
        public int Coordinate_X { get; set; }
        public int Coordinate_Y { get; set; }
        public DateTime? LastUPDATE { get; set; }
        public int MaxFOOD { get; set; }
        public int MaxIRON { get; set; }
        public int MaxWOOD { get; set; }
        public int PointCulture { get; set; }
        public int PointExp { get; set; }
        public int PointKarma { get; set; }
        public int TownFOOD { get; set; }
        public int? TownFOOD_perHour { get; set; }
        public int TownGOLD { get; set; }
        public int? TownGOLD_perHour { get; set; }
        public int TownIRON { get; set; }
        public int? TownIRON_perHour { get; set; }
        public string TownName { get; set; }
        public int TownWOOD { get; set; }
        public int? TownWOOD_perHour { get; set; }

        public virtual ICollection<TownBuildings> TownBuildings { get; set; }
        public virtual ICollection<TownPopulations> TownPopulations { get; set; }
        public virtual VindorelUser User { get; set; }
    }
}
