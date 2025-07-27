using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager
    {
        Repository<About> repoAbout = new Repository<About>();

        public List<About> GetAll()
        {
            return repoAbout.List();
        }

        public int AboutUpdateBL(About a)
        {
            About about = repoAbout.Find(x => x.AboutID == a.AboutID);
            about.AboutImage1 = a.AboutImage1;
            about.AboutImage2 = a.AboutImage2;
            about.AboutContent1 = a.AboutContent1;
            about.AboutContent2 = a.AboutContent2;
            return repoAbout.Update(about);
        }
    }
}
