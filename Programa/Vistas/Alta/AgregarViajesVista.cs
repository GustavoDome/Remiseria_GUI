using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Repositorios;
using Programa.Vistas.Alta.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Alta
{
    public partial class AgregarViajesVista : Form, IAgregarViajesVista
    {
        private int id;
        public AgregarViajesVista(int id)
        {
            this.id = id;
            InitializeComponent();
            cargarMovlies();
        }
        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static AgregarViajesVista instancia;

        public string txtDirecciones 
        {
            get {return txtDireccion.Text;}
            set {txtDireccion.Text = value;}
        }
        public string rtbComentarios 
        {
            get {return rtbComentario.Text;}
            set {rtbComentario.Text = value;}
        }
        public string rbtnAfueras 
        {
            get { return rbtnAfuera.Text; }
            set { rbtnAfuera.Text = value; }
        }
        public string rbtnDerivados 
        {
            get { return rdbtnDerivado.Text; }
            set { rdbtnDerivado.Text = value; }
        }
        public string rbtnDesignados 
        {
            get { return rbtnDesignado.Text; }
            set { rbtnDesignado.Text = value; }
        }
        public string rbtnOtros 
        {
            get { return rbtnOtro.Text; }
            set { rbtnOtro.Text = value;}
        }

        private List<int> moviles;

        public void cargarMovlies() 
        {
            var moviles = new MovilRepositorio();
            // Obtenemos la lista de móviles desde tu función
            var listaMoviles = moviles.seleccionarMovil();

            // Limpiamos ítems previos
            clbMoviles.Items.Clear();

            // Agregamos cada móvil como un ítem
            foreach (var movil in listaMoviles)
            {
                clbMoviles.Items.Add($"Móvil {movil.Numero_movil}", false); // false = no seleccionado por defecto
            }
        }
        public List<int> obtenermovil() 
        {
            List<int> movilesSeleccionados = new List<int>();

            foreach (var item in clbMoviles.CheckedItems)
            {
                movilesSeleccionados.Add(Convert.ToInt32(item.ToString().Split(' ')[1]));
            }

            return movilesSeleccionados;
        }

        public string obtenerOpcion()
        {
            string seleccion;

            if (rbtnAfuera.Checked) { seleccion = rbtnAfueras; }
            else if (rbtnDesignado.Checked) { seleccion = rbtnDesignados; }
            else if (rdbtnDerivado.Checked) { seleccion = rbtnDerivados; }
            else if (rbtnOtro.Checked) { seleccion = rbtnOtros; }
            else { seleccion = null; }

            return seleccion;
        }

        // Metodo para el uso del Singleton
        public static AgregarViajesVista ObtenerInstancia(int id)
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new AgregarViajesVista(id);
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var repositorio = new ViajesRepositorio();
            ViajesModelo viaje = new ViajesModelo();
            TimeSpan hora = DateTime.Now.TimeOfDay;
            viaje.Id_viajes = this.id;
            viaje.Hora_viaje = hora;
            viaje.Direccion = txtDirecciones;
            viaje.Estado_viaje = obtenerOpcion();
            viaje.Comentario = rtbComentarios;
            viaje.Id_movil = obtenermovil();
            viaje.Id_operador = 1; 

            try
            {
                repositorio.agregar(viaje);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"No se pudo agregar el viaje. Error {ex.Message}");
            }
        }
    }
}
