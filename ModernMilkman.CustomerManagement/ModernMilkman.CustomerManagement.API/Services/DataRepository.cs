using Microsoft.Extensions.Logging;
using ModernMilkman.CustomerManagement.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkman.CustomerManagement.API.Services
{
    public class DataRepository : IDataRepository
    {
        private readonly List<Customer> _customerList = new List<Customer>();
        private readonly ILogger<DataRepository> _logger;

        public DataRepository(ILogger<DataRepository> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Add a customer to the list
        /// </summary>
        /// <param name="customer">customer object</param>
        public void AddCustomer(Customer customer)
        {
            _logger.LogInformation("Adding customer");

            _logger.LogDebug("Adding {@customer}", customer);

            if (_customerList.Any(item => item.CustomerId == customer.CustomerId))
            {
                _logger.LogError("Customer already exists", customer);
                throw new ArgumentException("Customer already exists");
            }

            _customerList.Add(customer);

            _logger.LogInformation("Customer added successfully");
        }

        /// <summary>
        /// Delete an address from a customer
        /// </summary>
        /// <param name="customerId">customer id</param>
        /// <param name="addressId">address id</param>
        public void DeleteAddress(int customerId, int addressId)
        {
            _logger.LogInformation($"Deleting an address for customer Id {customerId} and address Id {addressId}");

            Customer customerReturned = _customerList.FirstOrDefault(item => item.CustomerId == customerId);

            if (customerReturned == null)
            {
                _logger.LogError($"Customer Does Not Exist for customer Id {customerId}");

                throw new NullReferenceException("Customer Does Not Exist");
            }

            Address addressReturned = customerReturned.Addresses.FirstOrDefault(item => item.AddressId == addressId);

            if (addressReturned == null)
            {
                _logger.LogError($"Address Does Not Exist for address Id {addressId}");

                throw new NullReferenceException("Address Does Not Exist");
            }

            if (customerReturned.Addresses.Count == 1)
            {
                _logger.LogError($"Cannot delete address customer has only one address associated");

                throw new ArgumentException("Customer must have at least one address");
            }

            customerReturned.Addresses.Remove(addressReturned);

            _logger.LogInformation("Address removed");
        }

        /// <summary>
        /// Delete a customer from the list
        /// </summary>
        /// <param name="customerId"></param>
        public void DeleteCustomer(int customerId)
        {
            _logger.LogInformation($"Deleting a customer for customer Id {customerId}");

            Customer customerReturned = _customerList.FirstOrDefault(item => item.CustomerId == customerId);

            if (customerReturned == null)
            {
                _logger.LogError($"Customer Does Not Exist for customer Id {customerId}");

                throw new NullReferenceException("Customer Does Not Exist");
            }

            _customerList.Remove(customerReturned);

            _logger.LogInformation("Customer removed");
        }

        public void MarkCustomerInActive(int customerId)
        {
            _logger.LogInformation($"Deactivating customer for customer Id {customerId}");

            Customer customerReturned = _customerList.FirstOrDefault(item => item.CustomerId == customerId);

            if (customerReturned == null)
            {
                _logger.LogError($"Customer Does Not Exist for customer Id {customerId}");

                throw new NullReferenceException("Customer Does Not Exist");
            }

            customerReturned.IsActive = false;

            _logger.LogInformation("Customer is now inactive");
        }

        /// <summary>
        /// Return all active customers
        /// </summary>
        /// <returns>Return a list of customer objects</returns>
        public List<Customer> ReturnAllActiveCustomers()
        {
            _logger.LogInformation("Returning all active customers");

            return _customerList.Where(customer => customer.IsActive).ToList();
        }

        /// <summary>
        /// Return all customers from the data store
        /// </summary>
        /// <returns>Return only active customers</returns>
        public List<Customer> ReturnAllCustomers()
        {
            _logger.LogInformation("Returning all customers");

            return _customerList;
        }

        /// <summary>
        /// Set a non-main address to be the main address for a customer
        /// </summary>
        /// <param name="customerId">customer id</param>
        /// <param name="addressId">address id</param>
        public void SetMainAddress(int customerId, int addressId)
        {
            _logger.LogInformation($"Setting main address for customer Id {customerId} for address id {addressId}");

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

            _logger.LogInformation("Main Address successfully set");
        }
    }
}
