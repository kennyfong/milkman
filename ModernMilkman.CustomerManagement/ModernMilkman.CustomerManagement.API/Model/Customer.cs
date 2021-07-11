using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkman.CustomerManagement.API.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public string MobileNumber { get; set; }

        public bool IsActive { get; set; }

        public List<Address> Addresses { get; set; }

        public Address MainAddress { get; set; }
    }
}
