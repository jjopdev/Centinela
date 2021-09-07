using System;
using System.Collections.Generic;

#nullable disable

namespace Centinela.Core.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            AuditoriumAddUsers = new HashSet<Auditorium>();
            AuditoriumChgUsers = new HashSet<Auditorium>();
            AuditoriumUsuarios = new HashSet<Auditorium>();
            ContactoEmergenciumAddUsers = new HashSet<ContactoEmergencium>();
            ContactoEmergenciumChgUsers = new HashSet<ContactoEmergencium>();
            CoordenadumAddUsers = new HashSet<Coordenadum>();
            CoordenadumChgUsers = new HashSet<Coordenadum>();
            DispositivoAddUsers = new HashSet<Dispositivo>();
            DispositivoChgUsers = new HashSet<Dispositivo>();
            DispositivoCoordenadumAddUsers = new HashSet<DispositivoCoordenadum>();
            DispositivoCoordenadumChgUsers = new HashSet<DispositivoCoordenadum>();
            EmpresaAddUsers = new HashSet<Empresa>();
            EmpresaChgUsers = new HashSet<Empresa>();
            EventoAddUsers = new HashSet<Evento>();
            EventoChgUsers = new HashSet<Evento>();
            EventoUsuarios = new HashSet<Evento>();
            InverseAddUser = new HashSet<Usuario>();
            InverseChgUser = new HashSet<Usuario>();
            PasswordAddUsers = new HashSet<Password>();
            PasswordChgUsers = new HashSet<Password>();
            PortadorAddUsers = new HashSet<Portador>();
            PortadorChgUsers = new HashSet<Portador>();
            RondumAddUsers = new HashSet<Rondum>();
            RondumChgUsers = new HashSet<Rondum>();
            VehiculoAddUsers = new HashSet<Vehiculo>();
            VehiculoChgUsers = new HashSet<Vehiculo>();
        }

        public int UsuarioId { get; set; }
        public string Correo { get; set; }
        public int EmpresaId { get; set; }
        public DateTime FechaLogin { get; set; }
        public DateTime? FechaLoginAnterior { get; set; }
        public string Observacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int TipoUsuario { get; set; }
        public int? AddUserId { get; set; }
        public DateTime AddDate { get; set; }
        public int? ChgUserId { get; set; }
        public DateTime? ChgDate { get; set; }
        public bool Activo { get; set; }
        public int Telefono { get; set; }

        public virtual Usuario AddUser { get; set; }
        public virtual Usuario ChgUser { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Password PasswordUsuario { get; set; }
        public virtual ICollection<Auditorium> AuditoriumAddUsers { get; set; }
        public virtual ICollection<Auditorium> AuditoriumChgUsers { get; set; }
        public virtual ICollection<Auditorium> AuditoriumUsuarios { get; set; }
        public virtual ICollection<ContactoEmergencium> ContactoEmergenciumAddUsers { get; set; }
        public virtual ICollection<ContactoEmergencium> ContactoEmergenciumChgUsers { get; set; }
        public virtual ICollection<Coordenadum> CoordenadumAddUsers { get; set; }
        public virtual ICollection<Coordenadum> CoordenadumChgUsers { get; set; }
        public virtual ICollection<Dispositivo> DispositivoAddUsers { get; set; }
        public virtual ICollection<Dispositivo> DispositivoChgUsers { get; set; }
        public virtual ICollection<DispositivoCoordenadum> DispositivoCoordenadumAddUsers { get; set; }
        public virtual ICollection<DispositivoCoordenadum> DispositivoCoordenadumChgUsers { get; set; }
        public virtual ICollection<Empresa> EmpresaAddUsers { get; set; }
        public virtual ICollection<Empresa> EmpresaChgUsers { get; set; }
        public virtual ICollection<Evento> EventoAddUsers { get; set; }
        public virtual ICollection<Evento> EventoChgUsers { get; set; }
        public virtual ICollection<Evento> EventoUsuarios { get; set; }
        public virtual ICollection<Usuario> InverseAddUser { get; set; }
        public virtual ICollection<Usuario> InverseChgUser { get; set; }
        public virtual ICollection<Password> PasswordAddUsers { get; set; }
        public virtual ICollection<Password> PasswordChgUsers { get; set; }
        public virtual ICollection<Portador> PortadorAddUsers { get; set; }
        public virtual ICollection<Portador> PortadorChgUsers { get; set; }
        public virtual ICollection<Rondum> RondumAddUsers { get; set; }
        public virtual ICollection<Rondum> RondumChgUsers { get; set; }
        public virtual ICollection<Vehiculo> VehiculoAddUsers { get; set; }
        public virtual ICollection<Vehiculo> VehiculoChgUsers { get; set; }
    }
}
