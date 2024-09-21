using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GonzStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Prodcut
        public ActionResult Index()
        {
            return View();
        }

    }

}