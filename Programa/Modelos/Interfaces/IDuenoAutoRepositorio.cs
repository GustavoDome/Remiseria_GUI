using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Programa.Modelos.Interfaces
{
    public interface IDuenoAutoRepositorio
    {
        void Agregar(DuenoAuto dueno);
        void Editar(DuenoAuto dueno);
        void Eliminar(int id);
        IEnumerable<DuenoAutoDTO> ObtenerTodos();
    }
}