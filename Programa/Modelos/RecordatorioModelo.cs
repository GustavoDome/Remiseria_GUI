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

        public int Id_recordatorio
        {
            get { return id_recordatorio; }
            set { id_recordatorio = value; }
        }

        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public string Fecha_dia
        {
            get { return fecha_dia; }
            set { fecha_dia = value; }
        }
        public string Fecha_hora
        {
            get { return fecha_hora; }
            set { fecha_hora = value; }
        }

        public int Id_viaje
        {
            get { return id_viaje; }
            set { id_viaje = value; }
        }
    }
}
