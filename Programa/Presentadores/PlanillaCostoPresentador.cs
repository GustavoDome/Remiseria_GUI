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
    public class PlanillaCostoPresentador
    {
        private IPlanillaCostosRepositorio repositorio;
        private IPlanillaCostoVista vista;
        private IEnumerable<CuadrasImporteModelo> cuadrasImporteModelo;
        private IEnumerable<CuadrasMinimoImporteModelo> cuadrasMinimoModelo;
        private IEnumerable<CuadrasMandadoModelo> cuadrasMandadoModelo;
        private IEnumerable<CuadrasEsperaModelo> cuadrasEsperaModelos;
        private IEnumerable<ImporteCiudadModelo> ciudadImportemodelo;
        private IEnumerable<ImporteCiudadEspera> ciudadEsperaModelo;
        private IEnumerable<CiudadesModelo> ciudadesmodelo;
        private BindingSource tablacuadras;
        private BindingSource tablaciudades;
        private string rol;

        public PlanillaCostoPresentador (IPlanillaCostoVista vista, IPlanillaCostosRepositorio repositorio, string rol) 
        {
            this.tablacuadras = new BindingSource();
            this.tablaciudades = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;
            this.rol = rol;

            this.vista.modificarCuadrasCosto += modificarCuadras_costo;
            this.vista.modificarCuadrasCostoMandado += modificarCuadras_mandado;
            this.vista.modificarCuadrasEspera += modificarCuadras_espera;
            this.vista.modificarCiudadCosto += modificarCiudad_costo;
            this.vista.modificarCiudadEspera += modificarCiudad_espera;
            this.vista.agregarCiudad += agregar_ciudad ;
            this.vista.modificarCiudad += modificar_ciudad;
            this.vista.eliminarCiudad += eliminar_ciudad;
            this.vista.volver += volver_menu;
        }

        private void modificarCuadras_costo(object sender, EventArgs e) { }
        private void modificarCuadras_mandado(object sender, EventArgs e) { }
        private void modificarCuadras_espera(object sender, EventArgs e) { }
        private void modificarCiudad_costo(object sender, EventArgs e) { }
        private void modificarCiudad_espera(object sender, EventArgs e) { }
        private void agregar_ciudad(object sender, EventArgs e) { }
        private void modificar_ciudad(object sender, EventArgs e) { }
        private void eliminar_ciudad(object sender, EventArgs e) { }
        private void volver_menu(object sender, EventArgs e) 
        {
            IRecordatorioRepositorio recordatorio = new RecordatorioRepositorio();
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            new InicioPresentador(inicio, recordatorio, this.rol);
            ((Form)vista).Close();
        }
    }
}
