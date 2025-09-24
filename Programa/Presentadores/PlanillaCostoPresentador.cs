using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Repositorios;
using Programa.Vistas;
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
    public class PlanillaCostoPresentador
    {
        private readonly IPlanillaCostoVista vista;
        private readonly ICiudadRepositorio ciudadRepo;
        private readonly IImporteCuadrasRepositorio cuadrasRepo;
        private readonly IImporteCiudadRepositorio ciudadImporteRepo;
        private readonly BindingSource tablacuadras;
        private readonly BindingSource tablaciudades;
        private readonly string rol;
        private readonly int id;

        public PlanillaCostoPresentador(
            IPlanillaCostoVista vista,
            ICiudadRepositorio ciudadRepo,
            IImporteCuadrasRepositorio cuadrasRepo,
            IImporteCiudadRepositorio ciudadImporteRepo,
            string rol,
            int id)
        {
            this.vista = vista;
            this.ciudadRepo = ciudadRepo;
            this.cuadrasRepo = cuadrasRepo;
            this.ciudadImporteRepo = ciudadImporteRepo;
            this.rol = rol;
            this.id = id;
            this.tablacuadras = new BindingSource();
            this.tablaciudades = new BindingSource();

            vista.modificarCuadrasCosto += modificarCuadras_costo;
            vista.modificarCuadrasCostoMandado += modificarCuadras_mandado;
            vista.modificarCuadrasEspera += modificarCuadras_espera;
            vista.modificarCiudadCosto += modificarCiudad_costo;
            vista.modificarCiudadEspera += modificarCiudad_espera;
            vista.agregarCiudad += agregar_ciudad;
            vista.modificarCiudad += modificar_ciudad;
            vista.eliminarCiudad += eliminar_ciudad;
            vista.volver += volver_menu;

            cargarDatos();
        }

        private void cargarDatos()
        {
            var cuadrasDTO = cuadrasRepo.ObtenerImportes();
            var ciudadDTO = ciudadImporteRepo.ObtenerImportes();
            var ciudades = ciudadRepo.ObtenerTodas();

            vista.MostrarImportesCuadras(cuadrasDTO.Minimo, cuadrasDTO.Espera, cuadrasDTO.Mandado);
            vista.MostrarImportesCiudad(ciudadDTO.Kilometro, ciudadDTO.Espera);

            var tabla = new DataTable();
            tabla.Columns.Add("Cuadra");
            tabla.Columns.Add("Importe");

            for (int i = 1; i <= 120; i++)
            {
                var row = tabla.NewRow();
                row["Cuadra"] = i;
                row["Importe"] = i <= 10 ? cuadrasDTO.Minimo : cuadrasDTO.Minimo + (i - 10) * cuadrasDTO.Cuadras;
                tabla.Rows.Add(row);
            }

            tablacuadras.DataSource = tabla;
            tablaciudades.DataSource = ciudades.ToList();

            vista.SetCuadraBindingSource(tablacuadras);
            vista.SetCiudadBindingSource(tablaciudades);
        }

        private void modificarCuadras_costo(object sender, EventArgs e) { /* abrir vista */ }
        private void modificarCuadras_mandado(object sender, EventArgs e) { /* abrir vista */ }
        private void modificarCuadras_espera(object sender, EventArgs e) { /* abrir vista */ }
        private void modificarCiudad_costo(object sender, EventArgs e) { /* abrir vista */ }
        private void modificarCiudad_espera(object sender, EventArgs e) { /* abrir vista */ }
        private void agregar_ciudad(object sender, EventArgs e) { /* abrir vista */ }
        private void modificar_ciudad(object sender, EventArgs e) { /* abrir vista */ }
        private void eliminar_ciudad(object sender, EventArgs e) { /* abrir vista */ }

        private void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }
    }
}
