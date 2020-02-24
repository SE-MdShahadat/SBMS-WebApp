using SBMSwebApp.Models.Models;
using SBMSwebApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.BLL.BLL
{
    public class ReportingManager
    {
        ReportingRepository _reportingRepository = new ReportingRepository();
        public List<SalesDetails> PeriodictIncomeReport(ProductViewModel productViewModel)
        {
            return _reportingRepository.PeriodictIncomeReport(productViewModel);
        }
        public List<PurchaseDetails> PeriodictIncomeReportOnPurchase(ProductViewModel productViewModel)
        {
            return _reportingRepository.PeriodictIncomeReportOnPurchase(productViewModel);
        }
        public decimal GetSalesDiscountPercentByDate(int salesId)
        {
            return _reportingRepository.GetSalesDiscountPercentByDate(salesId);
        }
    }
}
