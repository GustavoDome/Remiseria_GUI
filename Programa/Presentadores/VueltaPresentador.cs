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
        private readonly IVueltaVista vista;
        private readonly IViajesRepositorio repositorio;
        private readonly BindingSource filtrador;
        private DateTime fechaActual;
        private readonly string rol;
        private readonly int id;

        public VueltaPresentador(IVueltaVista vista, IViajesRepositorio repositorio, string rol, int id)
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

            cargar_vueltas();

            this.vista.agregarVuelta += agregar_vuelta;
            this.vista.modificarVuelta += modificar_vuelta;
            this.vista.eliminarVuelta += eliminar_vuelta;
            this.vista.retroceder += retroceder_dia;
            this.vista.adelantar += adelantar_dia;
            this.vista.ingresarViaje += ingresar_viaje;
            this.vista.volver += volver_menu;
        }

        private void cargar_vueltas()
        {
            var tabla = repositorio.MostrarVuelta(fechaActual); // Devuelve DataTable
            filtrador.DataSource = tabla;
        }

        private void agregar_vuelta(object sender, EventArgs e)
        {
            // Lógica para agregar vuelta manual o desde viaje
            // Podés abrir un formulario de entrada o usar un DTO predefinido
            cargar_vueltas();
        }

        private void modificar_vuelta(object sender, EventArgs e)
        {
            // Lógica para modificar estado de vuelta o reordenar
            cargar_vueltas();
        }

        private void eliminar_vuelta(object sender, EventArgs e)
        {
            // Lógica para eliminar vuelta del día
            cargar_vueltas();
        }

        private void retroceder_dia(object sender, EventArgs e)
        {
            fechaActual = fechaActual.AddDays(-1);
            vista.SetFecha(fechaActual);
            cargar_vueltas();
        }

        private void adelantar_dia(object sender, EventArgs e)
        {
            fechaActual = fechaActual.AddDays(1);
            vista.SetFecha(fechaActual);
            cargar_vueltas();
        }

        private void ingresar_viaje(object sender, EventArgs e)
        {
            IViajesVista viajesvista = ViajesVista.ObtenerInstancia(this.rol, this.id);
            IViajesRepositorio viajes = new ViajesRepositorio();
            new ViajesPresentador(viajesvista, viajes, this.rol, this.id);
            ((Form)vista).Close();
        }

        private void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }
    }
}
