using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager profileManager = new UserProfileManager();
        public ActionResult Index()
        {
          
            return View();
        }


        public PartialViewResult Partial1(string mail)
        {
            mail = (string)Session["Mail"];
            var profileValues = profileManager.GetAuthorByMail(mail);
            return PartialView(profileValues);
        }

        public ActionResult BlogList()
        {
            int id = 2;
            var blogs = profileManager.GetBlogByAuthor(id);
            return View(blogs);
        }
      
    }
}