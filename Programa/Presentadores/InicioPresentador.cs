using Programa.Commons;
using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Repositorios;
using Programa.Vistas;
using Programa.Vistas.Alta;
using Programa.Vistas.Alta.Interfaces;
using Programa.Vistas.Interfaces;
using Programa.Vistas.Modificacion;
using Programa.Vistas.Modificacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Programa.Presentadores.CUPresentador.CUInicioPresentador;

namespace Programa.Presentadores
{
    public class InicioPresentador
    {
        private IRecordatorioRepositorio repositorio;
        private IInicioVista vista;
        private BindingSource filtrador;
        private GestorAlarmasGlobal gestorAlarmas;
        private string rol;
        private int id;


        //constructor
        public InicioPresentador(IInicioVista vista, IRecordatorioRepositorio repositorio, string rol, int id)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;
            this.rol = rol;
            this.id = id;
            ((Form)this.vista).Shown += (s, e) =>
            {
                this.gestorAlarmas = new GestorAlarmasGlobal(this.repositorio, this.id, this);
            };

            this.vista.ocultarBotones(this.rol);

            this.vista.SetRecordatoriosBindingSource(this.filtrador);
            cargarRecordatorio();

            //metodos
            this.vista.agregarRecordatorio += agregarRecordatorio;
            this.vista.modificarRecordatorio += modificarRecordatorio;
            this.vista.eliminarRecordatorio += eliminarRecordatorio;
            this.vista.volver += volver_menu;
            this.vista.ingresarAyuda += ingresarAyuda;
            this.vista.ingresarConfiguracion += ingresarConfiguracion;
            this.vista.ingresarOperadores += ingresarOperadores;
            this.vista.ingresarMoviles += ingresarMoviles;
            this.vista.ingresarViajes += ingresarViajes;
            this.vista.ingresarVueltas += ingresarVueltas;
            this.vista.ingresarBases += ingresarBases;

        }

        public void cargarRecordatorio()
        {
            var lista = this.repositorio.ObtenerTodos().ToList();
            this.filtrador.DataSource = lista;

            // Configurar columnas después de asignar el DataSource
            if (vista is InicioVista vistaConcreta)
            {
                vistaConcreta.ConfigurarGrilla();
            }
        }

        public int? ObtenerIdRecordatorioSeleccionado()
        {
            if (filtrador.Current is RecordatorioDTO seleccionado)
            {
                return seleccionado.IdRecordatorio;
            }
            return null;
        }
        private void agregarRecordatorio(object sender, EventArgs e)
        {
            IAgregarInicioVistaRecordatorio agregarRecordatorio = AgregarInicioVistaRecordatorio.ObtenerInstancia();
            new CUAgregarRecordatorio(this.repositorio, agregarRecordatorio, this.id, this);
            ((Form)agregarRecordatorio).ShowDialog();
        }
        private void modificarRecordatorio(object sender, EventArgs e)
        {
            int? idrecordatorio = ObtenerIdRecordatorioSeleccionado();
            if (idrecordatorio != null)
            {
                IModificarInicioVistaRecordatorio modificarRecordatorio = ModificarInicioVistaRecordatorio.ObtenerInstancia();
                new CUModificarRecordatorio(modificarRecordatorio, this.repositorio, idrecordatorio, this.id, this);
                ((Form)modificarRecordatorio).ShowDialog();
            }
            else
            {
                MessageBox.Show("Porfavor seleccione el recordatorio a modificar");
            }
        }
        private void eliminarRecordatorio(object sender, EventArgs e)
        {
            int? idrecordatorio = ObtenerIdRecordatorioSeleccionado();
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar este recordatorio?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.repositorio.Eliminar(idrecordatorio.Value);
                cargarRecordatorio();
            }
        }
        private void volver_menu(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ingresarAyuda(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Ayuda");

            AyudaVista ayuda = AyudaVista.ObtenerInstancia(this.rol); // Usá el tipo concreto si vas a setear propiedades

            ICategoriaRepositorio categoria = new CategoriaRepositorio();
            IPreguntaRepositorio pregunta = new PreguntaRepositorio();
            IRespuestasRepositorio respuesta = new RespuestaRepositorio();

            new AyudaPresentador(ayuda, categoria, pregunta, respuesta, this.rol, this.id);
        }
        private void ingresarConfiguracion(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Configuraciones");
            IConfiguracionesVista configuracion = ConfiguracionesVista.ObtenerInstancia();
            IOperadorRepositorio usuario = new OperadorRepositorio();
            new ConfiguracionesPresentador(configuracion, usuario, this.rol, this.id);
        }
        private void ingresarOperadores(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Operadores");
            IOperadoresVista operadores = OperadoresVista.ObtenerInstancia();
            IOperadorRepositorio usuario = new OperadorRepositorio();
            new OperadoresPresentador(operadores, usuario, this.id);
        }
        private void ingresarMoviles(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Moviles");
            IMovilesVista movilVista = MovilesVista.ObtenerInstancia();
            IMovilRepositorio movilrepositorio = new MovilRepositorio();
            new MovilesPresentador(movilVista, movilrepositorio, this.id);
        }
        private void ingresarViajes(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Viajes");
            IViajesVista viajesvista = ViajesVista.ObtenerInstancia(this.rol, this.id);
            IViajesRepositorio viajes = new ViajesRepositorio();
            new ViajesPresentador(viajesvista, viajes, this.rol, this.id);
        }
        private void ingresarVueltas(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Vueltas");
            IVueltaVista vuelta = VueltaVista.ObtenerInstancia();
            IViajesRepositorio viajes = new ViajesRepositorio();
            new VueltaPresentador(vuelta, viajes, this.rol, this.id);
        }
        private void ingresarBases(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Bases");
            IBasesVista basesvista = BasesVista.ObtenerInstancia();
            IBasesRepositorio bases = new BaseRepositorio();
            new BasesPresentador(basesvista, bases, this.rol, this.id);
        }
    }
}
