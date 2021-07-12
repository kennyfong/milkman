using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkman.CustomerManagement.API.Model
{
    public class CustomerAPIRequest
    {
        /// <summary>
        /// Customer Id of the customer that we want to make the change for
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Address Id from the customer that we want to make the change for
        /// </summary>
        public int AddressId { get; set; }
    }
}
