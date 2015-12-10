using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vindorel_Online.Models;

namespace Vindorel_Online.Controllers
{
    public class VindorelController : Controller
    {
        
        // GET: Vindorel
        public ActionResult Index()
        {
            
            return View();
        }
        // GET: Vindorel/Create
        public ActionResult Create()
        {

            
            return View(new Players());
        }
        // POST: Vindorel/Create
        [HttpPost]
        public ActionResult Create(Players newuser)
        {
            try
            {
                var db = new vindorelEntities();
                newuser.Password = SHA256.Encode(newuser.Password);
                newuser.HeroName = "Your Hero name";
                newuser.Gold = 5;
                newuser.TechPoint = 0;
                newuser.ExpPoint = 0;

                db.Players.Add(newuser);       
                db.SaveChanges();

               
                ViewBag.Message = "Successfully Registration Done";



                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                
                return View("Error");
            }
        
        }




    }
}
