using SBMSwebApp.DatabaseContext.DatabaseContext;
using SBMSwebApp.Models.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SBMSwebApp.Repository.Repository
{
    public class ReportingRepository
    {
        SBMSdbContext db = new SBMSdbContext();
        public List<SalesDetails> PeriodictIncomeReport(ProductViewModel productViewModel)
        {
            List<SalesDetails> salesDetails = new List<SalesDetails>();
            var saleProducts = db.Sales.Where(c => c.Date >= productViewModel.StartDate && c.Date <= productViewModel.EndDate).ToList();
            foreach (var product in saleProducts)
            {

                var saleProductList = db.SalesDetails.Include(c => c.Product).Where(c => c.SalesId == product.Id).ToList();
                foreach (var salesProduct in saleProductList)
                {
                    salesDetails.Add(salesProduct);
                }
            }
            return salesDetails;
        }
        public List<PurchaseDetails> PeriodictIncomeReportOnPurchase(ProductViewModel productViewModel)
        {
            List<PurchaseDetails> purchaseDetails = new List<PurchaseDetails>();
            var purchaseProducts = db.Purchases.Where(c => c.Date >= productViewModel.StartDate && c.Date <= productViewModel.EndDate).ToList();
            foreach (var product in purchaseProducts)
            {
                var purchaseProductList = db.PurchaseDetails.Include(c => c.Product).Where(c => c.PurchaseId == product.Id).ToList();
                foreach (var purchaseProduct in purchaseProductList)
                {
                    purchaseDetails.Add(purchaseProduct);
                }
            }
            return purchaseDetails;
        }
        public decimal GetSalesDiscountPercentByDate(int salesId)
        {
            decimal salesDiscountPercent = db.Sales.Where(c => c.Id == salesId).Select(c => c.DiscountPerCent).FirstOrDefault();
            return salesDiscountPercent;
        }
    }
}
