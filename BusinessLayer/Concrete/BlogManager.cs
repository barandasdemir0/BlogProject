using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager:IBlogService
    {
        IBlogDal _blogDal;

        Repository<Blog> repoBlog = new Repository<Blog>();

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        //public List<Blog> GetAll()
        //{
        //    return repoBlog.List();
        //}
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

        //public void BlogAddBL(Blog blog)
        //{
        //    //if (blog.BlogTitle == null || blog.BlogImage == null || blog.BlogContent == null)
        //    //{
        //    //    return -1;
        //    //}
        //     repoBlog.Insert(blog);
        //}



        //public void DeleteBlogBL(int p)
        //{
        //    Blog blog = repoBlog.Find(x => x.BlogID == p);
        //     repoBlog.Delete(blog);
        //}


        //public Blog FindBlog(int id)
        //{
        //    return repoBlog.Find(x => x.BlogID == id);
        //}


        //public void BlogUpdateBL(Blog p)
        //{
        //     Blog blog = repoBlog.Find(x => x.BlogID == p.BlogID);
        //    blog.BlogTitle = p.BlogTitle;
        //    blog.BlogImage = p.BlogImage;
        //    blog.CategoryID = p.CategoryID;
        //    blog.AuthorID = p.AuthorID;
        //    blog.BlogContent = p.BlogContent;
        //     repoBlog.Update(blog);
        //}

        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

        public void BlogAdd(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetByID(id);
        }

        public void BlogDelete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public void BlogUpdate(Blog blog)
        {
            _blogDal.Update(blog);
        }
    }
}
