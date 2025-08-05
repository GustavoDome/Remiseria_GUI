using Programa.Modelos.Interfaces;
using Programa.Modelos;
using Programa.Vistas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programa.Repositorios;
using Programa.Vistas;

namespace Programa.Presentadores
{
    public class BasesPresentador
    {
        private IBasesRepositorio repositorio;
        private IBasesVista vista;
        private IEnumerable<BasesModelo> movilModelos;
        private BindingSource filtrador;

        public BasesPresentador(IBasesVista vista, IBasesRepositorio repositorio)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;

            this.vista.agregarBase += agregar_base;
            this.vista.modificarBase += modificar_base;
            this.vista.comentarBase += comentar_base;
            this.vista.eliminarBase += eliminar_base;
            this.vista.volver += voler_menu;
        }

        private void agregar_base(object sender, EventArgs e) { }
        private void modificar_base(object sender, EventArgs e) { }
        private void comentar_base(object sender, EventArgs e) { }
        private void eliminar_base(object sender, EventArgs e) { }
        private void voler_menu(object sender, EventArgs e) 
        {
            IRecordatorioRepositorio recordatorio = new RecordatorioRepositorio();
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            new InicioPresentador(inicio, recordatorio);
            ((Form)vista).Close();
        }
    }
}
