using Centinela.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Centinela.Infrastructure.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidator()
        {
            RuleFor(user => user.Observacion)
                .NotNull()
                .Length(10,15);
            RuleFor(user => user.Nombres)
                .NotNull()
                .Length(10, 15);

        }
    }
}
