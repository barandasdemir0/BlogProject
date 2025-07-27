using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repoAuthor = new Repository<Author>();
        Repository<Blog> repoBlog = new Repository<Blog>();
        public List<Author> GetAuthorByMail(string mail)
        {
            return repoAuthor.List(x => x.AuthorMail == mail);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoBlog.List(x => x.AuthorID == id);
        }

    }
}
