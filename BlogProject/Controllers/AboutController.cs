using BusinessLayer.Concrete;
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

        AboutManager about = new AboutManager();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Footer()
        {
            var aboutContentList = about.GetAll().Take(1);
            return PartialView(aboutContentList);
        }
        public PartialViewResult MeetTheTeam()
        {
            return PartialView();
        }
    }
}