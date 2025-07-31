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
    public class VueltaPresentador
    {
        private IViajesRepositorio repositorio;
        private IVueltaVista vista;
        private IEnumerable<ViajesModelo> viajesModelos;
        private BindingSource filtrador;

        public VueltaPresentador(IVueltaVista vista, IViajesRepositorio repositorio)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;
        }
    }
}
