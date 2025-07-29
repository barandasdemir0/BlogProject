using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
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
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.CategoryAdd(category);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();


        }


        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            var bilgiler = categoryManager.GetById(id);
            return View(bilgiler);
        }

        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {

            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.CategoryUpdate(category);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return View();

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