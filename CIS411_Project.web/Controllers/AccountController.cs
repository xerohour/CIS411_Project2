using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS411_Project.Core.Models;
using CIS411_Project.Core.Services;
using System.Web.Security;


namespace CIS411_Project.web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.USER_DISPLAYNAME, user.PASSWORD))
                {
                    FormsAuthentication.SetAuthCookie(user.USER_DISPLAYNAME, user.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Register/

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                {
                    IService service = new BookService();
                    service.insertUser(model);
                    return RedirectToAction("Index", "Home");

                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);

        }
    }
}
