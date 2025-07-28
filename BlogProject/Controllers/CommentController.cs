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

        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var commentList = comment.CommentByBlog(id);
            return PartialView(commentList);
        }

        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            c.CommentDate = Convert.ToDateTime( DateTime.Now.ToShortDateString());
            c.CommentStatus = true;
            comment.CommentAdd(c);
            return PartialView();
        }



        public ActionResult AdminCommentListTrue()
        {
            var commentList = comment.CommentByStatusTrue();
            return View(commentList);
        }

        public ActionResult AdminCommentListFalse()
        {
            var commentList = comment.CommentByStatusFalse();
            return View(commentList);
        }


        public ActionResult StatusChangeToFalse(int id)
        {
            comment.ChangeCommentStatusToFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }

        public ActionResult StatusChangeToTrue(int id)
        {
            comment.ChangeCommentStatusToTrue(id);
            return RedirectToAction("AdminCommentListTrue");
        }



    }
}