using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p); // sil veriyi gönderdiğim p parametresiyle 
            c.SaveChanges(); // değişiklikleri kaydet
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public void Insert(T p)
        {
            //_object.Add(p);
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _object.Where(where).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
