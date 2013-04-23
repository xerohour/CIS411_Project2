using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

       // [HttpPost]
        //public ActionResult Results(string searchText)
       // {
            // You would actually do something more useful here.
            // This just fudges some results for displaying in the View.
           // var model = new SearchResults {SearchText = searchText, Results = new List<string> {searchText}};
            //return View(model);        
       // }


    }
}
