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
        event EventHandler agregarRecordatorio;
        event EventHandler eliminarRecordatorio;
        event EventHandler modificarRecordatorio;
        event EventHandler ingresarViajes;
        event EventHandler ingresarBases;
        event EventHandler ingresarVueltas;
        event EventHandler ingresarMoviles;
        event EventHandler ingresaroperadores;
        event EventHandler ingresarayuda;
        event EventHandler ingresarconfiguracion;
        event EventHandler volver;


        //Metodos
        void SetRecordatoriosBindingSource(BindingSource RecordatorioLista);
        void Mostrar();
    }
}
