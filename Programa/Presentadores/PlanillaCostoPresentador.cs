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
    /// <summary>
    /// Presentador encargado de gestionar la vista de planilla de costos.
    /// Coordina la visualización y modificación de importes por cuadras y ciudades.
    /// </summary>
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

        /// <summary>
        /// Inicializa el presentador con la vista, los repositorios y los datos del operador.
        /// </summary>
        /// <param name="vista">Vista que implementa <see cref="IPlanillaCostoVista"/>.</param>
        /// <param name="ciudadRepo">Repositorio de ciudades.</param>
        /// <param name="cuadrasRepo">Repositorio de importes por cuadras.</param>
        /// <param name="ciudadImporteRepo">Repositorio de importes por ciudad.</param>
        /// <param name="rol">Rol del operador.</param>
        /// <param name="id">Identificador del operador.</param>
        public PlanillaCostoPresentador(IPlanillaCostoVista vista, ICiudadRepositorio ciudadRepo, IImporteCuadrasRepositorio cuadrasRepo, IImporteCiudadRepositorio ciudadImporteRepo, string rol, int id)
        {
            this.vista = vista;
            this.ciudadRepo = ciudadRepo;
            this.cuadrasRepo = cuadrasRepo;
            this.ciudadImporteRepo = ciudadImporteRepo;
            this.rol = rol;
            this.id = id;
            this.tablacuadras = new BindingSource();
            this.tablaciudades = new BindingSource();

            this.vista.ocultarBotones(this.rol);

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

        /// <summary>
        /// Carga los datos iniciales de importes y ciudades en la vista.
        /// </summary>
        private void cargarDatos()
        {
            var cuadrasDTO = cuadrasRepo.ObtenerImportes();
            var ciudadDTO = ciudadImporteRepo.ObtenerImportes();
            var ciudades = ciudadRepo.ObtenerTodas();

            vista.MostrarImportesCuadras(cuadrasDTO.Cuadras, cuadrasDTO.Espera, cuadrasDTO.Mandado);
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

        /// <summary>
        /// Recarga los importes por cuadras en la vista.
        /// </summary>
        public void RecargarImportesCuadras()
        {
            var dto = cuadrasRepo.ObtenerImportes();
            vista.MostrarImportesCuadras(dto.Minimo, dto.Espera, dto.Mandado);
            vista.MostrarCuadrasEnLayout(dto);
        }

        /// <summary>
        /// Recarga la lista de ciudades en la vista.
        /// </summary>
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

        /// <summary>
        /// Recarga los importes por ciudad y actualiza la vista.
        /// </summary>
        public void RecargarImporteCiudad()
        {
            var dto = ciudadImporteRepo.ObtenerImportes();
            vista.MostrarImportesCiudad(dto.Kilometro, dto.Espera);
            RecargarCiudades();
        }

        /// <summary>
        /// Abre el formulario para modificar el costo por cuadras.
        /// </summary>
        private void modificarCuadras_costo(object sender, EventArgs e)
        {
            IModificarPlanillaCostoVistaCuadraPrecio vistaModificar = ModificarPlanillaCostoVistaCuadraPrecio.ObtenerInstancia();
            new CUModificarImporteCuadraPlanillaCostoVista(vistaModificar, cuadrasRepo, this);
            ((Form)vistaModificar).ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para modificar el importe por mandado.
        /// </summary>
        private void modificarCuadras_mandado(object sender, EventArgs e)
        {
            IModificarPlanillaCostoVistaCuadraMandado vistaModificar = ModificarPlanillaCostoVistaCuadraMandado.ObtenerInstancia();
            new CUModificarImporteCuadraMandadoPlanillaCostoVista(vistaModificar, cuadrasRepo, this);
            ((Form)vistaModificar).ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para modificar el importe por espera en cuadras.
        /// </summary>
        private void modificarCuadras_espera(object sender, EventArgs e)
        {
            IModificarPlanillaCostoVistaEsperaCuadra vistaModificar = ModificarPlanillaCostoVistaEsperaCuadra.ObtenerInstancia();
            new CUModificarImporteCuadraEsperaPlanillaCostoVista(vistaModificar, cuadrasRepo, this);
            ((Form)vistaModificar).ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para modificar el costo por kilómetro en ciudad.
        /// </summary>
        private void modificarCiudad_costo(object sender, EventArgs e)
        {
            IModificarPlanillaCostoVistaCiudadPrecio vistaModificar = ModificarPlanillaCostoVistaCiudadPrecio.ObtenerInstancia();
            new CUModificarImporteCiudadPlanillaCostoVista(vistaModificar, ciudadImporteRepo, this);
            ((Form)vistaModificar).ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para modificar el importe por espera en ciudad.
        /// </summary>
        private void modificarCiudad_espera(object sender, EventArgs e)
        {
            IModificarPlanillaCostoVistaEsperaCiudad vistaModificar = ModificarPlanillaCostoVistaEsperaCiudad.ObtenerInstancia();
            new CUModificarImporteCiudadEsperaPlanillaCostoVista(vistaModificar, ciudadImporteRepo, this);
            ((Form)vistaModificar).ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para agregar una nueva ciudad.
        /// </summary>
        private void agregar_ciudad(object sender, EventArgs e)
        {
            IAgregarPlanillaCostoVista vistaAgregar = AgregarPlanillaCostoVista.ObtenerInstancia();
            new CUAgregarCiudadPlanillaCostoVista(vistaAgregar, ciudadRepo, ciudadImporteRepo, this);
            ((Form)vistaAgregar).ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para modificar una ciudad seleccionada.
        /// </summary>
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
            ((Form)vistaModificar).ShowDialog();
        }

        /// <summary>
        /// Elimina la ciudad seleccionada previa confirmación.
        /// </summary>
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

        /// <summary>
        /// Cierra la vista actual y retorna al menú de inicio.
        /// </summary>
        private void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }

    }
}
