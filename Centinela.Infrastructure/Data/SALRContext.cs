using Centinela.Core.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centinela.Infrastructure.Data
{
    public partial class SALRContext : DbContext
    {
        public SALRContext()
        {
        }

        public SALRContext(DbContextOptions<SALRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditorium> Auditoria { get; set; }
        public virtual DbSet<ContactoEmergencium> ContactoEmergencia { get; set; }
        public virtual DbSet<Coordenadum> Coordenada { get; set; }
        public virtual DbSet<Dispositivo> Dispositivos { get; set; }
        public virtual DbSet<DispositivoCoordenadum> DispositivoCoordenada { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Portador> Portadors { get; set; }
        public virtual DbSet<Rondum> Ronda { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Auditorium>(entity =>
            {
                entity.HasKey(e => e.AuditoriaId);

                entity.HasIndex(e => e.AddUserId, "IX_Auditoria_AddUserId");

                entity.HasIndex(e => e.ChgUserId, "IX_Auditoria_ChgUserId");

                entity.HasIndex(e => e.DispositivoId, "IX_Auditoria_DispositivoId");

                entity.HasIndex(e => e.UsuarioId, "IX_Auditoria_UsuarioId");

                entity.Property(e => e.Operacion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.AddUser)
                    .WithMany(p => p.AuditoriumAddUsers)
                    .HasForeignKey(d => d.AddUserId);

                entity.HasOne(d => d.ChgUser)
                    .WithMany(p => p.AuditoriumChgUsers)
                    .HasForeignKey(d => d.ChgUserId);

                entity.HasOne(d => d.Dispositivo)
                    .WithMany(p => p.Auditoria)
                    .HasForeignKey(d => d.DispositivoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.AuditoriumUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ContactoEmergencium>(entity =>
            {
                entity.HasKey(e => e.ContactoEmergenciaId);

                entity.HasIndex(e => e.AddUserId, "IX_ContactoEmergencia_AddUserId");

                entity.HasIndex(e => e.ChgUserId, "IX_ContactoEmergencia_ChgUserId");

                entity.HasIndex(e => e.PortadorId, "IX_ContactoEmergencia_PortadorId");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.AddUser)
                    .WithMany(p => p.ContactoEmergenciumAddUsers)
                    .HasForeignKey(d => d.AddUserId);

                entity.HasOne(d => d.ChgUser)
                    .WithMany(p => p.ContactoEmergenciumChgUsers)
                    .HasForeignKey(d => d.ChgUserId);

                entity.HasOne(d => d.Portador)
                    .WithMany(p => p.ContactoEmergencia)
                    .HasForeignKey(d => d.PortadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Coordenadum>(entity =>
            {
                entity.HasKey(e => e.CoordenadaId);

                entity.HasIndex(e => e.AddUserId, "IX_Coordenada_AddUserId");

                entity.HasIndex(e => e.ChgUserId, "IX_Coordenada_ChgUserId");

                entity.HasIndex(e => e.RondaId, "IX_Coordenada_RondaId");

                entity.Property(e => e.Latitud).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Longitud).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.AddUser)
                    .WithMany(p => p.CoordenadumAddUsers)
                    .HasForeignKey(d => d.AddUserId);

                entity.HasOne(d => d.ChgUser)
                    .WithMany(p => p.CoordenadumChgUsers)
                    .HasForeignKey(d => d.ChgUserId);

                entity.HasOne(d => d.Ronda)
                    .WithMany(p => p.Coordenada)
                    .HasForeignKey(d => d.RondaId);
            });

            modelBuilder.Entity<Dispositivo>(entity =>
            {
                entity.ToTable("Dispositivo");

                entity.HasIndex(e => e.AddUserId, "IX_Dispositivo_AddUserId");

                entity.HasIndex(e => e.ChgUserId, "IX_Dispositivo_ChgUserId");

                entity.HasIndex(e => e.EmpresaId, "IX_Dispositivo_EmpresaId");

                entity.HasIndex(e => e.PortadorId, "IX_Dispositivo_PortadorId");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.AddUser)
                    .WithMany(p => p.DispositivoAddUsers)
                    .HasForeignKey(d => d.AddUserId);

                entity.HasOne(d => d.ChgUser)
                    .WithMany(p => p.DispositivoChgUsers)
                    .HasForeignKey(d => d.ChgUserId);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Dispositivos)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Portador)
                    .WithMany(p => p.Dispositivos)
                    .HasForeignKey(d => d.PortadorId);
            });

            modelBuilder.Entity<DispositivoCoordenadum>(entity =>
            {
                entity.HasKey(e => e.DispositivoCoordenadaId);

                entity.HasIndex(e => e.AddUserId, "IX_DispositivoCoordenada_AddUserId");

                entity.HasIndex(e => e.ChgUserId, "IX_DispositivoCoordenada_ChgUserId");

                entity.HasIndex(e => e.CoordenadaId, "IX_DispositivoCoordenada_CoordenadaId");

                entity.HasIndex(e => e.DispositivoId, "IX_DispositivoCoordenada_DispositivoId");

                entity.HasOne(d => d.AddUser)
                    .WithMany(p => p.DispositivoCoordenadumAddUsers)
                    .HasForeignKey(d => d.AddUserId);

                entity.HasOne(d => d.ChgUser)
                    .WithMany(p => p.DispositivoCoordenadumChgUsers)
                    .HasForeignKey(d => d.ChgUserId);

                entity.HasOne(d => d.Coordenada)
                    .WithMany(p => p.DispositivoCoordenada)
                    .HasForeignKey(d => d.CoordenadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Dispositivo)
                    .WithMany(p => p.DispositivoCoordenada)
                    .HasForeignKey(d => d.DispositivoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");

                entity.HasIndex(e => e.AddUserId, "IX_Empresa_AddUserId");

                entity.HasIndex(e => e.ChgUserId, "IX_Empresa_ChgUserId");

                entity.HasIndex(e => e.Rut, "IX_Empresa_Rut")
                    .IsUnique()
                    .HasFilter("([Rut] IS NOT NULL)");

                entity.Property(e => e.Direccion).HasMaxLength(30);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Observacion).HasMaxLength(500);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Rut).HasMaxLength(50);

                entity.HasOne(d => d.AddUser)
                    .WithMany(p => p.EmpresaAddUsers)
                    .HasForeignKey(d => d.AddUserId);

                entity.HasOne(d => d.ChgUser)
                    .WithMany(p => p.EmpresaChgUsers)
                    .HasForeignKey(d => d.ChgUserId);
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.ToTable("Evento");

                entity.HasIndex(e => e.AddUserId, "IX_Evento_AddUserId");

                entity.HasIndex(e => e.ChgUserId, "IX_Evento_ChgUserId");

                entity.HasIndex(e => e.DispositivoId, "IX_Evento_DispositivoId");

                entity.HasIndex(e => e.UsuarioId, "IX_Evento_UsuarioId");

                entity.Property(e => e.Latitud).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Longitud).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Observacion).HasMaxLength(500);

                entity.Property(e => e.Precision)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.AddUser)
                    .WithMany(p => p.EventoAddUsers)
                    .HasForeignKey(d => d.AddUserId);

                entity.HasOne(d => d.ChgUser)
                    .WithMany(p => p.EventoChgUsers)
                    .HasForeignKey(d => d.ChgUserId);

                entity.HasOne(d => d.Dispositivo)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.DispositivoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.EventoUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Password>(entity =>
            {
                entity.ToTable("Password");

                entity.HasIndex(e => e.AddUserId, "IX_Password_AddUserId");

                entity.HasIndex(e => e.ChgUserId, "IX_Password_ChgUserId");

                entity.HasIndex(e => e.UsuarioId, "IX_Password_UsuarioId")
                    .IsUnique();

                entity.Property(e => e.PasswordUsuario)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.AddUser)
                    .WithMany(p => p.PasswordAddUsers)
                    .HasForeignKey(d => d.AddUserId);

                entity.HasOne(d => d.ChgUser)
                    .WithMany(p => p.PasswordChgUsers)
                    .HasForeignKey(d => d.ChgUserId);

                entity.HasOne(d => d.Usuario)
                    .WithOne(p => p.PasswordUsuario)
                    .HasForeignKey<Password>(d => d.UsuarioId);
            });

            modelBuilder.Entity<Portador>(entity =>
            {
                entity.ToTable("Portador");

                entity.HasIndex(e => e.AddUserId, "IX_Portador_AddUserId");

                entity.HasIndex(e => e.ChgUserId, "IX_Portador_ChgUserId");

                entity.HasIndex(e => e.EmpresaId, "IX_Portador_EmpresaId");

                entity.HasIndex(e => e.VehiculoId, "IX_Portador_VehiculoId");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Correo).HasMaxLength(15);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(130);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Observacion).HasMaxLength(500);

                entity.Property(e => e.Ubicacion).HasMaxLength(150);

                entity.HasOne(d => d.AddUser)
                    .WithMany(p => p.PortadorAddUsers)
                    .HasForeignKey(d => d.AddUserId);

                entity.HasOne(d => d.ChgUser)
                    .WithMany(p => p.PortadorChgUsers)
                    .HasForeignKey(d => d.ChgUserId);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Portadors)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Vehiculo)
                    .WithMany(p => p.Portadors)
                    .HasForeignKey(d => d.VehiculoId);
            });

            modelBuilder.Entity<Rondum>(entity =>
            {
                entity.HasKey(e => e.RondaId);

                entity.HasIndex(e => e.AddUserId, "IX_Ronda_AddUserId");

                entity.HasIndex(e => e.ChgUserId, "IX_Ronda_ChgUserId");

                entity.HasIndex(e => e.EmpresaId, "IX_Ronda_EmpresaId");

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.AddUser)
                    .WithMany(p => p.RondumAddUsers)
                    .HasForeignKey(d => d.AddUserId);

                entity.HasOne(d => d.ChgUser)
                    .WithMany(p => p.RondumChgUsers)
                    .HasForeignKey(d => d.ChgUserId);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Ronda)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.HasIndex(e => e.AddUserId, "IX_Usuario_AddUserId");

                entity.HasIndex(e => e.ChgUserId, "IX_Usuario_ChgUserId");

                entity.HasIndex(e => e.Correo, "IX_Usuario_Correo")
                    .IsUnique();

                entity.HasIndex(e => e.EmpresaId, "IX_Usuario_EmpresaId");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Observacion).HasMaxLength(500);

                entity.HasOne(d => d.AddUser)
                    .WithMany(p => p.InverseAddUser)
                    .HasForeignKey(d => d.AddUserId);

                entity.HasOne(d => d.ChgUser)
                    .WithMany(p => p.InverseChgUser)
                    .HasForeignKey(d => d.ChgUserId);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("Vehiculo");

                entity.HasIndex(e => e.AddUserId, "IX_Vehiculo_AddUserId");

                entity.HasIndex(e => e.ChgUserId, "IX_Vehiculo_ChgUserId");

                entity.Property(e => e.Color).HasMaxLength(30);

                entity.Property(e => e.Marca).HasMaxLength(20);

                entity.Property(e => e.Patente)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.AddUser)
                    .WithMany(p => p.VehiculoAddUsers)
                    .HasForeignKey(d => d.AddUserId);

                entity.HasOne(d => d.ChgUser)
                    .WithMany(p => p.VehiculoChgUsers)
                    .HasForeignKey(d => d.ChgUserId);
            });
           
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
