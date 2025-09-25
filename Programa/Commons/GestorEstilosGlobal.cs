using System.Drawing;
using System.Windows.Forms;
using Programa.DTOs;

namespace Programa.Estilos
{
    public class GestorEstilosGlobal
    {
        private static GestorEstilosGlobal instancia;
        private ConfiguracionDTO configuracionActual;

        private GestorEstilosGlobal() { }

        public static GestorEstilosGlobal Instance
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new GestorEstilosGlobal();
                }
                return instancia;
            }
        }

        public void AplicarConfiguracion(ConfiguracionDTO config)
        {
            configuracionActual = config;
        }

        public void AplicarEstilosAFormulario(Form form)
        {
            if (configuracionActual == null) return;

            Font fuente = new Font(configuracionActual.Fuente, configuracionActual.TamanoFuente);
            string tema = configuracionActual.TemaColor.ToLower();

            if (tema == "oscuro")
            {
                Color fondo = Color.FromArgb(45, 45, 48);
                Color fuenteColor = Color.White;

                form.Font = fuente;
                form.BackColor = fondo;
                form.ForeColor = fuenteColor;

                AplicarEstilosRecursivos(form, fuente, fondo, fuenteColor);
            }
            else
            {
                Color fondo = ObtenerColor(tema);
                Color fuenteColor = Color.Black;

                form.Font = fuente;
                form.BackColor = fondo;
                form.ForeColor = fuenteColor;

                AplicarEstilosRecursivos(form, fuente, fondo, fuenteColor);
            }
        }
        public string ObtenerTemaActual()
        {
            return configuracionActual?.TemaColor.ToLower() ?? "claro";
        }

        private void AplicarEstilosRecursivos(Control control, Font fuente, Color fondo, Color fuenteColor)
        {
            control.Font = fuente;
            control.BackColor = fondo;
            control.ForeColor = fuenteColor;

            if (control is TextBox cuadroTexto)
            {
                cuadroTexto.BackColor = fuenteColor == Color.White ? Color.DimGray : Color.White;
                cuadroTexto.ForeColor = fuenteColor;
            }
            if (control is Label label)
            {
                string tema = ObtenerTemaActual();
                label.ForeColor = ObtenerColorTextoLabel(tema);
                label.BackColor = Color.Transparent;
            }
            else if (control is Button boton)
            {
                boton.FlatAppearance.BorderSize = 1;
                boton.FlatAppearance.BorderColor = fuenteColor == Color.White ? Color.Gray : Color.DarkGray;
                boton.FlatStyle = FlatStyle.Standard;
                boton.Padding = new Padding(4);
                boton.BackColor = fuenteColor == Color.White ? Color.White : Color.LightGray;
                boton.ForeColor = Color.Black;
            }
            else if (control is ComboBox combo)
            {
                combo.BackColor = fuenteColor == Color.White ? Color.Gray : Color.White;
                combo.ForeColor = fuenteColor;
            }
            else if (control is TextBox texto)
            {
                texto.BackColor = fuenteColor == Color.White ? Color.DimGray : Color.White;
                texto.ForeColor = fuenteColor;
            }
            else if (control is DataGridView grid)
            {
                string tema = ObtenerTemaActual();
                Color fondoGrid = ObtenerColorDataGrid(tema);

                grid.BackgroundColor = fondoGrid;
                grid.DefaultCellStyle.BackColor = fondoGrid;
                grid.DefaultCellStyle.ForeColor = fuenteColor;
                grid.ColumnHeadersDefaultCellStyle.BackColor = fondoGrid;
                grid.ColumnHeadersDefaultCellStyle.ForeColor = fuenteColor;
                grid.EnableHeadersVisualStyles = false;
                grid.BorderStyle = BorderStyle.FixedSingle;
                grid.GridColor = fuenteColor == Color.White ? Color.Gray : Color.DarkGray;
            }
            else if (control is TabControl tabs)
            {
                foreach (TabPage page in tabs.TabPages)
                {
                    page.BackColor = fondo;
                    page.ForeColor = fuenteColor;
                    AplicarEstilosRecursivos(page, fuente, fondo, fuenteColor);
                }
            }

            foreach (Control hijo in control.Controls)
            {
                AplicarEstilosRecursivos(hijo, fuente, fondo, fuenteColor);
            }
        }
        private Color ObtenerColorTextoLabel(string tema)
        {
            switch (tema)
            {
                case "oscuro": return Color.White;
                case "claro": return Color.Black;
                case "azul": return Color.Navy;
                case "verde": return Color.WhiteSmoke;       // más claro para fondo verde
                case "rojo": return Color.WhiteSmoke;        // más claro para fondo rojo
                case "gris": return Color.Black;
                case "rosa": return Color.LavenderBlush;
                case "celeste": return Color.DarkSlateGray;
                case "turquesa": return Color.Black; // mejor contraste que WhiteSmoke; // pastel claro   // más claro para fondo turquesa
                case "purpura": return Color.WhiteSmoke;     // más claro para fondo púrpura
                default: return Color.Black;
            }
        }
        private Color ObtenerColorDataGrid(string tema)
        {
            switch (tema)
            {
                case "oscuro": return Color.FromArgb(30, 30, 30);
                case "claro": return Color.White;
                case "azul": return Color.FromArgb(220, 235, 250);       // más contraste que AliceBlue
                case "verde": return Color.FromArgb(230, 255, 230);      // más claro que Honeydew
                case "rojo": return Color.FromArgb(255, 230, 230);       // más claro que MistyRose
                case "gris": return Color.FromArgb(240, 240, 240);       // neutro claro
                case "rosa": return Color.FromArgb(255, 240, 250);       // más pastel
                case "celeste": return Color.FromArgb(225, 245, 255);    // más claro que Azure
                case "turquesa": return Color.FromArgb(230, 255, 250);   // más claro que MintCream
                case "purpura": return Color.FromArgb(240, 230, 255);    // pastel lavanda
                default: return Color.WhiteSmoke;
            }
        }

        private Color ObtenerColor(string nombreColor)
        {
            switch (nombreColor)
            {
                case "claro": return Color.WhiteSmoke;
                case "oscuro": return Color.FromArgb(45, 45, 48);
                case "azul": return Color.LightSteelBlue;
                case "verde": return Color.Green;
                case "rojo": return Color.Red;
                case "gris": return Color.Gray;
                case "rosa": return Color.Pink;
                case "celeste": return Color.SkyBlue;
                case "turquesa": return Color.Turquoise;
                case "purpura": return Color.Purple;
                default: return SystemColors.Control;
            }
        }
    }
}