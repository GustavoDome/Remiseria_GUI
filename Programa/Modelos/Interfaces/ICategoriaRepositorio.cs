using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Programa.Modelos.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de acceso a datos para la entidad Categoria.
    /// </summary>
    public interface ICategoriaRepositorio
    {
        void Agregar(Categoria categoria);
        void Editar(Categoria categoria);
        void Eliminar(int id);
        IEnumerable<CategoriaDTO> ObtenerTodas();
    }
}