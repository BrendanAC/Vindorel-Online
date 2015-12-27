using OnlineVindorel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
namespace OnlineVindorel.GameEngine
{
    public class CreateNewTown
    {
        public void CreateTown(Account Player,UserGameSettings Settings)
        {
            Towns NewTown = new Towns();
            SettingStats(Settings);
            SettingTown(NewTown,Player);
            Player.Towns.Add(NewTown);

        }
        private void SettingStats(UserGameSettings Settings)
        {
            if (Settings.God == "fus")
            {
                Settings.AnarchyRate = 1;
                Settings.ArmySpeed = 1;
                Settings.BuildSpeed = 1;
                Settings.CultureRate = 1;
                Settings.NaturalAttack = 1;
                Settings.NaturalDef = 1;
                Settings.Point_Culture = 1;
                Settings.Point_Economy = 1;
                Settings.Point_Exp = 1;
                Settings.Point_Karma = 1;
                Settings.Point_Military = 1;
                Settings.NaturalBreedRate = 1;
                Settings.TraderRate = 1;
                Settings.TrainSpeed = 1;
            }
            if (Settings.God == "teliros")
            {
                Settings.AnarchyRate = 1;
                Settings.ArmySpeed = 1;
                Settings.BuildSpeed = 1;
                Settings.CultureRate = 1;
                Settings.NaturalAttack = 1;
                Settings.NaturalDef = 1;
                Settings.Point_Culture = 1;
                Settings.Point_Economy = 1;
                Settings.Point_Exp = 1;
                Settings.Point_Karma = 1;
                Settings.Point_Military = 1;
                Settings.NaturalBreedRate = 1;
                Settings.TraderRate = 1;
                Settings.TrainSpeed = 1;
            }
            if (Settings.God == "sopyak")
            {
                Settings.AnarchyRate = 1;
                Settings.ArmySpeed = 1;
                Settings.BuildSpeed = 1;
                Settings.CultureRate = 1;
                Settings.NaturalAttack = 1;
                Settings.NaturalDef = 1;
                Settings.Point_Culture = 1;
                Settings.Point_Economy = 1;
                Settings.Point_Exp = 1;
                Settings.Point_Karma = 1;
                Settings.Point_Military = 1;
                Settings.NaturalBreedRate = 1;
                Settings.TraderRate = 1;
                Settings.TrainSpeed = 1;
            }
            if (Settings.God == "xaraxel")
            {
                Settings.AnarchyRate = 1;
                Settings.ArmySpeed = 1;
                Settings.BuildSpeed = 1;
                Settings.CultureRate = 1;
                Settings.NaturalAttack = 1;
                Settings.NaturalDef = 1;
                Settings.Point_Culture = 1;
                Settings.Point_Economy = 1;
                Settings.Point_Exp = 1;
                Settings.Point_Karma = 1;
                Settings.Point_Military = 1;
                Settings.NaturalBreedRate = 1;
                Settings.TraderRate = 1;
                Settings.TrainSpeed = 1;
            }
            if (Settings.God == "handor")
            {
                Settings.AnarchyRate = 1;
                Settings.ArmySpeed = 1;
                Settings.BuildSpeed = 1;
                Settings.CultureRate = 1;
                Settings.NaturalAttack = 1;
                Settings.NaturalDef = 1;
                Settings.Point_Culture = 1;
                Settings.Point_Economy = 1;
                Settings.Point_Exp = 1;
                Settings.Point_Karma = 1;
                Settings.Point_Military = 1;
                Settings.NaturalBreedRate = 1;
                Settings.TraderRate = 1;
                Settings.TrainSpeed = 1;
            }
            if (Settings.God == "zean")
            {
                Settings.AnarchyRate = 1;
                Settings.ArmySpeed = 1;
                Settings.BuildSpeed = 1;
                Settings.CultureRate = 1;
                Settings.NaturalAttack = 1;
                Settings.NaturalDef = 1;
                Settings.Point_Culture = 1;
                Settings.Point_Economy = 1;
                Settings.Point_Exp = 1;
                Settings.Point_Karma = 1;
                Settings.Point_Military = 1;
                Settings.NaturalBreedRate = 1;
                Settings.TraderRate = 1;
                Settings.TrainSpeed = 1;
            }
            if (Settings.God == "atheist")
            {
                Settings.AnarchyRate = 1;
                Settings.ArmySpeed = 1;
                Settings.BuildSpeed = 1;
                Settings.CultureRate = 1;
                Settings.NaturalAttack = 1;
                Settings.NaturalDef = 1;
                Settings.Point_Culture = 1;
                Settings.Point_Economy = 1;
                Settings.Point_Exp = 1;
                Settings.Point_Karma = 1;
                Settings.Point_Military = 1;
                Settings.NaturalBreedRate = 1;
                Settings.TraderRate = 1;
                Settings.TrainSpeed = 1;
            }
        }
        private void SettingTown(Towns NewTown,Account Player)
        {
            NewTown.TownName = "YourTownName";
            NewTown.TownBuildings.Add(new TownBuildings
            {
                TownID = NewTown.TownId,
                TownCenter = 1,
                Barracks = 0,
                CityWall = 0,
                Farm = 0,
                MeatCamp = 0,
                TaxHouse = 0,
                Temple = 0,
                TradeHouse = 0,
                Warehouse = 0,
                Mine = 0,
                TechnologyCamp = 0,
                WoodCutterHut = 0,
            });
            NewTown.TownPopulations.Add(new TownPopulations
            {
                AggressivePop = 2,
                BreedRate = 1,
                CulturalPop = 2,
                TraderPop = 2,
                TownId = NewTown.TownId,
            });

            #region DefaultTownStats
            NewTown.TownGOLD = 100;
            NewTown.TownIRON = 300;
            NewTown.TownMEAT = 600;
            NewTown.TownWHEAT = 500;
            NewTown.TownWOOD = 1000;
            NewTown.MaxFOOD = 10000;
            NewTown.MaxIRON = 10000;
            NewTown.MaxWOOD = 10000;
            NewTown.TownGOLD_perHour = 0;
            NewTown.TownIRON_perHour = 0;
            NewTown.TownMeat_perHour = 0;
            NewTown.TownWOOD_perHour = 0;
            NewTown.TownWHEAT_perHour = 0;
            NewTown.LastUpdated = DateTime.Now;
            
            NewTown.Coordinate_X = 0;
            NewTown.Coordinate_Y = 0;
            NewTown.User = Player;
            #endregion
        }
    }
}
