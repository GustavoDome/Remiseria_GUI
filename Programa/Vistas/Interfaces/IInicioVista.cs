using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Interfaces
{
    public interface IInicioVista
    {

        //Eventos
        event EventHandler btnOperadores;
        event EventHandler btnMoviles;
        event EventHandler btnViajes;
        event EventHandler btnVuelta;
        event EventHandler btnBases;
        event EventHandler btnVolver;
        event EventHandler btnRecAgregar;
        event EventHandler btnRecModificar;
        event EventHandler btnRecEliminar;
        event EventHandler btnAyuda;
        event EventHandler btnConfiguracion;

        //Metodos
        void SetRecordatoriosBindingSource(BindingSource RecordatorioLista);
        void Mostrar();
    }
}
