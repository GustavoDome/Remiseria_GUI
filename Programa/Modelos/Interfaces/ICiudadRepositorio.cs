using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface ICiudadRepositorio
    {
        IEnumerable<CiudadDTO> ObtenerTodas();
        void Agregar(CiudadDTO ciudad);
        void Editar(CiudadDTO ciudad);
        void Eliminar(int id);
    }
}
