using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkman.CustomerManagement.API.Model
{
    public class Address
    {
        public int AddressId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

        public string Postcode { get; set; }

        public string Country { get; set; } = "UK";
    }
}
