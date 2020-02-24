using SBMSwebApp.DatabaseContext.DatabaseContext;
using SBMSwebApp.Models.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SBMSwebApp.Repository.Repository
{
    public class CategoryRepository
    {
        SBMSdbContext db = new SBMSdbContext();
        public List<Category> SearchCategory(CategoryViewModel categoryViewModel)
        {
            var categories = db.Categories.Where(c => c.CategoryName.ToLower().Contains(categoryViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.CategoryCode.ToLower().Contains(categoryViewModel.SearchText.ToLower()) && c.IsActive == "True").ToList();
            return categories;
        }
        public string IsExistCategory(CategoryViewModel categoryViewModel)
        {
            string status = "";
            if (categoryViewModel.ActionType == "Insert")
            {
                var aCategory = db.Categories.Where(c => c.CategoryName.ToLower() == categoryViewModel.CategoryName.ToLower() || c.CategoryCode.ToLower() == categoryViewModel.CategoryCode.ToLower() && c.IsActive == "True").FirstOrDefault();
                if (aCategory != null)
                {
                    if (aCategory.CategoryName == categoryViewModel.CategoryName)
                    {
                        return status = "name";

                    }
                    if (aCategory.CategoryCode == categoryViewModel.CategoryCode)
                    {
                        return status = "code";
                    }
                }
                else return status = "no";
                    
            }
            if (categoryViewModel.ActionType == "Update")
            {

                var categories = db.Categories.Where(c => c.CategoryName.ToLower() == categoryViewModel.CategoryName.ToLower() || c.CategoryCode.ToLower() == categoryViewModel.CategoryCode.ToLower() && c.IsActive == "True").ToList();
              
                if(categories != null && categories.Count > 0)
                {
                    foreach(var category in categories)
                    {
                        if (category.CategoryId == categoryViewModel.CategoryId)
                        {
                            status = "no";
                            break;
                        }
                        if (category.CategoryName == categoryViewModel.CategoryName)
                        {
                            status = "name";
                            break;
                        }
                        if (category.CategoryCode == categoryViewModel.CategoryCode)
                        {
                            status = "code";
                            break;
                        }
                        else
                        {
                            status = "exist";
                            break;
                        }
                    }
                }
            }
            return status;

        }
        public bool SaveCategory(Category category)
        {
            db.Categories.Add(category);
            return db.SaveChanges() > 0;
        }
        public bool UpdateCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool DeleteCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public List<Category> GetCategories()
        {
            return db.Categories.Where(c => c.IsActive == "True").ToList();
        }
        public Category CategoryGetById(Category category)
        {
            var aCategory = db.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            return aCategory;
        }
    }
}
