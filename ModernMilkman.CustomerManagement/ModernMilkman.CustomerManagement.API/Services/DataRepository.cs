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
        private readonly Dictionary<int, Customer> _customerDict = new Dictionary<int, Customer>();
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

            if (_customerDict.ContainsKey(customer.Id))
            {
                _logger.LogError("Customer already exists", customer);
                throw new ArgumentException("Customer already exists");
            }

            _customerDict.Add(customer.Id, customer);

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

            _customerDict.TryGetValue(customerId, out var customerReturned);

            if (customerReturned == null)
            {
                _logger.LogError($"Customer Does Not Exist for customer Id {customerId}");

                throw new NullReferenceException("Customer Does Not Exist");
            }

            customerReturned.Addresses.TryGetValue(addressId, out var addressReturned);

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

            customerReturned.Addresses.Remove(addressReturned.Id);

            _logger.LogInformation("Address removed");
        }

        /// <summary>
        /// Delete a customer from the list
        /// </summary>
        /// <param name="customerId"></param>
        public void DeleteCustomer(int customerId)
        {
            _logger.LogInformation($"Deleting a customer for customer Id {customerId}");

            _customerDict.TryGetValue(customerId, out var customerReturned);

            if (customerReturned == null)
            {
                _logger.LogError($"Customer Does Not Exist for customer Id {customerId}");

                throw new NullReferenceException("Customer Does Not Exist");
            }

            _customerDict.Remove(customerReturned.Id);

            _logger.LogInformation("Customer removed");
        }

        public void MarkCustomerInActive(int customerId)
        {
            _logger.LogInformation($"Deactivating customer for customer Id {customerId}");

            _customerDict.TryGetValue(customerId, out var customerReturned);

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

            var resultReturn = (from pv in _customerDict
            where pv.Value.IsActive
            select pv.Value).ToList();

            return resultReturn;
        }

        /// <summary>
        /// Return all customers from the data store
        /// </summary>
        /// <returns>Return only active customers</returns>
        public List<Customer> ReturnAllCustomers()
        {
            _logger.LogInformation("Returning all customers");

            return _customerDict.Values.ToList();
        }

        /// <summary>
        /// Set a non-main address to be the main address for a customer
        /// </summary>
        /// <param name="customerId">customer id</param>
        /// <param name="addressId">address id</param>
        public void SetMainAddress(int customerId, int addressId)
        {
            _logger.LogInformation($"Setting main address for customer Id {customerId} for address id {addressId}");

            _customerDict.TryGetValue(customerId, out var customerReturned);

            if (customerReturned == null)
            {
                throw new NullReferenceException("Customer Does Not Exist");
            }

            customerReturned.Addresses.TryGetValue(addressId, out var addressReturned);

            if (addressReturned == null)
            {
                throw new NullReferenceException("Address Does Not Exist");
            }

            customerReturned.MainAddress = addressReturned;

            _logger.LogInformation("Main Address successfully set");
        }
    }
}
