using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    public class ViajeDTO
    {
        public int IdViaje { get; set; }
        public TimeSpan HoraViaje { get; set; }
        public string Direccion { get; set; }
        public string EstadoViaje { get; set; }
        public string Comentario { get; set; }
        public List<int> IdMoviles { get; set; }
        public string MovilesConcatenados { get; set; }
    }
}
