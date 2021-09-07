using System;
using System.Collections.Generic;

#nullable disable

namespace Centinela.Core.Entities
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Portadors = new HashSet<Portador>();
        }

        public int VehiculoId { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public string Patente { get; set; }
        public int? AddUserId { get; set; }
        public DateTime AddDate { get; set; }
        public int? ChgUserId { get; set; }
        public DateTime? ChgDate { get; set; }
        public bool Activo { get; set; }

        public virtual Usuario AddUser { get; set; }
        public virtual Usuario ChgUser { get; set; }
        public virtual ICollection<Portador> Portadors { get; set; }
    }
}
