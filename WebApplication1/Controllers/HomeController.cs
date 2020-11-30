using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Etudedecas;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private Bdd bdd;
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
            if(client.Name != null && client.FirstName != null & client.Address != null)
            {
                bdd = new Bdd();
                bdd.AddContact(client);
            }
        }
        public PartialViewResult DeleteClientView()
        {
            return PartialView("_DeleteClient");
        }
        public ActionResult DeleteClient(Client client)
        {
            bdd = new Bdd();
            
            return View("Clients");
        }
        public ActionResult GetClients()
        {
            //To Do
            List<Client> clients = new List<Client>();
            bdd = new Bdd();
            clients = bdd.getClients();
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