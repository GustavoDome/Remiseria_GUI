using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de acceso a datos para la entidad Ciudad.
    /// </summary>
    public interface ICiudadRepositorio
    {
        IEnumerable<CiudadDTO> ObtenerTodas();
        void Agregar(CiudadDTO ciudad);
        void Editar(CiudadDTO ciudad);
        void Eliminar(int id);
    }
}
