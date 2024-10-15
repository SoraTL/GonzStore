using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenZStore.Models;

namespace GenZStore.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index(string search="")
        {
            //HHLEntities1 db = new HHLEntities1();
            //List<CATEGORY> categories = db.CATEGORY.ToList();
            //List<CATEGORY> categories = db.CATEGORY.Where(row=> row.name.Contains(search)).ToList();
            return View();
        }

        public ActionResult Create()
        { 
            return View(); 
        }
        [HttpPost]
        public ActionResult Create(Cart p)
        {
            return View(p);
        }
    }
}