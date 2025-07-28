using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease;

namespace BlogProject.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author

        BlogManager blog = new BlogManager();
        AuthorManager author = new AuthorManager();

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetails = blog.GetBlogByID(id);
            return PartialView(authorDetails);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var authorId = blog.GetAll().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
            var authorBlogs = blog.GetBlogByAuthorID(authorId);
            return PartialView(authorBlogs);
        }


        public ActionResult AuthorList()
        {
           var values = author.GetAll();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author authorAdd)
        {
            
            author.AuthorAddBL(authorAdd);
            return RedirectToAction("AuthorList");
        
        }
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            var bilgiler = author.FindAuthor(id);
            return View(bilgiler);
        }

        [HttpPost]
        public ActionResult AuthorEdit(Author authorUpdate)
        {

            author.AuthorUpdateBL(authorUpdate);
            return RedirectToAction("AuthorList");

        }


  







        


    }
}