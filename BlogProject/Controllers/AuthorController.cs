using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author

        BlogManager blog = new BlogManager();
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetails = blog.GetBlogByID(id);
            return PartialView(authorDetails);
        }
        public PartialViewResult AuthorPopularPost(int id)
        {
            var authorId = blog.GetAll().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
            var authorBlogs = blog.GetBlogByAuthorID(authorId);
            return PartialView(authorBlogs);
        }
    }
}