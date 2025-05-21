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
        private int estado_vuelta;
        private int vuelta;
        private string vuelta_fecha;
        private int id_movil;
        private int id_operador;
        public int Id_viajes
        {
            get { return id_viajes; }
            set { id_viajes = value; }
        }

        public string Hora_viaje
        {
            get { return hora_viaje; }
            set { hora_viaje = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public int Estado_vuelta
        {
            get { return estado_vuelta; }
            set { estado_vuelta = value; }
        }

        public int Vuelta
        {
            get { return vuelta; }
            set { vuelta = value; }
        }

        public string Vuelta_fecha
        {
            get { return vuelta_fecha; }
            set { vuelta_fecha = value; }
        }

        public int Id_movil
        {
            get { return id_movil; }
            set { id_movil = value; }
        }

        public int Id_operador
        {
            get { return id_operador; }
            set { id_operador = value; }
        }
    }
}
