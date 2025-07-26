using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> //buradaki t paramatresi bizm tablolarımızdır
    {

        //yapılacak temel crud işlemleri oluşturduk
        List<T> List();
        int Insert(T p);
        int Update(T p);
        int Delete(T p);
        T GetByID(int id);

        List<T> List(Expression<Func<T, bool>> filter);
        T Find(Expression<Func<T, bool>> where);

     

     ////🔍 Neden int var?
        //Çünkü genellikle veritabanındaki bir kaydı tanımak için kullanılan birincil anahtar(Primary Key) tipi int olur.
        //Yani: int id → Hangi veriyi istiyoruz, onu belirtiriz.


    }
}
