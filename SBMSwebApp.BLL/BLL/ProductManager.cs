using SBMSwebApp.Models.Models;
using SBMSwebApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.BLL.BLL
{
    public class ProductManager
    {
        ProductRepository _productRepository = new ProductRepository();
        //StockRepository _stockRepository = new StockRepository();
        public bool SaveProduct(Product product)
        {
            return _productRepository.SaveProduct(product);
        }
        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
        public List<Product> SearchProducts(ProductViewModel productViewModel)
        {
            return _productRepository.SearchProducts(productViewModel);
        }
        public Product GetProductById(Product product)
        {
            return _productRepository.GetProductById(product);
        }
        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }
        public bool DeleteProduct(Product product)
        {
            return _productRepository.DeleteProduct(product);
        }
        public bool IsExistProduct(ProductViewModel productViewModel)
        {
            return _productRepository.IsExistProduct(productViewModel);
        }
        //public PurchaseDetails PurchaseDetails(Product product, DateTime startDate, DateTime endDate)
        //{
        //    return _stockRepository.PurchaseDetails(product, startDate, endDate);
        //}
        //public List<Product> GetProductsWithCatagory(Product product)
        //{
        //    return _productRepository.GetProductsWithCatagory(product);
        //}

        //public List<Product> GetAll()
        //{
        //    return _productRepository.GetAll();
        //}
        //public PurchaseDetails GetStockQuantity(int product)
        //{
        //    return _productRepository.GetStockQuantity(product);
        //}
    }
}
