using Programa.DTOs;
using Programa.Modelos.Interfaces;
using Programa.Vistas;
using Programa.Vistas.Alta.Interfaces;
using Programa.Vistas.Interfaces;
using Programa.Vistas.Modificacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Presentadores.CUPresentador
{
    public class CUViajesPresentador
    {
        public class CUAgregarViajePresentador
        {
            private readonly IAgregarViajesVista vista;
            private readonly IViajesRepositorio repositorio;
            private readonly DateTime fechaActual;
            private readonly ViajesPresentador presentadorPrincipal;

            public CUAgregarViajePresentador(
                IAgregarViajesVista vista,
                IViajesRepositorio repositorio,
                DateTime fechaActual,
                ViajesPresentador presentadorPrincipal)
            {
                this.vista = vista;
                this.repositorio = repositorio;
                this.fechaActual = fechaActual;
                this.presentadorPrincipal = presentadorPrincipal;
                this.vista.volver += volver_menu;
                this.vista.agregar -= agregar_viaje;
                this.vista.agregar += agregar_viaje;

                vista.CargarMoviles(repositorio.SeleccionarMovil().ToList());
            }

            private void volver_menu(object sender, EventArgs e) 
            {
                ((Form)vista).Close();
            }
            private bool TieneVueltaPendiente(int idMovil, int numeroVuelta)
            {
                return repositorio.ExisteVueltaConEstado(idMovil, fechaActual, numeroVuelta, "·");
            }
            private void agregar_viaje(object sender, EventArgs e)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(vista.txtDirecciones))
                    {
                        MessageBox.Show("La dirección no puede estar vacía.");
                        return;
                    }

                    if (vista.ObtenerMovilesSeleccionados().Count == 0)
                    {
                        MessageBox.Show("Debe seleccionar al menos un móvil.");
                        return;
                    }

                    var ids = obtenerMovilesSeleccionados();
                    var vueltas = obtenerNumerosDeVuelta();

                    var idsFiltrados = new List<int>();
                    var vueltasFiltradas = new List<int>();

                    var dto = new AgregarViajeDTO
                    {
                        NumeroViaje = presentadorPrincipal.ObtenerSiguienteNumeroViaje(),
                        HoraViaje = DateTime.Now.TimeOfDay,
                        Direccion = vista.txtDirecciones,
                        EstadoViaje = "·",
                        Comentario = vista.obtenerOpcion(),
                        IdOperador = presentadorPrincipal.IdOperador,
                        VueltaFecha = fechaActual,
                        EstadoVuelta = "X",
                        IdMoviles = new List<int>(),
                        Vueltas = new List<int>(),
                        IdsVueltasActivadas = new List<int>() // ← asegurate de que esta propiedad exista en el DTO
                    };

                    for (int i = 0; i < ids.Count; i++)
                    {
                        int idMovil = ids[i];
                        int numeroVuelta = vueltas[i];

                        if (!TieneVueltaPendiente(idMovil, numeroVuelta))
                        {
                            idsFiltrados.Add(idMovil);
                            vueltasFiltradas.Add(numeroVuelta);
                        }
                        else
                        {
                            repositorio.ActivarVueltaPendiente(idMovil, fechaActual, numeroVuelta);
                            int idVuelta = repositorio.ObtenerIdVuelta(idMovil, fechaActual, numeroVuelta);
                            dto.IdsVueltasActivadas.Add(idVuelta);
                        }
                    }

                    dto.IdMoviles = idsFiltrados;
                    dto.Vueltas = vueltasFiltradas;

                    repositorio.Agregar(dto);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar el viaje: {ex.Message}");
                }
                finally
                {
                    presentadorPrincipal.RecargarVista();
                    ((Form)vista).Close();
                }
            }

            private List<int> obtenerMovilesSeleccionados()
            {
                return vista.ObtenerMovilesSeleccionados();
            }

            private List<int> obtenerNumerosDeVuelta()
            {
                var moviles = obtenerMovilesSeleccionados();
                var vueltas = new List<int>();

                foreach (var idMovil in moviles)
                {
                    bool tieneVueltas = repositorio.MovilTieneVueltas(idMovil, fechaActual);

                    int numeroVuelta;

                    if (tieneVueltas)
                    {
                        // Asignar la próxima vuelta libre para ese móvil
                        numeroVuelta = repositorio.ObtenerProximoNumeroDeVuelta(idMovil, fechaActual);
                    }
                    else
                    {
                        // Asignar la vuelta más usada del día
                        numeroVuelta = repositorio.CalcularVueltaJustaParaNuevoMovil(fechaActual);

                        // Validar que el móvil no tenga ya esa vuelta (por seguridad)
                        if (repositorio.MovilYaTieneVuelta(idMovil, fechaActual, numeroVuelta))
                        {
                            numeroVuelta = repositorio.ObtenerProximoNumeroDeVuelta(idMovil, fechaActual);
                        }
                    }

                    vueltas.Add(numeroVuelta);
                }

                return vueltas;
            }
        }
        public class CUModificarViajePresentador
        {
            private readonly IModificarViajesVista vista;
            private readonly IViajesRepositorio repositorio;
            private readonly int idViaje;
            private readonly ViajesPresentador presentadorPrincipal;

            public CUModificarViajePresentador(
                IModificarViajesVista vista,
                IViajesRepositorio repositorio,
                int idViaje,
                ViajesPresentador presentadorPrincipal)
            {
                this.vista = vista;
                this.repositorio = repositorio;
                this.idViaje = idViaje;
                this.presentadorPrincipal = presentadorPrincipal;

                vista.volver += volver_menu;
                vista.modificar += modificar_viaje;

                var viaje = repositorio.ObtenerPorId(idViaje);
                vista.txtDirecciones = viaje.Direccion;
                vista.SetComentario(viaje.Comentario);
                vista.CargarMoviles(repositorio.SeleccionarMovil().ToList(), viaje.IdMoviles);
            }

            private void volver_menu(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }

            private void modificar_viaje(object sender, EventArgs e)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(vista.txtDirecciones))
                    {
                        MessageBox.Show("La dirección no puede estar vacía.");
                        return;
                    }

                    if (vista.ObtenerMovilesSeleccionados().Count == 0)
                    {
                        MessageBox.Show("Debe seleccionar al menos un móvil.");
                        return;
                    }

                    var dto = new ModificarViajeDTO
                    {
                        IdViaje = idViaje,
                        Direccion = vista.txtDirecciones,
                        Comentario = vista.obtenerOpcion(),
                        IdMoviles = vista.ObtenerMovilesSeleccionados()
                    };

                    repositorio.Editar(dto);
                    MessageBox.Show("El viaje fue modificado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar el viaje: {ex.Message}");
                }
                finally
                {
                    presentadorPrincipal.RecargarVista();
                    ((Form)vista).Close();
                }
            }
        }
    }
}
