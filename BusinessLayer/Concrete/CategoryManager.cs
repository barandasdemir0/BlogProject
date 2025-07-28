using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        Repository<Category> repoCategory = new Repository<Category>();
        public List<Category> GettAll()
        {
            return repoCategory.List();
        }

        public int CategoryAddBL(Category category)
        {
            if (category.CategoryName == null || category.CategoryDescription == null )
            {
                return -1;
            }
            return repoCategory.Insert(category);
        }


        public Category FindCategory(int id)
        {
            return repoCategory.Find(x => x.CategoryID == id);
        }
        public int CategoryUpdateBL(Category c)
        {
            Category category = repoCategory.Find(x => x.CategoryID == c.CategoryID);
            category.CategoryName = c.CategoryName;
            category.CategoryDescription = c.CategoryDescription;
            return repoCategory.Update(category);
        }


        public int ChangeCommentStatusToFalse(int id)
        {
            Category category = repoCategory.Find(x => x.CategoryID == id);
            category.CategoryStatus = false;
            return repoCategory.Update(category);
        }

        public int ChangeCommentStatusToTrue(int id)
        {
            Category category = repoCategory.Find(x => x.CategoryID == id);
            category.CategoryStatus = true;
            return repoCategory.Update(category);
        }


    }
}
