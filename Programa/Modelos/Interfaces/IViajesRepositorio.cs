using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IViajesRepositorio
    {
        void agregar(ViajesModelo viajesModelo);

        void editar(ViajesModelo viajesModelo);

        void eliminar(int id);

        IEnumerable<ViajesModelo> mostrarTodo();
    }
}
