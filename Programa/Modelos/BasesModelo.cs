using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos
{
    public class BasesModelo
    {
        private int id;
        private bool estado_base;
        private string fecha_base;
        private bool activo;
        private int id_movil;
        private int id_operador;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool Estado_base
        {
            get { return Estado_base; }
            set {  Estado_base = value; }
        }

        public string Fecha_base
        {
            get { return fecha_base; }
            set { fecha_base = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
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
