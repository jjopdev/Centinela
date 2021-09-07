using System;
using System.Collections.Generic;

#nullable disable

namespace Centinela.Core.Entities
{
    public partial class Rondum
    {
        public Rondum()
        {
            Coordenada = new HashSet<Coordenadum>();
        }

        public int RondaId { get; set; }
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? AddUserId { get; set; }
        public DateTime AddDate { get; set; }
        public int? ChgUserId { get; set; }
        public DateTime? ChgDate { get; set; }
        public bool Activo { get; set; }

        public virtual Usuario AddUser { get; set; }
        public virtual Usuario ChgUser { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Coordenadum> Coordenada { get; set; }
    }
}
