namespace Programa.Vistas
{
    partial class InicioVista
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcInternet = new System.Windows.Forms.TabControl();
            this.WebWhatsapp = new System.Windows.Forms.TabPage();
            this.wbWhatsapp = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.WebGoogleMaps = new System.Windows.Forms.TabPage();
            this.wbGoogleMaps = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.WebInternet = new System.Windows.Forms.TabPage();
            this.wbGoogle = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.btnViajes = new System.Windows.Forms.Button();
            this.btnVuelta = new System.Windows.Forms.Button();
            this.btnOperadores = new System.Windows.Forms.Button();
            this.btnMoviles = new System.Windows.Forms.Button();
            this.btnBases = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.PictureBox();
            this.btnRecAgregar = new System.Windows.Forms.Button();
            this.btnRecModificar = new System.Windows.Forms.Button();
            this.btnRecEliminar = new System.Windows.Forms.Button();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvRecordatorio = new System.Windows.Forms.DataGridView();
            this.tcInternet.SuspendLayout();
            this.WebWhatsapp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wbWhatsapp)).BeginInit();
            this.WebGoogleMaps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wbGoogleMaps)).BeginInit();
            this.WebInternet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wbGoogle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAyuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecordatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // tcInternet
            // 
            this.tcInternet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcInternet.Controls.Add(this.WebWhatsapp);
            this.tcInternet.Controls.Add(this.WebGoogleMaps);
            this.tcInternet.Controls.Add(this.WebInternet);
            this.tcInternet.ItemSize = new System.Drawing.Size(150, 18);
            this.tcInternet.Location = new System.Drawing.Point(12, 12);
            this.tcInternet.Name = "tcInternet";
            this.tcInternet.SelectedIndex = 0;
            this.tcInternet.Size = new System.Drawing.Size(518, 497);
            this.tcInternet.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcInternet.TabIndex = 0;
            // 
            // WebWhatsapp
            // 
            this.WebWhatsapp.Controls.Add(this.wbWhatsapp);
            this.WebWhatsapp.Location = new System.Drawing.Point(4, 22);
            this.WebWhatsapp.Name = "WebWhatsapp";
            this.WebWhatsapp.Padding = new System.Windows.Forms.Padding(3);
            this.WebWhatsapp.Size = new System.Drawing.Size(510, 471);
            this.WebWhatsapp.TabIndex = 0;
            this.WebWhatsapp.Text = "Whatsapp";
            this.WebWhatsapp.UseVisualStyleBackColor = true;
            // 
            // wbWhatsapp
            // 
            this.wbWhatsapp.AllowExternalDrop = true;
            this.wbWhatsapp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbWhatsapp.CreationProperties = null;
            this.wbWhatsapp.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wbWhatsapp.Location = new System.Drawing.Point(0, 0);
            this.wbWhatsapp.Name = "wbWhatsapp";
            this.wbWhatsapp.Size = new System.Drawing.Size(510, 471);
            this.wbWhatsapp.Source = new System.Uri("https://web.whatsapp.com/", System.UriKind.Absolute);
            this.wbWhatsapp.TabIndex = 0;
            this.wbWhatsapp.ZoomFactor = 0.8D;
            // 
            // WebGoogleMaps
            // 
            this.WebGoogleMaps.Controls.Add(this.wbGoogleMaps);
            this.WebGoogleMaps.Location = new System.Drawing.Point(4, 22);
            this.WebGoogleMaps.Name = "WebGoogleMaps";
            this.WebGoogleMaps.Padding = new System.Windows.Forms.Padding(3);
            this.WebGoogleMaps.Size = new System.Drawing.Size(510, 471);
            this.WebGoogleMaps.TabIndex = 1;
            this.WebGoogleMaps.Text = "Google Maps";
            this.WebGoogleMaps.UseVisualStyleBackColor = true;
            // 
            // wbGoogleMaps
            // 
            this.wbGoogleMaps.AllowExternalDrop = true;
            this.wbGoogleMaps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbGoogleMaps.CreationProperties = null;
            this.wbGoogleMaps.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wbGoogleMaps.Location = new System.Drawing.Point(0, 0);
            this.wbGoogleMaps.Name = "wbGoogleMaps";
            this.wbGoogleMaps.Size = new System.Drawing.Size(510, 460);
            this.wbGoogleMaps.Source = new System.Uri("https://www.google.com/maps", System.UriKind.Absolute);
            this.wbGoogleMaps.TabIndex = 0;
            this.wbGoogleMaps.ZoomFactor = 1D;
            // 
            // WebInternet
            // 
            this.WebInternet.Controls.Add(this.wbGoogle);
            this.WebInternet.Location = new System.Drawing.Point(4, 22);
            this.WebInternet.Name = "WebInternet";
            this.WebInternet.Size = new System.Drawing.Size(510, 471);
            this.WebInternet.TabIndex = 2;
            this.WebInternet.Text = "Internet";
            this.WebInternet.UseVisualStyleBackColor = true;
            // 
            // wbGoogle
            // 
            this.wbGoogle.AllowExternalDrop = true;
            this.wbGoogle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbGoogle.CreationProperties = null;
            this.wbGoogle.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wbGoogle.Location = new System.Drawing.Point(0, 0);
            this.wbGoogle.Name = "wbGoogle";
            this.wbGoogle.Size = new System.Drawing.Size(510, 475);
            this.wbGoogle.Source = new System.Uri("https://www.google.com/?hl=es", System.UriKind.Absolute);
            this.wbGoogle.TabIndex = 0;
            this.wbGoogle.ZoomFactor = 1D;
            // 
            // btnViajes
            // 
            this.btnViajes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViajes.Location = new System.Drawing.Point(540, 12);
            this.btnViajes.Name = "btnViajes";
            this.btnViajes.Size = new System.Drawing.Size(119, 57);
            this.btnViajes.TabIndex = 1;
            this.btnViajes.Text = "Viajes";
            this.btnViajes.UseVisualStyleBackColor = true;
            // 
            // btnVuelta
            // 
            this.btnVuelta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVuelta.Location = new System.Drawing.Point(667, 12);
            this.btnVuelta.Name = "btnVuelta";
            this.btnVuelta.Size = new System.Drawing.Size(119, 57);
            this.btnVuelta.TabIndex = 2;
            this.btnVuelta.Text = "Vuelta";
            this.btnVuelta.UseVisualStyleBackColor = true;
            // 
            // btnOperadores
            // 
            this.btnOperadores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOperadores.Location = new System.Drawing.Point(540, 86);
            this.btnOperadores.Name = "btnOperadores";
            this.btnOperadores.Size = new System.Drawing.Size(151, 57);
            this.btnOperadores.TabIndex = 3;
            this.btnOperadores.Text = "Operadores";
            this.btnOperadores.UseVisualStyleBackColor = true;
            // 
            // btnMoviles
            // 
            this.btnMoviles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoviles.Location = new System.Drawing.Point(697, 86);
            this.btnMoviles.Name = "btnMoviles";
            this.btnMoviles.Size = new System.Drawing.Size(119, 57);
            this.btnMoviles.TabIndex = 4;
            this.btnMoviles.Text = "Moviles";
            this.btnMoviles.UseVisualStyleBackColor = true;
            // 
            // btnBases
            // 
            this.btnBases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBases.Location = new System.Drawing.Point(799, 12);
            this.btnBases.Name = "btnBases";
            this.btnBases.Size = new System.Drawing.Size(119, 57);
            this.btnBases.TabIndex = 5;
            this.btnBases.Text = "Bases";
            this.btnBases.UseVisualStyleBackColor = true;
            // 
            // btnAyuda
            // 
            this.btnAyuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAyuda.Location = new System.Drawing.Point(536, 230);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(509, 76);
            this.btnAyuda.TabIndex = 6;
            this.btnAyuda.TabStop = false;
            // 
            // btnRecAgregar
            // 
            this.btnRecAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecAgregar.Location = new System.Drawing.Point(540, 352);
            this.btnRecAgregar.Name = "btnRecAgregar";
            this.btnRecAgregar.Size = new System.Drawing.Size(120, 37);
            this.btnRecAgregar.TabIndex = 8;
            this.btnRecAgregar.Text = "Agregar";
            this.btnRecAgregar.UseVisualStyleBackColor = true;
            // 
            // btnRecModificar
            // 
            this.btnRecModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecModificar.Location = new System.Drawing.Point(723, 352);
            this.btnRecModificar.Name = "btnRecModificar";
            this.btnRecModificar.Size = new System.Drawing.Size(138, 37);
            this.btnRecModificar.TabIndex = 9;
            this.btnRecModificar.Text = "Modificar";
            this.btnRecModificar.UseVisualStyleBackColor = true;
            // 
            // btnRecEliminar
            // 
            this.btnRecEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecEliminar.Location = new System.Drawing.Point(926, 352);
            this.btnRecEliminar.Name = "btnRecEliminar";
            this.btnRecEliminar.Size = new System.Drawing.Size(119, 37);
            this.btnRecEliminar.TabIndex = 10;
            this.btnRecEliminar.Text = "Eliminar";
            this.btnRecEliminar.UseVisualStyleBackColor = true;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfiguracion.Location = new System.Drawing.Point(540, 149);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(505, 62);
            this.btnConfiguracion.TabIndex = 11;
            this.btnConfiguracion.Text = "Configuracion";
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(730, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Recordatorio";
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.Location = new System.Drawing.Point(926, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(119, 57);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // dgvRecordatorio
            // 
            this.dgvRecordatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecordatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecordatorio.Location = new System.Drawing.Point(536, 395);
            this.dgvRecordatorio.Name = "dgvRecordatorio";
            this.dgvRecordatorio.Size = new System.Drawing.Size(509, 110);
            this.dgvRecordatorio.TabIndex = 14;
            // 
            // InicioVista
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1057, 510);
            this.Controls.Add(this.dgvRecordatorio);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfiguracion);
            this.Controls.Add(this.btnRecEliminar);
            this.Controls.Add(this.btnRecModificar);
            this.Controls.Add(this.btnRecAgregar);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.btnBases);
            this.Controls.Add(this.btnMoviles);
            this.Controls.Add(this.btnOperadores);
            this.Controls.Add(this.btnVuelta);
            this.Controls.Add(this.btnViajes);
            this.Controls.Add(this.tcInternet);
            this.Name = "InicioVista";
            this.Text = "Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tcInternet.ResumeLayout(false);
            this.WebWhatsapp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wbWhatsapp)).EndInit();
            this.WebGoogleMaps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wbGoogleMaps)).EndInit();
            this.WebInternet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wbGoogle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAyuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecordatorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcInternet;
        private System.Windows.Forms.TabPage WebGoogleMaps;
        private System.Windows.Forms.TabPage WebInternet;
        private System.Windows.Forms.Button btnViajes;
        private System.Windows.Forms.Button btnVuelta;
        private System.Windows.Forms.Button btnOperadores;
        private System.Windows.Forms.Button btnMoviles;
        private System.Windows.Forms.Button btnBases;
        private System.Windows.Forms.PictureBox btnAyuda;
        private System.Windows.Forms.Button btnRecAgregar;
        private System.Windows.Forms.Button btnRecModificar;
        private System.Windows.Forms.Button btnRecEliminar;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvRecordatorio;
        private System.Windows.Forms.TabPage WebWhatsapp;
        private Microsoft.Web.WebView2.WinForms.WebView2 wbWhatsapp;
        private Microsoft.Web.WebView2.WinForms.WebView2 wbGoogleMaps;
        private Microsoft.Web.WebView2.WinForms.WebView2 wbGoogle;
    }
}