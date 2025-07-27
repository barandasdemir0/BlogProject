using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        AuthorManager author = new AuthorManager();
        AboutManager about = new AboutManager();
        public ActionResult Index()
        {
            var aboutContent = about.GetAll();
            return View(aboutContent);
        }
        public PartialViewResult Footer()
        {
            var aboutContentList = about.GetAll().Take(1);
            return PartialView(aboutContentList);
        }
        public PartialViewResult MeetTheTeam()
        {
            var aboutMeetTeam = author.GetAll().Take(6);
            return PartialView(aboutMeetTeam);
        }

        public ActionResult UpdateAboutList()
        {
            var abaoutList = about.GetAll();
            return View(abaoutList);
        }

        public ActionResult UpdateAbout(About a)
        {
            about.AboutUpdateBL(a);
            return RedirectToAction("UpdateAboutList");
        }

    }
}