using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ModernMilkman.CustomerManagement.API.Model;

namespace ModernMilkman.CustomerManagement.API.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Title).NotNull().NotEmpty().MaximumLength(20);

            RuleFor(customer => customer.Forename).NotNull().NotEmpty().MaximumLength(50);

            RuleFor(customer => customer.Surname).NotNull().NotEmpty().MaximumLength(50);

            RuleFor(customer => customer.EmailAddress).NotNull().NotEmpty().MaximumLength(75);

            RuleFor(customer => customer.MobileNumber).NotNull().NotEmpty().MaximumLength(15);

            RuleFor(customer => customer.Addresses).NotNull().Must(address => address.Count > 0);

            RuleFor(customer => customer.MainAddress).SetValidator(new AddressValidator());
        }
    }
}
