using ConexionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectToShow.Controllers
{
    public class HomeController : Controller
    {
        private PDBContext dbContext = new PDBContext();
        public ActionResult Index()
        {
            
            ViewBag.Message = "Welcome to Delivery Application" ;

            return View();
        }

        
    }
}