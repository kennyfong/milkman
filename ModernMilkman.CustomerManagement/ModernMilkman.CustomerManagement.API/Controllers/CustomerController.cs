using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IDataRepository _dataRepository;

        public CustomerController(ILogger<CustomerController> logger, IDataRepository dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
        }

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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddCustomer(Customer customer)
        {
            _dataRepository.AddCustomer(customer);

            return Ok();
        }

        [HttpPut("Deactivate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeactivateCustomer(Customer customer)
        {
            _dataRepository.MarkCustomerInActive(customer.CustomerId);

            return Ok();
        }

        [HttpPut("DeleteAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteAddress(Customer customer, Address address)
        {
            _dataRepository.DeleteAddress(customer.CustomerId, address.AddressId);

            return Ok();
        }

        [HttpPut("SetMainAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SetMainAddress(Customer customer, Address address)
        {
            _dataRepository.SetMainAddress(customer.CustomerId, address.AddressId);

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteCustomer(Customer customer)
        {
            _dataRepository.DeleteCustomer(customer.CustomerId);

            return Ok();
        }
    }
}
