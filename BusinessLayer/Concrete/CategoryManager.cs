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
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;


        Repository<Category> repoCategory = new Repository<Category>();

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GettAll()
        {
            return _categoryDal.List();
        }

        //public void CategoryAddBL(Category category)
        //{
        //    //if (category.CategoryName == null || category.CategoryDescription == null )
        //    //{
        //    //    return -1;
        //    //}
        //     repoCategory.Insert(category);
        //}


        //public Category FindCategory(int id)
        //{
        //    return repoCategory.Find(x => x.CategoryID == id);
        //}
        //public void CategoryUpdateBL(Category c)
        //{
        //    //Category category = repoCategory.Find(x => x.CategoryID == c.CategoryID);
        //    //category.CategoryName = c.CategoryName;
        //    //category.CategoryDescription = c.CategoryDescription;
        //     repoCategory.Update(c);
        //}


        public void ChangeCommentStatusToFalse(int id)
        {
            Category category = repoCategory.Find(x => x.CategoryID == id);
            category.CategoryStatus = false;
            _categoryDal.Update(category);
        }

        public void ChangeCommentStatusToTrue(int id)
        {
            Category category = repoCategory.Find(x => x.CategoryID == id);
            category.CategoryStatus = true;
            _categoryDal.Update(category);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
         
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
