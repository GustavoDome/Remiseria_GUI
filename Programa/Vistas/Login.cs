using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programa.Vistas.Interfaces;
using Programa.Presentadores;
namespace Programa.Vistas
{
    public partial class Login : Form, ILogin
    {
        public Login() //Constructor del archivo
        {
            InitializeComponent();
            this.FormClosed += (s, e) => Application.Exit(); // Metodo para cerrar el programa
        }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static Login instancia;

        // Variables que contienen los Inputs de los TextInput
        public string txtUsuarios { get => txtUsuario.Text; }
        public string txtContrasenas { get => txtContrasena.Text; }

        // Metodo para el boton de la vista. Lo ejecuta el presentador
        event EventHandler ILogin.btnIngresar
        {
            add {this.btnIngresar.Click += value;}
            remove {this.btnIngresar.Click -= value;}
        }

        // Metodo para el uso del Singleton
        public static Login ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new Login();
            }
            else
            {
                if (instancia.WindowState == FormWindowState.Minimized)
                {
                    instancia.WindowState = FormWindowState.Normal;
                }
                instancia.BringToFront();
                instancia.Activate();
            }
            return instancia;
        }
    }
}
