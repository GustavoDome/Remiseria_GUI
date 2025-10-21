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
    /// <summary>
    /// Presentador principal del sistema. Gestiona la vista de inicio, los recordatorios del operador
    /// y la navegación hacia los distintos módulos del sistema.
    /// </summary>
    public class InicioPresentador
    {
        private IRecordatorioRepositorio repositorio;
        private IInicioVista vista;
        private BindingSource filtrador;
        private GestorAlarmasGlobal gestorAlarmas;
        private string rol;
        private int id;

        /// <summary>
        /// Inicializa el presentador con la vista de inicio, el repositorio de recordatorios,
        /// el rol del operador y su identificador.
        /// </summary>
        /// <param name="vista">Vista principal que implementa <see cref="IInicioVista"/>.</param>
        /// <param name="repositorio">Repositorio de recordatorios.</param>
        /// <param name="rol">Rol del operador (por ejemplo: "Gerente").</param>
        /// <param name="id">Identificador del operador actual.</param>

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

        /// <summary>
        /// Carga todos los recordatorios del operador y los vincula al BindingSource de la vista.
        /// </summary>
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

        /// <summary>
        /// Obtiene el identificador del recordatorio actualmente seleccionado en la grilla.
        /// </summary>
        /// <returns>Id del recordatorio o null si no hay selección.</returns>
        public int? ObtenerIdRecordatorioSeleccionado()
        {
            if (filtrador.Current is RecordatorioDTO seleccionado)
            {
                return seleccionado.IdRecordatorio;
            }
            return null;
        }

        /// <summary>
        /// Abre el formulario para agregar un nuevo recordatorio.
        /// </summary>
        private void agregarRecordatorio(object sender, EventArgs e)
        {
            IAgregarInicioVistaRecordatorio agregarRecordatorio = AgregarInicioVistaRecordatorio.ObtenerInstancia();
            new CUAgregarRecordatorio(this.repositorio, agregarRecordatorio, this.id, this);
            ((Form)agregarRecordatorio).ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para modificar el recordatorio seleccionado.
        /// </summary>
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

        /// <summary>
        /// Elimina el recordatorio seleccionado previa confirmación del usuario.
        /// </summary>
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

        /// <summary>
        /// Cierra la aplicación.
        /// </summary>
        private void volver_menu(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Navega al módulo de ayuda, inicializando su presentador y cerrando vistas en conflicto.
        /// </summary>
        private void ingresarAyuda(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Ayuda");

            AyudaVista ayuda = AyudaVista.ObtenerInstancia(this.rol); // Usá el tipo concreto si vas a setear propiedades

            ICategoriaRepositorio categoria = new CategoriaRepositorio();
            IPreguntaRepositorio pregunta = new PreguntaRepositorio();
            IRespuestasRepositorio respuesta = new RespuestaRepositorio();

            new AyudaPresentador(ayuda, categoria, pregunta, respuesta, this.rol, this.id);
        }

        /// <summary>
        /// Navega al módulo de configuración del operador.
        /// </summary>
        private void ingresarConfiguracion(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Configuraciones");
            IConfiguracionesVista configuracion = ConfiguracionesVista.ObtenerInstancia();
            IOperadorRepositorio usuario = new OperadorRepositorio();
            new ConfiguracionesPresentador(configuracion, usuario, this.rol, this.id);
        }

        /// <summary>
        /// Navega al módulo de gestión de operadores.
        /// </summary>
        private void ingresarOperadores(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Operadores");
            IOperadoresVista operadores = OperadoresVista.ObtenerInstancia();
            IOperadorRepositorio usuario = new OperadorRepositorio();
            new OperadoresPresentador(operadores, usuario, this.id);
        }

        /// <summary>
        /// Navega al módulo de gestión de móviles.
        /// </summary>
        private void ingresarMoviles(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Moviles");
            IMovilesVista movilVista = MovilesVista.ObtenerInstancia();
            IMovilRepositorio movilrepositorio = new MovilRepositorio();
            new MovilesPresentador(movilVista, movilrepositorio, this.id);
        }

        /// <summary>
        /// Navega al módulo de gestión de viajes.
        /// </summary>
        private void ingresarViajes(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Viajes");
            IViajesVista viajesvista = ViajesVista.ObtenerInstancia(this.rol, this.id);
            IViajesRepositorio viajes = new ViajesRepositorio();
            new ViajesPresentador(viajesvista, viajes, this.rol, this.id);
        }

        /// <summary>
        /// Navega al módulo de gestión de vueltas.
        /// </summary>
        private void ingresarVueltas(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Vueltas");
            IVueltaVista vuelta = VueltaVista.ObtenerInstancia();
            IViajesRepositorio viajes = new ViajesRepositorio();
            new VueltaPresentador(vuelta, viajes, this.rol, this.id);
        }

        /// <summary>
        /// Navega al módulo de gestión de bases.
        /// </summary>
        private void ingresarBases(object sender, EventArgs e)
        {
            GestorPantallasGlobal.CerrarConflictosAntesDeAbrir("Bases");
            IBasesVista basesvista = BasesVista.ObtenerInstancia();
            IBasesRepositorio bases = new BaseRepositorio();
            new BasesPresentador(basesvista, bases, this.rol, this.id);
        }
    }
}
