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
        public void DeleteClient(Client client)
        {

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