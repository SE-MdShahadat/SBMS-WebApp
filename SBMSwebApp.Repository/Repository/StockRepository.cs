using SBMSwebApp.DatabaseContext.DatabaseContext;
using SBMSwebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.Repository.Repository
{
    public class StockRepository
    {
        SBMSdbContext db = new SBMSdbContext();
        public int ExpiredProductQuantity(Product product)
        {
            int expiredProductQuantity = 0;
            int salesQuantity = 0;
            int stockOutQuantity = 0;
            DateTime today = DateTime.Now;
            var aProducts = db.PurchaseDetails.Where(c => c.ProductId == product.ProductId).ToList();
            foreach (var aProduct in aProducts)
            {
                if (aProduct.ExpireDate < today)
                {
                    expiredProductQuantity += aProduct.Quantity;
                }
            }
            var sales = db.SalesDetails.Where(c => c.ProductId == product.ProductId).ToList();
            foreach (var sale in sales)
            {
                salesQuantity += sale.Quantity;
            }
            var stockOutProducts = db.StockOuts.Where(c => c.ProductId == product.ProductId).ToList();
            foreach (var stockOutProduct in stockOutProducts)
            {
                stockOutQuantity += stockOutProduct.Quantity;
            }
            expiredProductQuantity -= salesQuantity + stockOutQuantity;
            if (expiredProductQuantity < 0)
            {
                expiredProductQuantity = 0;
            }
            return expiredProductQuantity;
        }
        public int ExpiredProductQuantityByExpiredDate(ProductViewModel productViewModel)
        {
            int expiredQuantity = 0;
            int salesQuantity = 0;
            int stockOutQuantity = 0;
            var purchasesExpiredProducts = db.PurchaseDetails.Where(c => c.ProductId == productViewModel.ProductId && c.ExpireDate >= productViewModel.StartDate && c.ExpireDate <= productViewModel.EndDate).ToList();
            foreach (var purchaseExpiredProduct in purchasesExpiredProducts)
            {
                expiredQuantity += purchaseExpiredProduct.Quantity;
            }
            var sales = db.SalesDetails.Where(c => c.ProductId == productViewModel.ProductId).ToList();
            foreach (var sale in sales)
            {
                salesQuantity += sale.Quantity;
            }
            var stockOutProducts = db.StockOuts.Where(c => c.ProductId == productViewModel.ProductId).ToList();
            foreach (var stockOutProduct in stockOutProducts)
            {
                stockOutQuantity += stockOutProduct.Quantity;
            }
            expiredQuantity -= salesQuantity + stockOutQuantity;
            if (expiredQuantity < 0)
            {
                expiredQuantity = 0;
            }
            return expiredQuantity;
        }
        public int GetOpeningBalance(ProductViewModel productViewModel)
        {
            int productQuantity = 0;
            if (productViewModel.StartDate == null && productViewModel.EndDate == null && productViewModel.ProductId > 0)
            {
                DateTime previousDay = DateTime.Now.AddDays(-1);
                //DateTime today = DateTime.Now;
                DateTime previousMonth = DateTime.Now.AddMonths(-1);
                //int productQuantity = 0;
                var previousMonthPurchaseProduct = db.Purchases.Where(c => c.Date >= previousMonth && c.Date < previousDay).ToList();
                //var previousMonthPurchaseProduct = db.Purchases.Where(c => c.Date >= previousMonth && c.Date < today).ToList();
                foreach (var purchaseProduct in previousMonthPurchaseProduct)
                {
                    var purchasseDetails = db.PurchaseDetails.Where(c => c.PurchaseId == purchaseProduct.Id && c.ProductId == productViewModel.ProductId).ToList();
                    foreach (var product in purchasseDetails)
                    {
                        productQuantity += product.Quantity;
                    }
                }
                //return productQuantity;
            }
            if (productViewModel.StartDate != null && productViewModel.EndDate != null && productViewModel.ProductId > 0)
            {
                DateTime startMonth = Convert.ToDateTime(productViewModel.StartDate);
                DateTime previousMonth = startMonth.AddMonths(-1);

                var purchaseProducts = db.Purchases.Where(c => c.Date >= previousMonth && c.Date < productViewModel.StartDate).ToList();
                foreach (var purchaseProduct in purchaseProducts)
                {
                    var purchasseDetails = db.PurchaseDetails.Where(c => c.PurchaseId == purchaseProduct.Id && c.ProductId == productViewModel.ProductId).ToList();
                    foreach (var product in purchasseDetails)
                    {
                        productQuantity += product.Quantity;
                    }
                }
            }
            return productQuantity;
        }
        public int GetInBalance(ProductViewModel productViewModel)
        {
            int productQuantity = 0;
            if (productViewModel.StartDate == null && productViewModel.EndDate == null && productViewModel.ProductId > 0)
            {
                DateTime today = DateTime.Now;
                DateTime previousDay = today.AddDays(-1);
                DateTime nextDay = today.AddDays(1);
                var nextMonthPurchaseProduct = db.Purchases.Where(c => c.Date > previousDay && c.Date < nextDay).ToList();
                foreach (var purchaseProduct in nextMonthPurchaseProduct)
                {
                    var purchasseDetails = db.PurchaseDetails.Where(c => c.PurchaseId == purchaseProduct.Id && c.ProductId == productViewModel.ProductId).ToList();
                    foreach (var product in purchasseDetails)
                    {
                        productQuantity += product.Quantity;
                    }
                }
            }
            if (productViewModel.StartDate != null && productViewModel.EndDate != null && productViewModel.ProductId > 0)
            {
                var purchaseProducts = db.Purchases.Where(c => c.Date >= productViewModel.StartDate && c.Date <= productViewModel.EndDate).ToList();
                foreach (var purchaseProduct in purchaseProducts)
                {
                    var purchasseDetails = db.PurchaseDetails.Where(c => c.PurchaseId == purchaseProduct.Id && c.ProductId == productViewModel.ProductId).ToList();
                    foreach (var product in purchasseDetails)
                    {
                        productQuantity += product.Quantity;
                    }
                }
            }
            return productQuantity;
        }
        public int GetOutBalance(ProductViewModel productViewModel)
        {
            int productQuantity = 0;
            if (productViewModel.StartDate == null && productViewModel.EndDate == null && productViewModel.ProductId > 0)
            {
                DateTime today = DateTime.Now;
                DateTime previousDay = today.AddDays(-1);
                DateTime nextDay = today.AddDays(1);

                var nextMonthSalesProduct = db.Sales.Where(c => c.Date > previousDay && c.Date < nextDay).ToList();
                foreach (var salesProduct in nextMonthSalesProduct)
                {
                    var salesDetails = db.SalesDetails.Where(c => c.SalesId == salesProduct.Id && c.ProductId == productViewModel.ProductId).ToList();
                    foreach (var product in salesDetails)
                    {
                        productQuantity += product.Quantity;
                    }
                }
            }
            if (productViewModel.StartDate != null && productViewModel.EndDate != null && productViewModel.ProductId > 0)
            {
                var salesProducts = db.Sales.Where(c => c.Date >= productViewModel.StartDate && c.Date <= productViewModel.EndDate).ToList();
                foreach (var salesProduct in salesProducts)
                {
                    var salesDetails = db.SalesDetails.Where(c => c.SalesId == salesProduct.Id && c.ProductId == productViewModel.ProductId).ToList();
                    foreach (var product in salesDetails)
                    {
                        productQuantity += product.Quantity;
                    }
                }
            }
            return productQuantity;
        }
    }
}
