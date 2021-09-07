using System;

#nullable disable

namespace Centinela.Core.Entities
{
    public partial class Evento
    {
        public int EventoId { get; set; }
        public int UsuarioId { get; set; }
        public int DispositivoId { get; set; }
        public DateTime MomentoOcurrido { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public string Observacion { get; set; }
        public DateTime? AtendidoEl { get; set; }
        public string Precision { get; set; }
        public string Status { get; set; }
        public int TipoAlarma { get; set; }
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
