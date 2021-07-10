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
        [SetUp]
        public void Setup()
        {
        }

        //Address Line 1 field is mandatory
        [Test]
        public void AddressLine1isMandatory()
        {
            throw new NotImplementedException();
        }

        //Address Line 1 field is up to 80 characters
        [Test]
        public void AddressLine1CannotbeOver80Characters()
        {
            throw new NotImplementedException();
        }

        //Address Line 2 field is up to 80 characters
        [Test]
        public void AddressLine2CannotbeOver80Characters()
        {
            throw new NotImplementedException();
        }

        //Town field is mandatory
        [Test]
        public void TownisMandatory()
        {
            throw new NotImplementedException();
        }

        //Town field is up to 50 characters
        [Test]
        public void TownCannotbeOver50Characters()
        {
            throw new NotImplementedException();
        }

        //County field is up to 50 characters
        [Test]
        public void CountyCannotbeOver50Characters()
        {
            throw new NotImplementedException();
        }

        //Postcode field is mandatory
        [Test]
        public void PostcodeisMandatory()
        {
            throw new NotImplementedException();
        }

        //Country defaults to UK if not provided
        [Test]
        public void CountryDefaultstoUKIfNotProvided()
        {
            throw new NotImplementedException();
        }
    }
}
