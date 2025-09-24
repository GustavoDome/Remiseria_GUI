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
    public class ConfiguracionesPresentador
    {
        private IOperadorRepositorio repositorio;
        private IConfiguracionesVista vista;
        private IEnumerable<Operador> usuarioModelos;
        private BindingSource filtrador;
        private string rol;
        private int id;

        public ConfiguracionesPresentador(IConfiguracionesVista vista, IOperadorRepositorio repositorio, string rol, int id)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;
            this.rol = rol;
            this.id = id;

            this.vista.guardar += guardar_configuracion;
            this.vista.volver += volver_menu;
        }
        private void guardar_configuracion(object sender, EventArgs e) { }
        private void volver_menu(object sender, EventArgs e) 
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }
    }
}
