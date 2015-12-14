using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VindorelOnline.Models
{
    public class UCreator
    {
        private TownCreator settings = new TownCreator();
        public UCreator()
        {
            
        }
        public void DefaultSettings(UserAccounts User,Towns Town)
        {
            User.RegisterDate = DateTime.Now;
            User.isAdmin = false;
            User.isConfirmed = false;
            RaceLogic(User);
            settings.StarterBuildings(Town);
            settings.StarterPopulations(Town);
            settings.StarterResources(Town);
            User.Towns.Add(Town);
            JobLogic(User, Town);
        }
        public void RaceLogic(UserAccounts User)
        {
            if(User.UserRace == "Orc")
            {
                User.SpeedTrainMultiplier = 3.6;
                User.SpeedBuildMultiplier = 1.2;
                User.SpeedTradeMultiplier = 0.7;
            }
            else
            {
                User.SpeedTrainMultiplier = 2.2;
                User.SpeedBuildMultiplier = 2.1;
                User.SpeedTradeMultiplier = 1.3;
            }
        }
        public void JobLogic(UserAccounts User,Towns UserTown)
        {
            if (User.UserJob == "Farmer")
            {
                UserTown.TownFOOD_perHour += UserTown.TownFOOD_perHour % 2;
            }
            else if (User.UserJob == "Miner")
            {
                UserTown.TownIRON_perHour += UserTown.TownIRON_perHour % 2;
            }
            else if (User.UserJob == "Warrior")
            {
                User.SpeedTrainMultiplier += 2.8;
            }
            else if (User.UserJob == "Monk")
            {
                UserTown.PointCulture += 50;
            }
            else if (User.UserJob == "Builder")
            {
                UserTown.TownWOOD_perHour += UserTown.TownWOOD_perHour % 2;
            }
            else if (User.UserJob == "Engineer")
            {
                User.SpeedBuildMultiplier += 2.4;
            }
        }
    }
}
