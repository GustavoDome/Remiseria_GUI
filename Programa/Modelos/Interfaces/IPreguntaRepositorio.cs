using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IPreguntaRepositorio
    {
        void agregar(PreguntaModelo preguntaModelo);

        void editar(PreguntaModelo preguntaModelo);

        void eliminar(int id);

        IEnumerable<PreguntaModelo> mostrarTodo();
    }
}
