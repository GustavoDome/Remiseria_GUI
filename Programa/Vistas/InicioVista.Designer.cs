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
            this.wbWhatsapp = new System.Windows.Forms.WebBrowser();
            this.WebGoogleMaps = new System.Windows.Forms.TabPage();
            this.wbGoogleMaps = new System.Windows.Forms.WebBrowser();
            this.WebInternet = new System.Windows.Forms.TabPage();
            this.wbInternet = new System.Windows.Forms.WebBrowser();
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
            this.WebGoogleMaps.SuspendLayout();
            this.WebInternet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAyuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecordatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // tcInternet
            // 
            this.tcInternet.Controls.Add(this.WebWhatsapp);
            this.tcInternet.Controls.Add(this.WebGoogleMaps);
            this.tcInternet.Controls.Add(this.WebInternet);
            this.tcInternet.Location = new System.Drawing.Point(12, 12);
            this.tcInternet.Name = "tcInternet";
            this.tcInternet.SelectedIndex = 0;
            this.tcInternet.Size = new System.Drawing.Size(429, 486);
            this.tcInternet.TabIndex = 0;
            // 
            // WebWhatsapp
            // 
            this.WebWhatsapp.Controls.Add(this.wbWhatsapp);
            this.WebWhatsapp.Location = new System.Drawing.Point(4, 22);
            this.WebWhatsapp.Name = "WebWhatsapp";
            this.WebWhatsapp.Padding = new System.Windows.Forms.Padding(3);
            this.WebWhatsapp.Size = new System.Drawing.Size(421, 460);
            this.WebWhatsapp.TabIndex = 0;
            this.WebWhatsapp.Text = "Whatsapp";
            this.WebWhatsapp.UseVisualStyleBackColor = true;
            // 
            // wbWhatsapp
            // 
            this.wbWhatsapp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbWhatsapp.Location = new System.Drawing.Point(3, 3);
            this.wbWhatsapp.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbWhatsapp.Name = "wbWhatsapp";
            this.wbWhatsapp.Size = new System.Drawing.Size(415, 454);
            this.wbWhatsapp.TabIndex = 0;
            // 
            // WebGoogleMaps
            // 
            this.WebGoogleMaps.Controls.Add(this.wbGoogleMaps);
            this.WebGoogleMaps.Location = new System.Drawing.Point(4, 22);
            this.WebGoogleMaps.Name = "WebGoogleMaps";
            this.WebGoogleMaps.Padding = new System.Windows.Forms.Padding(3);
            this.WebGoogleMaps.Size = new System.Drawing.Size(421, 460);
            this.WebGoogleMaps.TabIndex = 1;
            this.WebGoogleMaps.Text = "Google Maps";
            this.WebGoogleMaps.UseVisualStyleBackColor = true;
            // 
            // wbGoogleMaps
            // 
            this.wbGoogleMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbGoogleMaps.Location = new System.Drawing.Point(3, 3);
            this.wbGoogleMaps.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbGoogleMaps.Name = "wbGoogleMaps";
            this.wbGoogleMaps.Size = new System.Drawing.Size(415, 454);
            this.wbGoogleMaps.TabIndex = 0;
            // 
            // WebInternet
            // 
            this.WebInternet.Controls.Add(this.wbInternet);
            this.WebInternet.Location = new System.Drawing.Point(4, 22);
            this.WebInternet.Name = "WebInternet";
            this.WebInternet.Size = new System.Drawing.Size(421, 460);
            this.WebInternet.TabIndex = 2;
            this.WebInternet.Text = "Internet";
            this.WebInternet.UseVisualStyleBackColor = true;
            // 
            // wbInternet
            // 
            this.wbInternet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbInternet.Location = new System.Drawing.Point(0, 0);
            this.wbInternet.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbInternet.Name = "wbInternet";
            this.wbInternet.Size = new System.Drawing.Size(421, 460);
            this.wbInternet.TabIndex = 0;
            // 
            // btnViajes
            // 
            this.btnViajes.Location = new System.Drawing.Point(607, 12);
            this.btnViajes.Name = "btnViajes";
            this.btnViajes.Size = new System.Drawing.Size(76, 38);
            this.btnViajes.TabIndex = 1;
            this.btnViajes.Text = "Viajes";
            this.btnViajes.UseVisualStyleBackColor = true;
            // 
            // btnVuelta
            // 
            this.btnVuelta.Location = new System.Drawing.Point(689, 12);
            this.btnVuelta.Name = "btnVuelta";
            this.btnVuelta.Size = new System.Drawing.Size(76, 38);
            this.btnVuelta.TabIndex = 2;
            this.btnVuelta.Text = "Vuelta";
            this.btnVuelta.UseVisualStyleBackColor = true;
            // 
            // btnOperadores
            // 
            this.btnOperadores.Location = new System.Drawing.Point(443, 12);
            this.btnOperadores.Name = "btnOperadores";
            this.btnOperadores.Size = new System.Drawing.Size(76, 38);
            this.btnOperadores.TabIndex = 3;
            this.btnOperadores.Text = "Operadores";
            this.btnOperadores.UseVisualStyleBackColor = true;
            // 
            // btnMoviles
            // 
            this.btnMoviles.Location = new System.Drawing.Point(525, 12);
            this.btnMoviles.Name = "btnMoviles";
            this.btnMoviles.Size = new System.Drawing.Size(76, 38);
            this.btnMoviles.TabIndex = 4;
            this.btnMoviles.Text = "Moviles";
            this.btnMoviles.UseVisualStyleBackColor = true;
            // 
            // btnBases
            // 
            this.btnBases.Location = new System.Drawing.Point(771, 12);
            this.btnBases.Name = "btnBases";
            this.btnBases.Size = new System.Drawing.Size(76, 38);
            this.btnBases.TabIndex = 5;
            this.btnBases.Text = "Bases";
            this.btnBases.UseVisualStyleBackColor = true;
            // 
            // btnAyuda
            // 
            this.btnAyuda.Location = new System.Drawing.Point(839, 352);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(82, 62);
            this.btnAyuda.TabIndex = 6;
            this.btnAyuda.TabStop = false;
            // 
            // btnRecAgregar
            // 
            this.btnRecAgregar.Location = new System.Drawing.Point(585, 365);
            this.btnRecAgregar.Name = "btnRecAgregar";
            this.btnRecAgregar.Size = new System.Drawing.Size(76, 24);
            this.btnRecAgregar.TabIndex = 8;
            this.btnRecAgregar.Text = "Agregar";
            this.btnRecAgregar.UseVisualStyleBackColor = true;
            // 
            // btnRecModificar
            // 
            this.btnRecModificar.Location = new System.Drawing.Point(667, 365);
            this.btnRecModificar.Name = "btnRecModificar";
            this.btnRecModificar.Size = new System.Drawing.Size(76, 24);
            this.btnRecModificar.TabIndex = 9;
            this.btnRecModificar.Text = "Modificar";
            this.btnRecModificar.UseVisualStyleBackColor = true;
            // 
            // btnRecEliminar
            // 
            this.btnRecEliminar.Location = new System.Drawing.Point(749, 365);
            this.btnRecEliminar.Name = "btnRecEliminar";
            this.btnRecEliminar.Size = new System.Drawing.Size(76, 24);
            this.btnRecEliminar.TabIndex = 10;
            this.btnRecEliminar.Text = "Eliminar";
            this.btnRecEliminar.UseVisualStyleBackColor = true;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Location = new System.Drawing.Point(839, 442);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(82, 49);
            this.btnConfiguracion.TabIndex = 11;
            this.btnConfiguracion.Text = "Configuracion";
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(447, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Recordatorio";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(853, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(76, 38);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // dgvRecordatorio
            // 
            this.dgvRecordatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecordatorio.Location = new System.Drawing.Point(443, 389);
            this.dgvRecordatorio.Name = "dgvRecordatorio";
            this.dgvRecordatorio.Size = new System.Drawing.Size(382, 109);
            this.dgvRecordatorio.TabIndex = 14;
            // 
            // InicioVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 510);
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
            this.tcInternet.ResumeLayout(false);
            this.WebWhatsapp.ResumeLayout(false);
            this.WebGoogleMaps.ResumeLayout(false);
            this.WebInternet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAyuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecordatorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcInternet;
        private System.Windows.Forms.TabPage WebWhatsapp;
        private System.Windows.Forms.TabPage WebGoogleMaps;
        private System.Windows.Forms.TabPage WebInternet;
        private System.Windows.Forms.WebBrowser wbWhatsapp;
        private System.Windows.Forms.WebBrowser wbGoogleMaps;
        private System.Windows.Forms.WebBrowser wbInternet;
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
    }
}