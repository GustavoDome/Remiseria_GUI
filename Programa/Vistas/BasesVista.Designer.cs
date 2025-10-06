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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasesVista));
            this.dgvMoviles = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnComentar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.PBases = new System.Windows.Forms.Panel();
            this.TLPBases = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoviles)).BeginInit();
            this.PBases.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMoviles
            // 
            this.dgvMoviles.AllowUserToAddRows = false;
            this.dgvMoviles.AllowUserToResizeColumns = false;
            this.dgvMoviles.AllowUserToResizeRows = false;
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
            this.btnAgregar.Location = new System.Drawing.Point(12, 461);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(130, 37);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(418, 462);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 37);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnComentar
            // 
            this.btnComentar.Location = new System.Drawing.Point(282, 462);
            this.btnComentar.Name = "btnComentar";
            this.btnComentar.Size = new System.Drawing.Size(130, 37);
            this.btnComentar.TabIndex = 4;
            this.btnComentar.Text = "Comentar";
            this.btnComentar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(773, 462);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(130, 37);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(146, 461);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(130, 37);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // PBases
            // 
            this.PBases.Controls.Add(this.TLPBases);
            this.PBases.Location = new System.Drawing.Point(12, 43);
            this.PBases.Name = "PBases";
            this.PBases.Size = new System.Drawing.Size(891, 379);
            this.PBases.TabIndex = 7;
            // 
            // TLPBases
            // 
            this.TLPBases.ColumnCount = 2;
            this.TLPBases.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBases.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBases.Location = new System.Drawing.Point(0, 0);
            this.TLPBases.Name = "TLPBases";
            this.TLPBases.RowCount = 2;
            this.TLPBases.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBases.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBases.Size = new System.Drawing.Size(891, 379);
            this.TLPBases.TabIndex = 8;
            // 
            // BasesVista
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(915, 511);
            this.Controls.Add(this.PBases);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnComentar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvMoviles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BasesVista";
            this.Text = "Bases";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoviles)).EndInit();
            this.PBases.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMoviles;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnComentar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Panel PBases;
        private System.Windows.Forms.TableLayoutPanel TLPBases;
    }
}