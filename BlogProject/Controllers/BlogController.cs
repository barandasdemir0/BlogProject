using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        BlogManager blogManager = new BlogManager();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult BlogList(int paged=1)
        {

            var blogList = blogManager.GetAll().ToPagedList(paged,6);
            return PartialView(blogList);
        }

        public PartialViewResult FeaturedPosts()
        {

            var todayPost = blogManager.GetAll().Where(x => x.BlogDate == Convert.ToDateTime(DateTime.Now.ToShortDateString())).Select(y => new
            {
                name = y.BlogTitle,
                date = y.BlogDate.ToString("dd-MMM-yyyy"),
                image = y.BlogImage,
                category = y.Category.CategoryName 
            }).LastOrDefault();
            ViewBag.todayPost = todayPost.name;
            ViewBag.todayPostDate = todayPost.date;
            ViewBag.todayPostImage = todayPost.image;
            ViewBag.todayPostCategory = todayPost.category;


            var techPost = blogManager.GetAll().Where(x => x.CategoryID == 2).Select(y => new
            {
                name = y.BlogTitle,
                date = y.BlogDate.ToString("dd-MMM-yyyy"),
                image = y.BlogImage,
                category = y.Category.CategoryName
            }).LastOrDefault();
            ViewBag.techPostName = techPost.name;
            ViewBag.techPostDate = techPost.date;
            ViewBag.techPostImage = techPost.image;
            ViewBag.techPostCategory = techPost.category;

            var artificalPost = blogManager.GetAll().Where(x => x.CategoryID == 3).Select(y => new
            {
                name = y.BlogTitle,
                date = y.BlogDate.ToString("dd-MMM-yyyy"),
                image = y.BlogImage,
                category = y.Category.CategoryName
            }).LastOrDefault();
            ViewBag.artificalPostName = artificalPost.name;
            ViewBag.artificalPostDate = artificalPost.date;
            ViewBag.artificalPostImage = artificalPost.image;
            ViewBag.artificalPostCategory = artificalPost.category;


            var education = blogManager.GetAll().Where(x => x.CategoryID == 5).Select(y => new
            {
                name = y.BlogTitle,
                date = y.BlogDate.ToString("dd-MMM-yyyy"),
                image = y.BlogImage,
                category = y.Category.CategoryName
            }).LastOrDefault();
            ViewBag.educationPostName = artificalPost.name;
            ViewBag.educationPostDate = artificalPost.date;
            ViewBag.educationPostImage = artificalPost.image;
            ViewBag.educationPostCategory = artificalPost.category;


            var career = blogManager.GetAll().Where(x => x.CategoryID == 4).Select(y => new
            {
                name = y.BlogTitle,
                date = y.BlogDate.ToString("dd-MMM-yyyy"),
                image = y.BlogImage,
                category = y.Category.CategoryName
            }).LastOrDefault();
            ViewBag.careerPostName = career.name;
            ViewBag.careerPostDate = career.date;
            ViewBag.careerPostImage = career.image;
            ViewBag.careerPostCategory = career.category;






            return PartialView();
        }
        public PartialViewResult OtherFeaturedPosts()
        {
            return PartialView();
        }
      

        public ActionResult BlogDetails()
        {
            return View();
        }

        public PartialViewResult BlogCover(int id)
        {
            var blogDetailsList = blogManager.GetBlogByID(id);
            return PartialView(blogDetailsList);
        }

        public PartialViewResult BlogReadAll(int id)
        {
            var blogDetailsList = blogManager.GetBlogByID(id);
            return PartialView(blogDetailsList);
        }
        public ActionResult BlogByCategory()
        {
            return View();
        }

    }
}