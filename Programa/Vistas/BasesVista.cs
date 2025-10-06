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
    public partial class BasesVista : Form, IBasesVista
    {
        public BasesVista()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ModificarVista_Load);
            asociacionPresentador();
            this.Load += BasesVista_Load;
        }
        private void asociacionPresentador()
        {
            btnAgregar.Click += (s, e) => agregarBase?.Invoke(this, EventArgs.Empty);
            btnModificar.Click += (s, e) => modificarBase?.Invoke(this, EventArgs.Empty);
            btnComentar.Click += (s, e) => comentarBase?.Invoke(this, EventArgs.Empty);
            btnEliminar.Click += (s, e) => eliminarBase?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);

            dgvMoviles.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {
                    var binding = dgvMoviles.DataSource as BindingSource;
                    var dt = binding?.DataSource as DataTable;
                    var idMovil = dt.Rows
                        .Cast<DataRow>()
                        .FirstOrDefault(r => r[0].ToString() == "IdMovil")?[e.ColumnIndex];

                    if (idMovil != null)
                    {
                        id_movil = Convert.ToInt32(idMovil);
                        OnMovilSeleccionado?.Invoke(this, EventArgs.Empty);
                    }
                }
            };
        }
        private void ModificarVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }

        // Eventos
        public event EventHandler agregarBase;
        public event EventHandler modificarBase;
        public event EventHandler comentarBase;
        public event EventHandler eliminarBase;
        public event EventHandler volver;
        public event EventHandler OnMovilSeleccionado;

        // Propiedades
        public int id_movil { get; set; }

        // Métodos
        public void ocultarBotones(string rol)
        {
            if (rol == "Operador")
            {
                btnModificar.Hide();
                btnEliminar.Hide();
            }
        }

        public void mostrarMoviles(BindingSource listaMoviles)
        {
            dgvMoviles.AutoGenerateColumns = true;
            dgvMoviles.DataSource = listaMoviles;

            dgvMoviles.RowHeadersVisible = false;
            dgvMoviles.AllowUserToAddRows = false;
            dgvMoviles.AllowUserToDeleteRows = false;
            dgvMoviles.ReadOnly = true;

            // ✅ Ocultar la primera columna ("Propiedad")
            if (dgvMoviles.Columns.Count > 0)
                dgvMoviles.Columns[0].Visible = false;

            if (dgvMoviles.Rows.Count > 0)
                dgvMoviles.Rows[0].Visible = false;
        }
        private void BasesVista_Load(object sender, EventArgs e)
        {
            dgvMoviles.ClearSelection();
        }
        public void mostrarBases(List<BaseDetalleDTO> listaBases)
        {
            TLPBases.SuspendLayout();
            TLPBases.Controls.Clear();
            TLPBases.ColumnStyles.Clear();
            TLPBases.RowStyles.Clear();

            TLPBases.AutoScroll = false;
            TLPBases.AutoSize = false;
            TLPBases.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            TLPBases.Padding = new Padding(0);
            TLPBases.BackColor = Color.White;

            PBases.AutoScroll = true;
            PBases.HorizontalScroll.Enabled = true;
            PBases.VerticalScroll.Enabled = false;
            PBases.Padding = new Padding(0);

            int altoFila = 30;
            int anchoCelda = 700;
            int filasPorColumna = Math.Max(1, PBases.Height / altoFila);
            int totalBases = listaBases.Count;
            int columnasNecesarias = (int)Math.Ceiling((double)totalBases / filasPorColumna);

            TLPBases.ColumnCount = columnasNecesarias;
            TLPBases.RowCount = filasPorColumna;

            for (int c = 0; c < columnasNecesarias; c++)
                TLPBases.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, anchoCelda));

            for (int r = 0; r < filasPorColumna; r++)
                TLPBases.RowStyles.Add(new RowStyle(SizeType.Absolute, altoFila));

            foreach (var baseItem in listaBases)
            {
                int index = listaBases.IndexOf(baseItem);
                int columna = index / filasPorColumna;
                int fila = index % filasPorColumna;

                var lbl = new Label
                {
                    Text = $"Fecha: {baseItem.Fecha_base:dd/MM/yyyy} Estado: {(baseItem.EstadoBase ? "Activa" : "Inactiva")} Comentario: {baseItem.Comentario} Operador: {baseItem.NombreOperador}",
                    Font = TLPBases.Font,
                    Size = new Size(anchoCelda - 4, altoFila),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(2),
                    Tag = baseItem.IdBase,
                    Cursor = Cursors.Hand,
                    BackColor = Color.LightGray,
                    AutoEllipsis = true,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                lbl.Click += (s, e) =>
                {
                    TLPBases.Tag = baseItem.IdBase;
                    lbl.BackColor = Color.LightBlue;
                    foreach (Control ctrl in TLPBases.Controls)
                        if (ctrl != lbl && ctrl is Label l) l.BackColor = Color.LightGray;
                };

                TLPBases.Controls.Add(lbl, columna, fila);
            }

            TLPBases.Width = columnasNecesarias * anchoCelda;
            int margenVertical = 2;
            int alturaReal = filasPorColumna * (altoFila + margenVertical * 2);
            TLPBases.Height = Math.Min(PBases.ClientSize.Height - 2, alturaReal);
            TLPBases.Dock = DockStyle.None;
            TLPBases.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            ScrollHelper.OcultarScrollVertical(PBases);
            TLPBases.ResumeLayout();
        }

        public int? ObtenerBaseSeleccionada()
        {
            return TLPBases.Tag is int id ? id : (int?)null;
        }

        // Singleton
        public static BasesVista instancia;
        public static BasesVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new BasesVista();
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
