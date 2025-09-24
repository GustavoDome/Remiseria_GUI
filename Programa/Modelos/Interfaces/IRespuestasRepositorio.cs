using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IRespuestasRepositorio
    {
        void Agregar(Respuesta respuestaModelo);
        void Editar(Respuesta respuestaModelo);
        void Eliminar(int id);
        IEnumerable<RespuestaDTO> MostrarTodo();
    }
}
