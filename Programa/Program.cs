using System;
using System.Windows.Forms;
using Programa.Presentadores;
using Programa.Repositorios;
using Programa.Vistas;

namespace Programa
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Instanciar la vista una única vez
            var loginVista = Login.ObtenerInstancia();

            // Instanciar el repositorio
            var repositorio = new UsuarioRepositorio();

            // Instanciar el presentador
            var presentador = new LoginPresentador(loginVista, repositorio);

            // Ejecutar la aplicación con esa única instancia
            Application.Run(loginVista);
        }
    }
}
