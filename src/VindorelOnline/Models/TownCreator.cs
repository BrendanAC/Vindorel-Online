using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VindorelOnline.Models
{
    public class TownCreator
    {
        private TownBuildings Buildings = new TownBuildings();
        private TownPopulations Population = new TownPopulations();
        public void StarterBuildings(Towns Town)
        {
            Buildings.Town = Town;
            Buildings.TownCenter = 1;
            Buildings.HutHouse = 0;
            Buildings.WoodHouse = 0;
            Buildings.TechnologyCamp = 0;
            Buildings.BattleCamp = 0;
            Buildings.IronMine = 0;
            Buildings.SlaveMine = 0;
            Buildings.WoodCutterHut = 0;
            Buildings.WoodCutterCamp = 0;
            Buildings.Farm = 0;
            Buildings.MeatCamp = 0;
            Buildings.TradeHouse = 0;
            Buildings.CityWall = 0;
            Town.TownBuildings.Add(Buildings);  
        }
        public void StarterResources(Towns Town)
        {
            Town.TownFOOD = 20;
            Town.TownWOOD = 20;
            Town.TownIRON = 20;
            Town.MaxFOOD = 10000;
            Town.MaxIRON = 10000;
            Town.MaxWOOD = 10000;
            Town.PointCulture = 5;
            Town.PointExp = 5;
            Town.PointKarma = 0;   
            Town.TownName = "Town Name";
        }
        public void StarterPopulations(Towns Town)
        {
            Population.Town = Town;
            Population.AggressivePop = 4;
            Population.CulturalPop = 4;
            Population.TraderPop = 4;
            Population.Population = Population.AggressivePop + Population.CulturalPop + Population.TraderPop;
            Town.TownPopulations.Add(Population);
        }
    }
}
