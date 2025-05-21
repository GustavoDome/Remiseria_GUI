using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos
{
    public class CategoriaModelo
    {
        private int id_categoria;
        private string categoria_pregunta;

        public int Id_categoria
        {
            get { return id_categoria; }
            set { id_categoria = value; }
        }

        public string Categoria_pregunta
        {
            get { return categoria_pregunta;}
            set { categoria_pregunta = value; }
        }
    }
}
