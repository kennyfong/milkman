using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ModernMilkman.CustomerManagement.API.Model;

namespace ModernMilkman.CustomerManagement.API.Validation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.AddressLine1).NotNull().MaximumLength(80);

            RuleFor(address => address.AddressLine2).MaximumLength(80);

            RuleFor(address => address.Town).NotNull().MaximumLength(50);

            RuleFor(address => address.County).MaximumLength(50);

            RuleFor(address => address.Postcode).NotNull().MaximumLength(10);
        }
    }
}
