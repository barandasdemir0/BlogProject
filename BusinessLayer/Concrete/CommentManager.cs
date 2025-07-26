using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager
    {
        Repository<Comment> repoComment = new Repository<Comment>();

        public List<Comment> CommentList()
        {
            return repoComment.List();
        }


        public List<Comment> CommentByBlog(int id)
        {
            return repoComment.List(x => x.BlogID == id);
        }


        public int CommentAdd(Comment c)
        {
            if (c.CommentText.Length<=4 || c.CommentText.Length>=301 || c.Username == null || c.Mail== null)
            {
                return -1;
            }
            
           return repoComment.Insert(c);
        }

    }
}
