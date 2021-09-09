using Centinela.Core.DTOs;
using FluentValidation;

namespace Centinela.Infrastructure.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidator()
        {
            //RuleFor(user => user.Observacion)
            //    .NotNull()
            //    .Length(10,15);
            //RuleFor(user => user.Nombres)
            //    .NotNull()
            //    .Length(10, 15);

        }
    }
}
