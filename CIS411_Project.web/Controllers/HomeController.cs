using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS411_Project.Core.Models;
using CIS411_Project.Core.Services;

namespace CIS411_Project.web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var db = new BookService();
            return View(db.listBooks());
                
            
        }

        //public ActionResult Create()
        //{
        //    BookService service = new BookService();

        //}

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "About";  
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";
            return View();
        }

   



    }
}
