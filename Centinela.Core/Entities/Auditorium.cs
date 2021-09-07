using System;

#nullable disable

namespace Centinela.Core.Entities
{
    public partial class Auditorium
    {
        public int AuditoriaId { get; set; }
        public int UsuarioId { get; set; }
        public int DispositivoId { get; set; }
        public string Operacion { get; set; }
        public int? AddUserId { get; set; }
        public DateTime AddDate { get; set; }
        public int? ChgUserId { get; set; }
        public DateTime? ChgDate { get; set; }
        public bool Activo { get; set; }

        public virtual Usuario AddUser { get; set; }
        public virtual Usuario ChgUser { get; set; }
        public virtual Dispositivo Dispositivo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
