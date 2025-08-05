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
        private IUsuarioRepositorio repositorio;
        private IConfiguracionesVista vista;
        private IEnumerable<UsuarioModelo> usuarioModelos;
        private BindingSource filtrador;

        public ConfiguracionesPresentador(IConfiguracionesVista vista, IUsuarioRepositorio repositorio)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;

            this.vista.guardar += guardar_configuracion;
            this.vista.volver += volver_menu;
        }
        private void guardar_configuracion(object sender, EventArgs e) { }
        private void volver_menu(object sender, EventArgs e) 
        {
            IRecordatorioRepositorio recordatorio = new RecordatorioRepositorio();
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            new InicioPresentador(inicio, recordatorio);
            ((Form)vista).Close();
        }
    }
}
