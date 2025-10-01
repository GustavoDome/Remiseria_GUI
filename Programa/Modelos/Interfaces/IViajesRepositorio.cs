using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IViajesRepositorio
    {
        void Agregar(AgregarViajeDTO viaje);
        void Editar(ModificarViajeDTO dto);
        void Eliminar(int id);
        ModificarViajeDTO ObtenerPorId(int idViaje);
        IEnumerable<MovilResumenDTO> SeleccionarMovil();
        DataTable MostrarTodo(DateTime fecha);
        DataTable MostrarVuelta(DateTime fecha);
    }
}
