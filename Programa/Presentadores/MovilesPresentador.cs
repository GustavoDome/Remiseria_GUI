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
    public class MovilesPresentador
    {
        private IMovilRepositorio repositorio;
        private IMovilesVista vista;
        private IEnumerable<MovilModelo> movilModelos;
        private BindingSource filtrador;

        public MovilesPresentador(IMovilesVista vista, IMovilRepositorio repositorio)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;
        }
    }
}
