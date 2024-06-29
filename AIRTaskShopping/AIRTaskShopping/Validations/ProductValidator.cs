using AIRTaskShopping.Models;
using FluentValidation;

namespace AIRTaskShopping.Validations;

public class ProductValidator:AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 250);
        RuleFor(x => x.Description).Length(0, 250);
        RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(x => x.Stock).NotNull().NotEmpty().GreaterThan(0);
    }
}
