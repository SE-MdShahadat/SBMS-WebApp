using SBMSwebApp.Models.Models;
using SBMSwebApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.BLL.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository= new CustomerRepository();
        public List<Customer> SearchCustomer(CustomerViewModel customerViewModel)
        {
            return _customerRepository.SearchCustomer(customerViewModel);
        }
        public string IsExistCustomer(CustomerViewModel customerViewModel)
        {
            return _customerRepository.IsExistCustomer(customerViewModel);
        }
        public bool SaveCustomer(Customer customer)
        {
            return _customerRepository.SaveCustomer(customer);
        }
        public bool UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }
        public bool DeleteCustomer(Customer customer)
        {
            return _customerRepository.DeleteCustomer(customer);
        }
        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }
        public Customer CustomerGetById(Customer customer)
        {
            return _customerRepository.CustomerGetById(customer);
        }
    }
}
