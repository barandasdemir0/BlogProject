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
    [AllowAnonymous]
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


        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var userInfo = context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.Username, false);
                Session["Name"] = userInfo.Username.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return View();
            }

        }











    }
}