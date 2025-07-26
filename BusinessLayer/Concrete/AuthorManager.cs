using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {
        Repository<Author> repoAbout = new Repository<Author>();
        public List<Author> GetAll()
        {
            return repoAbout.List();
        }



        public int AuthorAddBL(Author author)
        {
            if (author.AuthorName == null || author.AuthorImage == null || author.AboutShort == null || author.AuthorAbout == null || author.AuthorTitle == null || author.AuthorMail == null || author.Password == null || author.PhoneNumber == null)
            {
                return -1;
            }
            return repoAbout.Insert(author);
        }



     
        public Author FindAuthor(int id)
        {
            return repoAbout.Find(x => x.AuthorID == id);
        }


        public int AuthorUpdateBL(Author a)
        {
            Author author = repoAbout.Find(x => x.AuthorID == a.AuthorID);
            author.AuthorName = a.AuthorName;
            author.AuthorImage = a.AuthorImage;
            author.AuthorAbout = a.AuthorAbout;
            author.AuthorTitle = a.AuthorTitle;
            author.AboutShort = a.AboutShort;
            author.AuthorMail = a.AuthorMail;
            author.Password = a.Password;
            author.PhoneNumber = a.PhoneNumber;
            return repoAbout.Update(author);
        }


    }
}
