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
    public class AyudaPresentador
    {
        private ICategoriaRepositorio repositorioCategoria;
        private IPreguntaRepositorio repositorioPregunta;
        private IRespuestasRepositorio repositorioRespuesta;
        private IAyudaVista vista;
        private IEnumerable<CategoriaModelo> modeloCategoria; 
        private IEnumerable<PreguntaModelo> modeloPregunta; 
        private IEnumerable<RespuestaModelo> modeloRespuesta;
        private BindingSource filtrador;
        private string rol;
        private int id;

        public AyudaPresentador(IAyudaVista vista, ICategoriaRepositorio repositorioCategoria, IPreguntaRepositorio repositorioPregunta, IRespuestasRepositorio repositorioRespuesta, string rol, int id)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorioCategoria = repositorioCategoria;
            this.repositorioPregunta = repositorioPregunta;
            this.repositorioRespuesta = repositorioRespuesta;
            this.rol = rol;
            this.id = id;

            this.vista.ocultarBotones(this.rol);

            this.vista.ingresarPlanillasCosto += ingresar_planilla_costos;
            this.vista.agregarPregunta += agregar_pregunta;
            this.vista.modificarPregunta += modificar_pregunta;
            this.vista.eliminarPregunta += eliminar_pregunta;
            this.vista.agregarRespuesta += agregar_respuesta;
            this.vista.modificarRespuesta += modificar_pregunta;
            this.vista.eliminarRespuesta += eliminar_respuesta;
            this.vista.agregarCategoria += agregar_categoria;
            this.vista.modificarCategoria += modificar_categoria;
            this.vista.eliminarCategoria += eliminar_categoria;
            this.vista.volver += volver_menu;
        }

        public void ingresar_planilla_costos(object sender, EventArgs e) 
        {
            IPlanillaCostosRepositorio planillacostosrepositorio = new PlanillaCostosRepositorio();
            IPlanillaCostoVista planillaCostoVista = PlanillaCostoVista.ObtenerInstancia();
            new PlanillaCostoPresentador(planillaCostoVista, planillacostosrepositorio, this.rol, this.id);
            ((Form)vista).Close();
        }

        public void agregar_pregunta(object sender, EventArgs e) { }

        public void modificar_pregunta(object sender, EventArgs e) { }

        public void eliminar_pregunta(object sender, EventArgs e) { }

        public void agregar_respuesta(object sender, EventArgs e) { }

        public void modificar_respuesta(object sender, EventArgs e) { }

        public void eliminar_respuesta(object sender, EventArgs e) { }

        public void agregar_categoria(object sender, EventArgs e) { }

        public void modificar_categoria(object sender, EventArgs e) { }

        public void eliminar_categoria(object sender, EventArgs e) { }

        public void volver_menu(object sender, EventArgs e) 
        {
            IRecordatorioRepositorio recordatorio = new RecordatorioRepositorio();
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            new InicioPresentador(inicio, recordatorio, this.rol, this.id);
            ((Form)vista).Close();
        }
    }
}
