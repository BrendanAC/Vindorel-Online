using Microsoft.Data.Entity.Storage;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vindorel_Online_Game.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<WorldContext>();
            if (serviceProvider.GetService<IRelationalDatabaseCreator>().Exists())
            {
                if (!context.UserAccounts.Any())
                {
                    var halpar = context.UserAccounts.Add(
                        new UserAccount
                        {
                            LoginMail = "gurcaglarogulcan@gmail.com",
                            LoginName = "canturk",
                            LoginPassword = "12345",
                            isConfirmed = false,
                            UserRace = "Human",
                            UserJob = "Farmer",
                            isAdmin = false,
                            SpeedBuild = 1.56f,
                            SpeedTrain = 1.74f,
                            SpeedDiplomacy = 1.25f,

                        }).Entity;
                    var canturk96 = context.UserAccounts.Add(
                       new UserAccount
                       {
                           LoginMail = "can@gmail.com",
                           LoginName = "halpar",
                           LoginPassword = "12332445",
                           isConfirmed = false,
                           UserRace = "Human",
                           UserJob = "Warrior",
                           isAdmin = false,
                           SpeedBuild = 1.56f,
                           SpeedTrain = 1.74f,
                           SpeedDiplomacy = 1.25f,

                       }).Entity;

                    var kalamor = context.UserAccounts.Add(
                    new UserAccount
                    {
                        LoginMail = "caadfasan@gmail.com",
                        LoginName = "cihaddi",
                        LoginPassword = "adfasdfAFGA123412332445",
                        isConfirmed = false,
                        UserRace = "Human",
                        UserJob = "Warrior",
                        isAdmin = true,
                        SpeedBuild = 1.56f,
                        SpeedTrain = 1.74f,
                        SpeedDiplomacy = 1.25f,

                    }).Entity;

                    context.Towns.AddRange(
                       new Town()
                       {
                           TownName = "Yullar",
                           x = 1,
                           y = 5,
                           TownIron = 532,
                           TownFood = 1251,
                           TownWood = 11211,
                           TownGold = 153,
                           Level = 5

                       },
                       new Town()
                       {
                           TownName = "UfrdsYullar",
                           x = 1,
                           y = 5,
                           TownIron = 532,
                           TownFood = 1251,
                           TownWood = 11211,
                           TownGold = 153,
                           Level = 5

                       },
                       new Town()
                       {
                           TownName = "Yullhfdhar",
                           x = 1,
                           y = 5,
                           TownIron = 532,
                           TownFood = 1251,
                           TownWood = 11211,
                           TownGold = 153,
                           Level = 5

                       },
                       new Town()
                       {
                           TownName = "Yadaullar",
                           x = 1,
                           y = 5,
                           TownIron = 532,
                           TownFood = 1251,
                           TownWood = 11211,
                           TownGold = 153,
                           Level = 6
                       }
                     );
                    context.Savechanges();
                }
            }
        }
    }
}
           
  

    
