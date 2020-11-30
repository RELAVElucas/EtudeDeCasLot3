using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public User user;

        public ActionResult Index()
        {
            if(user == null)
            {
                return LoginView();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            //TO DO Check Login
            this.user = user;
            return this.Index();
        }
        public ActionResult LoginView()
        {
            return View("Login");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}