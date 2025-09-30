using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    public class BaseDetalleDTO
    {
        public int IdBase { get; set; }
        public DateTime Fecha_base { get; set; }
        public bool EstadoBase { get; set; }
        public string Comentario { get; set; }
        // Opcional: si querés mostrar quién la registró
        public string NombreOperador { get; set; }
        public string RolOperador { get; set; }
    }
}
