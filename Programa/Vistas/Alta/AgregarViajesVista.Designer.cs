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
            this.rbtnAfuera.Location = new System.Drawing.Point(357, 38);
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
            this.rdbtnDerivado.Location = new System.Drawing.Point(444, 38);
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
            this.rbtnDesignado.Location = new System.Drawing.Point(544, 38);
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
            this.rbtnOtro.Location = new System.Drawing.Point(652, 38);
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
            this.label1.Location = new System.Drawing.Point(12, 9);
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
            this.txtDireccion.Size = new System.Drawing.Size(289, 26);
            this.txtDireccion.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Seleccione los moviles que acudiran al viaje";
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComentario.Location = new System.Drawing.Point(496, 90);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(42, 20);
            this.lblComentario.TabIndex = 18;
            this.lblComentario.Text = "label";
            this.lblComentario.Visible = false;
            // 
            // rtbComentario
            // 
            this.rtbComentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbComentario.Location = new System.Drawing.Point(444, 122);
            this.rtbComentario.Name = "rtbComentario";
            this.rtbComentario.Size = new System.Drawing.Size(343, 96);
            this.rtbComentario.TabIndex = 19;
            this.rtbComentario.Text = "";
            this.rtbComentario.Visible = false;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(16, 296);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 50);
            this.btnVolver.TabIndex = 20;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(415, 278);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(373, 68);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // clbMoviles
            // 
            this.clbMoviles.ColumnWidth = 80;
            this.clbMoviles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbMoviles.FormattingEnabled = true;
            this.clbMoviles.HorizontalExtent = 9;
            this.clbMoviles.HorizontalScrollbar = true;
            this.clbMoviles.Location = new System.Drawing.Point(16, 113);
            this.clbMoviles.MultiColumn = true;
            this.clbMoviles.Name = "clbMoviles";
            this.clbMoviles.Size = new System.Drawing.Size(369, 172);
            this.clbMoviles.TabIndex = 22;
            // 
            // AgregarViajesVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 358);
            this.Controls.Add(this.clbMoviles);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.rtbComentario);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtnOtro);
            this.Controls.Add(this.rbtnDesignado);
            this.Controls.Add(this.rdbtnDerivado);
            this.Controls.Add(this.rbtnAfuera);
            this.Controls.Add(this.label3);
            this.Name = "AgregarViajesVista";
            this.Text = "Agregar Viaje";
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
    }
}