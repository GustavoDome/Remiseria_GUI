using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    public class DuenoAutoDTO
    {
        public int IdDueno { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public bool Chofer { get; set; }
        public string Telefono { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
