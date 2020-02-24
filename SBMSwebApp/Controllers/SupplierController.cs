using AutoMapper;
using SBMSwebApp.BLL.BLL;
using SBMSwebApp.Models;
using SBMSwebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMSwebApp.Controllers
{
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();
        Supplier supplier = new Supplier();

        // GET: Supplier
        public ActionResult Index()
        {
            List<SupplierViewModel> suppliers = _supplierManager.GetSuppliers().Select(c => new SupplierViewModel { Id = c.Id, Code = c.Code, Name = c.Name, Address = c.Address, Email = c.Email, Contact = c.Contact, ContactPerson = c.ContactPerson, IsActive = c.IsActive, Date = c.Date }).ToList();
            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = suppliers;
            return View(supplierViewModel);
        }
        [HttpPost]
        public ActionResult Index(SupplierViewModel supplierViewModel)
        {
            List<SupplierViewModel> suppliers = _supplierManager.SearchSupplier(supplierViewModel).Select(c => new SupplierViewModel { Id = c.Id, Code = c.Code, Name = c.Name, Address = c.Address, Email = c.Email, Contact = c.Contact, ContactPerson = c.ContactPerson, IsActive = c.IsActive, Date = c.Date }).ToList();
            SupplierViewModel supplier = new SupplierViewModel();
            supplier.Suppliers = suppliers;
            return View(supplier);
        }
        public ActionResult SaveSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveSupplier(SupplierViewModel supplierViewModel)
        {
            if (ModelState.IsValid)
            {
                supplierViewModel.ActionType = "Insert";
                var status = _supplierManager.IsExistSupplier(supplierViewModel);
                if (status == "no")
                {
                    supplier.Name = supplierViewModel.Name;
                    supplier.Code = supplierViewModel.Code;
                    supplier.Address = supplierViewModel.Address;
                    supplier.Email = supplierViewModel.Email;
                    supplier.Contact = supplierViewModel.Contact;
                    supplier.ContactPerson = supplierViewModel.ContactPerson;
                    supplier.IsActive = supplierViewModel.IsActive;
                    supplier.Date = supplierViewModel.Date;
                    if (_supplierManager.SaveSupplier(supplier))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Operation Failed!";
                    }
                }
                if (status == "code")
                {
                    ViewBag.Message = "This supplier code is already exist!";
                }
                if (status == "contact")
                {
                    ViewBag.Message = "This supplier contact is already exist!";
                }
                if (status == "email")
                {
                    ViewBag.Message = "This supplier email is already exist!";
                }

            }
            else
            {
                ViewBag.Message = "Input Validation Error!";
            }
            return View(supplierViewModel);
        }
        public ActionResult UpdateSupplier(int id)
        {
            if (id > 0)
            {
                supplier.Id = id;
                var aSupplier = _supplierManager.SupplierGetById(supplier);
                if (aSupplier != null)
                {
                    SupplierViewModel supplierViewModel = new SupplierViewModel();
                    supplierViewModel.Id = aSupplier.Id;
                    supplierViewModel.Name = aSupplier.Name;
                    supplierViewModel.Code = aSupplier.Code;
                    supplierViewModel.Address = aSupplier.Address;
                    supplierViewModel.Email = aSupplier.Email;
                    supplierViewModel.Contact = aSupplier.Contact;
                    supplierViewModel.ContactPerson = aSupplier.ContactPerson;
                    supplierViewModel.IsActive = aSupplier.IsActive;
                    supplierViewModel.Date = aSupplier.Date;
                    return View(supplierViewModel);
                }
                else
                {
                    ViewBag.Message = "No Data Found!";
                }
            }
            else
            {
                return HttpNotFound();
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSupplier(SupplierViewModel supplierViewModel)
        {
            if (ModelState.IsValid)
            {
                supplierViewModel.ActionType = "Update";
                var status = _supplierManager.IsExistSupplier(supplierViewModel);
                if (status == "no")
                {
                    supplier.Id = supplierViewModel.Id;
                    supplier = _supplierManager.SupplierGetById(supplier);
                    supplier.Name = supplierViewModel.Name;
                    supplier.Code = supplierViewModel.Code;
                    supplier.Address = supplierViewModel.Address;
                    supplier.Email = supplierViewModel.Email;
                    supplier.Contact = supplierViewModel.Contact;
                    supplier.ContactPerson = supplierViewModel.ContactPerson;
                    supplier.IsActive = supplierViewModel.IsActive;
                    supplier.Date = supplierViewModel.Date;
                    if (_supplierManager.UpdateSupplier(supplier))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Opereation Failed!";
                    }
                }
                if (status == "code")
                {
                    ViewBag.Message = "This supplier code is already exist!";
                }
                if (status == "contact")
                {
                    ViewBag.Message = "This supplier contact is already exist!";
                }
                if (status == "email")
                {
                    ViewBag.Message = "This supplier email is already exist!";
                }

            }
            else
            {
                ViewBag.Message = "Input Validation Failed";
            }
            return View(supplierViewModel);
        }
        public ActionResult GetSupplierDetails(int id)
        {
            if (id > 0)
            {
                supplier.Id = id;
                var aSupplier = _supplierManager.SupplierGetById(supplier);
                if (aSupplier != null)
                {
                    SupplierViewModel supplierViewModel = new SupplierViewModel();
                    supplierViewModel.Id = aSupplier.Id;
                    supplierViewModel.Name = aSupplier.Name;
                    supplierViewModel.Code = aSupplier.Code;
                    supplierViewModel.Address = aSupplier.Address;
                    supplierViewModel.Email = aSupplier.Email;
                    supplierViewModel.Contact = aSupplier.Contact;
                    supplierViewModel.ContactPerson = aSupplier.ContactPerson;
                    supplierViewModel.IsActive = aSupplier.IsActive;
                    supplierViewModel.Date = aSupplier.Date;
                    return View(supplierViewModel);
                }
            }
            else
            {
                return HttpNotFound();
            }
            return View();
        }

        public ActionResult DeleteSupplier(int id)
        {
            if (id > 0)
            {
                supplier.Id = id;
                var aSupplier = _supplierManager.SupplierGetById(supplier);
                if (aSupplier != null)
                {
                    SupplierViewModel supplierViewModel = new SupplierViewModel();
                    supplierViewModel.Id = aSupplier.Id;
                    supplierViewModel.Name = aSupplier.Name;
                    supplierViewModel.Code = aSupplier.Code;
                    supplierViewModel.Address = aSupplier.Address;
                    supplierViewModel.Email = aSupplier.Email;
                    supplierViewModel.Contact = aSupplier.Contact;
                    supplierViewModel.ContactPerson = aSupplier.ContactPerson;
                    supplierViewModel.IsActive = aSupplier.IsActive;
                    supplierViewModel.Date = aSupplier.Date;
                    return View(supplierViewModel);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteSupplier(SupplierViewModel supplierViewModel)
        {
            if (supplierViewModel.Id > 0)
            {
                supplier.Id = supplierViewModel.Id;
                supplier.Name = supplierViewModel.Name;
                supplier.Code = supplierViewModel.Code;
                supplier.Address = supplierViewModel.Address;
                supplier.Email = supplierViewModel.Email;
                supplier.Contact = supplierViewModel.Contact;
                supplier.ContactPerson = supplierViewModel.ContactPerson;
                supplier.IsActive = supplierViewModel.IsActive;
                supplier.Date = supplierViewModel.Date;
                if (_supplierManager.DeleteSupplier(supplier))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}