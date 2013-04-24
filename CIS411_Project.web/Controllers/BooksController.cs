using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS411_Project.Core.Models;
using CIS411_Project.Core.Services;

namespace CIS411_Project.web.Controllers
{
    public class BooksController : Controller
    {
        //
        // GET: /Books/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int bookId)
        {
            BookService service = new BookService();
            return View(service.getBookById(bookId));
                   
        }

    }
}
