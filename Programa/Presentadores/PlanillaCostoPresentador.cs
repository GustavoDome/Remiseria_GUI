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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Programa.Presentadores.CUPresentador.CUPlanillaCostoVistaPresentador;

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

            vista.MostrarCuadrasEnLayout(cuadrasDTO);
            var ciudadesDTO = ciudadRepo.ObtenerTodas()
                .Select(c => new CiudadDTO
                {
                    IdCiudad = c.IdCiudad,
                    NombreCiudad = c.NombreCiudad,
                    Kilometros = c.Kilometros,
                    Importe = c.Importe
                })
                .ToList();

            vista.MostrarCiudadesEnLayout(ciudadesDTO);
        }
        public void RecargarImportesCuadras()
        {
            var dto = cuadrasRepo.ObtenerImportes();
            vista.MostrarImportesCuadras(dto.Minimo, dto.Espera, dto.Mandado);
            vista.MostrarCuadrasEnLayout(dto);
        }
        public void RecargarCiudades()
        {
            var ciudadesDTO = ciudadRepo.ObtenerTodas()
                .Select(c => new CiudadDTO
                {
                    IdCiudad = c.IdCiudad,
                    NombreCiudad = c.NombreCiudad,
                    Kilometros = c.Kilometros,
                    Importe = c.Importe
                })
                .ToList();

            vista.MostrarCiudadesEnLayout(ciudadesDTO);
        }
        public void RecargarImporteCiudad()
        {
            var dto = ciudadImporteRepo.ObtenerImportes();
            vista.MostrarImportesCiudad(dto.Kilometro, dto.Espera);
            RecargarCiudades();
        }
        private void modificarCuadras_costo(object sender, EventArgs e)
        {
            IModificarPlanillaCostoVistaCuadraPrecio vistaModificar = ModificarPlanillaCostoVistaCuadraPrecio.ObtenerInstancia();
            new CUModificarImporteCuadraPlanillaCostoVista(vistaModificar, cuadrasRepo, this);
        }
        private void modificarCuadras_mandado(object sender, EventArgs e)
        {
            IModificarPlanillaCostoVistaCuadraMandado vistaModificar = ModificarPlanillaCostoVistaCuadraMandado.ObtenerInstancia();
            new CUModificarImporteCuadraMandadoPlanillaCostoVista(vistaModificar, cuadrasRepo, this);
        }
        private void modificarCuadras_espera(object sender, EventArgs e)
        {
            IModificarPlanillaCostoVistaEsperaCuadra vistaModificar = ModificarPlanillaCostoVistaEsperaCuadra.ObtenerInstancia();
            new CUModificarImporteCuadraEsperaPlanillaCostoVista(vistaModificar, cuadrasRepo, this);
        }
        private void modificarCiudad_costo(object sender, EventArgs e)
        {
            IModificarPlanillaCostoVistaCiudadPrecio vistaModificar = ModificarPlanillaCostoVistaCiudadPrecio.ObtenerInstancia();
            new CUModificarImporteCiudadPlanillaCostoVista(vistaModificar, ciudadImporteRepo, this);
        }
        private void modificarCiudad_espera(object sender, EventArgs e)
        {
            IModificarPlanillaCostoVistaEsperaCiudad vistaModificar = ModificarPlanillaCostoVistaEsperaCiudad.ObtenerInstancia();
            new CUModificarImporteCiudadEsperaPlanillaCostoVista(vistaModificar, ciudadImporteRepo, this);
        }
        private void agregar_ciudad(object sender, EventArgs e)
        {
            IAgregarPlanillaCostoVista vistaAgregar = AgregarPlanillaCostoVista.ObtenerInstancia();
            new CUAgregarCiudadPlanillaCostoVista(vistaAgregar, ciudadRepo, ciudadImporteRepo, this);
        }
        private void modificar_ciudad(object sender, EventArgs e)
        {
            var ciudadId = vista.ObtenerCiudadSeleccionada();
            if (ciudadId == null)
            {
                MessageBox.Show("Debe seleccionar una ciudad para modificar.");
                return;
            }

            var ciudadSeleccionada = ciudadRepo.ObtenerTodas().FirstOrDefault(c => c.IdCiudad == ciudadId.Value);

            IModificarPlanillaCostoVistaCiudad vistaModificar = ModificarPlanillaCostoVistaCiudad.ObtenerInstancia();
            new CUModificarCiudadPlanillaCostoVista(vistaModificar, ciudadRepo, ciudadImporteRepo, ciudadSeleccionada, this);
        }
        private void eliminar_ciudad(object sender, EventArgs e)
        {
            var ciudadId = vista.ObtenerCiudadSeleccionada();
            if (ciudadId == null)
            {
                MessageBox.Show("Debe seleccionar una ciudad para eliminar.");
                return;
            }

            var ciudadSeleccionada = ciudadRepo.ObtenerTodas().FirstOrDefault(c => c.IdCiudad == ciudadId.Value);

            var confirmacion = MessageBox.Show(
                $"¿Está seguro que desea eliminar la ciudad '{ciudadSeleccionada.NombreCiudad}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes)
                return;

            ciudadRepo.Eliminar(ciudadSeleccionada.IdCiudad);
            RecargarCiudades();
        }
        private void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }

    }
}
