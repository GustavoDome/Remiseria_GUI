using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos
{
    public class MovilModelo
    {
        private int id_movil;
        private int numero_movil;
        private string marca_auto;
        private string modelo_auto;
        private string ano_auto;
        private string color_auto;
        private bool activo;
        private int id_dueno_auto;
        public int Id_movil
        {
            get { return id_movil; }
            set { id_movil = value; }
        }

        public int Numero_movil
        {
            get { return numero_movil; }
            set { numero_movil = value; }
        }

        public string Marca_auto
        {
            get { return marca_auto; }
            set { marca_auto = value; }
        }

        public string Modelo_auto
        {
            get { return modelo_auto; }
            set { modelo_auto = value; }
        }

        public string Ano_auto
        {
            get { return ano_auto; }
            set { ano_auto = value; }
        }

        public string Color_auto
        {
            get { return color_auto; }
            set { color_auto = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public int Id_dueno_auto
        {
            get { return id_dueno_auto; }
            set { id_dueno_auto = value; }
        }
    }
}
