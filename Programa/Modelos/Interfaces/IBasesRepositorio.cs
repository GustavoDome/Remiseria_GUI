using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IBasesRepositorio
    {
        void agregar(BasesModelo basesModelo);

        void editar(BasesModelo basesModelo);

        void eliminar(int id);

        IEnumerable<BasesModeloMovilId> seleccionarMovil();
        IEnumerable<BasesModelo> mostrarTodo(BasesModelo basesmodelo);
    }
}
