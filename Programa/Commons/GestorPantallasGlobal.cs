using Programa.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Commons
{
    /// <summary>
    /// Clase encargada de gestionar el cierre de vistas en conflicto antes de abrir una nueva pantalla.
    /// Permite mantener la coherencia visual y evitar superposición de formularios.
    /// </summary>
    public static class GestorPantallasGlobal
    {
        /// <summary>
        /// Cierra las vistas que podrían generar conflicto visual antes de abrir la vista destino.
        /// La lógica depende del tipo de pantalla que se desea abrir.
        /// </summary>
        /// <param name="destino">Nombre de la vista que se desea abrir.</param>
        public static void CerrarConflictosAntesDeAbrir(string destino)
        {
            // Configuración bloquea todo
            if (destino == "Configuraciones")
            {
                CerrarSiExiste(ViajesVista.instancia);
                CerrarSiExiste(VueltaVista.instancia);
                CerrarSiExiste(MovilesVista.instancia);
                CerrarSiExiste(BasesVista.instancia);
                CerrarSiExiste(OperadoresVista.instancia);
                CerrarSiExiste(AyudaVista.instancia);
                CerrarSiExiste(PlanillaCostoVista.instancia);
            }

            // Operadores bloquea configuraciones
            if(destino == "Operadores") { CerrarSiExiste(ConfiguracionesVista.instancia); }

            // Moviles bloquea todo excepto Ayuda y Operadores
            if (destino == "Moviles")
            {
                CerrarSiExiste(ViajesVista.instancia);
                CerrarSiExiste(VueltaVista.instancia);
                CerrarSiExiste(BasesVista.instancia);
                CerrarSiExiste(ConfiguracionesVista.instancia);
            }

            // Viajes cierra Vueltas y Configuraciones
            if (destino == "Viajes")
            {
                CerrarSiExiste(VueltaVista.instancia);
                CerrarSiExiste(ConfiguracionesVista.instancia);
                CerrarSiExiste(MovilesVista.instancia);
            }

            // Vueltas cierra Viajes y Configuraciones
            if (destino == "Vueltas")
            {
                CerrarSiExiste(ViajesVista.instancia);
                CerrarSiExiste(ConfiguracionesVista.instancia);
                CerrarSiExiste(MovilesVista.instancia);
            }

            // Bases cierra Moviles y Configuraciones
            if (destino == "Bases") 
            {
                CerrarSiExiste(MovilesVista.instancia);
                CerrarSiExiste(ConfiguracionesVista.instancia);
            }

            // Ayuda cierra Configuraciones
            if (destino == "Ayuda")
            {
                CerrarSiExiste(ConfiguracionesVista.instancia);
            }
        }

        /// <summary>
        /// Cierra una vista si está activa y no ha sido eliminada.
        /// </summary>
        /// <param name="vista">Instancia del formulario a cerrar.</param>
        private static void CerrarSiExiste(Form vista)
        {
            if (vista != null && !vista.IsDisposed)
            {
                vista.Close();
            }
        }
    }
}
