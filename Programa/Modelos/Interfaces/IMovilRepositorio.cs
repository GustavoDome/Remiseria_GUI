using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IMovilRepositorio
    {
        void agregar(MovilModelo movilModelo);

        void editar(MovilModelo movilModelo);

        void eliminar(int id);

        IEnumerable<MovilModelo> mostrarTodo();
    }
}
