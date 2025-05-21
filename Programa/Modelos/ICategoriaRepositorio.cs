using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos
{
    public interface ICategoriaRepositorio
    {
        void agregar(CategoriaModelo categoriaModelo);

        void editar(CategoriaModelo categoriaModelo);

        void eliminar(int id);

        IEnumerable<CategoriaModelo> mostrarTodo();
    }
}
