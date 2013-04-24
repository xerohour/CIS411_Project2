using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS411_Project.Core.Models;
using CIS411_Project.Core.Services;


namespace CIS411_Project.web.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Results(string searchText)
        {
            BookService service = new BookService();
            return View(service.searchBookByTitle(searchText));

            //ICollection<Books> book = 
            //return View(book);
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //[ActionName("Results")]
        //public ActionResult ResultsPost(string searchText)
        //{
        //    return RedirectToAction("Results", new { searchText = searchText });
        //}

    }
}
