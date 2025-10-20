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
    /// <summary>
    /// Presentador encargado de gestionar el proceso de autenticación del operador.
    /// Coordina entre la vista de login y el repositorio de operadores.
    /// </summary>
    public class LoginPresentador
    {
        private readonly IOperadorRepositorio repositorio;
        private readonly ILogin vista;

        /// <summary>
        /// Inicializa el presentador con la vista de login y el repositorio de operadores.
        /// </summary>
        /// <param name="vista">Vista que implementa <see cref="ILogin"/>.</param>
        /// <param name="repositorio">Repositorio que implementa <see cref="IOperadorRepositorio"/>.</param>
        public LoginPresentador(ILogin vista, IOperadorRepositorio repositorio)
        {
            this.vista = vista;
            this.repositorio = repositorio;

            // Asocia el evento de búsqueda de usuario al método correspondiente
            this.vista.buscarUsuario += buscar_usuario;
        }

        /// <summary>
        /// Lógica de autenticación del operador. Verifica credenciales, aplica configuración visual
        /// y lanza la vista principal del sistema si el login es exitoso.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
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
                var inner = ex.InnerException;
                while (inner?.InnerException != null)
                    inner = inner.InnerException;

                MessageBox.Show("Error interno: " + (inner?.Message ?? ex.Message));
                throw;
            }
        }
    }
}
