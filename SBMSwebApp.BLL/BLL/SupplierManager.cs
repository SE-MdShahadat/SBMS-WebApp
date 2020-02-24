using SBMSwebApp.Models.Models;
using SBMSwebApp.Repository.Repository;
using System.Collections.Generic;

namespace SBMSwebApp.BLL.BLL
{
    public class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();
        public List<Supplier> SearchSupplier(SupplierViewModel supplierViewModel)
        {
            return _supplierRepository.SearchSupplier(supplierViewModel);
        }
        public string IsExistSupplier(SupplierViewModel supplierViewModel)
        {
            return _supplierRepository.IsExistSupplier(supplierViewModel);
        }
        public bool SaveSupplier(Supplier supplier)
        {
            return _supplierRepository.SaveSupplier(supplier);
        }
        public bool UpdateSupplier(Supplier supplier)
        {
            return _supplierRepository.UpdateSupplier(supplier);
        }
        public bool DeleteSupplier(Supplier supplier)
        {
            return _supplierRepository.DeleteSupplier(supplier);
        }
        public List<Supplier> GetSuppliers()
        {
            return _supplierRepository.GetSuppliers();
        }
        public Supplier SupplierGetById(Supplier supplier)
        {
            return _supplierRepository.SupplierGetById(supplier);
        }
        public List<Supplier> GetAll()
        {
            return _supplierRepository.GetAll();
        }

    }
}
