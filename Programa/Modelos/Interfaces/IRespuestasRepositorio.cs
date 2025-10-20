using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de acceso a datos para la entidad Respuesta.
    /// </summary>
    public interface IRespuestasRepositorio
    {
        void Agregar(Respuesta respuestaModelo);
        void Editar(Respuesta respuestaModelo);
        void Eliminar(int id);
        IEnumerable<RespuestaDTO> MostrarTodo();
    }
}
