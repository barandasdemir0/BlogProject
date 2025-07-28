using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
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

        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminCategoryAdd(Category category)
        {
            categoryManager.CategoryAddBL(category);
            return RedirectToAction("AdminCategoryList");
        }


        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            var bilgiler = categoryManager.FindCategory(id);
            return View(bilgiler);
        }

        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {

            categoryManager.CategoryUpdateBL(category);
            return RedirectToAction("AdminCategoryList");

        }


        public ActionResult StatusChangeToFalse(int id)
        {
            categoryManager.ChangeCommentStatusToFalse(id);
            return RedirectToAction("AdminCategoryList");
        }

        public ActionResult StatusChangeToTrue(int id)
        {
            categoryManager.ChangeCommentStatusToTrue(id);
            return RedirectToAction("AdminCategoryList");
        }

    }
}