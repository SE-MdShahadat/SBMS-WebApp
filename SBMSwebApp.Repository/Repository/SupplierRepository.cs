using SBMSwebApp.DatabaseContext.DatabaseContext;
using SBMSwebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.Repository.Repository
{
    public class SupplierRepository
    {
        SBMSdbContext db = new SBMSdbContext();
        public List<Supplier> SearchSupplier(SupplierViewModel supplierViewModel)
        {
            var suppliers = db.Suppliers.Where(c => c.Name.ToLower().Contains(supplierViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.Code.ToLower().Contains(supplierViewModel.SearchText.ToLower()) && c.IsActive == "True").ToList();
            return suppliers;
        }
        public string IsExistSupplier(SupplierViewModel supplierViewModel)
        {
            string status = "";
            if (supplierViewModel.ActionType == "Insert")
            {
                var aSupplier = db.Suppliers.Where(c => c.Email.ToLower() == supplierViewModel.Email.ToLower() || c.Code.ToLower() == supplierViewModel.Code.ToLower() && c.IsActive == "True").FirstOrDefault();
                if (aSupplier != null)
                {
                    if (aSupplier.Email == supplierViewModel.Email)
                    {
                        return status = "email";

                    }
                    if (aSupplier.Code == supplierViewModel.Code)
                    {
                        return status = "code";
                    }
                    if (aSupplier.Contact == supplierViewModel.Contact)
                    {
                        return status = "contact";
                    }
                }
                else return status = "no";

            }
            if (supplierViewModel.ActionType == "Update")
            {

                var suppliers = db.Suppliers.Where(c => c.Email.ToLower() == supplierViewModel.Email.ToLower() || c.Code.ToLower() == supplierViewModel.Code.ToLower() && c.IsActive == "True").ToList();

                if (suppliers != null && suppliers.Count > 0)
                {
                    foreach (var supplier in suppliers)
                    {
                        if (supplier.Id == supplierViewModel.Id)
                        {
                            status = "no";
                            break;
                        }
                        if (supplier.Email == supplierViewModel.Email)
                        {
                            status = "email";
                            break;
                        }
                        if (supplier.Contact == supplierViewModel.Code)
                        {
                            status = "contact";
                            break;
                        }
                        else
                        {
                            status = "exist";
                            break;
                        }
                    }
                }
            }
            return status;

        }
        public bool SaveSupplier(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
            return db.SaveChanges() > 0;
        }
        public bool UpdateSupplier(Supplier supplier)
        {
            db.Entry(supplier).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool DeleteSupplier(Supplier supplier)
        {
            db.Entry(supplier).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public List<Supplier> GetSuppliers()
        {
            return db.Suppliers.Where(c => c.IsActive == "True").ToList();
        }
        public Supplier SupplierGetById(Supplier supplier)
        {
            var aSupplier = db.Suppliers.FirstOrDefault(c => c.Id == supplier.Id);
            return aSupplier;
        }
        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }
    }
}
