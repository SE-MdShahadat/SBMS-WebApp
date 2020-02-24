using SBMSwebApp.BLL.BLL;
using SBMSwebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMSwebApp.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager _customerManager= new CustomerManager();
        Customer customer= new Customer();

        // GET: Customer
        public ActionResult Index()
        {
            List<CustomerViewModel> customers= _customerManager.GetCustomers().Select(c => new CustomerViewModel { Id = c.Id, Code = c.Code, Name = c.Name,  Address=c.Address, Email=c.Email, Contact=c.Contact, LoyaltyPoint=c.LoyaltyPoint, IsActive = c.IsActive, Date = c.Date }).ToList();
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = customers;
            return View(customerViewModel);
        }
        [HttpPost]
        public ActionResult Index(CustomerViewModel customerViewModel)
        {
            List<CustomerViewModel> customers = _customerManager.SearchCustomer(customerViewModel).Select(c => new CustomerViewModel { Id = c.Id, Code = c.Code, Name = c.Name,  Address = c.Address, Email = c.Email, Contact = c.Contact, LoyaltyPoint = c.LoyaltyPoint, IsActive = c.IsActive, Date = c.Date }).ToList();
            CustomerViewModel customer = new CustomerViewModel();
            customer.Customers = customers;
            return View(customer);
        }
        public ActionResult SaveCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveCustomer(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                customerViewModel.ActionType = "Insert";
                var status = _customerManager.IsExistCustomer(customerViewModel);
                if (status == "no")
                {
                    customer.Name = customerViewModel.Name;
                    customer.Code = customerViewModel.Code;
                    customer.Address = customerViewModel.Address;
                    customer.Email = customerViewModel.Email;
                    customer.Contact = customerViewModel.Contact;
                    customer.LoyaltyPoint = customerViewModel.LoyaltyPoint;
                    customer.IsActive = customerViewModel.IsActive;
                    customer.Date = customerViewModel.Date;
                    if (_customerManager.SaveCustomer(customer))
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
                    ViewBag.Message = "This customer code is already exist!";
                }
                if (status == "contact")
                {
                    ViewBag.Message = "This customer contact is already exist!";
                }
                if (status == "email")
                {
                    ViewBag.Message = "This customer email is already exist!";
                }

            }
            else
            {
                ViewBag.Message = "Input Validation Error!";
            }
            return View(customerViewModel);
        }
        public ActionResult UpdateCustomer(int id)
        {
            if (id > 0)
            {
                customer.Id = id;
                var aCustomer = _customerManager.CustomerGetById(customer);
                if (aCustomer != null)
                {
                    CustomerViewModel customerViewModel = new CustomerViewModel();
                    customerViewModel.Id = aCustomer.Id;
                    customerViewModel.Name = aCustomer.Name;
                    customerViewModel.Code = aCustomer.Code;
                    customerViewModel.Address = aCustomer.Address;
                    customerViewModel.Email = aCustomer.Email;
                    customerViewModel.Contact = aCustomer.Contact;
                    customerViewModel.LoyaltyPoint = aCustomer.LoyaltyPoint;
                    customerViewModel.IsActive = aCustomer.IsActive;
                    customerViewModel.Date = aCustomer.Date;
                    return View(customerViewModel);
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
        public ActionResult UpdateCustomer(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                customerViewModel.ActionType = "Update";
                var status = _customerManager.IsExistCustomer(customerViewModel);
                if (status == "no")
                {
                    customer.Id = customerViewModel.Id;
                    customer = _customerManager.CustomerGetById(customer);
                    customer.Name = customerViewModel.Name;
                    customer.Code = customerViewModel.Code;
                    customer.Address = customerViewModel.Address;
                    customer.Email = customerViewModel.Email;
                    customer.Contact = customerViewModel.Contact;
                    customer.LoyaltyPoint = customerViewModel.LoyaltyPoint;
                    customer.IsActive = customerViewModel.IsActive;
                    customer.Date = customerViewModel.Date;
                    if (_customerManager.UpdateCustomer(customer))
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
                    ViewBag.Message = "This customer code is already exist!";
                }
                if (status == "contact")
                {
                    ViewBag.Message = "This customer contact is already exist!";
                }
                if (status == "email")
                {
                    ViewBag.Message = "This customer email is already exist!";
                }

            }
            else
            {
                ViewBag.Message = "Input Validation Failed";
            }
            return View(customerViewModel);
        }
        public ActionResult GetCustomerDetails(int id)
        {
            if (id > 0)
            {
                customer.Id = id;
                var aCustomer = _customerManager.CustomerGetById(customer);
                if (aCustomer != null)
                {
                    CustomerViewModel customerViewModel = new CustomerViewModel();
                    customerViewModel.Id = aCustomer.Id;
                    customerViewModel.Name = aCustomer.Name;
                    customerViewModel.Code = aCustomer.Code;
                    customerViewModel.Address = aCustomer.Address;
                    customerViewModel.Email = aCustomer.Email;
                    customerViewModel.Contact = aCustomer.Contact;
                    customerViewModel.LoyaltyPoint = aCustomer.LoyaltyPoint;
                    customerViewModel.IsActive = aCustomer.IsActive;
                    customerViewModel.Date = aCustomer.Date;
                    return View(customerViewModel);
                }
            }
            else
            {
                return HttpNotFound();
            }
            return View();
        }

        public ActionResult DeleteCustomer(int id)
        {
            if (id > 0)
            {
                customer.Id = id;
                var aCustomer = _customerManager.CustomerGetById(customer);
                if (aCustomer != null)
                {
                    CustomerViewModel customerViewModel = new CustomerViewModel();
                    customerViewModel.Id = aCustomer.Id;
                    customerViewModel.Name = aCustomer.Name;
                    customerViewModel.Code = aCustomer.Code;
                    customerViewModel.Address = aCustomer.Address;
                    customerViewModel.Email = aCustomer.Email;
                    customerViewModel.Contact = aCustomer.Contact;
                    customerViewModel.LoyaltyPoint = aCustomer.LoyaltyPoint;
                    customerViewModel.IsActive = aCustomer.IsActive;
                    customerViewModel.Date = aCustomer.Date;
                    return View(customerViewModel);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteCustomer(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Id > 0)
            {
                customer.Id = customerViewModel.Id;
                customer.Name = customerViewModel.Name;
                customer.Code = customerViewModel.Code;
                customer.Address = customerViewModel.Address;
                customer.Email = customerViewModel.Email;
                customer.Contact = customerViewModel.Contact;
                customer.LoyaltyPoint = customerViewModel.LoyaltyPoint;
                customer.IsActive = customerViewModel.IsActive;
                customer.Date = customerViewModel.Date;
                if (_customerManager.DeleteCustomer(customer))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}