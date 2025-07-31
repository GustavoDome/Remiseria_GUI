using Programa.Modelos.Interfaces;
using Programa.Modelos;
using Programa.Vistas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Presentadores
{
    public class OperadoresPresentador
    {
        private IUsuarioRepositorio repositorio;
        private IOperadoresVista vista;
        private IEnumerable<UsuarioModelo> usuarioModelos;
        private BindingSource filtrador;

        public OperadoresPresentador(IOperadoresVista vista, IUsuarioRepositorio repositorio)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;
        }
    }
}
