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

        public int Id_pregunta
        {
            get { return id_pregunta; }
            set { id_pregunta = value; } 
        }

        public string Pregunta
        {
            get { return pregunta; }
            set { pregunta = value; }
        }

        public int Id_categoria
        {
            get { return id_categoria; }
            set { id_categoria = value; }
        }
    }
}
