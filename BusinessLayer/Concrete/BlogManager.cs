using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager
    {
        Repository<Blog> repoBlog = new Repository<Blog>();

        public List<Blog> GetAll()
        {
            return repoBlog.List();
        }
        public List<Blog> GetBlogByID(int id)
        {
            return repoBlog.List(x => x.BlogID == id);
        }
        public List<Blog> GetBlogByAuthorID(int id)
        {
            return repoBlog.List(x => x.AuthorID == id);
        }
        public List<Blog> GetBlogByCategory(int id)
        {
            return repoBlog.List(x => x.CategoryID == id);
        }
    }
}
