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

            return View();
        }
        // POST: Vindorel/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                vindorelEntities vindorel = new vindorelEntities();
                Players Player = new Players();
                vindorel.SaveChanges();
                
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




    }
}
