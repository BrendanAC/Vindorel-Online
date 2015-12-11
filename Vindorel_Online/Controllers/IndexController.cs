using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Vindorel_Online.Models;

namespace Vindorel_Online.Controllers
{
    public class IndexController : Controller
    {
        private vindorelEntities db = new vindorelEntities();
        // GET: Vindorel
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(Players Player, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(Player.Login, Player.Password))
                {
                    FormsAuthentication.SetAuthCookie(Player.Login,true);
                    if (string.IsNullOrEmpty(returnUrl) || returnUrl.ToLower().Contains("login"))
                    {
                        returnUrl = Url.Action("Index", "Index");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }

            }
            else
            {

                ModelState.AddModelError("", "The Username and/or password is incorrect,Please try again");

            }

            return View(returnUrl, Player);
        }
        public bool IsValid(string Login, string Password)
        {
            string passwordHash = SHA256.Encode(Password);
            var data = from Player in db.Players
                       where Player.Login == Login && Player.Password == passwordHash
                       select new
                       {
                           Player.Id,
                           Player.Login,
                           Player.Password,
                           Player.Email,
                           Player.Access,
                           Player.Race,
                           Player.Job,
                           Player.ExpPoint,
                           Player.TechPoint,
                           Player.Gold,
                           Player.HeroName
                       };


            return data.Count() > 0;
        }

        // GET: Vindorel/Create
        public ActionResult Create()
        {


            return View(new Players());
        }
        // POST: Vindorel/Create
        [HttpPost]
        public RedirectToRouteResult Create(Players newuser)
        {
                newuser.Password = SHA256.Encode(newuser.Password);
                newuser.HeroName = "Your Hero name";
                newuser.Gold = 5;
                newuser.Access = false;
                newuser.TechPoint = 0;
                newuser.ExpPoint = 0;

                db.Players.Add(newuser);       
                db.SaveChanges();

                // TODO: Add insert logic here

                return RedirectToAction("Index");
        }




    }
}
