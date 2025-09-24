using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    public class VueltaDTO
    {
        public int IdViaje { get; set; }
        public int IdMovil { get; set; }
        public int NumeroVuelta { get; set; }
        public DateTime VueltaFecha { get; set; }
        public string EstadoVuelta { get; set; }
    }
}
