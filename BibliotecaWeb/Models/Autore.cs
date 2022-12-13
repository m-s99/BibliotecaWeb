using System;
using System.Collections.Generic;

namespace BibliotecaWeb.Models
{
    public partial class Autore
    {
        public Autore()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Eliminado { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
