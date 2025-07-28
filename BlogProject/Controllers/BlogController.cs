using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
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
        Context context = new Context();


        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public PartialViewResult BlogList(int paged=1)
        {

            var blogList = blogManager.GetAll().OrderByDescending(x=>x.BlogID).ToPagedList(paged,6);
            return PartialView(blogList);
        }


        [AllowAnonymous]
        public PartialViewResult FeaturedPosts()
        {

            var todayPost = blogManager.GetAll().Where(x => x.CategoryID == 1).Select(y => new
            {
                name = y.BlogTitle,
                date = y.BlogDate.ToString("dd-MMM-yyyy"),
                image = y.BlogImage,
                category = y.Category.CategoryName ,
                id= y.BlogID
            }).LastOrDefault();
            ViewBag.todayPost = todayPost.name;
            ViewBag.todayPostDate = todayPost.date;
            ViewBag.todayPostImage = todayPost.image;
            ViewBag.todayPostCategory = todayPost.category;
            ViewBag.todayPostid = todayPost.id;


            var techPost = blogManager.GetAll().Where(x => x.CategoryID == 2).Select(y => new
            {
                name = y.BlogTitle,
                date = y.BlogDate.ToString("dd-MMM-yyyy"),
                image = y.BlogImage,
                category = y.Category.CategoryName,
                id = y.BlogID
            }).LastOrDefault();
            ViewBag.techPostName = techPost.name;
            ViewBag.techPostDate = techPost.date;
            ViewBag.techPostImage = techPost.image;
            ViewBag.techPostCategory = techPost.category;
            ViewBag.techPostid = techPost.id;

            var artificalPost = blogManager.GetAll().Where(x => x.CategoryID == 3).Select(y => new
            {
                name = y.BlogTitle,
                date = y.BlogDate.ToString("dd-MMM-yyyy"),
                image = y.BlogImage,
                category = y.Category.CategoryName,
                id = y.BlogID
            }).LastOrDefault();
            ViewBag.artificalPostName = artificalPost.name;
            ViewBag.artificalPostDate = artificalPost.date;
            ViewBag.artificalPostImage = artificalPost.image;
            ViewBag.artificalPostCategory = artificalPost.category;
            ViewBag.artificalPostid = artificalPost.id;


            var education = blogManager.GetAll().Where(x => x.CategoryID == 5).Select(y => new
            {
                name = y.BlogTitle,
                date = y.BlogDate.ToString("dd-MMM-yyyy"),
                image = y.BlogImage,
                category = y.Category.CategoryName,
                id = y.BlogID
            }).LastOrDefault();
            ViewBag.educationPostName = education.name;
            ViewBag.educationPostDate = education.date;
            ViewBag.educationPostImage = education.image;
            ViewBag.educationPostCategory = education.category;
            ViewBag.educationPostid = education.id;


            var career = blogManager.GetAll().Where(x => x.CategoryID == 4).Select(y => new
            {
                name = y.BlogTitle,
                date = y.BlogDate.ToString("dd-MMM-yyyy"),
                image = y.BlogImage,
                category = y.Category.CategoryName,
                id = y.BlogID
            }).LastOrDefault();
            ViewBag.careerPostName = career.name;
            ViewBag.careerPostDate = career.date;
            ViewBag.careerPostImage = career.image;
            ViewBag.careerPostCategory = career.category;
            ViewBag.careerPostid = career.id;






            return PartialView();
        }


        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPosts()
        {
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
            ViewBag.educationPostName = education.name;
            ViewBag.educationPostDate = education.date;
            ViewBag.educationPostImage = education.image;
            ViewBag.educationPostCategory = education.category;


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


        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var blogDetailsList = blogManager.GetBlogByID(id);
            return PartialView(blogDetailsList);
        }

        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var blogDetailsList = blogManager.GetBlogByID(id);
            return PartialView(blogDetailsList);
        }

        [AllowAnonymous]
        public ActionResult BlogByCategory(int id, int paged=1)
        {
            var blogListByCategory = blogManager.GetBlogByCategory(id).ToPagedList(paged,6);

            var category  = blogManager.GetBlogByCategory(id).Select(y => new
            {
                categoryName = y.Category.CategoryName,
                categoryDescription = y.Category.CategoryDescription
            }).FirstOrDefault();

            ViewBag.categoryName = category.categoryName;
            ViewBag.categoryDescription = category.categoryDescription;
            return View(blogListByCategory);
        }

        public ActionResult AdminBlogList()
        {
            var blogList = blogManager.GetAll();
            return View(blogList);
        }


        public ActionResult AdminBlogList2()
        {
            var blogList = blogManager.GetAll();
            return View(blogList);
        }

        #region ekle sil güncelle getir
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            var categoryList = context.Categories.Select(x => new SelectListItem
            {
                Value = x.CategoryID.ToString(),
                Text = x.CategoryName
            }).ToList();

            var authorList = context.Authors.Select(x => new SelectListItem
            {
                Value = x.AuthorID.ToString(),
                Text = x.AuthorName
            }).ToList();

            ViewBag.categoryName = categoryList;
            ViewBag.authorName = authorList;

            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog blog)
        {
            blog.BlogDate = Convert.ToDateTime(DateTime.Now);
            blogManager.BlogAddBL(blog);
            return RedirectToAction("AdminBlogList2");
        }


        public ActionResult DeleteBlog(int id)
        {
            blogManager.DeleteBlogBL(id);
            return RedirectToAction("AdminBlogList2");
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

            var authorList = context.Authors.Select(x => new SelectListItem
            {
                Value = x.AuthorID.ToString(),
                Text = x.AuthorName
            }).ToList();

            ViewBag.categoryName = categoryList;
            ViewBag.authorName = authorList;



            return View(bilgiler);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog blog)
        {
            blog.BlogDate = Convert.ToDateTime(DateTime.Now);
            blogManager.BlogUpdateBL(blog);
            return RedirectToAction("AdminBlogList2");
        }


        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager comment = new CommentManager();
            var commentList = comment.CommentByBlog(id);
            return View(commentList);
        }







        #endregion


    }
}