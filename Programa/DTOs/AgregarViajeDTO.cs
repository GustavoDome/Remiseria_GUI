using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    public class AgregarViajeDTO
    {
        public int IdViaje { get; set; } // solo para edición
        public int NumeroViaje { get; set; }
        public TimeSpan HoraViaje { get; set; }
        public string Direccion { get; set; }
        public int IdOperador { get; set; }
        public string EstadoViaje { get; set; }
        public string Comentario { get; set; }
        public List<int> IdMoviles { get; set; }
        public List<int> Vueltas { get; set; }
        public DateTime VueltaFecha { get; set; }
        public string EstadoVuelta { get; set; }
        public List<int> IdsVueltasActivadas { get; set; } = new List<int>();
    }
}
