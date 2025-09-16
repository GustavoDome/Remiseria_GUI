using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos
{
    public class ViajesModelo
    {
        private int id_viajes;
        private TimeSpan hora_viaje;
        private string direccion;
        private string comentario;
        private string estado_viaje;
        private int id_operador;
        private List<int> id_movil;
        private string movilesconcatenados;

        public int Id_viajes { get; set; }
        public TimeSpan Hora_viaje { get; set; }
        public string Direccion { get; set; }
        public string Comentario { get; set; }
        public string Estado_viaje { get; set; }
        public int Id_operador { get; set; }
        public List<int> Id_movil { get; set; } // Lista de móviles
        public string MovilesConcatenados { get; set; } // Para mostrar en DataGridView
    }

    public class agregarViajeModelo 
    {
        private int id;
        private TimeSpan hora_viaje;
        private string direccion;
        private string estado_vuelta;
        private string vuelta;
        private DateTime vuelta_fecha;
        private string id_operador;
        private string estado_viaje;
        private string comentario;
        private List<int> id_movil;
        private string movilesconcatenados;
        public int Id { get; set; }
        public TimeSpan Hora_viaje { get; set; }
        public string Direccion { get; set; }
        public string Estado_vuelta { get; set; }
        public int Vuelta { get; set; }
        public DateTime Vuelta_fecha { get; set; }
        public int Id_operador { get; set; }
        public string Estado_viaje { get; set; }
        public string Comentario { get; set; }
        public List<int> Id_movil { get; set; } // Lista de móviles
        public string MovilesConcatenados { get; set; } // Para mostrar en DataGridView

    }

    public class ViajesModeloId 
    {
        private string numero_movil;

        public int Id_movil { get; set; }
    }

    public class VueltaModelo
    {
        private string estado_vuelta;
        private int vuelta;
        private string vuelta_fecha;

        public string Estado_vuelta { get; set; }
        public int Vuelta { get; set; }
        public string Vuelta_fecha { get; set; }

        public IEnumerable<ViajesModeloId> Id_movil { get; set; }
    }
}
