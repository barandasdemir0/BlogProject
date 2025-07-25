using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class //dışarıdan bir t nesnesi aldık nereden verileri alacaz ı repositoryden alacağız ı repositoryde de zaten bir t değeri where bu t değerleri nereden gelecek classımızdan entity layer klasslarımızdan
    {
        Context c = new Context();
        DbSet<T> _object; // dışarıdan alacağımız veriler
        public Repository()
        {
            _object = c.Set<T>(); // context üzerinden gönderdiğimiz verileri objecte ata
        }

        public int Delete(T p)
        {
            _object.Remove(p); // sil veriyi gönderdiğim p parametresiyle 
            return c.SaveChanges(); // değişiklikleri kaydet
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public int Insert(T p)
        {
            _object.Add(p);
            return c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public int Update(T p)
        {
            return c.SaveChanges();
        }
    }
}
