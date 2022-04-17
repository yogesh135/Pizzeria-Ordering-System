using FluentValidation;

namespace Pizzeria_Ordering_System.Contract.Validators
{
    public class PizzaOrderRequestValidator : AbstractValidator<PizzaOrderRequest>
    {
        public PizzaOrderRequestValidator()
        {
            RuleFor(rule => rule.Name).NotEmpty().WithMessage("Name required for the Pizza");
            RuleFor(rule => rule.Size).NotEqual(0).WithMessage("Pizza Size is required");
            RuleFor(p => p.NumberOfPizza).NotEqual(0).WithMessage("Number of pizza required");
        }
    }
}
