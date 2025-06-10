using Programa.Modelos;
using Programa.Repositorios;
using Programa.Vistas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Presentadores
{
    internal class LoginPresentador
    {
        private readonly ILogin vista;
        private readonly UsuarioRepositorio repositorio;

        public LoginPresentador(ILogin vista, UsuarioRepositorio repositorio)
        {
            this.vista = vista;
            this.repositorio = repositorio;
            Console.WriteLine("Estuve aqui");
            this.vista.btnIngresar += ValidarLogin;
        }

        private void ValidarLogin(object sender, EventArgs e)
        {
            string nombre = vista.txtUsuarios;
            string contrasena = vista.txtContrasenas;

            UsuarioModelo usuario = repositorio.LoginUsuario(nombre, contrasena);

            if (usuario != null)
            {
                MessageBox.Show($"Bienvenido {usuario.Nombre}, rol: {usuario.RolUsuario}");
                // Ir a menú principal
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}
