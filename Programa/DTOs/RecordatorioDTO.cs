using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    public class RecordatorioDTO
    {
        public int IdRecordatorio { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaDia { get; set; }
        public DateTime? FechaHora { get; set; }
        public string Comentario { get; set; }
        public string NombreOperador { get; set; }
    }
}
