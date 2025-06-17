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
        private IEnumerable<UsuarioModelo> modelos_usuario;
        private BindingSource filtrador;

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
            var usuario = repositorio.LoginUsuario(vista.txtUsuarios,vista.txtContrasenas);

            if(usuario != null) 
            {
            }
            else 
            {
                MessageBox.Show("No se encontro al usuario");
            }
        }
    }
}
