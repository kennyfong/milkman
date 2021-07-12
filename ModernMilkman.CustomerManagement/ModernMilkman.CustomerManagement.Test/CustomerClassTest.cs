using ModernMilkman.CustomerManagement.API.Model;
using ModernMilkman.CustomerManagement.API.Validation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernMilkman.CustomerManagement.Test
{
    public class CustomerClassTest
    {
        private CustomerValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new CustomerValidator();
        }

        //Title field is mandatory
        [Test]
        public void TitleisMandatory()
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
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

            var result = validator.Validate(customer1);

            Assert.That(result.IsValid);

            Customer customer2 = new Customer()
            {
                Id = 1,
                Forename = "Andreas",
                Surname = "Anderson",
                EmailAddress = "aa@hotmail.com",
                MobileNumber = "0123456789",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address1
            };

            result = validator.Validate(customer2);

            Assert.That(!result.IsValid);
            Assert.That(result.Errors.Any(o => o.PropertyName == "Title"));
        }

        //Title field is up to 20 characters
        [Test]
        [TestCase("Mrmrmrmrmrmrmrmrmrmrmrmrmrmrmrmrmr", false)]
        [TestCase("", false)]
        [TestCase("Mrmrmrmrmrmrmrmrmrmr", true)]
        public void TitleCannotbeOver20Characters(string titleIn, bool expectedResult)
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Customer customer1 = new Customer()
            {
                Id = 1,
                Title = titleIn,
                Forename = "Andreas",
                Surname = "Anderson",
                EmailAddress = "aa@hotmail.com",
                MobileNumber = "0123456789",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address1
            };

            var result = validator.Validate(customer1);

            Assert.That(result.IsValid == expectedResult);
            if (!expectedResult)
            {
                Assert.That(result.Errors.Any(o => o.PropertyName == "Title"));
            }
        }

        //Forename field is mandatory
        [Test]
        public void ForenameisMandatory()
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Customer customer1 = new Customer()
            {
                Id = 1,
                Title = "Mr",
                Surname = "Anderson",
                EmailAddress = "aa@hotmail.com",
                MobileNumber = "0123456789",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address1
            };

            var result = validator.Validate(customer1);

            Assert.That(result.IsValid == false);
            Assert.That(result.Errors.Any(o => o.PropertyName == "Forename"));
        }

        //Forename field is up to 50 characters
        [Test]
        [TestCase("Andreas", true)]
        [TestCase("", false)]
        [TestCase("AndreasAndreasAndreasAndreasAndreasAndreasAndreasAndreas", false)]
        public void ForenameCannotbeOver50Characters(string forenameIn, bool expectedResult)
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Customer customer1 = new Customer()
            {
                Id = 1,
                Title = "Mr",
                Forename = forenameIn,
                Surname = "Anderson",
                EmailAddress = "aa@hotmail.com",
                MobileNumber = "0123456789",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address1
            };

            var result = validator.Validate(customer1);

            Assert.That(result.IsValid == expectedResult);
            if (!expectedResult)
            {
                Assert.That(result.Errors.Any(o => o.PropertyName == "Forename"));
            }
        }

        //Surname field is mandatory
        [Test]
        public void SurnameisMandatory()
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Customer customer1 = new Customer()
            {
                Id = 1,
                Title = "Mr",
                Forename = "Andreas",
                EmailAddress = "aa@hotmail.com",
                MobileNumber = "0123456789",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address1
            };

            var result = validator.Validate(customer1);

            Assert.That(result.IsValid == false);
            Assert.That(result.Errors.Any(o => o.PropertyName == "Surname"));
        }

        //Surname field is up to 50 characters
        [Test]
        [TestCase("Anderson", true)]
        [TestCase("", false)]
        [TestCase("AndersonAndersonAndersonAndersonAndersonAndersonAnderson", false)]
        public void SurnameCannotbeOver50Characters(string surnameIn, bool expectedResult)
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Customer customer1 = new Customer()
            {
                Id = 1,
                Title = "Mr",
                Forename = "Andreas",
                Surname = surnameIn,
                EmailAddress = "aa@hotmail.com",
                MobileNumber = "0123456789",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address1
            };

            var result = validator.Validate(customer1);

            Assert.That(result.IsValid == expectedResult);
            if (!expectedResult)
            {
                Assert.That(result.Errors.Any(o => o.PropertyName == "Surname"));
            }
        }

        //Title field is mandatory
        [Test]
        public void EmailAddressisMandatory()
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Customer customer1 = new Customer()
            {
                Id = 1,
                Title = "Mr",
                Forename = "Andreas",
                Surname = "Anderson",
                MobileNumber = "0123456789",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address1
            };

            var result = validator.Validate(customer1);

            Assert.That(result.IsValid == false);
            Assert.That(result.Errors.Any(o => o.PropertyName == "EmailAddress"));
        }

        //Email Address field is up to 75 characters
        [Test]
        [TestCase("aa@gmail.com", true)]
        [TestCase("", false)]
        [TestCase("aa@gmail.comaa@gmail.comaa@gmail.comaa@gmail.comaa@gmail.comaa@gmail.comaa@gmail.com", false)]
        public void EmailAddressCannotbeOver75Characters(string emailIn, bool expectedResult)
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Customer customer1 = new Customer()
            {
                Id = 1,
                Title = "Mr",
                Forename = "Andreas",
                Surname = "Anderson",
                EmailAddress = emailIn,
                MobileNumber = "0123456789",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address1
            };

            var result = validator.Validate(customer1);

            Assert.That(result.IsValid == expectedResult);
            if (!expectedResult)
            {
                Assert.That(result.Errors.Any(o => o.PropertyName == "EmailAddress"));
            }
        }

        //Mobile Number field is mandatory
        [Test]
        public void MobileNumberisMandatory()
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Customer customer1 = new Customer()
            {
                Id = 1,
                Title = "Mr",
                Forename = "Andreas",
                Surname = "Anderson",
                EmailAddress = "aa@gmail.com",
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address1
            };

            var result = validator.Validate(customer1);

            Assert.That(result.IsValid == false);
            Assert.That(result.Errors.Any(o => o.PropertyName == "MobileNumber"));
        }

        //Mobile Number field is up to 15 characters
        [Test]
        [TestCase("0123456789", true)]
        [TestCase("", false)]
        [TestCase("012345678910111213", false)]
        public void MobileNumberCannotbeOver15Characters(string mobileIn, bool expectedResult)
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            Customer customer1 = new Customer()
            {
                Id = 1,
                Title = "Mr",
                Forename = "Andreas",
                Surname = "Anderson",
                EmailAddress = "aa@gmail.com",
                MobileNumber = mobileIn,
                Addresses = new Dictionary<int, Address>() { { address1.Id, address1 } },
                MainAddress = address1
            };

            var result = validator.Validate(customer1);

            Assert.That(result.IsValid == expectedResult);
            if (!expectedResult)
            {
                Assert.That(result.Errors.Any(o => o.PropertyName == "MobileNumber"));
            }
        }
    }
}
