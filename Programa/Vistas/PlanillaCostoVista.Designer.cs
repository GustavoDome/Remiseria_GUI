namespace Programa.Vistas
{
    partial class PlanillaCostoVista
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPrecioCuadraMandado = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrecioCuadraEspera = new System.Windows.Forms.Button();
            this.btnPrecioCuadra = new System.Windows.Forms.Button();
            this.dgvCuadras = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminarCiudad = new System.Windows.Forms.Button();
            this.btnModificarCiudad = new System.Windows.Forms.Button();
            this.btnAgregarCiudad = new System.Windows.Forms.Button();
            this.btnPrecioCiudadEspera = new System.Windows.Forms.Button();
            this.btnPrecioCiudad = new System.Windows.Forms.Button();
            this.dgvCiudad = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuadras)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudad)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 30);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(992, 484);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnPrecioCuadraMandado);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnPrecioCuadraEspera);
            this.tabPage1.Controls.Add(this.btnPrecioCuadra);
            this.tabPage1.Controls.Add(this.dgvCuadras);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(984, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dentro de la ciudad";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(426, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Monto por Mandado:";
            // 
            // btnPrecioCuadraMandado
            // 
            this.btnPrecioCuadraMandado.Location = new System.Drawing.Point(391, 386);
            this.btnPrecioCuadraMandado.Name = "btnPrecioCuadraMandado";
            this.btnPrecioCuadraMandado.Size = new System.Drawing.Size(215, 54);
            this.btnPrecioCuadraMandado.TabIndex = 6;
            this.btnPrecioCuadraMandado.Text = "Modificar Precio Mandado";
            this.btnPrecioCuadraMandado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrecioCuadraMandado.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(796, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Espera por 5m:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(38, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Monto de cuadras:";
            // 
            // btnPrecioCuadraEspera
            // 
            this.btnPrecioCuadraEspera.Location = new System.Drawing.Point(763, 386);
            this.btnPrecioCuadraEspera.Name = "btnPrecioCuadraEspera";
            this.btnPrecioCuadraEspera.Size = new System.Drawing.Size(215, 54);
            this.btnPrecioCuadraEspera.TabIndex = 3;
            this.btnPrecioCuadraEspera.Text = "Modificar Espera";
            this.btnPrecioCuadraEspera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrecioCuadraEspera.UseVisualStyleBackColor = true;
            // 
            // btnPrecioCuadra
            // 
            this.btnPrecioCuadra.Location = new System.Drawing.Point(6, 386);
            this.btnPrecioCuadra.Name = "btnPrecioCuadra";
            this.btnPrecioCuadra.Size = new System.Drawing.Size(218, 54);
            this.btnPrecioCuadra.TabIndex = 2;
            this.btnPrecioCuadra.Text = "Modificar Precio Cuadras";
            this.btnPrecioCuadra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrecioCuadra.UseVisualStyleBackColor = true;
            // 
            // dgvCuadras
            // 
            this.dgvCuadras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuadras.Location = new System.Drawing.Point(6, 6);
            this.dgvCuadras.Name = "dgvCuadras";
            this.dgvCuadras.Size = new System.Drawing.Size(972, 334);
            this.dgvCuadras.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnEliminarCiudad);
            this.tabPage2.Controls.Add(this.btnModificarCiudad);
            this.tabPage2.Controls.Add(this.btnAgregarCiudad);
            this.tabPage2.Controls.Add(this.btnPrecioCiudadEspera);
            this.tabPage2.Controls.Add(this.btnPrecioCiudad);
            this.tabPage2.Controls.Add(this.dgvCiudad);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(984, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fuera de la ciudad";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(634, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Espera fuera de la ciudad: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(76, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Costo del KM:";
            // 
            // btnEliminarCiudad
            // 
            this.btnEliminarCiudad.Location = new System.Drawing.Point(822, 385);
            this.btnEliminarCiudad.Name = "btnEliminarCiudad";
            this.btnEliminarCiudad.Size = new System.Drawing.Size(156, 55);
            this.btnEliminarCiudad.TabIndex = 6;
            this.btnEliminarCiudad.Text = "Eliminar Ciudad";
            this.btnEliminarCiudad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminarCiudad.UseVisualStyleBackColor = true;
            // 
            // btnModificarCiudad
            // 
            this.btnModificarCiudad.Location = new System.Drawing.Point(660, 385);
            this.btnModificarCiudad.Name = "btnModificarCiudad";
            this.btnModificarCiudad.Size = new System.Drawing.Size(156, 55);
            this.btnModificarCiudad.TabIndex = 5;
            this.btnModificarCiudad.Text = "Modificar Ciudad";
            this.btnModificarCiudad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificarCiudad.UseVisualStyleBackColor = true;
            // 
            // btnAgregarCiudad
            // 
            this.btnAgregarCiudad.Location = new System.Drawing.Point(498, 385);
            this.btnAgregarCiudad.Name = "btnAgregarCiudad";
            this.btnAgregarCiudad.Size = new System.Drawing.Size(156, 55);
            this.btnAgregarCiudad.TabIndex = 4;
            this.btnAgregarCiudad.Text = "Agregar Ciudad";
            this.btnAgregarCiudad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarCiudad.UseVisualStyleBackColor = true;
            // 
            // btnPrecioCiudadEspera
            // 
            this.btnPrecioCiudadEspera.Location = new System.Drawing.Point(234, 385);
            this.btnPrecioCiudadEspera.Name = "btnPrecioCiudadEspera";
            this.btnPrecioCiudadEspera.Size = new System.Drawing.Size(225, 55);
            this.btnPrecioCiudadEspera.TabIndex = 3;
            this.btnPrecioCiudadEspera.Text = "Modificar Espera";
            this.btnPrecioCiudadEspera.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPrecioCiudadEspera.UseVisualStyleBackColor = true;
            // 
            // btnPrecioCiudad
            // 
            this.btnPrecioCiudad.Location = new System.Drawing.Point(3, 385);
            this.btnPrecioCiudad.Name = "btnPrecioCiudad";
            this.btnPrecioCiudad.Size = new System.Drawing.Size(225, 55);
            this.btnPrecioCiudad.TabIndex = 2;
            this.btnPrecioCiudad.Text = "Modificar Kilometros";
            this.btnPrecioCiudad.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPrecioCiudad.UseVisualStyleBackColor = true;
            // 
            // dgvCiudad
            // 
            this.dgvCiudad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCiudad.Location = new System.Drawing.Point(6, 6);
            this.dgvCiudad.Name = "dgvCiudad";
            this.dgvCiudad.Size = new System.Drawing.Size(972, 334);
            this.dgvCiudad.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 498);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(992, 43);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // PlanillaCostoVista
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1016, 544);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.tabControl1);
            this.Name = "PlanillaCostoVista";
            this.Text = "Planilla de Costos";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuadras)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnPrecioCuadraEspera;
        private System.Windows.Forms.Button btnPrecioCuadra;
        private System.Windows.Forms.DataGridView dgvCuadras;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAgregarCiudad;
        private System.Windows.Forms.Button btnPrecioCiudadEspera;
        private System.Windows.Forms.Button btnPrecioCiudad;
        private System.Windows.Forms.DataGridView dgvCiudad;
        private System.Windows.Forms.Button btnModificarCiudad;
        private System.Windows.Forms.Button btnEliminarCiudad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPrecioCuadraMandado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}