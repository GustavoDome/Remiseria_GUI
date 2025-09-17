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
    public class VueltaPresentador
    {
        private IViajesRepositorio repositorio;
        private IVueltaVista vista;
        private IEnumerable<VueltaModelo> vueltaModelos;
        private BindingSource filtrador;
        private string rol;
        private int id;

        public VueltaPresentador(IVueltaVista vista, IViajesRepositorio repositorio, string rol, int id)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;
            this.rol = rol;
            this.id = id;

            this.vista.ocultarBotones(this.rol);
            this.vista.SetViajesBindingSource(this.filtrador);
            MostrarVuelta();

            this.vista.agregarVuelta += agregar_vuelta;
            this.vista.modificarVuelta += modificar_vuelta;
            this.vista.eliminarVuelta += eliminar_vuelta;
            this.vista.retroceder += retroceder_dia;
            this.vista.adelantar += adelantar_dia;
            this.vista.ingresarViaje += ingresar_viaje;
            this.vista.volver += volver_menu;
            this.id = id;
        }

        private void MostrarVuelta() 
        {
            var lista = this.repositorio.mostrarVuelta().ToList();
            this.filtrador.DataSource = lista;
        }
        private void agregar_vuelta(object sender, EventArgs e) { }
        private void modificar_vuelta(object sender, EventArgs e) { }
        private void eliminar_vuelta(object sender, EventArgs e) { }
        private void retroceder_dia(object sender, EventArgs e) { }
        private void adelantar_dia(object sender, EventArgs e) { }
        private void ingresar_viaje(object sender, EventArgs e)
        {
            IViajesRepositorio viajes = new ViajesRepositorio();
            IViajesVista viajesvista = ViajesVista.ObtenerInstancia(this.rol, this.id);
            new ViajesPresentador(viajesvista, viajes, this.rol, this.id);
            ((Form)vista).Close();
        }
        private void volver_menu(object sender, EventArgs e) 
        {
            IRecordatorioRepositorio recordatorio = new RecordatorioRepositorio();
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            new InicioPresentador(inicio, recordatorio, this.rol, this.id);
            ((Form)vista).Close();
        }
    }
}
