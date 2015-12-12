using System;
using System.Collections.Generic;

namespace VindorelOnline.Models
{
    public partial class TownPopulations
    {
        public int PopulationID { get; set; }
        public int AggressivePop { get; set; }
        public int CulturalPop { get; set; }
        public int Population { get; set; }
        public int TownID { get; set; }
        public int TraderPop { get; set; }

        public virtual Towns Town { get; set; }
    }
}
