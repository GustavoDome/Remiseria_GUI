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
        private string hora_viaje;
        private string direccion;
        private int id_operador;

        public int Id_viajes { get; set; }
        public string Hora_viaje { get; set; }
        public string Direccion { get; set; }
        public IEnumerable<ViajesModeloId> Id_movil { get; set; }
        public string Id_operador { get; set; }
    }

    public class ViajesModeloId 
    {
        private string id_movil;

        public int Id_movil { get; set; }
    }

    public class VueltaModelo
    {
        private int estado_vuelta;
        private int vuelta;
        private string vuelta_fecha;

        public int Estado_vuelta { get; set; }
        public int Vuelta { get; set; }
        public string Vuelta_fecha { get; set; }

        public IEnumerable<ViajesModeloId> Id_movil { get; set; }
    }
}
