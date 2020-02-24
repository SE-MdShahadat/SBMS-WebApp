using SBMSwebApp.DatabaseContext.DatabaseContext;
using SBMSwebApp.Models.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SBMSwebApp.Repository.Repository
{
    public class CustomerRepository
    {
        SBMSdbContext db = new SBMSdbContext();
        public List<Customer> SearchCustomer(CustomerViewModel customerViewModel)
        {
            var customers = db.Customers.Where(c => c.Name.ToLower().Contains(customerViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.Code.ToLower().Contains(customerViewModel.SearchText.ToLower()) && c.IsActive == "True").ToList();
            return customers;
        }
        public string IsExistCustomer(CustomerViewModel customerViewModel)
        {
            string status = "";
            if (customerViewModel.ActionType == "Insert")
            {
                var aCustomer = db.Customers.Where(c => c.Email.ToLower() == customerViewModel.Email.ToLower() || c.Code.ToLower() == customerViewModel.Code.ToLower() && c.IsActive == "True").FirstOrDefault();
                if (aCustomer != null)
                {
                    if (aCustomer.Email == customerViewModel.Email)
                    {
                        return status = "email";

                    }
                    if (aCustomer.Code == customerViewModel.Code)
                    {
                        return status = "code";
                    }
                    if (aCustomer.Contact == customerViewModel.Contact)
                    {
                        return status = "contact";
                    }
                }
                else return status = "no";

            }
            if (customerViewModel.ActionType == "Update")
            {

                var customers = db.Customers.Where(c => c.Email.ToLower() == customerViewModel.Email.ToLower() || c.Code.ToLower() == customerViewModel.Code.ToLower() && c.IsActive == "True").ToList();

                if (customers != null && customers.Count > 0)
                {
                    foreach (var customer in customers)
                    {
                        if (customer.Id == customerViewModel.Id)
                        {
                            status = "no";
                            break;
                        }
                        if (customer.Email == customerViewModel.Email)
                        {
                            status = "email";
                            break;
                        }
                        if (customer.Contact == customerViewModel.Code)
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
        public bool SaveCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            return db.SaveChanges() > 0;
        }
        public bool UpdateCustomer(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool DeleteCustomer(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public List<Customer> GetCustomers()
        {
            return db.Customers.Where(c => c.IsActive == "True").ToList();
        }
        public Customer CustomerGetById(Customer customer)
        {
            var aCustomer = db.Customers.FirstOrDefault(c => c.Id == customer.Id);
            return aCustomer;
        }
    }
}
