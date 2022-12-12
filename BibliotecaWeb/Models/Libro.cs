using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BibliotecaWeb.Models
{
    public partial class Libro
    {
        public Libro()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int Id { get; set; }
        [DisplayName("Código")]
        public string CodigoInterno { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public string Editorial { get; set; } = null!;
        public bool Disponible { get; set; }
        [DisplayName("Temática")]
        public int TematicaId { get; set; }
        public bool Eliminado { get; set; }

        public virtual Tematica? Tematica { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
