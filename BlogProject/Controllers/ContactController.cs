using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contact = new ContactManager();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(Contact c)
        {
            contact.BlContactAdd(c);
            return View();
        }
    }
}