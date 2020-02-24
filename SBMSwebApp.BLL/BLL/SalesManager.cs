using SBMSwebApp.Models.Models;
using SBMSwebApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.BLL.BLL
{
    public class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();
        public int GetProductAvailableQuantity(Product product)
        {
            return _salesRepository.GetProductAvailableQuantity(product);
        }
        public bool SaveSalesProduct(Sales sales)
        {
            return _salesRepository.SaveSalesProduct(sales);
        }
    }
}
