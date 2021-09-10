using Centinela.Core.DTOs;
using FluentValidation;

namespace Centinela.Infrastructure.Validators
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(user => user.Correo)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .EmailAddress()
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            RuleFor(user => user.Password)
                .Cascade(CascadeMode.Stop)
                .NotNull();                         

        }
    }
}
