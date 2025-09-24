using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IPreguntaRepositorio
    {
        void Agregar(Pregunta preguntaModelo);
        void Editar(Pregunta preguntaModelo);
        void Eliminar(int id);
        IEnumerable<PreguntaDTO> MostrarTodo();
    }
}
