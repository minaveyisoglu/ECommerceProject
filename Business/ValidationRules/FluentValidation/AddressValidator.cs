using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.AddressDetail).NotEmpty();
            RuleFor(a => a.PostalCode).NotEmpty();

        }
    }
}
