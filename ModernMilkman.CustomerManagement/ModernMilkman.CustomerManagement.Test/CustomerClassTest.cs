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
        [SetUp]
        public void Setup()
        {
        }

        //Title field is mandatory
        [Test]
        public void TitleisMandatory()
        {
            throw new NotImplementedException();
        }

        //Title field is up to 20 characters
        [Test]
        public void TitleCannotbeOver20Characters()
        {
            throw new NotImplementedException();
        }

        //Forename field is mandatory
        [Test]
        public void ForenameisMandatory()
        {
            throw new NotImplementedException();
        }

        //Forename field is up to 50 characters
        [Test]
        public void ForenameCannotbeOver50Characters()
        {
            throw new NotImplementedException();
        }

        //Surname field is mandatory
        [Test]
        public void SurnameisMandatory()
        {
            throw new NotImplementedException();
        }

        //Surname field is up to 50 characters
        [Test]
        public void SurnameCannotbeOver50Characters()
        {
            throw new NotImplementedException();
        }

        //Title field is mandatory
        [Test]
        public void EmailAddressisMandatory()
        {
            throw new NotImplementedException();
        }

        //Email Address field is up to 75 characters
        [Test]
        public void EmailAddressCannotbeOver75Characters()
        {
            throw new NotImplementedException();
        }

        //Mobile Number field is mandatory
        [Test]
        public void MobileNumberisMandatory()
        {
            throw new NotImplementedException();
        }

        //Mobile Number field is up to 15 characters
        [Test]
        public void MobileNumberCannotbeOver15Characters()
        {
            throw new NotImplementedException();
        }
    }
}
