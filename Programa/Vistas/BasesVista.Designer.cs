namespace Programa.Vistas
{
    partial class BasesVista
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
            this.dgvBases = new System.Windows.Forms.DataGridView();
            this.dgvMoviles = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnComentar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoviles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBases
            // 
            this.dgvBases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBases.Location = new System.Drawing.Point(12, 43);
            this.dgvBases.Name = "dgvBases";
            this.dgvBases.Size = new System.Drawing.Size(891, 412);
            this.dgvBases.TabIndex = 0;
            // 
            // dgvMoviles
            // 
            this.dgvMoviles.AllowUserToAddRows = false;
            this.dgvMoviles.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvMoviles.ColumnHeadersHeight = 50;
            this.dgvMoviles.ColumnHeadersVisible = false;
            this.dgvMoviles.EnableHeadersVisualStyles = false;
            this.dgvMoviles.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dgvMoviles.Location = new System.Drawing.Point(12, 12);
            this.dgvMoviles.MultiSelect = false;
            this.dgvMoviles.Name = "dgvMoviles";
            this.dgvMoviles.RowHeadersVisible = false;
            this.dgvMoviles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvMoviles.Size = new System.Drawing.Size(891, 25);
            this.dgvMoviles.TabIndex = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 462);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 37);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(255, 462);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 37);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnComentar
            // 
            this.btnComentar.Location = new System.Drawing.Point(174, 461);
            this.btnComentar.Name = "btnComentar";
            this.btnComentar.Size = new System.Drawing.Size(75, 37);
            this.btnComentar.TabIndex = 4;
            this.btnComentar.Text = "Comentar";
            this.btnComentar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(828, 462);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 37);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(93, 462);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 37);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // BasesVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 511);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnComentar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvMoviles);
            this.Controls.Add(this.dgvBases);
            this.Name = "BasesVista";
            this.Text = "Bases";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoviles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBases;
        private System.Windows.Forms.DataGridView dgvMoviles;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnComentar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnModificar;
    }
}