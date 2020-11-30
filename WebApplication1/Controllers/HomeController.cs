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
            if(user != null)
            {
                return View("Index");
            }
            return View("Login");
        }
        public ActionResult Login(User user)
        {
            // To Do
            this.user = user;
            return this.Index();
        }
        public PartialViewResult AddClientView()
        {
            return PartialView("_AddClient");
        }
        public void AddClient(Client client)
        {

        }
        public PartialViewResult DeleteClientView()
        {
            return PartialView("_DeleteClient");
        }
        public void DeleteClient(Client client)
        {

        }
        public ActionResult GetClients()
        {
            //To Do
            List<Client> clients = new List<Client>();

            return View("Clients", clients);
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