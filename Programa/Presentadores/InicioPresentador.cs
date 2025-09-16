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
using Microsoft.Web.WebView2.WinForms;

namespace Programa.Presentadores
{
    public class InicioPresentador
    {
        private IRecordatorioRepositorio repositorio;
        private IInicioVista vista;
        private IEnumerable<RecordatorioModelo> modelosRecordatorio;
        private BindingSource filtrador;
        private string rol;
        private int id;


        //constructor
        public InicioPresentador (IInicioVista vista, IRecordatorioRepositorio repositorio, string rol, int id)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;
            this.rol = rol;
            this.id = id;

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

        private void cargarRecordatorio() 
        {
            var lista = this.repositorio.mostrarTodo().ToList();
            this.filtrador.DataSource = lista;
        }

        private void agregarRecordatorio(object sender, EventArgs e)
        {

        }
        private void modificarRecordatorio(object sender, EventArgs e) 
        {
            
        }
        private void eliminarRecordatorio(object sender, EventArgs e) 
        {

        }
        private void volver_menu(object sender, EventArgs e) 
        {
            Application.Exit();
        }
        private void ingresarAyuda(object sender, EventArgs e)
        {
            ICategoriaRepositorio categoria = new CategoriaRepositorio();
            IPreguntaRepositorio pregunta = new PreguntaRepositorio();
            IRespuestasRepositorio respuesta = new RespuestaRepositorio();
            IAyudaVista ayuda = AyudaVista.ObtenerInstancia();
            new AyudaPresentador(ayuda, categoria, pregunta, respuesta, this.rol, this.id);
        }
        private void ingresarConfiguracion(object sender, EventArgs e) 
        {
            IUsuarioRepositorio usuario = new UsuarioRepositorio();
            IConfiguracionesVista configuracion = ConfiguracionesVista.ObtenerInstancia();
            new ConfiguracionesPresentador(configuracion, usuario, this.rol, this.id);
            ((Form)vista).Close();
        }
        private void ingresarOperadores(object sender, EventArgs e) 
        {
            IUsuarioRepositorio usuario = new UsuarioRepositorio();
            IOperadoresVista operadores = OperadoresVista.ObtenerInstancia();
            new OperadoresPresentador(operadores, usuario, this.id);
        }
        private void ingresarMoviles(object sender, EventArgs e) 
        {
            IMovilRepositorio movilrepositorio = new MovilRepositorio();
            IMovilesVista movilVista = MovilesVista.ObtenerInstancia();
            new MovilesPresentador(movilVista, movilrepositorio, this.id);
        }
        private void ingresarViajes(object sender, EventArgs e) 
        {
            IViajesRepositorio viajes = new ViajesRepositorio();
            IViajesVista viajesvista = ViajesVista.ObtenerInstancia();
            new ViajesPresentador(viajesvista, viajes, this.rol, this.id);
        }
        private void ingresarVueltas(object sender, EventArgs e) 
        {
            IViajesRepositorio viajes = new ViajesRepositorio();
            IVueltaVista vuelta = VueltaVista.ObtenerInstancia();
            new VueltaPresentador(vuelta, viajes, this.rol, this.id);
        }
        private void ingresarBases(object sender, EventArgs e) 
        {
            IBasesRepositorio bases = new BasesRepositorio();
            IBasesVista basesvista = BasesVista.ObtenerInstancia();
            new BasesPresentador(basesvista, bases, this.rol, this.id);
        }
    }
}
