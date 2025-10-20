using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de acceso a datos para los importes por ciudad.
    /// </summary>
    public interface IImporteCiudadRepositorio
    {
        ImporteCiudadDTO ObtenerImportes();
        void ModificarImportes(ImporteCiudadDTO dto);
    }
}