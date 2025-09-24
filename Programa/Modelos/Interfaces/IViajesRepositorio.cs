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
        void Editar(AgregarViajeDTO viaje);
        void Eliminar(int id);

        IEnumerable<MovilResumenDTO> SeleccionarMovil();
        DataTable MostrarTodo(DateTime fecha);
        DataTable MostrarVuelta(DateTime fecha);
    }
}
