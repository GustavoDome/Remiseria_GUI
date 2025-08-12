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

        public int Id_movil { get; set; }
        public int Numero_movil { get; set; }
        public string Marca_auto { get; set; }
        public string Modelo_auto { get; set; }
        public string Ano_auto { get; set; }
        public string Color_auto { get; set; }
        public bool Activo { get; set; }
        public int Id_dueno_auto { get; set; }
    }
}
