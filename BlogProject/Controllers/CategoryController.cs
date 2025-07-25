using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager();
        public ActionResult Index()
        {
            var categoryValues = categoryManager.GettAll();
            return View(categoryValues);
        }

        public PartialViewResult BlogDetailsCategoryList()
        {
            return PartialView();
        }
    }
}