using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineVindorel.Models
{
    public class Towns
    {
        public Towns()
        {
            TownBuildings = new HashSet<TownBuildings>();
            TownPopulations = new HashSet<TownPopulations>();
        }

        [Key]
        public int TownId { get; set; }

        public string TownName { get; set; }
        public int Coordinate_X { get; set; }
        public int Coordinate_Y { get; set; }
        public int MaxFOOD { get; set; }
        public int MaxIRON { get; set; }
        public int MaxWOOD { get; set; }
        public int TownWHEAT{ get; set; }
        public int TownWHEAT_perHour { get; set; }
        public int TownMEAT { get; set; }
        public int TownMeat_perHour { get; set; }
        public int TownGOLD { get; set; }
        public int TownGOLD_perHour { get; set; }
        public int TownIRON { get; set; }
        public int TownIRON_perHour { get; set; }
        public int TownWOOD { get; set; }
        public int TownWOOD_perHour { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual ICollection<TownBuildings> TownBuildings { get; set; }
        public virtual ICollection<TownPopulations> TownPopulations { get; set; }

        public string UserId { get; set; }
        public virtual Account User { get; set; }

    }
}
