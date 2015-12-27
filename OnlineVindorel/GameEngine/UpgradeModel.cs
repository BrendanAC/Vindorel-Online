using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVindorel.GameEngine
{
    public class UpgradeModel
    {
        [Key]
        public int index { get; set; }
        public int Cost_Iron { get; set; }
        public int Cost_Wood { get; set; }
        public int Cost_Wheat { get; set; }
        public int Cost_Meat { get; set; }
        public int Gain_Exp { get; set; }
        public int Gain_Culture { get; set; }
        public int Gain_Karma { get; set; }
        public int Gain_Military { get; set; }
        public int Gain_Economy { get; set; }
        public int Gain_AgressivePop { get; set; }
        public int Gain_CulturalPop { get; set; }
        public int Gain_TraderPop { get; set; }
        public int Gain_NaturalAttack { get; set; }
        public int Gain_NaturalDef { get; set; }
        public int Gain_TownWHEAT_perHour { get; set; }
        public int Gain_TownGOLD_perHour { get; set; }
        public int Gain_TownMeat_perHour { get; set; }
        public int Gain_TownIRON_perHour { get; set; }
        public int Gain_TownWOOD_perHour { get; set; }
        public double Buildtime { get; set; }
    }
}
