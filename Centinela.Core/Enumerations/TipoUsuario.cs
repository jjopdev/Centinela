using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Centinela.Core.Enumerations
{
    public enum TipoUsuario
    {

        [Display(Name = "Super Admin")]
        SuperAdmin,
        [Display(Name = "Administrador")]
        Administrador,
        [Display(Name = "Operador")]
        Operador,

    }
}
