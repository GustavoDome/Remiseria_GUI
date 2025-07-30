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
    public class InicioPresentador
    {
        private IRecordatorioRepositorio repositorio;
        private IInicioVista vista;
        private IEnumerable<RecordatorioModelo> modelosRecordatorio;
        private BindingSource filtrador;
        public InicioPresentador (IInicioVista vista, IRecordatorioRepositorio repositorio)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;
        }

        private void agregarRecordatorio(object sender, EventArgs e) { }
        private void modificarRecordatorio(object sender, EventArgs e) { }
        private void eliminarRecordatorio(object sender, EventArgs e) { }
        private void volver(object sender, EventArgs e) { }
        private void ingresarayuda(object sender, EventArgs e) { }
        private void ingresarconfiguracion(object sender, EventArgs e) { }
        private void ingresaroperadores(object sender, EventArgs e) { }
        private void ingresarMoviles(object sender, EventArgs e) { }
        private void ingresarViajes(object sender, EventArgs e) { }
        private void ingresarVueltas(object sender, EventArgs e) { }
        private void ingresarBases(object sender, EventArgs e) { }
    }
}
