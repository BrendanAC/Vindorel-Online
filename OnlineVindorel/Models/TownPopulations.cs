using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVindorel.Models
{
    public class TownPopulations
    {
        [Key]
        public int PopulationID { get; set; }

        public int AggressivePop { get; set; }
        public int CulturalPop { get; set; }
        public int TraderPop { get; set; }
        public int BreedRate { get; set; }

        public int TownId { get; set; }
        public virtual Towns Town { get; set; }
    }
}
