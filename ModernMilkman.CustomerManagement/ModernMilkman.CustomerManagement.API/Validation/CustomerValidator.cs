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
            RuleFor(customer => customer.Title).NotNull().MaximumLength(20);

            RuleFor(customer => customer.Forename).NotNull().MaximumLength(50);

            RuleFor(customer => customer.Surname).NotNull().MaximumLength(50);

            RuleFor(customer => customer.EmailAddress).NotNull().MaximumLength(75);

            RuleFor(customer => customer.MobileNumber).NotNull().MaximumLength(15);

            RuleFor(customer => customer.Addresses).Must(address => address.Count == 0);

            RuleFor(customer => customer.MainAddress).SetValidator(new AddressValidator());
        }
    }
}
