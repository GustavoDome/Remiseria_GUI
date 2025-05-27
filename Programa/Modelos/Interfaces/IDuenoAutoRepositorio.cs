using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IDuenoAutoRepositorio
    {
        void agregar(DuenoAutoModelo duenoAutoModelo);

        void editar(DuenoAutoModelo duenoAutoModelo);

        void eliminar(int id);

        IEnumerable<DuenoAutoModelo> mostrarTodo();
    }
}
