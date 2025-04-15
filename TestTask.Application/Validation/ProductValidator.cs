using FluentValidation;
using VendingMachine.Domain.Dto;

namespace VendingMachine.Application.Validations;

public class ProductValidator : AbstractValidator<ProductDto>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
    }
}