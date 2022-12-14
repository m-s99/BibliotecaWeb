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
        public int EditorialId { get; set; }
        public int AutorId { get; set; }
        public int TematicaId { get; set; }
        public bool Disponible { get; set; }
        public bool Eliminado { get; set; }

        public virtual Autore? Autor { get; set; }
        public virtual Editoriale? Editorial { get; set; }
        public virtual Tematica? Tematica { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
