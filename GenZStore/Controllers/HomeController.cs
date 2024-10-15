using GenZStore.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenZStore.Controllers
{
    public class HomeController : Controller
    {
        public GonzStoreDbContext db = new GonzStoreDbContext();
        public ActionResult Index(int? page)
        {
            int pageSize = 10; 
            int pageNumber = (page ?? 1); 

            var products = db.products.OrderBy(p => p.name).ToPagedList(pageNumber, pageSize);
            return View(products);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}