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
    public class AboutManager:IAboutService
    {
        IAboutDal _aboutDal;
        Repository<About> repoAbout = new Repository<About>();

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        //public List<About> GetAll()
        //{
        //    return repoAbout.List();
        //}

        //public void AboutUpdateBL(About a)
        //{
        //    About about = repoAbout.Find(x => x.AboutID == a.AboutID);
        //    about.AboutImage1 = a.AboutImage1;
        //    about.AboutImage2 = a.AboutImage2;
        //    about.AboutContent1 = a.AboutContent1;
        //    about.AboutContent2 = a.AboutContent2;
        //     repoAbout.Update(about);
        //}

        public List<About> GetList()
        {
            return _aboutDal.List();
        }

        public void AboutAdd(About about)
        {
            _aboutDal.Insert(about);
        }

        public About GetById(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public void AboutDelete(About about)
        {
            _aboutDal.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
