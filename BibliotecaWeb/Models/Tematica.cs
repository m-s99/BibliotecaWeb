using System;
using System.Collections.Generic;

namespace BibliotecaWeb.Models
{
    public partial class Tematica
    {
        public Tematica()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int? UsuarioId { get; set; }
        public DateTime? FechaHoraEliminacion { get; set; }
        public bool Eliminado { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<Libro> Libros { get; set; }
    }
}
