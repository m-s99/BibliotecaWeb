using System;
using System.Collections.Generic;

namespace BibliotecaWeb.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            InverseUsuarioId1Navigation = new HashSet<Usuario>();
            Libros = new HashSet<Libro>();
            Prestamos = new HashSet<Prestamo>();
            Socios = new HashSet<Socio>();
            Tematicas = new HashSet<Tematica>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string User { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int TipoUsuario { get; set; }
        public int? UsuarioId { get; set; }
        public int? UsuarioId1 { get; set; }
        public DateTime? FechaHoraEliminacion { get; set; }
        public bool Eliminado { get; set; }

        public virtual Usuario? UsuarioId1Navigation { get; set; }
        public virtual ICollection<Usuario> InverseUsuarioId1Navigation { get; set; }
        public virtual ICollection<Libro> Libros { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
        public virtual ICollection<Socio> Socios { get; set; }
        public virtual ICollection<Tematica> Tematicas { get; set; }
    }
}
