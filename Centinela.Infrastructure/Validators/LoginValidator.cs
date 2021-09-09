using Centinela.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

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
