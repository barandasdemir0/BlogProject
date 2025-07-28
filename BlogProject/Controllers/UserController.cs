using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebGrease;

namespace BlogProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager profileManager = new UserProfileManager();
        BlogManager blogManager = new BlogManager();
        Context context = new Context();
        public ActionResult Index()
        {

            return View();
        }


        public PartialViewResult Partial1(string mail)
        {
            mail = (string)Session["Mail"];
            var profileValues = profileManager.GetAuthorByMail(mail);
            return PartialView(profileValues);
        }


        public ActionResult UpdateUserProfile(Author p)
        {

            profileManager.AuthorUpdateBL(p);
            return RedirectToAction("Index");
        }

        public ActionResult BlogList(string mail)
        {
            mail = (string)Session["Mail"];
            int id = context.Authors.Where(x => x.AuthorMail == mail).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = profileManager.GetBlogByAuthor(id);
            return View(blogs);
        }


        [HttpGet]
        public ActionResult AddNewBlog()
        {
            var categoryList = context.Categories.Select(x => new SelectListItem
            {
                Value = x.CategoryID.ToString(),
                Text = x.CategoryName
            }).ToList();

            var mail = (string)Session["Mail"];
            var name = context.Authors.Where(x => x.AuthorMail == mail).Select(y => y.AuthorName).FirstOrDefault();
            var id = context.Authors.Where(x => x.AuthorMail == mail).Select(y => y.AuthorID).FirstOrDefault();

            ViewBag.authorName = name;
            ViewBag.authorId = id;

            //var authorList = context.Authors.Select(x => new SelectListItem
            //{
            //    Value = x.AuthorID.ToString(),
            //    Text = x.AuthorName
            //}).ToList();

            ViewBag.categoryName = categoryList;
         

            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog blog)
        {
            blog.BlogDate = Convert.ToDateTime(DateTime.Now);
            blogManager.BlogAddBL(blog);
            return RedirectToAction("BlogList");
        }


        public ActionResult DeleteBlog(int id)
        {
            blogManager.DeleteBlogBL(id);
            return RedirectToAction("BlogList");
        }


        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {

            var bilgiler = blogManager.FindBlog(id);
            var categoryList = context.Categories.Select(x => new SelectListItem
            {
                Value = x.CategoryID.ToString(),
                Text = x.CategoryName
            }).ToList();

            //var authorList = context.Authors.Select(x => new SelectListItem
            //{
            //    Value = x.AuthorID.ToString(),
            //    Text = x.AuthorName
            //}).ToList();

            var mail = (string)Session["Mail"];
            var name = context.Authors.Where(x => x.AuthorMail == mail).Select(y => y.AuthorName).FirstOrDefault();
            var detectedId = context.Authors.Where(x => x.AuthorMail == mail).Select(y => y.AuthorID).FirstOrDefault();

            ViewBag.authorName = name;
            ViewBag.authorId = detectedId;

            ViewBag.categoryName = categoryList;
            //ViewBag.authorName = authorList;



            return View(bilgiler);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog blog)
        {
            blog.BlogDate = Convert.ToDateTime(DateTime.Now);
            blogManager.BlogUpdateBL(blog);
            return RedirectToAction("BlogList");
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }

    }
}