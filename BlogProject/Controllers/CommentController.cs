using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager comment = new CommentManager();
        public PartialViewResult CommentList(int id)
        {
            var commentList = comment.CommentByBlog(id);
            return PartialView(commentList);
        }

        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            c.CommentDate = Convert.ToDateTime( DateTime.Now.ToShortDateString());
            comment.CommentAdd(c);
            return PartialView();
        }
    }
}