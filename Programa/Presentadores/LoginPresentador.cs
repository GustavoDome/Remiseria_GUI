using Programa.Conexion;
using Programa.Estilos;
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

        private void buscar_usuario(object sender, EventArgs e)
        {
            try
            {
                var usuario = repositorio.Autenticar(vista.txtUsuarios, vista.txtContrasenas);

                if (usuario != null)
                {
                    // 1. Cargar configuración visual del operador
                    var config = repositorio.ObtenerConfiguracion(usuario.IdOperador);
                    GestorEstilosGlobal.Instance.AplicarConfiguracion(config);

                    // 2. Crear vista y presentador de inicio
                    IRecordatorioRepositorio recordatorio = new RecordatorioRepositorio();
                    IInicioVista inicio = InicioVista.ObtenerInstancia();
                    new InicioPresentador(inicio, recordatorio, usuario.RolUsuario, usuario.IdOperador);

                    // 3. Aplicar estilos visuales en tiempo real
                    inicio.RefrescarEstilos();

                    // 4. Ocultar login
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
