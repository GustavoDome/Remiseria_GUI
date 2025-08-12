using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos
{
    public class PreguntaModelo
    {
        private int id_pregunta;
        private string pregunta;
        private int id_categoria;

        public int Id_pregunta { get; set; }
        public string Pregunta { get; set; }
        public int Id_categoria { get; set; }
    }
}
