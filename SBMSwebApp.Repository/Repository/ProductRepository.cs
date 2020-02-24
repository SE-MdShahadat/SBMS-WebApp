using SBMSwebApp.DatabaseContext.DatabaseContext;
using SBMSwebApp.Models.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SBMSwebApp.Repository.Repository
{
    public class ProductRepository
    {
        SBMSdbContext db = new SBMSdbContext();
        public bool SaveProduct(Product product)
        {
            db.Products.Add(product);
            return db.SaveChanges() > 0;
        }
        public List<Product> GetProducts()
        {
            return db.Products.Include(c => c.Category).Where(c => c.IsActive == "True").ToList();
        }
        public List<Product> SearchProducts(ProductViewModel productViewModel)
        {
            var products = db.Products.Include(c => c.Category).Where(c => c.ProductName.ToLower().Contains(productViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.ProductCode.ToLower().Contains(productViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.Category.CategoryName.ToLower().Contains(productViewModel.SearchText.ToLower()) && c.IsActive == "True").ToList();
            return products;
        }
        public Product GetProductById(Product product)
        {
            return db.Products.Include(c => c.Category).Where(c => c.ProductId == product.ProductId && c.IsActive == "True").FirstOrDefault();
        }
        public bool UpdateProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool DeleteProduct(Product product)
        {
            db.Products.Remove(product);
            return db.SaveChanges() > 0;
        }
        public bool IsExistProduct(ProductViewModel productViewModel)
        {
            if (productViewModel.ActionType == "Insert")
            {
                var aProduct = db.Products.Where(c => c.ProductName.ToLower() == productViewModel.ProductName.ToLower() && c.IsActive == "True").FirstOrDefault();
                if (aProduct != null)
                {
                    return true;
                }
            }
            if (productViewModel.ActionType == "Update")
            {
                var aProduct = db.Products.Where(c => c.ProductName.ToLower() == productViewModel.ProductName.ToLower() && c.IsActive == "True").FirstOrDefault();
                if (aProduct != null)
                {
                    if (aProduct.ProductId == productViewModel.ProductId)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        
       
    }
}
