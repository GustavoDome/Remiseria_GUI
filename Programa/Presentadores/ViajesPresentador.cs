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
        private readonly IViajesVista vista;
        private readonly IViajesRepositorio repositorio;
        private readonly BindingSource filtrador;
        private DateTime fechaActual;
        private readonly string rol;
        private readonly int id;

        public ViajesPresentador(IViajesVista vista, IViajesRepositorio repositorio, string rol, int id)
        {
            this.vista = vista;
            this.repositorio = repositorio;
            this.rol = rol;
            this.id = id;
            this.filtrador = new BindingSource();
            this.fechaActual = DateTime.Today;

            this.vista.ocultarBotones(this.rol);
            this.vista.SetViajesBindingSource(this.filtrador);
            this.vista.SetFecha(this.fechaActual);

            cargar_datos();

            this.vista.agregarViaje += agregar_viaje;
            this.vista.modificarViaje += modificar_viaje;
            this.vista.comentarViaje += comentar_viaje;
            this.vista.eliminarViaje += eliminar_viaje;
            this.vista.retroceder += retroceder_dia;
            this.vista.adelantar += adelantar_dia;
            this.vista.ingresarVuelta += ingresar_vuelta;
            this.vista.volver += volver_menu;
            this.vista.recargar += cargar_datos;
        }

        private void cargar_datos(object sender = null, EventArgs e = null)
        {
            var tabla = repositorio.MostrarTodo(fechaActual);
            filtrador.DataSource = tabla;
            vista.congelarVista();
            vista.OcultarIdViaje();
        }

        private int ObtenerSiguienteNumeroViaje()
        {
            var tabla = filtrador.DataSource as DataTable;
            if (tabla == null || tabla.Rows.Count == 0)
                return 1;

            var max = tabla.AsEnumerable()
                .Select(row => Convert.ToInt32(row["N° Viaje"]))
                .DefaultIfEmpty(0)
                .Max();

            return max + 1;
        }

        private void agregar_viaje(object sender, EventArgs e)
        {
            int numeroViaje = ObtenerSiguienteNumeroViaje();
            IAgregarViajesVista agregarVista = AgregarViajesVista.ObtenerInstancia(numeroViaje, id, rol);
            // Podés pasar fechaActual si querés que el viaje se cree en ese día
        }

        private void modificar_viaje(object sender, EventArgs e)
        {
            // Implementar lógica de edición
            cargar_datos();
        }

        private void comentar_viaje(object sender, EventArgs e)
        {
            // Implementar lógica de comentario
            cargar_datos();
        }

        private void eliminar_viaje(object sender, EventArgs e)
        {
            int idViaje = vista.ObtenerIdViajeSeleccionado();
            repositorio.Eliminar(idViaje);
            cargar_datos();
        }

        private void retroceder_dia(object sender, EventArgs e)
        {
            fechaActual = fechaActual.AddDays(-1);
            vista.SetFecha(fechaActual);
            cargar_datos();
        }

        private void adelantar_dia(object sender, EventArgs e)
        {
            fechaActual = fechaActual.AddDays(1);
            vista.SetFecha(fechaActual);
            cargar_datos();
        }

        private void ingresar_vuelta(object sender, EventArgs e)
        {
            IVueltaVista vueltaVista = VueltaVista.ObtenerInstancia();
            IViajesRepositorio repo = new ViajesRepositorio();
            new VueltaPresentador(vueltaVista, repo, rol, id);
            ((Form)vista).Close();
        }

        private void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }
    }
}
