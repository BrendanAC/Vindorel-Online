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
        public async Task<IActionResult> Index()
        {
            var Player = await _userManager.FindByIdAsync(User.GetUserId());
           var Set =  _context.UserGameSettings.LastOrDefault(x => x.UserId == Player.Id);
           

            if(Set.Race == null || Set.Job == null)
            {

                return View("Starter");

            }
            else
            {
                return View(Player);
            }

        }
        public async Task<IActionResult> Starter(UserGameSettings Starter)
        {
            var Player = await _userManager.FindByIdAsync(User.GetUserId());
            var Set = await _context.UserGameSettings.LastOrDefaultAsync(x => x.UserId == Player.Id);
            var GameEngine = new CreateNewTown();

            Set.Job = Starter.Job;
            Set.Race = Starter.Race;

            GameEngine.CreateTown(Player, Set);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // GET: Game/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Account account = await _context.Account.SingleAsync(m => m.Id == id);
            if (account == null)
            {
                return HttpNotFound();
            }

            return View(account);
        }

 








        // GET: Game/Delete/5



    }
}
