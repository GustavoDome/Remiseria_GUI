using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
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
    public class CUBasesPresentador
    {
        /// <summary>
        /// Subpresentador encargado de agregar una nueva base para un móvil en una fecha específica.
        /// Valida duplicados y actualiza la vista principal.
        /// </summary>
        public class CUAgregarBasePresentador
        {
            private readonly IAgregarBasesVista vista;
            private readonly IBasesRepositorio repositorio;
            private readonly IBasesVista vistaPrincipal;
            private readonly int idOperador;
            private readonly int idMovil;
            private readonly BasesPresentador presentador;

            public CUAgregarBasePresentador(IBasesRepositorio repositorio, IAgregarBasesVista vista, int idOperador, int idMovil, BasesPresentador presentador, IBasesVista vistaPrincipal)
            {
                this.repositorio = repositorio;
                this.vista = vista;
                this.vistaPrincipal = vistaPrincipal;
                this.idOperador = idOperador;
                this.idMovil = idMovil;
                this.presentador = presentador;

                this.vista.agregar += agregar_base;
                this.vista.volver += volver;
            }

            private void agregar_base(object sender, EventArgs e)
            {
                if (vista.fecha != DateTime.MinValue)
                {
                    if (repositorio.ExisteBaseEnFecha(idMovil, vista.fecha))
                    {
                        MessageBox.Show("Ya existe una base registrada para este móvil en la fecha seleccionada.");
                        return;
                    }
                    Base nuevaBase = new Base
                    {
                        Fecha_base = vista.fecha,
                        EstadoBase = true,
                        IdMovil = idMovil,
                        IdOperador = idOperador,
                        Activo = true
                    };

                    repositorio.Agregar(nuevaBase);
                    presentador.vista_OnMovilSeleccionado(this, EventArgs.Empty); // recarga la grilla
                    var listaBases = repositorio.MostrarTodo(idMovil).ToList();
                    vistaPrincipal.mostrarBases(listaBases);

                    ((Form)vista).Close();
                }
                else
                {
                    MessageBox.Show("Por favor seleccione una fecha válida.");
                }
            }

            private void volver(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }
        }

        /// <summary>
        /// Subpresentador encargado de modificar los datos de una base existente.
        /// Coordina entre la vista de edición y el repositorio, actualizando la grilla de móviles.
        /// </summary>
        public class CUModificarBasePresentador
        {
            private readonly IModificarBasesVista vista;
            private readonly IBasesRepositorio repositorio;
            private readonly int idOperador;
            private readonly BaseDetalleDTO baseOriginal;
            private readonly BasesPresentador presentador;

            public CUModificarBasePresentador(
                IBasesRepositorio repositorio,
                IModificarBasesVista vista,
                int idOperador,
                BaseDetalleDTO baseOriginal,
                BasesPresentador presentador)
            {
                this.repositorio = repositorio;
                this.vista = vista;
                this.idOperador = idOperador;
                this.baseOriginal = baseOriginal;
                this.presentador = presentador;

                // Precargar datos
                this.vista.fecha = baseOriginal.Fecha_base;
                this.vista.comentario = baseOriginal.Comentario ?? string.Empty; // o usar Comentario si lo tenés separado

                this.vista.modificar += modificar_base;
                this.vista.volver += volver;
            }

            private void modificar_base(object sender, EventArgs e)
            {
                if (vista.fecha == DateTime.MinValue || string.IsNullOrWhiteSpace(vista.comentario))
                {
                    MessageBox.Show("Por favor complete todos los campos.");
                    return;
                }

                Base baseModificada = new Base
                {
                    IdBase = baseOriginal.IdBase,
                    Fecha_base = vista.fecha,
                    EstadoBase = baseOriginal.EstadoBase,
                    Comentario = this.vista.comentario,
                    IdMovil = presentador.id_movil,
                    IdOperador = idOperador,
                    Activo = true
                    // Si tenés un campo Comentario en la entidad, lo agregás acá
                };

                repositorio.Editar(baseModificada);
                presentador.vista_OnMovilSeleccionado(this, EventArgs.Empty);

                ((Form)vista).Close();
            }

            private void volver(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }
        }

        /// <summary>
        /// Subpresentador encargado de agregar o modificar el comentario de una base existente.
        /// Coordina entre la vista de comentario y el repositorio.
        /// </summary>
        public class CUComentarioBasePresentador
        {
            private readonly IAgregarBasesVistaComentario vista;
            private readonly IBasesRepositorio repositorio;
            private readonly BaseDetalleDTO baseOriginal;
            private readonly BasesPresentador presentador;

            public CUComentarioBasePresentador(
                IBasesRepositorio repositorio,
                IAgregarBasesVistaComentario vista,
                BaseDetalleDTO baseOriginal,
                BasesPresentador presentador)
            {
                this.repositorio = repositorio;
                this.vista = vista;
                this.baseOriginal = baseOriginal;
                this.presentador = presentador;

                // Precargar comentario actual
                this.vista.comentario = baseOriginal.Comentario ?? string.Empty;

                this.vista.agregar += guardar_comentario;
                this.vista.volver += volver;
            }

            private void guardar_comentario(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(vista.comentario))
                {
                    MessageBox.Show("Por favor ingrese un comentario válido.");
                    return;
                }

                Base baseEditada = new Base
                {
                    IdBase = baseOriginal.IdBase,
                    Comentario = vista.comentario
                };

                repositorio.EditarComentario(baseEditada);
                presentador.vista_OnMovilSeleccionado(this, EventArgs.Empty); // recarga la grilla

                ((Form)vista).Close();
            }

            private void volver(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }
        }
    }
}
