using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModernMilkman.CustomerManagement.API.Attributes.BasicAuthenticationWEBAPI.Models;
using ModernMilkman.CustomerManagement.API.Model;
using ModernMilkman.CustomerManagement.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkman.CustomerManagement.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [CustomAuth]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IDataRepository _dataRepository;

        /// <summary>
        /// Constructor method for the customer controller
        /// </summary>
        /// <param name="logger">logger object for the controller</param>
        /// <param name="dataRepository">service for performing action on data store</param>
        public CustomerController(ILogger<CustomerController> logger, IDataRepository dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
        }

        /// <summary>
        /// Retrieve all customers
        /// </summary>
        /// <param name="activeOnly">Retrieve active customers only</param>
        /// <returns>Returns list of customer</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
        public IActionResult GetCustomers(bool? activeOnly)
        {
            if (activeOnly.HasValue && activeOnly.Value)
            {
                return Ok(_dataRepository.ReturnAllActiveCustomers());
            }

            return Ok(_dataRepository.ReturnAllCustomers());
        }

        /// <summary>
        /// Add a new customer to the data store
        /// </summary>
        /// <param name="customer">Customer object</param>
        /// <returns>Returns status of the method</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddCustomer(Customer customer)
        {
            _dataRepository.AddCustomer(customer);

            return Ok();
        }

        /// <summary>
        /// Mark a customer inactive
        /// </summary>
        /// <param name="request">request object with customer details</param>
        /// <returns>Returns status of the method</returns>
        [HttpPut("Deactivate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeactivateCustomer([FromBody] CustomerAPIRequest request)
        {
            _dataRepository.MarkCustomerInActive(request.CustomerId);

            return Ok();
        }

        /// <summary>
        /// Delete an address from the customer
        /// </summary>
        /// <param name="request">request object with customer details</param>
        /// <returns>Returns status of the method</returns>
        [HttpPut("DeleteAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteAddress([FromBody] CustomerAPIRequest request)
        {
            _dataRepository.DeleteAddress(request.CustomerId, request.AddressId);

            return Ok();
        }

        /// <summary>
        /// Set an address for a customer as the main address
        /// </summary>
        /// <param name="request">request object with customer details</param>
        /// <returns>Returns status of the method</returns>
        [HttpPut("SetMainAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SetMainAddress([FromBody] CustomerAPIRequest request)
        {
            _dataRepository.SetMainAddress(request.CustomerId, request.AddressId);

            return Ok();
        }

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="request">request object with customer details</param>
        /// <returns>Returns status of the method</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteCustomer([FromBody] CustomerAPIRequest request)
        {
            _dataRepository.DeleteCustomer(request.CustomerId);

            return Ok();
        }
    }
}
