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
    public class BasesPresentador
    {
        private IBasesRepositorio repositorio;
        private IBasesVista vista;
        private IEnumerable<BasesModelo> movilModelos;
        private BindingSource filtrador;

        public BasesPresentador(IBasesVista vista, IBasesRepositorio repositorio)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;
        }
    }
}
