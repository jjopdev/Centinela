using System;

#nullable disable

namespace Centinela.Core.Entities
{
    public partial class ContactoEmergencium
    {
        public int ContactoEmergenciaId { get; set; }
        public int PortadorId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Descripcion { get; set; }
        public int PrioridadContacto { get; set; }
        public int Telefono1 { get; set; }
        public int? Telefono2 { get; set; }
        public int? AddUserId { get; set; }
        public DateTime AddDate { get; set; }
        public int? ChgUserId { get; set; }
        public DateTime? ChgDate { get; set; }
        public bool Activo { get; set; }

        public virtual Usuario AddUser { get; set; }
        public virtual Usuario ChgUser { get; set; }
        public virtual Portador Portador { get; set; }
    }
}
