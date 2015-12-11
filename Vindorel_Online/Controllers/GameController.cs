using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vindorel_Online.Models;
namespace Vindorel_Online.Controllers
{
    [Authorize(Roles = "admin")]
    public class GameController : Controller
    {
        private vindorelEntities db = new vindorelEntities();

        // GET: Game
        public ActionResult FirstLogin()
        {
            
            return View();
        }
    }
}