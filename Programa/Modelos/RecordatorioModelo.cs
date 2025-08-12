using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos
{
    public class RecordatorioModelo
    {
        private int id_recordatorio;
        private string ubicacion;
        private string fecha_dia;
        private string fecha_hora;
        private int id_viaje;

        public int Id_recordatorio { get; set; }
        public string Ubicacion { get; set; }
        public string Fecha_dia { get; set; }
        public string Fecha_hora { get; set; }
        public int Id_viaje { get; set; }
    }
}
