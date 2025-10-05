using Programa.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Commons
{
    public static class GestorPantallasGlobal
    {
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
        private static void CerrarSiExiste(Form vista)
        {
            if (vista != null && !vista.IsDisposed)
            {
                vista.Close();
            }
        }
    }
}
