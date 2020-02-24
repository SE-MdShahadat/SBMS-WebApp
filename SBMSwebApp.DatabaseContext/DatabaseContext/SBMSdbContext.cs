

using SBMSwebApp.Models.Models;
using System.Data.Entity;

namespace SBMSwebApp.DatabaseContext.DatabaseContext
{
    public class SBMSdbContext:DbContext
    {
        public SBMSdbContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetails { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesDetails> SalesDetails { get; set; }
        public DbSet<StockOut> StockOuts { get; set; }

    }
}
