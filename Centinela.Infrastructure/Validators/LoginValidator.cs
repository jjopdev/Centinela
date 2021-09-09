using Centinela.Core.DTOs;
using FluentValidation;

namespace Centinela.Infrastructure.Validators
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(user => user.Correo)
                .NotNull()
                .EmailAddress();
            RuleFor(user => user.Password)
                .NotNull();                

        }
    }
}
