using Programa.Modelos.Interfaces;
using Programa.Modelos;
using Programa.Vistas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programa.Repositorios;
using Programa.Vistas;

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

            this.vista.agregarMovil += agregar_movil;
            this.vista.modificarMovil += modificar_movil;
            this.vista.eliminarMovil += eliminar_movil;
            this.vista.volver += volver_menu;
        }

        private void agregar_movil(object sender, EventArgs e) { }
        private void modificar_movil(object sender, EventArgs e) { }
        private void eliminar_movil(object sender, EventArgs e) { }
        private void volver_menu(object sender, EventArgs e) 
        {
            IRecordatorioRepositorio recordatorio = new RecordatorioRepositorio();
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            new InicioPresentador(inicio, recordatorio);
            ((Form)vista).Close();
        }
    }
}
