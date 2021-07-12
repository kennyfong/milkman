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
        public IActionResult DeactivateCustomer([FromBody] CustomerAPIRequest request)
        {
            _dataRepository.MarkCustomerInActive(request.CustomerId);

            return Ok();
        }

        [HttpPut("DeleteAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteAddress([FromBody] CustomerAPIRequest request)
        {
            _dataRepository.DeleteAddress(request.CustomerId, request.AddressId);

            return Ok();
        }

        [HttpPut("SetMainAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SetMainAddress([FromBody] CustomerAPIRequest request)
        {
            _dataRepository.SetMainAddress(request.CustomerId, request.AddressId);

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteCustomer([FromBody] CustomerAPIRequest request)
        {
            _dataRepository.DeleteCustomer(request.CustomerId);

            return Ok();
        }
    }
}
