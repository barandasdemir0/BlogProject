using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAboutDal:IRepository<About> //repositoryden miras alıyoruz ekle sil güncelleden hangi sınıfı kullancal ıaboutdalda olduğumuz için about tablosu
    {
    }
}
