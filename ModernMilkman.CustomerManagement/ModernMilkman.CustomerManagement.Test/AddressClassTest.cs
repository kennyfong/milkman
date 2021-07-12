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
    public class AddressClassTest
    {
        private AddressValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new AddressValidator();
        }

        //Address Line 1 field is mandatory
        [Test]
        public void AddressLine1isMandatory()
        {
            Address address1 = new Address()
            {
                Id = 1,
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            var result = validator.Validate(address1);

            Assert.That(!result.IsValid);
            Assert.That(result.Errors.Any(o => o.PropertyName == "AddressLine1"));
        }

        //Address Line 1 field is up to 80 characters
        [Test]
        [TestCase("1 Street", true)]
        [TestCase("", false)]
        [TestCase("1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street", false)]
        public void AddressLine1CannotbeOver80Characters(string addressline1In, bool expectedResult)
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = addressline1In,
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            var result = validator.Validate(address1);

            Assert.That(result.IsValid == expectedResult);
            if (!expectedResult)
            {
                Assert.That(result.Errors.Any(o => o.PropertyName == "AddressLine1"));
            }
        }

        //Address Line 2 field is up to 80 characters
        [Test]
        [TestCase("1 Street", true)]
        [TestCase("", true)]
        [TestCase("1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street1 Street", false)]
        public void AddressLine2CannotbeOver80Characters(string addressLine2In, bool expectedResult)
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                AddressLine2 = addressLine2In,
                Town = "Manchester",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            var result = validator.Validate(address1);

            Assert.That(result.IsValid == expectedResult);
            if (!expectedResult)
            {
                Assert.That(result.Errors.Any(o => o.PropertyName == "AddressLine2"));
            }
        }

        //Town field is mandatory
        [Test]
        public void TownisMandatory()
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            var result = validator.Validate(address1);

            Assert.That(result.IsValid == false);
            Assert.That(result.Errors.Any(o => o.PropertyName == "Town"));
        }

        //Town field is up to 50 characters
        [Test]
        [TestCase("Manchester", true)]
        [TestCase("", false)]
        [TestCase("ManchesterManchesterManchesterManchesterManchesterManchester", false)]
        public void TownCannotbeOver50Characters(string townIn, bool expectedResult)
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = townIn,
                County = "Lancashire",
                Postcode = "M11 1AA"
            };

            var result = validator.Validate(address1);

            Assert.That(result.IsValid == expectedResult);
            if (!expectedResult)
            {
                Assert.That(result.Errors.Any(o => o.PropertyName == "Town"));
            }
        }

        //County field is up to 50 characters
        [Test]
        [TestCase("Lancashire", true)]
        [TestCase("", true)]
        [TestCase("LancashireLancashireLancashireLancashireLancashireLancashire", false)]
        public void CountyCannotbeOver50Characters(string countyIn, bool expectedResult)
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = countyIn,
                Postcode = "M11 1AA"
            };

            var result = validator.Validate(address1);

            Assert.That(result.IsValid == expectedResult);
            if (!expectedResult)
            {
                Assert.That(result.Errors.Any(o => o.PropertyName == "County"));
            }
        }

        //Postcode field is mandatory
        [Test]
        public void PostcodeisMandatory()
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire"
            };

            var result = validator.Validate(address1);

            Assert.That(result.IsValid == false);
            Assert.That(result.Errors.Any(o => o.PropertyName == "Postcode"));
        }

        //Postcode field is up to 10 characters
        [Test]
        [TestCase("M11 1AA", true)]
        [TestCase("", false)]
        [TestCase("M11 1AAM11 1AA", false)]
        public void PostcodeCannotbeOver10Characters(string postcodeIn, bool expectedResult)
        {
            Address address1 = new Address()
            {
                Id = 1,
                AddressLine1 = "1 Street",
                Town = "Manchester",
                County = "Lancashire",
                Postcode = postcodeIn
            };

            var result = validator.Validate(address1);

            Assert.That(result.IsValid == expectedResult);
            if (!expectedResult)
            {
                Assert.That(result.Errors.Any(o => o.PropertyName == "Postcode"));
            }
        }
    }
}
