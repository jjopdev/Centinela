using System;

#nullable disable

namespace Centinela.Core.Entities
{
    public partial class DispositivoCoordenadum
    {
        public int DispositivoCoordenadaId { get; set; }
        public int DispositivoId { get; set; }
        public int CoordenadaId { get; set; }
        public DateTime Momento { get; set; }
        public int? AddUserId { get; set; }
        public DateTime AddDate { get; set; }
        public int? ChgUserId { get; set; }
        public DateTime? ChgDate { get; set; }
        public bool Activo { get; set; }

        public virtual Usuario AddUser { get; set; }
        public virtual Usuario ChgUser { get; set; }
        public virtual Coordenadum Coordenada { get; set; }
        public virtual Dispositivo Dispositivo { get; set; }
    }
}
