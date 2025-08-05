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
    public class OperadoresPresentador
    {
        private IUsuarioRepositorio repositorio;
        private IOperadoresVista vista;
        private IEnumerable<UsuarioModelo> usuarioModelos;
        private BindingSource filtrador;

        public OperadoresPresentador(IOperadoresVista vista, IUsuarioRepositorio repositorio)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;

            this.vista.agregarOperador += agregar_operador;
            this.vista.modificiarOperador += modificar_operador;
            this.vista.eliminarOperador += eliminar_operador;
            this.vista.volver += volver_menu;
        }

        private void agregar_operador(object sender, EventArgs e) { }
        private void modificar_operador(object sender, EventArgs e) { }
        private void eliminar_operador(object sender, EventArgs e) { }
        private void volver_menu(object sender, EventArgs e) 
        {
            IRecordatorioRepositorio recordatorio = new RecordatorioRepositorio();
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            new InicioPresentador(inicio, recordatorio);
            ((Form)vista).Close();
        }
    }
}
