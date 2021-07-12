using Microsoft.Extensions.Logging.Abstractions;
using ModernMilkman.CustomerManagement.API.Model;
using ModernMilkman.CustomerManagement.API.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernMilkman.CustomerManagement.Test
{
    public class CustomerManagementTests
    {
        private IDataRepository _dataRepository;

        [SetUp]
        public void Setup()
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Address address2 = new Address()
            {
                Id = 2,
                AddressLine1 = "2 Street",
                Town = "Birmingham",
                Postcode = "B11 1AA"
            };

            Customer customer1 = new Customer()
            {
                Id = 1,
                Title = "Mr",
                Forename = "Andreas",
                Surname = "Anderson",
                EmailAddress = "aa@hotmail.com",
                MobileNumber = "0123456789",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 }, { address2.Id, address2 } },
                MainAddress = address1
            };

            Address address3 = new Address()
            {
                Id = 3,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Customer customer2 = new Customer()
            {
                Id = 2,
                Title = "Mr",
                Forename = "Bruce",
                Surname = "Beale",
                EmailAddress = "bb@hotmail.com",
                MobileNumber = "0123456789",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address3,
                IsActive = false
            };

            _dataRepository = new DataRepository(new NullLogger<DataRepository>());

            _dataRepository.AddCustomer(customer1);
            _dataRepository.AddCustomer(customer2);
        }

        //A customer can be added to the database
        [Test]
        public void CustomerCanBeAdded()
        {
            Address address1 = new Address()
            {
                Id = 3,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Customer customer1 = new Customer()
            {
                Id = 3,
                Title = "Mr",
                Forename = "Chris",
                Surname = "Campbell",
                EmailAddress = "cc@hotmail.com",
                MobileNumber = "0123456789",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address1
            };

            _dataRepository.AddCustomer(customer1);

            Assert.IsTrue(_dataRepository.ReturnAllCustomers().Any(customer => customer == customer1));
        }

        //A customer can only exist once within the database
        [Test]
        public void CustomerCanOnlyExistsOnce()
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Address address2 = new Address()
            {
                Id = 2,
                AddressLine1 = "2 Street",
                Town = "Birmingham",
                Postcode = "B11 1AA"
            };

            Customer customer1 = new Customer()
            {
                Id = 1,
                Title = "Mr",
                Forename = "Andreas",
                Surname = "Anderson",
                EmailAddress = "aa@hotmail.com",
                MobileNumber = "0123456789",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address1
            };

            Assert.Throws<ArgumentException>(() => _dataRepository.AddCustomer(customer1));
        }

        //A customer can have multiple addresses
        [Test]
        public void CustomerCanHaveMultipleAddresses()
        {
            Assert.IsTrue(_dataRepository.ReturnAllCustomers().FirstOrDefault()?.Addresses.Count > 1);
        }

        //You cannot delete the last address as a customer MUST have at least one address
        [Test]
        public void CustomerMustHaveAtLeastOneAddressAfterDeleteAttempt ()
        {
            _dataRepository.DeleteAddress(1, 1);

            Assert.Throws<ArgumentException>(() => _dataRepository.DeleteAddress(1, 2));
        }

        //A secondary address can become the main address
        [Test]
        public void SetSecondaryAddressAsMainAddress()
        {
            _dataRepository.SetMainAddress(1, 2);

            Assert.IsTrue(_dataRepository.ReturnAllCustomers().FirstOrDefault(customer => customer.Id == 1).MainAddress.Id == 2);
        }

        //A customer can be marked as in-active
        public void CustomerIsMarkedAsInActive()
        {
            _dataRepository.MarkCustomerInActive(1);

            Assert.IsTrue(!_dataRepository.ReturnAllCustomers().FirstOrDefault(customer => customer.Id == 1).IsActive);
        }

        //list of ALL customers can be returned
        public void ReturnAllCustomers()
        {
            Assert.IsTrue(_dataRepository.ReturnAllCustomers().Count == 1);
        }

        //list of ACTIVE customers can be returned
        public void ReturnOnlyActiveCustomers()
        {
            Address address1 = new Address()
            {
                Id = 3,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Customer customer1 = new Customer()
            {
                Id = 2,
                Title = "Mr",
                Forename = "Bruce",
                Surname = "Beale",
                EmailAddress = "bb@hotmail.com",
                MobileNumber = "0123456789",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address1,
                IsActive = false
            };

            _dataRepository.AddCustomer(customer1);

            Assert.IsTrue(_dataRepository.ReturnAllCustomers().Count == 1);
        }
    }
}