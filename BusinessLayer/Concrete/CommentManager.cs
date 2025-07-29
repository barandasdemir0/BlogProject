using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer.Concrete
{
    public class CommentManager:ICommentService
    {
        ICommentDal _commentDal;

        Repository<Comment> repoComment = new Repository<Comment>();

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> CommentList()
        {
            return repoComment.List();
        }


        public List<Comment> CommentByBlog(int id)
        {
            return _commentDal.List(x => x.BlogID == id);
        }


        public void CommentAdd(Comment comment)
        {
            //if (c.CommentText=="" ||  c.Username == "" || c.Mail == "")
            //{
            //    return -1;
            //}

            //repoComment.Insert(c);
            _commentDal.Insert(comment);
        }

        public List<Comment> CommentByStatusTrue()
        {
            return _commentDal.List(x => x.CommentStatus == true);

        }

        public List<Comment> CommentByStatusFalse()
        {
            return _commentDal.List(x => x.CommentStatus == false);

        }



        public void ChangeCommentStatusToFalse(int id)
        {
            Comment comment = repoComment.Find(x => x.CommentID ==id);
            comment.CommentStatus = false;
             repoComment.Update(comment);
        }

        public void ChangeCommentStatusToTrue(int id)
        {
            Comment comment = repoComment.Find(x => x.CommentID == id);
            comment.CommentStatus = true;
             repoComment.Update(comment);
        }

        public List<Comment> GetList()
        {
            return _commentDal.List();
        }

        public Comment GetById(int id)
        {
           return _commentDal.GetByID(id);
        }

        public void CommentDelete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public void CommentUpdate(Comment comment)
        {
            _commentDal.Update(comment);
        }

      
    }
}
