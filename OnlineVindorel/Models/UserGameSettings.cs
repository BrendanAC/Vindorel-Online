using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVindorel.Models
{
    public class UserGameSettings
    {   
        [Key]
        public int SettingID { get; set; }

        public int Point_Exp { get; set; }
        public int Point_Karma { get; set; }
        public int Point_Military { get; set; }
        public int Point_Economy { get; set; }
        public int Point_Culture { get; set; }

        public int NaturalBreedRate { get; set; }
        public int AnarchyRate { get; set; }
        public int TraderRate { get; set; }
        public int CultureRate { get; set; }
        public int BuildSpeed { get; set; }
        public int TrainSpeed { get; set; }
        public int ArmySpeed { get; set; }


        public int NaturalAttack { get; set; }
        public int NaturalDef { get; set; }

        public string Job { get; set; }
        public string Race { get; set; }
        public string God { get; set; }
        
        public string UserId { get; set; }
        public Account User { get; set; }


    }
}
