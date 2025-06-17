using System;
using System.Windows.Forms;
using Programa.Modelos.Interfaces;
using Programa.Presentadores;
using Programa.Repositorios;
using Programa.Vistas;
using Programa.Vistas.Interfaces;

namespace Programa
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                ILogin vista = new Login();
                IUsuarioRepositorio vista_modelo = new UsuarioRepositorio();
                new LoginPresentador(vista, vista_modelo);
                Application.Run((Form)vista);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en tiempo de ejecución: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
