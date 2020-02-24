using SBMSwebApp.Models.Models;
using SBMSwebApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.BLL.BLL
{
    public class StockManager
    {
        StockRepository _stockRepository = new StockRepository();
        public int ExpiredProductQuantity(Product product)
        {
            return _stockRepository.ExpiredProductQuantity(product);
        }
        public int ExpiredProductQuantityByExpiredDate(ProductViewModel productViewModel)
        {
            return _stockRepository.ExpiredProductQuantityByExpiredDate(productViewModel);
        }
        public int GetOpeningBalance(ProductViewModel productViewModel)
        {
            return _stockRepository.GetOpeningBalance(productViewModel);
        }
        public int GetInBalance(ProductViewModel productViewModel)
        {
            return _stockRepository.GetInBalance(productViewModel);
        }
        public int GetOutBalance(ProductViewModel productViewModel)
        {
            return _stockRepository.GetOutBalance(productViewModel);
        }
    }
}
