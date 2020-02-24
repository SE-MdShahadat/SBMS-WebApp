using SBMSwebApp.Models.Models;
using SBMSwebApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.BLL.BLL
{
    public class StockOutManager
    {
        StockOutRepository _stockOutRepository = new StockOutRepository();
        public bool SaveStockOutProduct(StockOut stockOut)
        {
            return _stockOutRepository.SaveStockOutProduct(stockOut);
        }
    }
}
