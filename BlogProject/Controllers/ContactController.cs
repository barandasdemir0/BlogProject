using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contact = new ContactManager(new EfContactDal());
        Context context = new Context();


        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]

        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendMessage(Contact c)
        {
            contact.BlContactAdd(c);
            return View();
        }



        public ActionResult SendBox()
        {
            var messageList = contact.GetList();
            ViewBag.veri = context.Contacts.Count();
            return View(messageList);
        }
        public ActionResult MessageDetails(int id)
        {
            Contact c = contact.GetById(id);
            ViewBag.veri = context.Contacts.Count();
            return View(c);
        }
    }
}