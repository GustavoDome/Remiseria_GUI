namespace Programa.Vistas
{
    partial class VueltaVista
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
            this.dgvVuelta = new System.Windows.Forms.DataGridView();
            this.btnAgregarMovil = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnViajes = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminarMovil = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnAgregarVuelta = new System.Windows.Forms.Button();
            this.btnEliminarVuelta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuelta)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVuelta
            // 
            this.dgvVuelta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVuelta.Location = new System.Drawing.Point(12, 36);
            this.dgvVuelta.Name = "dgvVuelta";
            this.dgvVuelta.Size = new System.Drawing.Size(1302, 409);
            this.dgvVuelta.TabIndex = 0;
            // 
            // btnAgregarMovil
            // 
            this.btnAgregarMovil.Location = new System.Drawing.Point(12, 537);
            this.btnAgregarMovil.Name = "btnAgregarMovil";
            this.btnAgregarMovil.Size = new System.Drawing.Size(180, 37);
            this.btnAgregarMovil.TabIndex = 1;
            this.btnAgregarMovil.Text = "Agregar movil";
            this.btnAgregarMovil.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(1184, 537);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(130, 37);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnViajes
            // 
            this.btnViajes.Location = new System.Drawing.Point(1048, 537);
            this.btnViajes.Name = "btnViajes";
            this.btnViajes.Size = new System.Drawing.Size(130, 37);
            this.btnViajes.TabIndex = 3;
            this.btnViajes.Text = "Viajes";
            this.btnViajes.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(200, 496);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(180, 37);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar vuelta";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminarMovil
            // 
            this.btnEliminarMovil.Location = new System.Drawing.Point(384, 537);
            this.btnEliminarMovil.Name = "btnEliminarMovil";
            this.btnEliminarMovil.Size = new System.Drawing.Size(180, 37);
            this.btnEliminarMovil.TabIndex = 5;
            this.btnEliminarMovil.Text = "Eliminar movil";
            this.btnEliminarMovil.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(643, 505);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(130, 37);
            this.btnAnterior.TabIndex = 6;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(818, 505);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(130, 37);
            this.btnSiguiente.TabIndex = 7;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(1302, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // btnAgregarVuelta
            // 
            this.btnAgregarVuelta.Location = new System.Drawing.Point(12, 451);
            this.btnAgregarVuelta.Name = "btnAgregarVuelta";
            this.btnAgregarVuelta.Size = new System.Drawing.Size(180, 37);
            this.btnAgregarVuelta.TabIndex = 9;
            this.btnAgregarVuelta.Text = "Agregar vuelta";
            this.btnAgregarVuelta.UseVisualStyleBackColor = true;
            // 
            // btnEliminarVuelta
            // 
            this.btnEliminarVuelta.Location = new System.Drawing.Point(384, 451);
            this.btnEliminarVuelta.Name = "btnEliminarVuelta";
            this.btnEliminarVuelta.Size = new System.Drawing.Size(180, 37);
            this.btnEliminarVuelta.TabIndex = 10;
            this.btnEliminarVuelta.Text = "Eliminar Vuelta";
            this.btnEliminarVuelta.UseVisualStyleBackColor = true;
            // 
            // VueltaVista
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1326, 586);
            this.Controls.Add(this.btnEliminarVuelta);
            this.Controls.Add(this.btnAgregarVuelta);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnEliminarMovil);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnViajes);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAgregarMovil);
            this.Controls.Add(this.dgvVuelta);
            this.Name = "VueltaVista";
            this.Text = "Vuelta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuelta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVuelta;
        private System.Windows.Forms.Button btnAgregarMovil;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnViajes;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminarMovil;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnAgregarVuelta;
        private System.Windows.Forms.Button btnEliminarVuelta;
    }
}