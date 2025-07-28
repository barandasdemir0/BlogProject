using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        Context context = new Context();
        public ActionResult Index()
        {
            var categoryValues = categoryManager.GettAll();
            return View(categoryValues);
        }

        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryValues = categoryManager.GettAll().Take(5);
            return PartialView(categoryValues);
        }
        
        public ActionResult AdminCategoryList()
        {
            var categoryValues = categoryManager.GettAll();
            return View(categoryValues);
        }


    }
}