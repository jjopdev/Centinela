using System;

#nullable disable

namespace Centinela.Core.Entities
{
    public partial class Password
    {
        public int PasswordId { get; set; }
        public string PasswordUsuario { get; set; }
        public int UsuarioId { get; set; }
        public int? AddUserId { get; set; }
        public DateTime AddDate { get; set; }
        public int? ChgUserId { get; set; }
        public DateTime? ChgDate { get; set; }
        public bool Activo { get; set; }

        public virtual Usuario AddUser { get; set; }
        public virtual Usuario ChgUser { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
