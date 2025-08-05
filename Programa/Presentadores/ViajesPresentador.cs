using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Repositorios;
using Programa.Vistas;
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

            this.vista.agregarViaje += agregar_viaje;
            this.vista.modificarViaje += modificar_viaje;
            this.vista.comentarViaje += comentar_viaje;
            this.vista.eliminarViaje += eliminar_viaje;
            this.vista.retroceder += retroceder_dia;
            this.vista.adelantar += adelantar_dia;
            this.vista.ingresarVuelta += ingresar_vuelta;
            this.vista.volver += volver_menu;
        }

        private void agregar_viaje(object sender, EventArgs e) { }
        private void modificar_viaje(object sender, EventArgs e) { }
        private void comentar_viaje(object sender, EventArgs e) { }
        private void eliminar_viaje(object sender, EventArgs e) { }
        private void retroceder_dia(object sender, EventArgs e) { }
        private void adelantar_dia(object sender, EventArgs e) { }
        private void ingresar_vuelta(object sender, EventArgs e) { }
        private void volver_menu(object sender, EventArgs e) 
        {
            IRecordatorioRepositorio recordatorio = new RecordatorioRepositorio();
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            new InicioPresentador(inicio, recordatorio);
            ((Form)vista).Close();
        }
    }
}
