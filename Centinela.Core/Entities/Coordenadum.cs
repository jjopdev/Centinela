using System;
using System.Collections.Generic;

#nullable disable

namespace Centinela.Core.Entities
{
    public partial class Coordenadum
    {
        public Coordenadum()
        {
            DispositivoCoordenada = new HashSet<DispositivoCoordenadum>();
        }

        public int CoordenadaId { get; set; }
        public int? RondaId { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public int? AddUserId { get; set; }
        public DateTime AddDate { get; set; }
        public int? ChgUserId { get; set; }
        public DateTime? ChgDate { get; set; }
        public bool Activo { get; set; }

        public virtual Usuario AddUser { get; set; }
        public virtual Usuario ChgUser { get; set; }
        public virtual Rondum Ronda { get; set; }
        public virtual ICollection<DispositivoCoordenadum> DispositivoCoordenada { get; set; }
    }
}
