using System;
using System.Collections.Generic;

#nullable disable

namespace Centinela.Core.Entities
{
    public partial class Dispositivo
    {
        public Dispositivo()
        {
            Auditoria = new HashSet<Auditorium>();
            DispositivoCoordenada = new HashSet<DispositivoCoordenadum>();
            Eventos = new HashSet<Evento>();
        }

        public int DispositivoId { get; set; }
        public int EmpresaId { get; set; }
        public int? PortadorId { get; set; }
        public string Status { get; set; }
        public int NumeroTelefono { get; set; }
        public int TipoDispositivo { get; set; }
        public int? AddUserId { get; set; }
        public DateTime AddDate { get; set; }
        public int? ChgUserId { get; set; }
        public DateTime? ChgDate { get; set; }
        public bool Activo { get; set; }

        public virtual Usuario AddUser { get; set; }
        public virtual Usuario ChgUser { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Portador Portador { get; set; }
        public virtual ICollection<Auditorium> Auditoria { get; set; }
        public virtual ICollection<DispositivoCoordenadum> DispositivoCoordenada { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
