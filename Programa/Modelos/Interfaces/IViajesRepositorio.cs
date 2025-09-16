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
        void agregar(agregarViajeModelo viajesModelo);

        void editar(agregarViajeModelo viajesModelo);

        void eliminar(int id);

        IEnumerable<MovilModeloId> seleccionarMovil();
        DataTable mostrarTodo();
        IEnumerable<VueltaModelo> mostrarVuelta();
        IEnumerable<VueltaIdModelo> seleccionarVuelta();
    }
}
