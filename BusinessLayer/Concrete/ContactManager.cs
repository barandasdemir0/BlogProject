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
    public class ContactManager:IContactService
    {

        IContactDal _contactDal;

        Repository<Contact> repoContact = new Repository<Contact>();

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void BlContactAdd(Contact c)
        {
            //if (c.Mail == "" || c.Message == "" || c.Name == "" || c.Subject == "" || c.Surname == "")
            //{
            //    return -1;
            //}
            repoContact.Insert(c);
        }

        //public List<Contact> GetAll()
        //{
        //    return repoContact.List();
        //}

        public Contact GetById(int id)
        {
            return _contactDal.GetByID(id);
        }

        //public Contact GetContactDetails(int id)
        //{
        //    return repoContact.Find(x => x.ContactID == id);
             
        //}

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }

        public void TAdd(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void TDelete(Contact t)
        {
            _contactDal.Delete(t);
        }

        public void TUpdate(Contact t)
        {
            _contactDal.Update(t);
        }
    }
}
