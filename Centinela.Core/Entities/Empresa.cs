using System;
using System.Collections.Generic;

#nullable disable

namespace Centinela.Core.Entities
{
    public partial class Empresa
    {
        public Empresa()
        {
            Dispositivos = new HashSet<Dispositivo>();
            Portadors = new HashSet<Portador>();
            Ronda = new HashSet<Rondum>();
            Usuarios = new HashSet<Usuario>();
        }

        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Rut { get; set; }
        public string Observacion { get; set; }
        public int? AddUserId { get; set; }
        public DateTime AddDate { get; set; }
        public int? ChgUserId { get; set; }
        public DateTime? ChgDate { get; set; }
        public bool Activo { get; set; }

        public virtual Usuario AddUser { get; set; }
        public virtual Usuario ChgUser { get; set; }
        public virtual ICollection<Dispositivo> Dispositivos { get; set; }
        public virtual ICollection<Portador> Portadors { get; set; }
        public virtual ICollection<Rondum> Ronda { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
