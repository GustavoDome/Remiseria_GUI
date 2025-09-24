using Programa.Conexion;
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
        private readonly IOperadorRepositorio repositorio;
        private readonly ILogin vista;

        public LoginPresentador(ILogin vista, IOperadorRepositorio repositorio)
        {
            this.vista = vista;
            this.repositorio = repositorio;

            this.vista.buscarUsuario += buscar_usuario;
        }
        private void test()
        {
            try
            {
                using (var contexto = new RemiseriaDbContext())
                {
                    var test = contexto.Operadores.FirstOrDefault();
                    MessageBox.Show("Conexión exitosa");
                }
            }
            catch (Exception ex)
            {
                string mensaje = "Error: " + ex.Message;
                if (ex.InnerException != null)
                {
                    mensaje += "\n\nDetalle interno: " + ex.InnerException.Message;
                }
                MessageBox.Show(mensaje);
            }

        }

        private void buscar_usuario(object sender, EventArgs e)
        {
            test();
            try
            {
                var usuario = repositorio.Autenticar(vista.txtUsuarios, vista.txtContrasenas);

                if (usuario != null)
                {
                    IRecordatorioRepositorio recordatorio = new RecordatorioRepositorio();
                    IInicioVista inicio = InicioVista.ObtenerInstancia();
                    new InicioPresentador(inicio, recordatorio, usuario.RolUsuario, usuario.IdOperador);

                    ((Form)vista).Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar iniciar sesión: {ex.Message}");
            }
        }
    }
}
