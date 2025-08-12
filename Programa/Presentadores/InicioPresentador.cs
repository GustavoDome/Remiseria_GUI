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


        //constructor
        public InicioPresentador (IInicioVista vista, IRecordatorioRepositorio repositorio)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;

            //metodos
            this.vista.agregarRecordatorio += agregarRecordatorio;
            this.vista.modificarRecordatorio += modificarRecordatorio;
            this.vista.eliminarRecordatorio += eliminarRecordatorio;
            this.vista.volver += volver;
            this.vista.ingresarAyuda += ingresarAyuda;
            this.vista.ingresarConfiguracion += ingresarConfiguracion;
            this.vista.ingresarOperadores += ingresarOperadores;
            this.vista.ingresarMoviles += ingresarMoviles;
            this.vista.ingresarViajes += ingresarViajes;
            this.vista.ingresarVueltas += ingresarVueltas;
            this.vista.ingresarBases += ingresarBases;
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
        private void volver(object sender, EventArgs e) 
        {
            IUsuarioRepositorio usuario = new UsuarioRepositorio();
            ILogin login = Login.ObtenerInstancia();
            new LoginPresentador(login, usuario);
            ((Form)vista).Close();
        }
        private void ingresarAyuda(object sender, EventArgs e)
        {
            ICategoriaRepositorio categoria = new CategoriaRepositorio();
            IPreguntaRepositorio pregunta = new PreguntaRepositorio();
            IRespuestasRepositorio respuesta = new RespuestaRepositorio();
            IAyudaVista ayuda = AyudaVista.ObtenerInstancia();
            new AyudaPresentador(ayuda, categoria, pregunta, respuesta);
        }
        private void ingresarConfiguracion(object sender, EventArgs e) 
        {
            IUsuarioRepositorio usuario = new UsuarioRepositorio();
            IConfiguracionesVista configuracion = ConfiguracionesVista.ObtenerInstancia();
            new ConfiguracionesPresentador(configuracion, usuario);
            ((Form)vista).Close();
        }
        private void ingresarOperadores(object sender, EventArgs e) 
        {
            IUsuarioRepositorio usuario = new UsuarioRepositorio();
            IOperadoresVista operadores = OperadoresVista.ObtenerInstancia();
            new OperadoresPresentador(operadores, usuario);
        }
        private void ingresarMoviles(object sender, EventArgs e) 
        {
            IMovilRepositorio movilrepositorio = new MovilRepositorio();
            IMovilesVista movilVista = MovilesVista.ObtenerInstancia();
            new MovilesPresentador(movilVista, movilrepositorio);
        }
        private void ingresarViajes(object sender, EventArgs e) 
        {
            IViajesRepositorio viajes = new ViajesRepositorio();
            IViajesVista viajesvista = ViajesVista.ObtenerInstancia();
            new ViajesPresentador(viajesvista, viajes);
        }
        private void ingresarVueltas(object sender, EventArgs e) 
        {
            IViajesRepositorio viajes = new ViajesRepositorio();
            IVueltaVista vuelta = VueltaVista.ObtenerInstancia();
            new VueltaPresentador(vuelta, viajes);
        }
        private void ingresarBases(object sender, EventArgs e) 
        {
            IBasesRepositorio bases = new BasesRepositorio();
            IBasesVista basesvista = BasesVista.ObtenerInstancia();
            new BasesPresentador(basesvista, bases);
        }
    }
}
