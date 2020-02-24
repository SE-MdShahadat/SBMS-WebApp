using SBMSwebApp.DatabaseContext.DatabaseContext;
using SBMSwebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.Repository.Repository
{
    public class StockOutRepository
    {
        SBMSdbContext db = new SBMSdbContext();
        public bool SaveStockOutProduct(StockOut stockOut)
        {
            db.StockOuts.Add(stockOut);
            return db.SaveChanges() > 0;
        }
    }
}
