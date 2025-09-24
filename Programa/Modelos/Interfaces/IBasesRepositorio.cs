using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IBasesRepositorio
    {
        void Agregar(Base entidad);
        void Editar(Base entidad);
        void Eliminar(int id);

        IEnumerable<MovilResumenDTO> SeleccionarMovil(); // reemplaza MovilModeloId
        IEnumerable<BaseDetalleDTO> MostrarTodo(int id_movil);
    }
}