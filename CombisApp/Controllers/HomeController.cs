using CombisApp.DAL;
using CombisApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CombisApp.Controllers
{
    public class HomeController : Controller
    {
        private PodaciRepository repository;

        public HomeController()
        {
            repository = new PodaciRepository();
        }

        public ActionResult Index()
        {
            var myList = new List<Podaci>();

            return View(myList);
        }

        public ActionResult Table()
        {
            var myList = repository.GetAll();

            return PartialView("_IndexTable", myList);
        }

        public ActionResult SaveAll()
        {
            var myList = repository.GetAll();
            repository.AddToDatabase(myList);
            return PartialView("_Bravo");
        }
    }
}