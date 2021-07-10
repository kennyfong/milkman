using NUnit.Framework;
using System;

namespace ModernMilkman.CustomerManagement.Test
{
    public class CustomerManagementTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //A customer can only exist once within the database
        [Test]
        public void CustomerCanOnlyExistsOnce()
        {
            throw new NotImplementedException();
        }

        //A customer can have multiple addresses
        [Test]
        public void CustomerCanHaveMultipleAddresses()
        {
            throw new NotImplementedException();
        }

        //You cannot delete the last address as a customer MUST have at least one address
        [Test]
        public void CustomerMustHaveAtLeastOneAddress()
        {
            throw new NotImplementedException();
        }

        //A secondary address can become the main address
        [Test]
        public void SetSecondaryAddressAsMainAddress()
        {
            throw new NotImplementedException();
        }

        //a customer can have ONLY ONE main address
        [Test]
        public void CustomerCanHaveOnlyOneMainAddress()
        {
            throw new NotImplementedException();
        }

        //A customer can be marked as in-active
        public void CustomerIsMarkedAsInActive()
        {
            throw new NotImplementedException();
        }

        //Customer can be deleted, and all associated addresses should also be deleted
        public void CustomerDeletedAndAddressesToo()
        {
            throw new NotImplementedException();
        }

        //list of ALL customers can be returned
        public void ReturnAllCustomers()
        {
            throw new NotImplementedException();
        }

        //list of ACTIVE customers can be returned
        public void ReturnOnlyActiveCustomers()
        {
            throw new NotImplementedException();
        }
    }
}