using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using OnlineVindorel.Models;
using Microsoft.AspNet.Identity;
using OnlineVindorel.ViewModels.Account;
using System.Security.Claims;
using System.Collections.Generic;
using OnlineVindorel.GameEngine;
using System;
using Microsoft.AspNet.Authorization;

namespace OnlineVindorel.Controllers
{
    public class GameController : Controller
    {
        private readonly UserManager<Account> _userManager;
        private VindorelDbContext _context;

        public GameController(VindorelDbContext context,UserManager<Account> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Game
        [Authorize(Roles = "Player")]
        public async Task<IActionResult> Index()
        {
           var Player = await _userManager.FindByIdAsync(User.GetUserId());
           var Set =  _context.UserGameSettings.LastOrDefault(x => x.UserId == Player.Id);
            var count = _context.Towns.LastOrDefault(x => x.UserId == Player.Id);
            if(Player.Towns.Count > 0)
            {
                return View(Player);
            }
            else
            {
                var GameEngine = new CreateNewTown();
                GameEngine.CreateTown(Player, Set);
                await _context.SaveChangesAsync();
                return View(Player);
            }


            
        }
        [Authorize(Roles = "Player")]
        public async Task<IActionResult> Starter(UserGameSettings Starter)
        {
            var Player = await _userManager.FindByIdAsync(User.GetUserId());
            var Set = await _context.UserGameSettings.LastOrDefaultAsync(x => x.UserId == Player.Id);
            var GameEngine = new CreateNewTown();
            GameEngine.CreateTown(Player, Set);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Player")]
        public async Task<IActionResult> Buildings()
        {
            var Town = await _context.Towns.LastOrDefaultAsync(x => x.UserId == User.GetUserId());
            var Player = await _userManager.FindByIdAsync(User.GetUserId());
            var Set = await _context.UserGameSettings.LastOrDefaultAsync(x => x.UserId == User.GetUserId());
            UpgradeSystem model = new UpgradeSystem();
            UpdateAll Engine = new UpdateAll();

            Engine.UpdateResource(Town);
            Engine.UpdateBuildings(Town);
            model.BuildingPage(Town);

            await _context.SaveChangesAsync();
                return View(model);

        }

        [HttpPost]
        [Authorize(Roles = "Player")]
        public async Task<IActionResult> Upgrade(UpgradeSystem selected)
        {
            UpdateAll upengine = new UpdateAll();
            var Town = await _context.Towns.LastOrDefaultAsync(x => x.UserId == User.GetUserId());
            var Player = await _userManager.FindByIdAsync(User.GetUserId());
            UpgradeSystem buildings= new UpgradeSystem(_context, Player);
            buildings.BuildingPage(Town);
            var production = buildings.Upgrades.ElementAt(selected.UpgradeIndex);
            upengine.UpdateResource(Town);
            upengine.UpdateBuildings(Town);
            await _context.SaveChangesAsync();
            if (ModelState.IsValid && production.Cost_Iron <= Town.TownIRON
                && production.Cost_Meat <= Town.TownMEAT && production.Cost_Wheat 
                <= Town.TownWHEAT && production.Cost_Wood <= Town.TownWOOD )
            {
                Town.TownWHEAT = Town.TownWHEAT - production.Cost_Wheat;
                Town.TownMEAT = Town.TownMEAT - production.Cost_Meat;
                Town.TownIRON = Town.TownIRON - production.Cost_Iron;
                Town.TownWOOD = Town.TownWOOD - production.Cost_Wood;

                UpgradeSystem Engine = new UpgradeSystem(_context, Player);
                UpgradeQueue NewUpgrade = new UpgradeQueue();

                NewUpgrade.BuildingINDEX = production.index;
                NewUpgrade.TownID = Town.TownId;
                
                NewUpgrade.ProductionTime = DateTime.Now.AddSeconds(production.Buildtime);

                _context.upgradeQueue.Add(NewUpgrade);
                
                await _context.SaveChangesAsync();
                return View("Buildings",buildings);
            }
            else
            {
                await _context.SaveChangesAsync();
                ModelState.AddModelError("", "Not Enough Resources");
                return View("Buildings", buildings);
            }
        }
        [Authorize(Roles = "Player")]
        public async Task<IActionResult> MyAccount()
        {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NameUpdate(NameViewModel newname)
        {

            var Town = await _context.Towns.LastOrDefaultAsync(x => x.UserId == User.GetUserId());

            Town.TownName = newname.Name;
            await _context.SaveChangesAsync();
            return View("MyAccount");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string name)
        {

            var acc = await _userManager.FindByNameAsync(name);
            await _userManager.DeleteAsync(acc);
            return View();
        }
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminPanel()
        {
            return View();
        }

    }
}
