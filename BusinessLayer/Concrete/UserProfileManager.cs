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

        public void AuthorUpdateBL(Author a)
        {
            Author author = repoAuthor.Find(x => x.AuthorID == a.AuthorID);
            author.AuthorName = a.AuthorName;
            author.AuthorImage = a.AuthorImage;
            author.AuthorAbout = a.AuthorAbout;
            author.AuthorTitle = a.AuthorTitle;
            author.AboutShort = a.AboutShort;
            author.AuthorMail = a.AuthorMail;
            author.Password = a.Password;
            author.PhoneNumber = a.PhoneNumber;
             repoAuthor.Update(author);
        }

    }
}
