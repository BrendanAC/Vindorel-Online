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
        private vindorelEntities db = new vindorelEntities();
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
                newuser.Password = SHA256.Encode(newuser.Password);
                db.Players.Add(newuser);
                db.SaveChanges();
                
                


                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Bir hata meydana geldi");
            }
        }




    }
}
