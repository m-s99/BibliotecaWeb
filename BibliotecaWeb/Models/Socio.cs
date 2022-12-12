using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaWeb.Models
{
    public partial class Socio
    {
        public Socio()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int Id { get; set; }
        public string Apellido { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int Dni { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; } = null!;
        public double Telefono { get; set; }
        public bool Eliminado { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
