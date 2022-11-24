using System;
using System.Collections.Generic;

namespace BibliotecaWeb.Models
{
    public partial class Libro
    {
        public Libro()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int Id { get; set; }
        public string CodigoInterno { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public string Editorial { get; set; } = null!;
        public bool Disponible { get; set; }
        public byte[]? Imagen { get; set; }
        public int TematicaId { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime? FechaHoraEliminacion { get; set; }
        public bool Eliminado { get; set; }

        public virtual Tematica Tematica { get; set; } = null!;
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
