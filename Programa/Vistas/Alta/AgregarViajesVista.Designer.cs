namespace Programa.Vistas.Alta
{
    partial class AgregarViajesVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarViajesVista));
            this.label3 = new System.Windows.Forms.Label();
            this.rbtnAfuera = new System.Windows.Forms.RadioButton();
            this.rdbtnDerivado = new System.Windows.Forms.RadioButton();
            this.rbtnDesignado = new System.Windows.Forms.RadioButton();
            this.rbtnOtro = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblComentario = new System.Windows.Forms.Label();
            this.rtbComentario = new System.Windows.Forms.RichTextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.clbMoviles = new System.Windows.Forms.CheckedListBox();
            this.gbTipoComentario = new System.Windows.Forms.GroupBox();
            this.gbTipoComentario.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(440, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Seleccione el tipo de comentario";
            // 
            // rbtnAfuera
            // 
            this.rbtnAfuera.AutoSize = true;
            this.rbtnAfuera.Location = new System.Drawing.Point(6, 19);
            this.rbtnAfuera.Name = "rbtnAfuera";
            this.rbtnAfuera.Size = new System.Drawing.Size(81, 17);
            this.rbtnAfuera.TabIndex = 8;
            this.rbtnAfuera.TabStop = true;
            this.rbtnAfuera.Text = "Viaje afuera";
            this.rbtnAfuera.UseVisualStyleBackColor = true;
            // 
            // rdbtnDerivado
            // 
            this.rdbtnDerivado.AutoSize = true;
            this.rdbtnDerivado.Location = new System.Drawing.Point(108, 19);
            this.rdbtnDerivado.Name = "rdbtnDerivado";
            this.rdbtnDerivado.Size = new System.Drawing.Size(94, 17);
            this.rdbtnDerivado.TabIndex = 9;
            this.rdbtnDerivado.TabStop = true;
            this.rdbtnDerivado.Text = "Viaje Derivado";
            this.rdbtnDerivado.UseVisualStyleBackColor = true;
            // 
            // rbtnDesignado
            // 
            this.rbtnDesignado.AutoSize = true;
            this.rbtnDesignado.Location = new System.Drawing.Point(224, 19);
            this.rbtnDesignado.Name = "rbtnDesignado";
            this.rbtnDesignado.Size = new System.Drawing.Size(102, 17);
            this.rbtnDesignado.TabIndex = 10;
            this.rbtnDesignado.TabStop = true;
            this.rbtnDesignado.Text = "Viaje Designado";
            this.rbtnDesignado.UseVisualStyleBackColor = true;
            // 
            // rbtnOtro
            // 
            this.rbtnOtro.AutoSize = true;
            this.rbtnOtro.Location = new System.Drawing.Point(345, 19);
            this.rbtnOtro.Name = "rbtnOtro";
            this.rbtnOtro.Size = new System.Drawing.Size(135, 17);
            this.rbtnOtro.TabIndex = 13;
            this.rbtnOtro.TabStop = true;
            this.rbtnOtro.Text = "Otro tipo de comentario";
            this.rbtnOtro.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ingrese la direccion del viaje";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(12, 38);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(306, 26);
            this.txtDireccion.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Seleccione los moviles que acudiran al viaje";
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComentario.Location = new System.Drawing.Point(595, 103);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(42, 20);
            this.lblComentario.TabIndex = 18;
            this.lblComentario.Text = "label";
            this.lblComentario.Visible = false;
            // 
            // rtbComentario
            // 
            this.rtbComentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbComentario.Location = new System.Drawing.Point(461, 141);
            this.rtbComentario.Name = "rtbComentario";
            this.rtbComentario.Size = new System.Drawing.Size(343, 96);
            this.rtbComentario.TabIndex = 19;
            this.rtbComentario.Text = "";
            this.rtbComentario.Visible = false;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(16, 307);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(151, 50);
            this.btnVolver.TabIndex = 20;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(444, 289);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(373, 68);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // clbMoviles
            // 
            this.clbMoviles.ColumnWidth = 130;
            this.clbMoviles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbMoviles.FormattingEnabled = true;
            this.clbMoviles.HorizontalExtent = 9;
            this.clbMoviles.HorizontalScrollbar = true;
            this.clbMoviles.Location = new System.Drawing.Point(16, 129);
            this.clbMoviles.MultiColumn = true;
            this.clbMoviles.Name = "clbMoviles";
            this.clbMoviles.Size = new System.Drawing.Size(369, 172);
            this.clbMoviles.TabIndex = 22;
            // 
            // gbTipoComentario
            // 
            this.gbTipoComentario.Controls.Add(this.rbtnAfuera);
            this.gbTipoComentario.Controls.Add(this.rdbtnDerivado);
            this.gbTipoComentario.Controls.Add(this.rbtnDesignado);
            this.gbTipoComentario.Controls.Add(this.rbtnOtro);
            this.gbTipoComentario.Location = new System.Drawing.Point(324, 32);
            this.gbTipoComentario.Name = "gbTipoComentario";
            this.gbTipoComentario.Size = new System.Drawing.Size(494, 57);
            this.gbTipoComentario.TabIndex = 23;
            this.gbTipoComentario.TabStop = false;
            // 
            // AgregarViajesVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 369);
            this.Controls.Add(this.gbTipoComentario);
            this.Controls.Add(this.clbMoviles);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.rtbComentario);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AgregarViajesVista";
            this.Text = "Agregar Viaje";
            this.gbTipoComentario.ResumeLayout(false);
            this.gbTipoComentario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtnAfuera;
        private System.Windows.Forms.RadioButton rdbtnDerivado;
        private System.Windows.Forms.RadioButton rbtnDesignado;
        private System.Windows.Forms.RadioButton rbtnOtro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.RichTextBox rtbComentario;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.CheckedListBox clbMoviles;
        private System.Windows.Forms.GroupBox gbTipoComentario;
    }
}