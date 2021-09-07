using System;
using System.Collections.Generic;

#nullable disable

namespace Centinela.Core.Entities
{
    public partial class Portador
    {
        public Portador()
        {
            ContactoEmergencia = new HashSet<ContactoEmergencium>();
            Dispositivos = new HashSet<Dispositivo>();
        }

        public int PortadorId { get; set; }
        public int EmpresaId { get; set; }
        public int? VehiculoId { get; set; }
        public string Direccion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public int TipoPortador { get; set; }
        public string Observacion { get; set; }
        public string Ubicacion { get; set; }
        public int? AddUserId { get; set; }
        public DateTime AddDate { get; set; }
        public int? ChgUserId { get; set; }
        public DateTime? ChgDate { get; set; }
        public bool Activo { get; set; }

        public virtual Usuario AddUser { get; set; }
        public virtual Usuario ChgUser { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
        public virtual ICollection<ContactoEmergencium> ContactoEmergencia { get; set; }
        public virtual ICollection<Dispositivo> Dispositivos { get; set; }
    }
}
