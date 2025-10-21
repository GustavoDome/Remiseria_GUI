using Programa.DTOs;
using System.Collections.Generic;

namespace Programa.Modelos.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de acceso a datos para la entidad Movil.
    /// </summary>
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