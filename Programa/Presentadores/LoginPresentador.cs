using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Repositorios;
using Programa.Vistas;
using Programa.Vistas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Presentadores
{
    public class LoginPresentador
    {
        private IUsuarioRepositorio repositorio;
        private ILogin vista;
        private IEnumerable<UsuarioModelo> modelosUsuario;
        private BindingSource filtrador;
        private string rol;

        //Constructor
        public LoginPresentador(ILogin vista, IUsuarioRepositorio repositorio)
        {
            this.filtrador = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;

            //metodos

            this.vista.buscarUsuario += buscar_usuario;
        }

        private void buscar_usuario(object sender, EventArgs e)
        {
            try 
            {
                var usuario = this.repositorio.LoginUsuario(vista.txtUsuarios, vista.txtContrasenas);

                if (usuario.Nombre == vista.txtUsuarios && usuario.Contrasena == vista.txtContrasenas)
                {
                    IRecordatorioRepositorio recordatorio = new RecordatorioRepositorio();
                    IInicioVista inicio = InicioVista.ObtenerInstancia();
                    new InicioPresentador(inicio, recordatorio);
                    ((Form)vista).Hide();

                }
            }
            catch (NullReferenceException ex) 
            {
                MessageBox.Show($"No se encuentra al usuario. Error {ex.Message}");

            }
        }
    }
}
