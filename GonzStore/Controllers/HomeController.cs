using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GonzStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search() 
        {
            return View(); 
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Product()
        {
            return View();
        }



        public ActionResult GetEmployee(int Id)
        {
            var employees = new[] {
                new { Id = 1, Name = "Justin", Salary = 1000 },
                new { Id = 1, Name = "Justin", Salary = 1000 },
                new { Id = 1, Name = "Justin", Salary = 1000 },
                new { Id = 1, Name = "Justin", Salary = 1000 }
            };

            string matchName = null;
            foreach (var employee in employees)
            {
                if(employee.Id == Id)
                    matchName = employee.Name;
            }

            return new ContentResult() { Content = matchName, ContentType = "text/plain" };
        }
    }
}