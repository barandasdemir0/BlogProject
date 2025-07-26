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

        public int BlogAddBL(Blog blog)
        {
            if (blog.BlogTitle == null || blog.BlogImage == null || blog.BlogContent == null)
            {
                return -1;
            }
            return repoBlog.Insert(blog);
        }



        public int DeleteBlogBL(int p)
        {
            Blog blog = repoBlog.Find(x => x.BlogID == p);
            return repoBlog.Delete(blog);
        }


        public Blog FindBlog(int id)
        {
            return repoBlog.Find(x => x.BlogID == id);
        }


        public int BlogUpdateBL(Blog p)
        {
             Blog blog = repoBlog.Find(x => x.BlogID == p.BlogID);
            blog.BlogTitle = p.BlogTitle;
            blog.BlogImage = p.BlogImage;
            blog.CategoryID = p.CategoryID;
            blog.AuthorID = p.AuthorID;
            blog.BlogContent = p.BlogContent;
            return repoBlog.Update(blog);
        }





      
    }
}
