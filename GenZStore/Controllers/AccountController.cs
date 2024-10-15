using GenZStore.Models;
using GenZStore.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace GenZStore.Controllers
{
    public class AccountController : Controller
    {

        private GonzStoreDbContext _context;

        public AccountController()
        {
            _context = new GonzStoreDbContext(); // Khởi tạo DbContext
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose(); 
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account account)
        {
            if (ModelState.IsValid)
            {
                if (_context.users.Any(a => a.Username == account.Username))
                {
                    ModelState.AddModelError("", "Username already exists.");
                    return View(account);
                }

                account.Id = _context.users.Max(a => a.Id) + 1;
                _context.users.Add(account);

                return RedirectToAction("Login");
            }

            return View(account);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.users 
                    .FirstOrDefault(u => u.Email == model.email && u.Password == model.password);

                if (user != null)
                {
                    Session["UserId"] = user.Id;
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }


    }
}