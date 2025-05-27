using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IRespuestasRepositorio
    {
        void agregar(RespuestaModelo respuestaModelo);

        void editar(RespuestaModelo respuestaModelo);

        void eliminar(int id);

        IEnumerable<RespuestaModelo> mostrarTodo();
    }
}
