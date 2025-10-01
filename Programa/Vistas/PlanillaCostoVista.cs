using Programa.DTOs;
using Programa.Estilos;
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

namespace Programa.Vistas
{
    public partial class PlanillaCostoVista : Form, IPlanillaCostoVista
    {
        public PlanillaCostoVista()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ModificarVista_Load);
            asociarPresentador();
        }
        private void ModificarVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }

        public event EventHandler modificarCuadrasCosto;
        public event EventHandler modificarCuadrasCostoMandado;
        public event EventHandler modificarCuadrasEspera;
        public event EventHandler modificarCiudadCosto;
        public event EventHandler modificarCiudadEspera;
        public event EventHandler agregarCiudad;
        public event EventHandler modificarCiudad;
        public event EventHandler eliminarCiudad;
        public event EventHandler volver;

        public void asociarPresentador()
        {
            btnPrecioCuadra.Click += (s, e) => modificarCuadrasCosto?.Invoke(this, EventArgs.Empty);
            btnPrecioCuadraMandado.Click += (s, e) => modificarCuadrasCostoMandado?.Invoke(this, EventArgs.Empty);
            btnPrecioCuadraEspera.Click += (s, e) => modificarCuadrasEspera?.Invoke(this, EventArgs.Empty);
            btnPrecioCiudad.Click += (s, e) => modificarCiudadCosto?.Invoke(this, EventArgs.Empty);
            btnPrecioCiudadEspera.Click += (s, e) => modificarCiudadEspera?.Invoke(this, EventArgs.Empty);
            btnAgregarCiudad.Click += (s, e) => agregarCiudad?.Invoke(this, EventArgs.Empty);
            btnModificarCiudad.Click += (s, e) => modificarCiudad?.Invoke(this, EventArgs.Empty);
            btnEliminarCiudad.Click += (s, e) => eliminarCiudad?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }
        public void MostrarImportesCuadras(int minimo, int espera, int mandado)
        {
            label3.Text = $"Monto de cuadras: {minimo}";
            label4.Text = $"Espera por 5m: {espera}";
            label5.Text = $"Monto por Mandado: {mandado}";
        }

        public void MostrarImportesCiudad(int kilometro, int espera)
        {
            label1.Text = $"Costo del KM: {kilometro}";
            label2.Text = $"Espera fuera de la ciudad: {espera}";
        }
        private void TransformarCiudadesEnHorizontalEnTLP(List<CiudadDTO> ciudades)
        {
            TLPCiudades.SuspendLayout();
            TLPCiudades.Controls.Clear();
            TLPCiudades.ColumnStyles.Clear();
            TLPCiudades.RowStyles.Clear();

            TLPCiudades.AutoScroll = false;
            TLPCiudades.AutoSize = false;
            TLPCiudades.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            TLPCiudades.Padding = new Padding(0);
            TLPCiudades.BackColor = Color.White;

            PCiudades.AutoScroll = true;
            PCiudades.HorizontalScroll.Enabled = true;
            PCiudades.VerticalScroll.Enabled = false;
            PCiudades.Padding = new Padding(0);

            int altoFila = 30;
            int anchoCelda = 450;
            int filasPorColumna = Math.Max(1, PCiudades.Height / altoFila);
            int totalCiudades = ciudades.Count;
            int columnasNecesarias = (int)Math.Ceiling((double)totalCiudades / filasPorColumna);

            TLPCiudades.ColumnCount = columnasNecesarias;
            TLPCiudades.RowCount = filasPorColumna;

            for (int c = 0; c < columnasNecesarias; c++)
                TLPCiudades.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, anchoCelda));

            for (int r = 0; r < filasPorColumna; r++)
                TLPCiudades.RowStyles.Add(new RowStyle(SizeType.Absolute, altoFila));

            foreach (var ciudad in ciudades)
            {
                int index = ciudades.IndexOf(ciudad);
                int columna = index / filasPorColumna;
                int fila = index % filasPorColumna;

                var lbl = new Label
                {
                    Text = $"Ciudad: {ciudad.NombreCiudad} Km: {ciudad.Kilometros} Importe: ${ciudad.Importe}",
                    Font = TLPCiudades.Font,
                    Size = new Size(anchoCelda - 4, altoFila),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(2),
                    Tag = ciudad.IdCiudad,
                    Cursor = Cursors.Hand,
                    BackColor = Color.LightGray,
                    AutoEllipsis = true,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                lbl.Click += (s, e) =>
                {
                    TLPCiudades.Tag = ciudad.IdCiudad;
                    lbl.BackColor = Color.LightBlue;
                    foreach (Control ctrl in TLPCiudades.Controls)
                        if (ctrl != lbl && ctrl is Label l) l.BackColor = Color.LightGray;
                };

                TLPCiudades.Controls.Add(lbl, columna, fila);
            }

            TLPCiudades.Width = columnasNecesarias * anchoCelda;
            int margenVertical = 2;
            int alturaReal = filasPorColumna * (altoFila + margenVertical * 2);
            TLPCiudades.Height = Math.Min(PCiudades.ClientSize.Height - 2, alturaReal);
            TLPCiudades.Dock = DockStyle.None;
            TLPCiudades.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            ScrollHelper.OcultarScrollVertical(PCiudades);
            TLPCiudades.ResumeLayout();
        }
        private void TransformarCuadrasEnHorizontalEnTLP(CuadrasImporteDTO dto)
        {
            TLPCuadras.SuspendLayout();
            TLPCuadras.Controls.Clear();
            TLPCuadras.ColumnStyles.Clear();
            TLPCuadras.RowStyles.Clear();

            // Configuración del TableLayoutPanel
            TLPCuadras.AutoScroll = false;
            TLPCuadras.AutoSize = false;
            TLPCuadras.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TLPCuadras.Padding = new Padding(0, 0, 0, 0);
            TLPCuadras.BackColor = Color.White;

            // Configuración del Panel contenedor
            PCuadras.AutoScroll = true;
            PCuadras.HorizontalScroll.Enabled = true;
            PCuadras.VerticalScroll.Enabled = false;
            PCuadras.Padding = new Padding(0);

            // Parámetros visuales
            int altoFila = 30;
            int anchoCelda = 290;
            int filasPorColumna = Math.Max(1, PCuadras.Height / altoFila);
            int totalCuadras = 120;
            int columnasNecesarias = (int)Math.Ceiling((double)totalCuadras / filasPorColumna);

            TLPCuadras.ColumnCount = columnasNecesarias;
            TLPCuadras.RowCount = filasPorColumna;

            for (int c = 0; c < columnasNecesarias; c++)
                TLPCuadras.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, anchoCelda));

            for (int r = 0; r < filasPorColumna; r++)
                TLPCuadras.RowStyles.Add(new RowStyle(SizeType.Absolute, altoFila));

            for (int i = 0; i < totalCuadras; i++)
            {
                int columna = i / filasPorColumna;
                int fila = i % filasPorColumna;

                int numero = i + 1;
                int importe = numero <= 9 ? dto.Minimo : dto.Minimo + (numero - 9) * dto.Cuadras;

                var lbl = new Label
                {
                    Text = $"Cuadra: {numero} Importe: ${importe}",
                    Font = TLPCuadras.Font,
                    Size = new Size(anchoCelda - 4, altoFila),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(2),
                    Tag = numero,
                    Cursor = Cursors.Hand,
                    BackColor = Color.LightGray,
                    AutoEllipsis = true,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                lbl.Click += (s, e) =>
                {
                    TLPCuadras.Tag = numero;
                    lbl.BackColor = Color.LightBlue;
                    foreach (Control ctrl in TLPCuadras.Controls)
                        if (ctrl != lbl && ctrl is Label l) l.BackColor = Color.LightGray;
                };

                TLPCuadras.Controls.Add(lbl, columna, fila);
            }

            // Asignar tamaño horizontal total
            TLPCuadras.Width = columnasNecesarias * anchoCelda;
            int margenVertical = 2; // el mismo que usás en lbl.Margin
            int alturaReal = filasPorColumna * (altoFila + margenVertical * 2);
            TLPCuadras.Height = Math.Min(PCuadras.ClientSize.Height - 2, alturaReal);
            TLPCuadras.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            TLPCuadras.Dock = DockStyle.None;
            TLPCuadras.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            ScrollHelper.OcultarScrollVertical(PCuadras);
            TLPCuadras.ResumeLayout();
        }
        public int? ObtenerCuadraSeleccionada()
        {
            return TLPCuadras.Tag is int valor ? valor : (int?)null;
        }
        public int? ObtenerCiudadSeleccionada()
        {
            return TLPCiudades.Tag is int id ? id : (int?)null;
        }
        public void MostrarCuadrasEnLayout(CuadrasImporteDTO dto)
        {
            TransformarCuadrasEnHorizontalEnTLP(dto);
        }
        public void MostrarCiudadesEnLayout(List<CiudadDTO> ciudades)
        {
            TransformarCiudadesEnHorizontalEnTLP(ciudades);
        }
        // Singleton
        private static PlanillaCostoVista instancia;
        public static PlanillaCostoVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new PlanillaCostoVista();
                instancia.Show();
            }
            else
            {
                if (instancia.WindowState == FormWindowState.Minimized)
                    instancia.WindowState = FormWindowState.Normal;

                instancia.BringToFront();
                instancia.Activate();
            }
            return instancia;
        }
    }
}
