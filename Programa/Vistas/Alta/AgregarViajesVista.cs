using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Presentadores;
using Programa.Repositorios;
using Programa.Vistas.Alta.Interfaces;
using Programa.Vistas.Interfaces;
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
        private int idusuario;
        private string rol;
        public AgregarViajesVista(int id, int idusuario, string rol)
        {
            this.id = id;
            this.idusuario = idusuario;
            this.rol = rol;
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
            var movilesrepositorios = new MovilRepositorio();
            var listaMoviles = movilesrepositorios.seleccionarMovil();

            // IDs reales desde la base de datos
            var numeroMovilesid = listaMoviles.Select(m => m.Id).ToList();

            // IDs seleccionados desde la UI
            var numeroMoviles = clbMoviles.CheckedItems
                .Cast<string>()
                .Select(item => Convert.ToInt32(item.ToString().Split(' ')[1]))
                .ToList();

            // Intersección entre ambos
            var movilesSeleccionados = numeroMoviles.Intersect(numeroMovilesid).ToList();

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
        public static AgregarViajesVista ObtenerInstancia(int id, int idusuario, string rol)
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new AgregarViajesVista(id, idusuario, rol);
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

        public List<int> obtenerVuelta()
        {
            var repositorio = new ViajesRepositorio();

            // Móviles seleccionados desde la UI (por ejemplo, CheckedListBox)
            var movilesSeleccionados = obtenermovil(); // List<int>

            // Lista de vueltas desde la base
            var listavueltas = repositorio.seleccionarVuelta(); // IEnumerable<VueltaIdModelo>

            // Filtrar las vueltas que coinciden con los móviles seleccionados
            var vueltasFiltradas = listavueltas
                .Where(v => movilesSeleccionados.Contains(v.Numero_movil))
                .Select(v => v.Vuelta)
                .ToList();

            return vueltasFiltradas;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var repositorio = new ViajesRepositorio();
            agregarViajeModelo viaje = new agregarViajeModelo();
            TimeSpan hora = DateTime.Now.TimeOfDay;
            DateTime fecha_vuelta = DateTime.Today;
            viaje.Id = this.id;
            viaje.Hora_viaje = hora;
            viaje.Direccion = txtDirecciones;
            viaje.Vuelta = obtenerVuelta();
            viaje.Estado_vuelta = "X";
            viaje.Vuelta_fecha = fecha_vuelta;
            viaje.Estado_viaje = "·";
            viaje.Comentario = obtenerOpcion();
            viaje.Id_movil = obtenermovil();
            viaje.Id_operador = this.idusuario; 

            try
            {
                repositorio.agregar(viaje);
                MessageBox.Show("si se pudo agregar el viaje");
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"No se pudo agregar el viaje. Error {ex.Message}");
            }
            finally
            {
                this.Close();
                IViajesRepositorio viajes = new ViajesRepositorio();
                IViajesVista viajesvista = ViajesVista.ObtenerInstancia();
                new ViajesPresentador(viajesvista, viajes, this.rol, this.id);
            }
        }
    }
}
