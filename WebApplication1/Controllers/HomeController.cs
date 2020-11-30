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
            bdd = new Bdd();
            Boolean result = bdd.authentification(user.Email, user.Password);
            if (result)
            {
                this.user = user;
                return this.Index();
            }
            else
            {
               return View("Login");
            }
           
        }
        public PartialViewResult AddClientView()
        {
            return PartialView("_AddClient");
        }
        public ActionResult AddClient(Client client)
        {
            if(client.Id != null && client.Name != null && client.FirstName != null & client.Address != null)
            {
                bdd = new Bdd();
                bdd.AddContact(client);
            }
            return View("Index");
        }
        public PartialViewResult DeleteClientView()
        {
            return PartialView("_DeleteClient");
        }
        public ActionResult UpdateClientView(string Id)
        {
            List<Client> clients = new List<Client>();
            clients = Session["client"] as List<Client>;
            Client client = clients.Find(c => c.Id.Equals(Id));
            return View("UpdateClient", client);
           
        }
        public ActionResult UpdateClient(Client target)
        {
            bdd = new Bdd();
            bdd.UpdateClient(target);
            return GetClients();
        }
        public ActionResult DeleteClient(string Id)
        {
            List<Client> clients = new List<Client>();
            clients = Session["client"] as List<Client>;
            Client client = clients.Find(c => c.Id.Equals(Id));
            bdd = new Bdd();
            bdd.DeleteClient(client);
            return GetClients();
        }
        public ActionResult GetClients()
        {
            List<Client> clients = new List<Client>();
            bdd = new Bdd();
            clients = bdd.getClients();
            Session["client"] = clients;
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