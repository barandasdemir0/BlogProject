using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author author)
        {
            var userInfo = context.Authors.FirstOrDefault(x => x.AuthorMail == author.AuthorMail && x.Password == author.Password);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.AuthorMail, false);
                Session["Name"] = userInfo.AuthorName.ToString();
                Session["Mail"] = userInfo.AuthorMail.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View();
            }
               
        }
    }
}