using ModernMilkman.CustomerManagement.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkman.CustomerManagement.API.Services
{
    public class DataRepository : IDataRepository
    {
        private readonly List<Customer> _customerList;

        public DataRepository(List<Customer> customerList)
        {
            _customerList = customerList ?? throw new ArgumentNullException(nameof(customerList));
        }

        public void AddCustomer(Customer customer)
        {
            if (_customerList.Any(item => item.CustomerId == customer.CustomerId))
            {
                throw new ArgumentException("Customer already exists");
            }

            _customerList.Add(customer);
        }

        public void DeleteAddress(int customerId, int addressId)
        {
            Customer customerReturned = _customerList.FirstOrDefault(item => item.CustomerId == customerId);

            if (customerReturned == null)
            {
                throw new NullReferenceException("Customer Does Not Exist");
            }

            Address addressReturned = customerReturned.Addresses.FirstOrDefault(item => item.AddressId == addressId);

            if (addressReturned == null)
            {
                throw new NullReferenceException("Address Does Not Exist");
            }

            if (customerReturned.Addresses.Count == 1)
            {
                throw new ArgumentException("Customer must have at least one address");
            }

            customerReturned.Addresses.Remove(addressReturned);
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customerReturned = _customerList.FirstOrDefault(item => item.CustomerId == customerId);

            if (customerReturned == null)
            {
                throw new NullReferenceException("Customer Does Not Exist");
            }

            _customerList.Remove(customerReturned);
        }

        public void MarkCustomerInActive(int customerId)
        {
            Customer customerReturned = _customerList.FirstOrDefault(item => item.CustomerId == customerId);

            if (customerReturned == null)
            {
                throw new NullReferenceException("Customer Does Not Exist");
            }

            customerReturned.IsActive = false;
        }

        public List<Customer> ReturnAllActiveCustomers()
        {
            return _customerList.Where(customer => customer.IsActive).ToList();
        }

        public List<Customer> ReturnAllCustomers()
        {
            return _customerList;
        }

        public void SetMainAddress(int customerId, int addressId)
        {
            Customer customerReturned = _customerList.FirstOrDefault(item => item.CustomerId == customerId);

            if (customerReturned == null)
            {
                throw new NullReferenceException("Customer Does Not Exist");
            }

            Address addressReturned = customerReturned.Addresses.FirstOrDefault(item => item.AddressId == addressId);

            if (addressReturned == null)
            {
                throw new NullReferenceException("Address Does Not Exist");
            }

            customerReturned.MainAddress = addressReturned;
        }
    }
}
