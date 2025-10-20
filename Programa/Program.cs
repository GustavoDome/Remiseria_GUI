using System;
using System.Windows.Forms;
using Programa.Modelos.Interfaces;
using Programa.Presentadores;
using Programa.Repositorios;
using Programa.Vistas;
using Programa.Vistas.Interfaces;

namespace Programa
{
    /// <summary>
    /// Clase principal que contiene el punto de entrada de la aplicación.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Método principal de la aplicación. Inicializa la base de datos si es necesario,
        /// configura el entorno visual y lanza la interfaz de inicio de sesión.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                // Inicializar la base de datos
                bool created = DbBootstrapper.InitializeDatabase();
                if (created)
                {
                    MessageBox.Show("Se creo de manera exitosa la Base de Datos");
                }
                // Inicializar vista y presentador de login
                ILogin vista = new Login();
                IOperadorRepositorio vista_modelo = new OperadorRepositorio();
                new LoginPresentador(vista, vista_modelo);

                // Ejecutar la aplicación
                Application.Run((Form)vista);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en tiempo de ejecución: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
