using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Repositorios;
using Programa.Vistas;
using Programa.Vistas.Alta;
using Programa.Vistas.Alta.Interfaces;
using Programa.Vistas.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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
        private string rol;
        private int id;

        public ViajesPresentador(IViajesVista vista, IViajesRepositorio repositorio, string rol, int id) 
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;
            this.rol = rol;
            this.id = id;

            this.vista.ocultarBotones(this.rol);
            this.vista.SetViajesBindingSource(filtrador);
            cargar_datos();

            this.vista.agregarViaje += agregar_viaje;
            this.vista.modificarViaje += modificar_viaje;
            this.vista.comentarViaje += comentar_viaje;
            this.vista.eliminarViaje += eliminar_viaje;
            this.vista.retroceder += retroceder_dia;
            this.vista.adelantar += adelantar_dia;
            this.vista.ingresarVuelta += ingresar_vuelta;
            this.vista.volver += volver_menu;
        }

        private void cargar_datos() 
        {
            this.filtrador.DataSource = this.repositorio.mostrarTodo();
            this.vista.congelarVista();
        }

        private int ObtenerSiguienteId()
        {
            // Verificamos si el DataSource está vacío
            if (this.filtrador.Count == 0)
                return 1;

            // Convertimos el DataTable a una lista de ViajesModelo
            var tabla = this.filtrador.DataSource as DataTable;
            if (tabla == null)
                throw new InvalidOperationException("El DataSource no es un DataTable.");

            var listaViajes = tabla.AsEnumerable()
                .Select(row => new ViajesModelo
                {
                    Id_viajes = Convert.ToInt32(row["ID Viaje"]),
                    // Agregá otros campos si los necesitás
                }).ToList();

            // Obtenemos el ID máximo
            var maxId = listaViajes.Max(v => v.Id_viajes);
            return maxId + 1;
        }


        private void agregar_viaje(object sender, EventArgs e) 
        {
            int siguienteid = ObtenerSiguienteId();
            IAgregarViajesVista agregarViajes = AgregarViajesVista.ObtenerInstancia(siguienteid, this.id, this.rol);
        }
        private void modificar_viaje(object sender, EventArgs e) { }
        private void comentar_viaje(object sender, EventArgs e) { }
        private void eliminar_viaje(object sender, EventArgs e) { }
        private void retroceder_dia(object sender, EventArgs e) { }
        private void adelantar_dia(object sender, EventArgs e) { }
        private void ingresar_vuelta(object sender, EventArgs e) 
        {
            IViajesRepositorio viajes = new ViajesRepositorio();
            IVueltaVista vuelta = VueltaVista.ObtenerInstancia();
            new VueltaPresentador(vuelta, viajes, this.rol, this.id);
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
