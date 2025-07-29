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
    public class AuthorManager:IAuthorService
    {


        IAuthorDal _authorDal;

        Repository<Author> repoAbout = new Repository<Author>();

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        //public List<Author> GetAll()
        //{
        //    return repoAbout.List();
        //}



        //public void AuthorAddBL(Author author)
        //{
        //    //if (author.AuthorName == null || author.AuthorImage == null || author.AboutShort == null || author.AuthorAbout == null || author.AuthorTitle == null || author.AuthorMail == null || author.Password == null || author.PhoneNumber == null)
        //    //{
        //    //     r
        //    //}
        //     repoAbout.Insert(author);
        //}



     
        //public Author FindAuthor(int id)
        //{
        //    return repoAbout.Find(x => x.AuthorID == id);
        //}


        //public void AuthorUpdateBL(Author a)
        //{
        //    Author author = repoAbout.Find(x => x.AuthorID == a.AuthorID);
        //    author.AuthorName = a.AuthorName;
        //    author.AuthorImage = a.AuthorImage;
        //    author.AuthorAbout = a.AuthorAbout;
        //    author.AuthorTitle = a.AuthorTitle;
        //    author.AboutShort = a.AboutShort;
        //    author.AuthorMail = a.AuthorMail;
        //    author.Password = a.Password;
        //    author.PhoneNumber = a.PhoneNumber;
        //     repoAbout.Update(author);
        //}

        public List<Author> GetList()
        {
           return  _authorDal.List();
        }

        public void AuthorAdd(Author author)
        {
            _authorDal.Insert(author);
        }

        public Author GetById(int id)
        {
            return _authorDal.GetByID(id);
            
        }

        public void AuthorDelete(Author author)
        {
            _authorDal.Delete(author);
        }

        public void AuthorUpdate(Author author)
        {
            _authorDal.Update(author);
        }
    }
}
