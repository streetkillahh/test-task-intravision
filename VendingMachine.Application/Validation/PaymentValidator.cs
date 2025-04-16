using FluentValidation;
using VendingMachine.Domain.Dto;

namespace VendingMachine.Application.Validations;

public class PaymentValidator : AbstractValidator<PaymentDto>
{
    public PaymentValidator()
    {
        RuleFor(x => x.OrderId).GreaterThan(0);
        RuleFor(x => x.InsertedCoins).NotEmpty();
        RuleForEach(x => x.InsertedCoins).ChildRules(coin =>
        {
            coin.RuleFor(c => (int)c.Denomination).InclusiveBetween(1, 10);
            coin.RuleFor(c => c.Quantity).GreaterThan(0);
        });
    }
}
