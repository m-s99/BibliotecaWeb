using System;
using System.Collections.Generic;
using BibliotecaWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BibliotecaWeb.Data
{
    public partial class smartsof_biblioContext : DbContext
    {
        public smartsof_biblioContext()
        {
        }

        public smartsof_biblioContext(DbContextOptions<smartsof_biblioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
        public virtual DbSet<Socio> Socios { get; set; } = null!;
        public virtual DbSet<Tematica> Tematicas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseMySql("server=184.175.77.148;database=smartsof_biblio;uid=smartsof_matisabino;pwd=matisabino", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.37-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasIndex(e => e.TematicaId, "IX_Libros_TematicaId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Autor).HasColumnType("text");

                entity.Property(e => e.CodigoInterno).HasColumnType("text");

                entity.Property(e => e.Editorial).HasColumnType("text");

                entity.Property(e => e.TematicaId).HasColumnType("int(11)");

                entity.Property(e => e.Titulo).HasColumnType("text");

                entity.HasOne(d => d.Tematica)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.TematicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasIndex(e => e.LibroId, "IX_Prestamos_LibroId");

                entity.HasIndex(e => e.SocioId, "IX_Prestamos_SocioId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FechaEntrega).HasColumnType("datetime");

                entity.Property(e => e.FechaRetiro).HasColumnType("datetime");

                entity.Property(e => e.LibroId).HasColumnType("int(11)");

                entity.Property(e => e.SocioId).HasColumnType("int(11)");

                entity.HasOne(d => d.Libro)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.LibroId);

                entity.HasOne(d => d.Socio)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.SocioId);

                
            });

            modelBuilder.Entity<Socio>(entity =>
            {

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Apellido).HasColumnType("text");

                entity.Property(e => e.Dni).HasColumnType("int(11)");

                entity.Property(e => e.Domicilio).HasColumnType("text");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasColumnType("text");
            });

            modelBuilder.Entity<Tematica>(entity =>
            {

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("text");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.UsuarioId1, "IX_Usuarios_UsuarioId1");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FechaHoraEliminacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasColumnType("text");

                entity.Property(e => e.Password).HasColumnType("text");

                entity.Property(e => e.TipoUsuario).HasColumnType("int(11)");

                entity.Property(e => e.User).HasColumnType("text");

                entity.Property(e => e.UsuarioId).HasColumnType("int(11)");

                entity.Property(e => e.UsuarioId1).HasColumnType("int(11)");

                entity.HasOne(d => d.UsuarioId1Navigation)
                    .WithMany(p => p.InverseUsuarioId1Navigation)
                    .HasForeignKey(d => d.UsuarioId1);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
