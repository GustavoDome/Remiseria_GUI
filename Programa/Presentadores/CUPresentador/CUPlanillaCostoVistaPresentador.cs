using Programa.DTOs;
using Programa.Modelos.Interfaces;
using Programa.Vistas.Alta.Interfaces;
using Programa.Vistas.Modificacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Presentadores.CUPresentador
{
    public class CUPlanillaCostoVistaPresentador
    {
        public class CUAgregarCiudadPlanillaCostoVista
        {
            private readonly IAgregarPlanillaCostoVista vista;
            private readonly ICiudadRepositorio ciudadRepo;
            private readonly IImporteCiudadRepositorio importeRepo;
            private readonly PlanillaCostoPresentador presentador;

            public CUAgregarCiudadPlanillaCostoVista(
                IAgregarPlanillaCostoVista vista,
                ICiudadRepositorio ciudadRepo,
                IImporteCiudadRepositorio importeRepo,
                PlanillaCostoPresentador presentador)
            {
                this.vista = vista;
                this.ciudadRepo = ciudadRepo;
                this.importeRepo = importeRepo;
                this.presentador = presentador;

                vista.agregar += agregar_ciudad;
                vista.volver += volver;
            }

            private void agregar_ciudad(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(vista.NombreCiudad))
                {
                    MessageBox.Show("Debe ingresar el nombre de la ciudad.");
                    return;
                }

                if (vista.Kilometros <= 0)
                {
                    MessageBox.Show("Los kilómetros deben ser mayores a cero.");
                    return;
                }

                var precioKm = importeRepo.ObtenerImportes()?.Kilometro ?? 0;
                var importeCalculado = vista.Kilometros * precioKm;

                var nuevaCiudad = new CiudadDTO
                {
                    NombreCiudad = vista.NombreCiudad,
                    Kilometros = vista.Kilometros,
                    Importe = importeCalculado
                };

                ciudadRepo.Agregar(nuevaCiudad);
                MessageBox.Show($"Ciudad agregada correctamente.\nImporte calculado: ${importeCalculado}");

                presentador.RecargarCiudades();
                ((Form)vista).Close();
            }

            private void volver(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }
        }
        public class CUModificarCiudadPlanillaCostoVista
        {
            private readonly IModificarPlanillaCostoVistaCiudad vista;
            private readonly ICiudadRepositorio ciudadRepo;
            private readonly IImporteCiudadRepositorio importeRepo;
            private readonly CiudadDTO ciudadOriginal;
            private readonly PlanillaCostoPresentador presentador;

            public CUModificarCiudadPlanillaCostoVista(
                IModificarPlanillaCostoVistaCiudad vista,
                ICiudadRepositorio ciudadRepo,
                IImporteCiudadRepositorio importeRepo,
                CiudadDTO ciudadOriginal,
                PlanillaCostoPresentador presentador)
            {
                this.vista = vista;
                this.ciudadRepo = ciudadRepo;
                this.importeRepo = importeRepo;
                this.ciudadOriginal = ciudadOriginal;
                this.presentador = presentador;

                // Precarga
                vista.NombreCiudad = ciudadOriginal.NombreCiudad;
                vista.Kilometros = ciudadOriginal.Kilometros;

                vista.modificar += modificar_ciudad;
                vista.volver += volver;
            }

            private void modificar_ciudad(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(vista.NombreCiudad))
                {
                    MessageBox.Show("Debe ingresar el nombre de la ciudad.");
                    return;
                }

                if (vista.Kilometros <= 0)
                {
                    MessageBox.Show("Los kilómetros deben ser mayores a cero.");
                    return;
                }

                var precioKm = importeRepo.ObtenerImportes()?.Kilometro ?? 0;
                var nuevoImporte = vista.Kilometros * precioKm;

                var confirmacion = MessageBox.Show(
                    $"¿Desea guardar los cambios?\nImporte recalculado: ${nuevoImporte}",
                    "Confirmar modificación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                var ciudadModificada = new CiudadDTO
                {
                    IdCiudad = ciudadOriginal.IdCiudad,
                    NombreCiudad = vista.NombreCiudad,
                    Kilometros = vista.Kilometros,
                    Importe = nuevoImporte
                };

                ciudadRepo.Editar(ciudadModificada);
                presentador.RecargarCiudades();
                ((Form)vista).Close();
            }

            private void volver(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }
        }
        public class CUModificarImporteCuadraPlanillaCostoVista
        {
            private readonly IModificarPlanillaCostoVistaCuadraPrecio vista;
            private readonly IImporteCuadrasRepositorio cuadrasRepo;
            private readonly PlanillaCostoPresentador presentador;

            public CUModificarImporteCuadraPlanillaCostoVista(
                IModificarPlanillaCostoVistaCuadraPrecio vista,
                IImporteCuadrasRepositorio cuadrasRepo,
                PlanillaCostoPresentador presentador)
            {
                this.vista = vista;
                this.cuadrasRepo = cuadrasRepo;
                this.presentador = presentador;

                var dto = cuadrasRepo.ObtenerImportes();
                vista.MontoMinimo = dto.Minimo;
                vista.MontoPorCuadra = dto.Cuadras;

                vista.modificar += modificar_cuadras;
                vista.volver += volver;
            }

            private void modificar_cuadras(object sender, EventArgs e)
            {
                if (vista.MontoMinimo < 0 || vista.MontoPorCuadra <= 0)
                {
                    MessageBox.Show("Los valores deben ser positivos y el monto por cuadra mayor a cero.");
                    return;
                }

                var confirmacion = MessageBox.Show(
                    $"¿Desea modificar los importes?\nBase: ${vista.MontoMinimo}\nPor cuadra: ${vista.MontoPorCuadra}",
                    "Confirmar modificación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                cuadrasRepo.ModificarMinimo(vista.MontoMinimo);
                cuadrasRepo.ModificarCuadras(vista.MontoPorCuadra);
                presentador.RecargarImportesCuadras();
                ((Form)vista).Close();
            }

            private void volver(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }
        }
        public class CUModificarImporteCuadraEsperaPlanillaCostoVista
        {
            private readonly IModificarPlanillaCostoVistaEsperaCuadra vista;
            private readonly IImporteCuadrasRepositorio cuadrasRepo;
            private readonly PlanillaCostoPresentador presentador;

            public CUModificarImporteCuadraEsperaPlanillaCostoVista(
                IModificarPlanillaCostoVistaEsperaCuadra vista,
                IImporteCuadrasRepositorio cuadrasRepo,
                PlanillaCostoPresentador presentador)
            {
                this.vista = vista;
                this.cuadrasRepo = cuadrasRepo;
                this.presentador = presentador;

                vista.MontoEsperaCuadra = cuadrasRepo.ObtenerImportes().Espera;

                vista.modificar += modificar_espera;
                vista.volver += volver;
            }

            private void modificar_espera(object sender, EventArgs e)
            {
                if (vista.MontoEsperaCuadra <= 0)
                {
                    MessageBox.Show("El monto de espera debe ser mayor a cero.");
                    return;
                }

                var confirmacion = MessageBox.Show(
                    $"¿Desea modificar el monto de espera por cuadra a ${vista.MontoEsperaCuadra}?",
                    "Confirmar modificación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                cuadrasRepo.ModificarEspera(vista.MontoEsperaCuadra);
                presentador.RecargarImportesCuadras();
                ((Form)vista).Close();
            }

            private void volver(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }
        }
        public class CUModificarImporteCuadraMandadoPlanillaCostoVista
        {
            private readonly IModificarPlanillaCostoVistaCuadraMandado vista;
            private readonly IImporteCuadrasRepositorio cuadrasRepo;
            private readonly PlanillaCostoPresentador presentador;

            public CUModificarImporteCuadraMandadoPlanillaCostoVista(
                IModificarPlanillaCostoVistaCuadraMandado vista,
                IImporteCuadrasRepositorio cuadrasRepo,
                PlanillaCostoPresentador presentador)
            {
                this.vista = vista;
                this.cuadrasRepo = cuadrasRepo;
                this.presentador = presentador;

                vista.MontoMandado = cuadrasRepo.ObtenerImportes().Mandado;

                vista.modificar += modificar_mandado;
                vista.volver += volver;
            }

            private void modificar_mandado(object sender, EventArgs e)
            {
                if (vista.MontoMandado <= 0)
                {
                    MessageBox.Show("El monto del mandado debe ser mayor a cero.");
                    return;
                }

                var confirmacion = MessageBox.Show(
                    $"¿Desea modificar el monto del mandado a ${vista.MontoMandado}?",
                    "Confirmar modificación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                cuadrasRepo.ModificarMandado(vista.MontoMandado);
                presentador.RecargarImportesCuadras();
                ((Form)vista).Close();
            }

            private void volver(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }
        }
        public class CUModificarImporteCiudadPlanillaCostoVista
        {
            private readonly IModificarPlanillaCostoVistaCiudadPrecio vista;
            private readonly IImporteCiudadRepositorio importeRepo;
            private readonly PlanillaCostoPresentador presentador;

            public CUModificarImporteCiudadPlanillaCostoVista(
                IModificarPlanillaCostoVistaCiudadPrecio vista,
                IImporteCiudadRepositorio importeRepo,
                PlanillaCostoPresentador presentador)
            {
                this.vista = vista;
                this.importeRepo = importeRepo;
                this.presentador = presentador;

                var importeActual = importeRepo.ObtenerImportes()?.Kilometro ?? 0;
                vista.MontoKilometro = importeActual;

                vista.modificar += modificar_importe;
                vista.volver += volver;
            }

            private void modificar_importe(object sender, EventArgs e)
            {
                if (vista.MontoKilometro <= 0)
                {
                    MessageBox.Show("El monto por kilómetro debe ser mayor a cero.");
                    return;
                }

                var confirmacion = MessageBox.Show(
                    $"¿Desea modificar el monto por kilómetro a ${vista.MontoKilometro}?",
                    "Confirmar modificación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                var dto = new ImporteCiudadDTO
                {
                    Kilometro = vista.MontoKilometro,
                    Espera = importeRepo.ObtenerImportes()?.Espera ?? 0
                };

                importeRepo.ModificarImportes(dto);
                presentador.RecargarImporteCiudad(); // actualiza el label
                ((Form)vista).Close();
            }

            private void volver(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }
        }
        public class CUModificarImporteCiudadEsperaPlanillaCostoVista
        {
            private readonly IModificarPlanillaCostoVistaEsperaCiudad vista;
            private readonly IImporteCiudadRepositorio importeRepo;
            private readonly PlanillaCostoPresentador presentador;

            public CUModificarImporteCiudadEsperaPlanillaCostoVista(
                IModificarPlanillaCostoVistaEsperaCiudad vista,
                IImporteCiudadRepositorio importeRepo,
                PlanillaCostoPresentador presentador)
            {
                this.vista = vista;
                this.importeRepo = importeRepo;
                this.presentador = presentador;

                var importeActual = importeRepo.ObtenerImportes()?.Espera ?? 0;
                vista.MontoEspera = importeActual;

                vista.modificar += modificar_espera;
                vista.volver += volver;
            }

            private void modificar_espera(object sender, EventArgs e)
            {
                if (vista.MontoEspera <= 0)
                {
                    MessageBox.Show("El monto de espera debe ser mayor a cero.");
                    return;
                }

                var confirmacion = MessageBox.Show(
                    $"¿Desea modificar el monto de espera a ${vista.MontoEspera}?",
                    "Confirmar modificación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                var dto = new ImporteCiudadDTO
                {
                    Kilometro = importeRepo.ObtenerImportes()?.Kilometro ?? 0,
                    Espera = vista.MontoEspera
                };

                importeRepo.ModificarImportes(dto);
                presentador.RecargarImporteCiudad(); // actualiza el label
                ((Form)vista).Close();
            }

            private void volver(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }
        }
    }
}
