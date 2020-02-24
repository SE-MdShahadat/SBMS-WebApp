using SBMSwebApp.DatabaseContext.DatabaseContext;
using SBMSwebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.Repository.Repository
{
    public class SalesRepository
    {
        SBMSdbContext db = new SBMSdbContext();
        public int GetProductAvailableQuantity(Product product)
        {
            int availableQuantity = 0;
            int purchaseQuantity = 0;
            int salesQuantity = 0;
            int stockOutQuantity = 0;
            var purchaseProducts = db.PurchaseDetails.Where(c => c.ProductId == product.ProductId).ToList();
            foreach (var purchaseProduct in purchaseProducts)
            {
                purchaseQuantity += purchaseProduct.Quantity;
            }
            var salesProducts = db.SalesDetails.Where(c => c.ProductId == product.ProductId).ToList();
            foreach (var salesProduct in salesProducts)
            {
                salesQuantity += salesProduct.Quantity;
            }
            var stockOutProducts = db.StockOuts.Where(c => c.ProductId == product.ProductId).ToList();
            foreach (var stockOutProduct in stockOutProducts)
            {
                stockOutQuantity += stockOutProduct.Quantity;
            }
            availableQuantity = purchaseQuantity - (salesQuantity + stockOutQuantity);
            return availableQuantity;
        }
        public bool SaveSalesProduct(Sales sales)
        {
            db.Sales.Add(sales);
            return db.SaveChanges() > 0;
        }
    }
}
