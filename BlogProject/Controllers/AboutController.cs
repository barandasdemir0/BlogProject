using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About

        AuthorManager author = new AuthorManager(new EfAuthorDal());
        AboutManager about = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutContent = about.GetList();
            return View(aboutContent);
        }

        public PartialViewResult Footer()
        {
            var aboutContentList = about.GetList().Take(1);
            return PartialView(aboutContentList);
        }
        public PartialViewResult MeetTheTeam()
        {
            var aboutMeetTeam = author.GetList().Take(6);
            return PartialView(aboutMeetTeam);
        }

        public ActionResult UpdateAboutList()
        {
            var abaoutList = about.GetList();
            return View(abaoutList);
        }

        public ActionResult UpdateAbout(About a)
        {
            about.AboutUpdate(a);
            return RedirectToAction("UpdateAboutList");
        }

    }
}