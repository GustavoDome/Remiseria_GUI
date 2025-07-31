using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Vistas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Presentadores
{
    public class ViajesPresentador
    {
        private IViajesRepositorio repositorio;
        private IViajesVista vista;
        private IEnumerable<ViajesModelo> viajesModelos;
        private BindingSource filtrador;

        public ViajesPresentador(IViajesVista vista, IViajesRepositorio repositorio) 
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;
        }
    }
}
