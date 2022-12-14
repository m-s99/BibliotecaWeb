using System;
using System.Collections.Generic;

namespace BibliotecaWeb.Models
{
    public partial class Prestamo
    {
        public int Id { get; set; }
        public DateTime FechaRetiro { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int SocioId { get; set; }
        public int LibroId { get; set; }
        public bool LibroDevuelto { get; set; }
        public bool Eliminado { get; set; }

        public virtual Libro Libro { get; set; } = null!;
        public virtual Socio Socio { get; set; } = null!;
    }
}
