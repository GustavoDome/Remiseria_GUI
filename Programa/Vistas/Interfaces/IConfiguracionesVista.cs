using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Interfaces
{
    /// <summary>
    /// Contrato de la vista de configuración.
    /// Permite ajustar fuente, tamaño, tema y alarma, con eventos de guardado y navegación.
    /// </summary>
    public interface IConfiguracionesVista
    {
        string tipoFuente { get; set; }
        string tamanoFuente { get; set; }
        string temaSistema { get; set; }
        string tipoAlarma { get; set; }

        event EventHandler volver;
        event EventHandler guardar;

        void RefrescarEstilos();
        void SetTipoFuenteBindingSource(BindingSource tipoFuentes);
        void ReproducirAlarmaPreview(string nombreAlarma);
        void SetTamanoFuenteBindingSource(BindingSource tamanoFuentes);
        void SetTemaSistemaBindingSource(BindingSource temaSistemas);
        void SetTipoAlarmaBindingSource(BindingSource tipoAlarmas);
    }
}
