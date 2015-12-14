using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using VindorelOnline.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace VindorelOnline.Controllers
{
    public class RegisterController : Controller
    {
        UCreator BuildUser = new UCreator();
        private vindorelContext _context;
        public RegisterController(vindorelContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserAccounts User,Towns Town)
        {
            if (ModelState.IsValid)
            {
                BuildUser.DefaultSettings(User,Town);
                _context.UserAccounts.Add(User);
                _context.SaveChanges();
                return RedirectToAction("Register");

            }

            return View(User);
        }
    }
}
