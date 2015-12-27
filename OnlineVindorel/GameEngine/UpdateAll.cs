using OnlineVindorel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
namespace OnlineVindorel.GameEngine
{
    public class UpdateAll
    {
        public Towns UpdateResource(Towns Town)
        {
            VindorelDbContext _context = new VindorelDbContext(); 
            if(DateTime.Now.Ticks-Town.LastUpdated.Ticks > 100 )
            {
                Town.TownGOLD += Town.TownGOLD_perHour;
                Town.TownIRON += Town.TownIRON_perHour;
                Town.TownWHEAT += Town.TownWHEAT_perHour;
                Town.TownWOOD += Town.TownWOOD_perHour;
                Town.TownMEAT += Town.TownMeat_perHour;
                Town.LastUpdated = DateTime.Now;
            }
            _context.SaveChanges();
            return Town;
        }
        public void UpdateBuildings(Towns Town)
        {
            ICollection<UpgradeModel> Render = new List<UpgradeModel>();
            VindorelDbContext _context = new VindorelDbContext();
            var BuildQUEUE = _context.upgradeQueue.LastOrDefault(x => x.TownID == Town.TownId);
            if (BuildQUEUE == null)
            {

            }
            else
            {
                var engine = new UpgradeSystem();
                if (BuildQUEUE.ProductionTime.Ticks < DateTime.Now.Ticks)
                {
                    var indexer = engine.BuildingPage(Town);
                    var Building = indexer.LastOrDefault(x => x.index == BuildQUEUE.BuildingINDEX);
                    var TownBuildings = _context.Buildings.LastOrDefault(x => x.TownID == Town.TownId);
                    var Settings = _context.UserGameSettings.LastOrDefault(x => x.UserId == Town.UserId);
                    var Populations = _context.Population.LastOrDefault(x => x.TownId == Town.TownId);

                    #region SelectBuild
                    switch (Building.index)
                    {
                        case 0:
                            TownBuildings.TownCenter++;
                            break;
                        case 1:
                            TownBuildings.CityWall++;
                            break;
                        case 2:
                            TownBuildings.TechnologyCamp++;
                            break;
                        case 3:
                            TownBuildings.TradeHouse++;
                            break;
                        case 4:
                            TownBuildings.Warehouse++;
                            break;
                        case 5:
                            TownBuildings.Temple++;
                            break;
                        case 6:
                            TownBuildings.Barracks++;
                            break;
                        case 7:
                            TownBuildings.Farm++;
                            break;
                        case 8:
                            TownBuildings.MeatCamp++;
                            break;
                        case 9:
                            TownBuildings.Mine++;
                            break;
                        case 10:
                            TownBuildings.WoodCutterHut++;
                            break;
                        case 11:
                            TownBuildings.TaxHouse++;
                            break;
                    }
                    #endregion
                    #region Upgraded
                    Settings.Point_Culture += Building.Gain_Culture;
                    Settings.Point_Economy += Building.Gain_Economy;
                    Settings.Point_Military += Building.Gain_Military;
                    Settings.Point_Exp += Building.Gain_Exp;
                    Settings.Point_Karma += Building.Gain_Karma;
                    Settings.NaturalAttack += Building.Gain_NaturalAttack;
                    Settings.NaturalDef += Building.Gain_NaturalDef;
                    Town.TownWOOD_perHour = Building.Gain_TownWOOD_perHour;
                    Town.TownGOLD_perHour = Building.Gain_TownGOLD_perHour;
                    Town.TownIRON_perHour = Building.Gain_TownIRON_perHour;
                    Town.TownMeat_perHour = Building.Gain_TownMeat_perHour;
                    Town.TownWHEAT_perHour += Building.Gain_TownWHEAT_perHour;
                    Populations.TraderPop += Building.Gain_TraderPop;
                    Populations.AggressivePop += Building.Gain_AgressivePop;
                    Populations.CulturalPop += Building.Gain_CulturalPop;
                    _context.upgradeQueue.Remove(BuildQUEUE);
                    _context.SaveChanges();
                    #endregion
                }
            }
            
        }

    }
}
