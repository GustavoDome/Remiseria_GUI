using Programa.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IUsuarioRepositorio
    {
        void agregar(UsuarioModelo usuarioModelo);
        void editar(UsuarioModelo usuarioModelo);
        void eliminar(int id);
        IEnumerable<UsuarioModelo> mostrarTodo();
        UsuarioModelo LoginUsuario(string nombre, string contrasena);
    }
}
