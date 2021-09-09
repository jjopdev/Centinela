using System.ComponentModel.DataAnnotations;

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
