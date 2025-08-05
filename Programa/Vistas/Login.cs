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
            asociacionPresentador();
            this.FormClosed += (s, e) => Application.Exit();
        }

        //Conexion con el presentador
        void asociacionPresentador()
        {
            btnIngresar.Click += delegate 
            {
                buscarUsuario?.Invoke(this, EventArgs.Empty);
            };
        }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static Login instancia;

        // Variables que contienen los Inputs de los TextInput
        public string txtUsuarios 
        {
            get { return txtUsuario.Text;}
            set { txtUsuario.Text = value; }
        }
        public string txtContrasenas 
        {
            get { return txtContrasena.Text; }
            set { txtContrasena.Text = value; }
        }
        // Metodo para el boton de la vista. Lo ejecuta el presentador
        public event EventHandler buscarUsuario;

        // Metodo para el uso del Singleton
        public static Login ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new Login();
                instancia.Show();
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
