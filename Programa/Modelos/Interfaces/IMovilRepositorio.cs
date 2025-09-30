using Programa.DTOs;
using System.Collections.Generic;

namespace Programa.Modelos.Interfaces
{
    public interface IMovilRepositorio
    {
        void Agregar(Movil movil);
        void Editar(Movil movil);
        void Eliminar(int id);
        IEnumerable<Movil> ObtenerTodosDesdeBD();
        IEnumerable<MovilDetalleDTO> ObtenerTodos();
        IEnumerable<MovilResumenDTO> ObtenerMovilesReducidos();
    }
}