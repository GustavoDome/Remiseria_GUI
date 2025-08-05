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
            this.btnPrecioCuadraEspera = new System.Windows.Forms.Button();
            this.btnPrecioCuadra = new System.Windows.Forms.Button();
            this.dgvCuadras = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEliminarCiudad = new System.Windows.Forms.Button();
            this.btnModificarCiudad = new System.Windows.Forms.Button();
            this.btnAgregarCiudad = new System.Windows.Forms.Button();
            this.btnPrecioCiudadEspera = new System.Windows.Forms.Button();
            this.btnPrecioCiudad = new System.Windows.Forms.Button();
            this.dgvCiudad = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrecioCuadraMandado = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
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
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(842, 465);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(834, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dentro de la ciudad";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnPrecioCuadraEspera
            // 
            this.btnPrecioCuadraEspera.Location = new System.Drawing.Point(692, 403);
            this.btnPrecioCuadraEspera.Name = "btnPrecioCuadraEspera";
            this.btnPrecioCuadraEspera.Size = new System.Drawing.Size(126, 30);
            this.btnPrecioCuadraEspera.TabIndex = 3;
            this.btnPrecioCuadraEspera.Text = "Modificar Espera";
            this.btnPrecioCuadraEspera.UseVisualStyleBackColor = true;
            // 
            // btnPrecioCuadra
            // 
            this.btnPrecioCuadra.Location = new System.Drawing.Point(6, 403);
            this.btnPrecioCuadra.Name = "btnPrecioCuadra";
            this.btnPrecioCuadra.Size = new System.Drawing.Size(140, 30);
            this.btnPrecioCuadra.TabIndex = 2;
            this.btnPrecioCuadra.Text = "Modificar Precio Cuadras";
            this.btnPrecioCuadra.UseVisualStyleBackColor = true;
            // 
            // dgvCuadras
            // 
            this.dgvCuadras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuadras.Location = new System.Drawing.Point(6, 6);
            this.dgvCuadras.Name = "dgvCuadras";
            this.dgvCuadras.Size = new System.Drawing.Size(822, 334);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(834, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fuera de la ciudad";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEliminarCiudad
            // 
            this.btnEliminarCiudad.Location = new System.Drawing.Point(722, 403);
            this.btnEliminarCiudad.Name = "btnEliminarCiudad";
            this.btnEliminarCiudad.Size = new System.Drawing.Size(106, 30);
            this.btnEliminarCiudad.TabIndex = 6;
            this.btnEliminarCiudad.Text = "Eliminar Ciudad";
            this.btnEliminarCiudad.UseVisualStyleBackColor = true;
            // 
            // btnModificarCiudad
            // 
            this.btnModificarCiudad.Location = new System.Drawing.Point(610, 403);
            this.btnModificarCiudad.Name = "btnModificarCiudad";
            this.btnModificarCiudad.Size = new System.Drawing.Size(106, 30);
            this.btnModificarCiudad.TabIndex = 5;
            this.btnModificarCiudad.Text = "Modificar Ciudad";
            this.btnModificarCiudad.UseVisualStyleBackColor = true;
            // 
            // btnAgregarCiudad
            // 
            this.btnAgregarCiudad.Location = new System.Drawing.Point(498, 403);
            this.btnAgregarCiudad.Name = "btnAgregarCiudad";
            this.btnAgregarCiudad.Size = new System.Drawing.Size(106, 30);
            this.btnAgregarCiudad.TabIndex = 4;
            this.btnAgregarCiudad.Text = "Agregar Ciudad";
            this.btnAgregarCiudad.UseVisualStyleBackColor = true;
            // 
            // btnPrecioCiudadEspera
            // 
            this.btnPrecioCiudadEspera.Location = new System.Drawing.Point(152, 403);
            this.btnPrecioCiudadEspera.Name = "btnPrecioCiudadEspera";
            this.btnPrecioCiudadEspera.Size = new System.Drawing.Size(106, 30);
            this.btnPrecioCiudadEspera.TabIndex = 3;
            this.btnPrecioCiudadEspera.Text = "Modificar Espera";
            this.btnPrecioCiudadEspera.UseVisualStyleBackColor = true;
            // 
            // btnPrecioCiudad
            // 
            this.btnPrecioCiudad.Location = new System.Drawing.Point(6, 403);
            this.btnPrecioCiudad.Name = "btnPrecioCiudad";
            this.btnPrecioCiudad.Size = new System.Drawing.Size(128, 30);
            this.btnPrecioCiudad.TabIndex = 2;
            this.btnPrecioCiudad.Text = "Modificar Kilometros";
            this.btnPrecioCiudad.UseVisualStyleBackColor = true;
            // 
            // dgvCiudad
            // 
            this.dgvCiudad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCiudad.Location = new System.Drawing.Point(6, 6);
            this.dgvCiudad.Name = "dgvCiudad";
            this.dgvCiudad.Size = new System.Drawing.Size(822, 334);
            this.dgvCiudad.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 483);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(842, 30);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(44, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Costo del KM:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(550, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Espera fuera de la ciudad: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(6, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Monto de cuadras:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(689, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Espera por 5m:";
            // 
            // btnPrecioCuadraMandado
            // 
            this.btnPrecioCuadraMandado.Location = new System.Drawing.Point(354, 403);
            this.btnPrecioCuadraMandado.Name = "btnPrecioCuadraMandado";
            this.btnPrecioCuadraMandado.Size = new System.Drawing.Size(144, 30);
            this.btnPrecioCuadraMandado.TabIndex = 6;
            this.btnPrecioCuadraMandado.Text = "Modificar Precio Mandado";
            this.btnPrecioCuadraMandado.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(351, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Monto por Mandado:";
            // 
            // PlanillaCostoVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 525);
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