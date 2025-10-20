using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de acceso a datos para la entidad Base.
    /// </summary>
    public interface IBasesRepositorio
    {
        void Agregar(Base entidad);
        void Editar(Base entidad);
        void Eliminar(int id);
        bool ExisteBaseEnFecha(int idMovil, DateTime fecha);
        void EditarComentario(Base baseEditada);
        IEnumerable<MovilResumenDTO> SeleccionarMovil(); // reemplaza MovilModeloId
        IEnumerable<BaseDetalleDTO> MostrarTodo(int id_movil);
        BaseDetalleDTO BuscarPorId(int idBase);
    }
}