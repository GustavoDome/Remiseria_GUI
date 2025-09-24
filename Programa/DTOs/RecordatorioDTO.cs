using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    public class RecordatorioDTO
    {
        public string Ubicacion { get; set; }
        public DateTime? FechaDia { get; set; }
        public DateTime? FechaHora { get; set; }
        public string FechaCompleta => $"{FechaDia:dd/MM/yyyy} {FechaHora:HH:mm}";
        public string NombreOperador { get; set; }
    }
}
