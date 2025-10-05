using Programa.DTOs;
using Programa.Modelos.Interfaces;
using Programa.Vistas.Alta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Presentadores.CUPresentador
{
    public class CUVueltaPresentador
    {
        private readonly IAgregarVueltaVista vista;
        private readonly IViajesRepositorio vueltasRepositorio;
        private readonly DateTime fechaActual;
        private readonly Action recargarPrincipal;

        public CUVueltaPresentador(IAgregarVueltaVista vista, IViajesRepositorio vueltasRepositorio, DateTime fechaActual, Action recargarPrincipal)
        {
            this.vista = vista;
            this.vueltasRepositorio = vueltasRepositorio;
            this.fechaActual = fechaActual;
            this.recargarPrincipal = recargarPrincipal;

            vista.agregarMovil += agregar_movil;
            vista.volver += (s, e) => vista.Cerrar();

            var moviles = vueltasRepositorio.SeleccionarMovil();
            vista.SetMoviles(moviles);
        }

        private void agregar_movil(object sender, EventArgs e)
        {
            var seleccionados = vista.ObtenerMovilesSeleccionados();
            if (seleccionados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un móvil para agregar a la vuelta.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (var idMovil in seleccionados)
            {
                if (!vueltasRepositorio.MovilTieneVueltas(idMovil, fechaActual))
                {
                    int vueltaJusta = vueltasRepositorio.CalcularVueltaJustaParaNuevoMovil(fechaActual);
                    var dto = new VueltaDTO
                    {
                        IdMovil = idMovil,
                        VueltaFecha = fechaActual,
                        NumeroVuelta = vueltaJusta,
                        EstadoVuelta = "·"
                    };
                    vueltasRepositorio.AgregarVueltaManual(dto);
                }
            }

            recargarPrincipal?.Invoke();
            vista.Cerrar();
        }
    }
}
