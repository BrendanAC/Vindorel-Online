using Microsoft.Data.Entity;
using OnlineVindorel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVindorel.GameEngine
{
    public class UpgradeSystem
    {
        private readonly VindorelDbContext _context;
        private TownBuildings Buildings;
        private Account Player;
        private UserGameSettings Settings;
        private TownPopulations Populations;
        private Towns Town;
        public virtual ICollection<UpgradeModel> Upgrades{get; set;}
        public int UpgradeIndex { get; set; }


        public UpgradeSystem() { }
        public UpgradeSystem(VindorelDbContext context,Account player)
        {
            _context = context;         
            Upgrades = new List<UpgradeModel>();
            Player = player;
        }
        public async void SelectedUpgrade(UpgradeModel SelectedBuilding)
        {
            Town = _context.Towns.LastOrDefault(x => x.UserId == Player.Id);
            Settings = _context.UserGameSettings.LastOrDefault(x => x.UserId == Player.Id);
            Populations = _context.Population.LastOrDefault(x => x.TownId == Town.TownId);
            #region SelectBuild
            switch(SelectedBuilding.index)
            {
                case 0:
                    Buildings.TownCenter++;
                    break;
                case 1:
                    Buildings.CityWall++;
                    break;
                case 2:
                    Buildings.TechnologyCamp++;
                    break;
                case 3:
                    Buildings.TradeHouse++;
                    break;
                case 4:
                    Buildings.Warehouse++;
                    break;
                case 5:
                    Buildings.Temple++;
                    break;
                case 6:
                    Buildings.Barracks++;
                    break;
                case 7:
                    Buildings.Farm++;
                    break;
                case 8:
                    Buildings.MeatCamp++;
                    break;
                case 9:
                    Buildings.Mine++;
                    break;
                case 10:
                    Buildings.WoodCutterHut++;
                    break;
                case 11:
                    Buildings.TaxHouse++;
                    break;
            }
            #endregion
            #region Upgraded
            Settings.Point_Culture += SelectedBuilding.Gain_Culture;
            Settings.Point_Economy += SelectedBuilding.Gain_Economy;
            Settings.Point_Military += SelectedBuilding.Gain_Military;
            Settings.Point_Exp += SelectedBuilding.Gain_Exp;
            Settings.Point_Karma += SelectedBuilding.Gain_Karma;
            Settings.NaturalAttack += SelectedBuilding.Gain_NaturalAttack;
            Settings.NaturalDef += SelectedBuilding.Gain_NaturalDef;
            Town.TownWOOD_perHour = SelectedBuilding.Gain_TownWOOD_perHour;
            Town.TownGOLD_perHour = SelectedBuilding.Gain_TownGOLD_perHour;
            Town.TownIRON_perHour = SelectedBuilding.Gain_TownIRON_perHour;
            Town.TownMeat_perHour = SelectedBuilding.Gain_TownMeat_perHour;
            Town.TownWHEAT_perHour += SelectedBuilding.Gain_TownWHEAT_perHour;
            Populations.TraderPop += SelectedBuilding.Gain_TraderPop;
            Populations.AggressivePop += SelectedBuilding.Gain_AgressivePop;
            Populations.CulturalPop += SelectedBuilding.Gain_CulturalPop;
            #endregion
            await _context.SaveChangesAsync();

        }
        public ICollection<UpgradeModel> BuildingPage(Towns Town)
        {
            VindorelDbContext _context = new VindorelDbContext();
            ICollection<UpgradeModel> Upgrades = new List<UpgradeModel>();
            Buildings = _context.Buildings.LastOrDefault(x => x.TownID == Town.TownId);
            Settings = _context.UserGameSettings.LastOrDefault(x => x.UserId == Town.UserId);
            Populations = _context.Population.LastOrDefault(x => x.TownId == Town.TownId);
            this.Upgrades = Upgrades;
           this.Upgrades.Add(UpgradeTownCenter(Buildings.TownCenter));
           this.Upgrades.Add(UpgradeCityWall(Buildings.CityWall));
           this.Upgrades.Add(UpgradeTechnologyCamp(Buildings.TechnologyCamp));
           this.Upgrades.Add(UpgradeTradeHouse(Buildings.TradeHouse));
           this.Upgrades.Add(UpgradeWareHouse(Buildings.Warehouse));
           this.Upgrades.Add(UpgradeTemple(Buildings.Temple));
           this.Upgrades.Add(UpgradeBarracks(Buildings.Barracks));
           this.Upgrades.Add(UpgradeFarm(Buildings.Farm));
           this.Upgrades.Add(UpgradeMeatCamp(Buildings.MeatCamp));
           this.Upgrades.Add(UpgradeMine(Buildings.Mine));
           this.Upgrades.Add(UpgradeWoodCutterHut(Buildings.WoodCutterHut));
           this.Upgrades.Add(UpgradeTaxHouse(Buildings.TaxHouse));
    
            return Upgrades;
        }

        private UpgradeModel UpgradeTownCenter(int Level)
        {
            var upgradeModel = new UpgradeModel();
            upgradeModel.index = 0;
            upgradeModel.Cost_Iron = 150;
            upgradeModel.Cost_Wheat = 150;
            upgradeModel.Cost_Meat = 150;
            upgradeModel.Cost_Wood = 150;
            upgradeModel.Gain_Exp = 3 * Level + Settings.Point_Karma * 2 + Settings.CultureRate * 10;
            upgradeModel.Gain_Culture = 10 * Level;
            upgradeModel.Gain_Karma = 0;
            upgradeModel.Gain_Economy = (Populations.TraderPop * Level) + 15 / 2 * Settings.TraderRate;
            upgradeModel.Gain_Military = 3*Level;
            upgradeModel.Gain_CulturalPop = 2 * Level;
            upgradeModel.Gain_AgressivePop = 4*Level;
            upgradeModel.Gain_TraderPop = 6*Level;
            upgradeModel.Gain_NaturalAttack = 4*Level;
            upgradeModel.Gain_NaturalDef =2*Level;
            upgradeModel.Gain_TownGOLD_perHour = 0;
            upgradeModel.Gain_TownIRON_perHour = 0;
            upgradeModel.Gain_TownMeat_perHour = 0;
            upgradeModel.Gain_TownWHEAT_perHour = 0;
            upgradeModel.Gain_TownWOOD_perHour = 0;
            upgradeModel.Buildtime = Level * 540;
             return upgradeModel;
         }
        private UpgradeModel UpgradeCityWall(int Level)
        {
            var upgradeModel = new UpgradeModel();
            upgradeModel.index = 1;

            upgradeModel.Cost_Iron = 150;
            upgradeModel.Cost_Wheat = 150;
            upgradeModel.Cost_Meat = 150;
            upgradeModel.Cost_Wood = 150;
            upgradeModel.Gain_Exp = 3 * Level + Settings.Point_Karma * 2 + Settings.CultureRate * 10;
            upgradeModel.Gain_Culture = 10 * Level;
            upgradeModel.Gain_Karma = 0;
            upgradeModel.Gain_Economy = (Populations.TraderPop * Level) + 15 / 2 * Settings.TraderRate;
            upgradeModel.Gain_Military = 3 * Level;
            upgradeModel.Gain_AgressivePop = 4 * Level;
            upgradeModel.Gain_TraderPop = 6 * Level;
            upgradeModel.Gain_CulturalPop = 2 * Level;
            upgradeModel.Gain_NaturalAttack = 4 * Level;
            upgradeModel.Gain_NaturalDef = 2 * Level;
            upgradeModel.Gain_TownGOLD_perHour = 0;
            upgradeModel.Gain_TownIRON_perHour = 0;
            upgradeModel.Gain_TownMeat_perHour = 0;
            upgradeModel.Gain_TownWHEAT_perHour = 0;
            upgradeModel.Gain_TownWOOD_perHour = 0;
            upgradeModel.Buildtime = Level * 2;
            return upgradeModel;
        }
        private UpgradeModel UpgradeTechnologyCamp(int Level)
        {
            var upgradeModel = new UpgradeModel();
            upgradeModel.index = 2;

            upgradeModel.Cost_Iron = 150;
            upgradeModel.Cost_Wheat = 150;
            upgradeModel.Cost_Meat = 150;
            upgradeModel.Cost_Wood = 150;
            upgradeModel.Gain_Exp = 3 * Level + Settings.Point_Karma * 2 + Settings.CultureRate * 10;
            upgradeModel.Gain_Culture = 10 * Level;
            upgradeModel.Gain_Karma = 0;
            upgradeModel.Gain_Economy = (Populations.TraderPop * Level) + 15 / 2 * Settings.TraderRate;
            upgradeModel.Gain_Military = 3 * Level;
            upgradeModel.Gain_AgressivePop = 4 * Level;
            upgradeModel.Gain_TraderPop = 6 * Level;
            upgradeModel.Gain_CulturalPop = 2 * Level;
            upgradeModel.Gain_NaturalAttack = 4 * Level;
            upgradeModel.Gain_NaturalDef = 2 * Level;
            upgradeModel.Gain_TownGOLD_perHour = 0;
            upgradeModel.Gain_TownIRON_perHour = 0;
            upgradeModel.Gain_TownMeat_perHour = 0;
            upgradeModel.Gain_TownWHEAT_perHour = 0;
            upgradeModel.Gain_TownWOOD_perHour = 0;
            upgradeModel.Buildtime = Level * 2;
            return upgradeModel;
        }
        private UpgradeModel UpgradeTradeHouse(int Level)
        {
            var upgradeModel = new UpgradeModel();
            upgradeModel.index =3;

            upgradeModel.Cost_Iron = 150;
            upgradeModel.Cost_Wheat = 150;
            upgradeModel.Cost_Meat = 150;
            upgradeModel.Cost_Wood = 150;
            upgradeModel.Gain_Exp = 3 * Level + Settings.Point_Karma * 2 + Settings.CultureRate * 10;
            upgradeModel.Gain_Culture = 10 * Level;
            upgradeModel.Gain_Karma = 0;
            upgradeModel.Gain_Economy = (Populations.TraderPop * Level) + 15 / 2 * Settings.TraderRate;
            upgradeModel.Gain_Military = 3*Level;
            upgradeModel.Gain_AgressivePop = 4*Level;
            upgradeModel.Gain_TraderPop = 6*Level;

            upgradeModel.Gain_CulturalPop = 2 * Level;
            upgradeModel.Gain_NaturalAttack = 4*Level;
            upgradeModel.Gain_NaturalDef =2*Level;
            upgradeModel.Gain_TownGOLD_perHour = 0;
            upgradeModel.Gain_TownIRON_perHour = 0;
            upgradeModel.Gain_TownMeat_perHour = 0;
            upgradeModel.Gain_TownWHEAT_perHour = 0;
            upgradeModel.Gain_TownWOOD_perHour = 0;
            upgradeModel.Buildtime = (Level+1) * 2;
            return upgradeModel;
        }
        private UpgradeModel UpgradeWareHouse(int Level)
        {
            var upgradeModel = new UpgradeModel();
            upgradeModel.index = 4;

            upgradeModel.Cost_Iron = 150;
            upgradeModel.Cost_Wheat = 150;
            upgradeModel.Cost_Meat = 150;
            upgradeModel.Cost_Wood = 150;
            upgradeModel.Gain_Exp = 3 * Level + Settings.Point_Karma * 2 + Settings.CultureRate * 10;
            upgradeModel.Gain_Culture = 10 * Level;
            upgradeModel.Gain_Karma = 0;
            upgradeModel.Gain_Economy = (Populations.TraderPop * Level) + 15 / 2 * Settings.TraderRate;
            upgradeModel.Gain_Military = 3 * Level;
            upgradeModel.Gain_AgressivePop = 4 * Level;
            upgradeModel.Gain_TraderPop = 6 * Level;
            upgradeModel.Gain_CulturalPop = 2 * Level;
            upgradeModel.Gain_NaturalAttack = 4 * Level;
            upgradeModel.Gain_NaturalDef = 2 * Level;
            upgradeModel.Gain_TownGOLD_perHour = 0;
            upgradeModel.Gain_TownIRON_perHour = 0;
            upgradeModel.Gain_TownMeat_perHour = 0;
            upgradeModel.Gain_TownWHEAT_perHour = 0;
            upgradeModel.Gain_TownWOOD_perHour = 0;
            upgradeModel.Buildtime = Level * 2;
            return upgradeModel;
        }
        private UpgradeModel UpgradeTemple(int Level)
        {
            var upgradeModel = new UpgradeModel();
            upgradeModel.index = 5;

            upgradeModel.Cost_Iron = 150;
            upgradeModel.Cost_Wheat = 150;
            upgradeModel.Cost_Meat = 150;
            upgradeModel.Cost_Wood = 150;
            upgradeModel.Gain_Exp = 3 * Level + Settings.Point_Karma * 2 + Settings.CultureRate * 10;
            upgradeModel.Gain_Culture = 10 * Level;
            upgradeModel.Gain_Karma = 0;
            upgradeModel.Gain_Economy = (Populations.TraderPop * Level) + 15 / 2 * Settings.TraderRate;
            upgradeModel.Gain_Military = 3 * Level;
            upgradeModel.Gain_AgressivePop = 4 * Level;
            upgradeModel.Gain_TraderPop = 6 * Level;
            upgradeModel.Gain_CulturalPop = 2 * Level;
            upgradeModel.Gain_NaturalAttack = 4 * Level;
            upgradeModel.Gain_NaturalDef = 2 * Level;
            upgradeModel.Gain_TownGOLD_perHour = 0;
            upgradeModel.Gain_TownIRON_perHour = 0;
            upgradeModel.Gain_TownMeat_perHour = 0;
            upgradeModel.Gain_TownWHEAT_perHour = 0;
            upgradeModel.Gain_TownWOOD_perHour = 0;
            upgradeModel.Buildtime = Level * 2;
            return upgradeModel;
        }
        private UpgradeModel UpgradeBarracks(int Level)
        {
            var upgradeModel = new UpgradeModel();
            upgradeModel.index = 6;

            upgradeModel.Cost_Iron = 150;
            upgradeModel.Cost_Wheat = 150;
            upgradeModel.Cost_Meat = 150;
            upgradeModel.Cost_Wood = 150;
            upgradeModel.Gain_Exp = 3 * Level + Settings.Point_Karma * 2 + Settings.CultureRate * 10;
            upgradeModel.Gain_Culture = 10 * Level;
            upgradeModel.Gain_Karma = 0;
            upgradeModel.Gain_Economy = (Populations.TraderPop * Level) + 15 / 2 * Settings.TraderRate;
            upgradeModel.Gain_Military = 3 * Level;
            upgradeModel.Gain_AgressivePop = 4 * Level;
            upgradeModel.Gain_TraderPop = 6 * Level;
            upgradeModel.Gain_CulturalPop = 2 * Level;
            upgradeModel.Gain_NaturalAttack = 4 * Level;
            upgradeModel.Gain_NaturalDef = 2 * Level;
            upgradeModel.Gain_TownGOLD_perHour = 0;
            upgradeModel.Gain_TownIRON_perHour = 0;
            upgradeModel.Gain_TownMeat_perHour = 0;
            upgradeModel.Gain_TownWHEAT_perHour = 0;
            upgradeModel.Gain_TownWOOD_perHour = 0;
            upgradeModel.Buildtime = Level * 2;
            return upgradeModel;
        }
        private UpgradeModel UpgradeFarm(int Level)
        {
            var upgradeModel = new UpgradeModel();
            upgradeModel.index = 7;

            upgradeModel.Cost_Iron = 150;
            upgradeModel.Cost_Wheat = 150;
            upgradeModel.Cost_Meat = 150;
            upgradeModel.Cost_Wood = 150;
            upgradeModel.Gain_Exp = 3 * Level + Settings.Point_Karma * 2 + Settings.CultureRate * 10;
            upgradeModel.Gain_Culture = 10 * Level;
            upgradeModel.Gain_Karma = 0;
            upgradeModel.Gain_Economy = (Populations.TraderPop * Level) + 15 / 2 * Settings.TraderRate;
            upgradeModel.Gain_Military = 3 * Level;
            upgradeModel.Gain_AgressivePop = 4 * Level;
            upgradeModel.Gain_TraderPop = 6 * Level;
            upgradeModel.Gain_CulturalPop = 2 * Level;
            upgradeModel.Gain_NaturalAttack = 4 * Level;
            upgradeModel.Gain_NaturalDef = 2 * Level;
            upgradeModel.Gain_TownGOLD_perHour = 0;
            upgradeModel.Gain_TownIRON_perHour = 0;
            upgradeModel.Gain_TownMeat_perHour = 0;
            upgradeModel.Gain_TownWHEAT_perHour = 12*(Level+1);
            upgradeModel.Gain_TownWOOD_perHour = 0;
            upgradeModel.Buildtime = Level * 2;
            return upgradeModel;
        }
        private UpgradeModel UpgradeMeatCamp(int Level)
        {
            var upgradeModel = new UpgradeModel();
            upgradeModel.index = 8;

            upgradeModel.Cost_Iron = 150;
            upgradeModel.Cost_Wheat = 150;
            upgradeModel.Cost_Meat = 150;
            upgradeModel.Cost_Wood = 150;
            upgradeModel.Gain_Exp = 3 * Level + Settings.Point_Karma * 2 + Settings.CultureRate * 10;
            upgradeModel.Gain_Culture = 10 * Level;
            upgradeModel.Gain_Karma = 0;
            upgradeModel.Gain_Economy = (Populations.TraderPop * Level) + 15 / 2 * Settings.TraderRate;
            upgradeModel.Gain_Military = 3*Level;
            upgradeModel.Gain_AgressivePop = 4*Level;
            upgradeModel.Gain_TraderPop = 6*Level;
            upgradeModel.Gain_CulturalPop = 2 * Level;
            upgradeModel.Gain_NaturalAttack = 4*Level;
            upgradeModel.Gain_NaturalDef =2*Level;
            upgradeModel.Gain_TownGOLD_perHour = 0;
            upgradeModel.Gain_TownIRON_perHour = 0;
            upgradeModel.Gain_TownMeat_perHour = 16*(Level+1);
            upgradeModel.Gain_TownWHEAT_perHour = 0;
            upgradeModel.Gain_TownWOOD_perHour = 0;
            upgradeModel.Buildtime = Level * 2;
            return upgradeModel;
        }
        private UpgradeModel UpgradeMine(int Level)
        {
            var upgradeModel = new UpgradeModel();
            upgradeModel.index = 9;

            upgradeModel.Cost_Iron = 150;
            upgradeModel.Cost_Wheat = 150;
            upgradeModel.Cost_Meat = 150;
            upgradeModel.Cost_Wood = 150;
            upgradeModel.Gain_Exp = 3 * Level + Settings.Point_Karma * 2 + Settings.CultureRate * 10;
            upgradeModel.Gain_Culture = 10 * Level;
            upgradeModel.Gain_Karma = 0;
            upgradeModel.Gain_Economy = (Populations.TraderPop * Level) + 15 / 2 * Settings.TraderRate;
            upgradeModel.Gain_Military = 3 * Level;
            upgradeModel.Gain_AgressivePop = 4 * Level;
            upgradeModel.Gain_CulturalPop = 2 * Level;
            upgradeModel.Gain_TraderPop = 6 * Level;
            upgradeModel.Gain_NaturalAttack = 4 * Level;
            upgradeModel.Gain_NaturalDef = 2 * Level;
            upgradeModel.Gain_TownGOLD_perHour = 0;
            upgradeModel.Gain_TownIRON_perHour = 60*(Level+1);
            upgradeModel.Gain_TownMeat_perHour = 0;
            upgradeModel.Gain_TownWHEAT_perHour = 0;
            upgradeModel.Gain_TownWOOD_perHour = 0;
            upgradeModel.Buildtime = Level * 2;
            return upgradeModel;
        }
        private UpgradeModel UpgradeWoodCutterHut(int Level)
        {
            var upgradeModel = new UpgradeModel();
            upgradeModel.index = 10;

            upgradeModel.Cost_Iron = 150;
            upgradeModel.Cost_Wheat = 150;
            upgradeModel.Cost_Meat = 150;
            upgradeModel.Cost_Wood = 150;
            upgradeModel.Gain_Exp = 3 * Level + Settings.Point_Karma * 2 + Settings.CultureRate * 10;
            upgradeModel.Gain_Culture = 10 * Level;
            upgradeModel.Gain_Karma = 0;
            upgradeModel.Gain_Economy = (Populations.TraderPop * Level) + 15 / 2 * Settings.TraderRate;
            upgradeModel.Gain_Military = 3 * Level;
            upgradeModel.Gain_AgressivePop = 4 * Level;
            upgradeModel.Gain_TraderPop = 6 * Level;
            upgradeModel.Gain_CulturalPop = 2 * Level;
            upgradeModel.Gain_NaturalAttack = 4 * Level;
            upgradeModel.Gain_NaturalDef = 2 * Level;
            upgradeModel.Gain_TownGOLD_perHour = 0;
            upgradeModel.Gain_TownIRON_perHour = 0;
            upgradeModel.Gain_TownMeat_perHour = 0;
            upgradeModel.Gain_TownWHEAT_perHour = 0;
            upgradeModel.Gain_TownWOOD_perHour = 50*(Level+1);
            upgradeModel.Buildtime = Level * 2;
            return upgradeModel;
        }
        private UpgradeModel UpgradeTaxHouse(int Level)
        {
            var upgradeModel = new UpgradeModel();
            upgradeModel.index = 11;

            upgradeModel.Cost_Iron = 150;
            upgradeModel.Cost_Wheat = 150;
            upgradeModel.Cost_Meat = 150;
            upgradeModel.Cost_Wood = 150;
            upgradeModel.Gain_Exp = 3 * Level + Settings.Point_Karma * 2 + Settings.CultureRate * 10;
            upgradeModel.Gain_Culture = 10 * Level;
            upgradeModel.Gain_Karma = 0;
            upgradeModel.Gain_Economy = (Populations.TraderPop * Level) + 15 / 2 * Settings.TraderRate;
            upgradeModel.Gain_Military = 3 * Level;
            upgradeModel.Gain_AgressivePop = 4 * Level;
            upgradeModel.Gain_CulturalPop = 2 * Level;
            upgradeModel.Gain_TraderPop = 6 * Level;
            upgradeModel.Gain_NaturalAttack = 4 * Level;
            upgradeModel.Gain_NaturalDef = 2 * Level;
            upgradeModel.Gain_TownGOLD_perHour = 5+Level*(Settings.TraderRate)+Populations.TraderPop*Level;
            upgradeModel.Gain_TownIRON_perHour = 0;
            upgradeModel.Gain_TownMeat_perHour = 0;
            upgradeModel.Gain_TownWHEAT_perHour = 0;
            upgradeModel.Gain_TownWOOD_perHour = 0;
            upgradeModel.Buildtime = Level * 2;
            return upgradeModel;
        }
    }

}
