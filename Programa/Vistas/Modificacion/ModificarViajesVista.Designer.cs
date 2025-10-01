namespace Programa.Vistas.Modificacion
{
    partial class ModificarViajesVista
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtViaje = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbMoviles = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtnAfuera = new System.Windows.Forms.RadioButton();
            this.rbtnDerivado = new System.Windows.Forms.RadioButton();
            this.rbtnDesignado = new System.Windows.Forms.RadioButton();
            this.rbtnOtro = new System.Windows.Forms.RadioButton();
            this.lblComentario = new System.Windows.Forms.Label();
            this.rtbComentarios = new System.Windows.Forms.RichTextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ingrese la direccion del viaje";
            // 
            // txtViaje
            // 
            this.txtViaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtViaje.Location = new System.Drawing.Point(12, 32);
            this.txtViaje.Name = "txtViaje";
            this.txtViaje.Size = new System.Drawing.Size(289, 26);
            this.txtViaje.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Seleccione los moviles que acudiran al viaje";
            // 
            // gbMoviles
            // 
            this.gbMoviles.Location = new System.Drawing.Point(12, 100);
            this.gbMoviles.Name = "gbMoviles";
            this.gbMoviles.Size = new System.Drawing.Size(386, 172);
            this.gbMoviles.TabIndex = 23;
            this.gbMoviles.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(441, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Seleccione el tipo de comentario";
            // 
            // rbtnAfuera
            // 
            this.rbtnAfuera.AutoSize = true;
            this.rbtnAfuera.Location = new System.Drawing.Point(339, 41);
            this.rbtnAfuera.Name = "rbtnAfuera";
            this.rbtnAfuera.Size = new System.Drawing.Size(81, 17);
            this.rbtnAfuera.TabIndex = 25;
            this.rbtnAfuera.TabStop = true;
            this.rbtnAfuera.Text = "Viaje afuera";
            this.rbtnAfuera.UseVisualStyleBackColor = true;
            // 
            // rbtnDerivado
            // 
            this.rbtnDerivado.AutoSize = true;
            this.rbtnDerivado.Location = new System.Drawing.Point(436, 41);
            this.rbtnDerivado.Name = "rbtnDerivado";
            this.rbtnDerivado.Size = new System.Drawing.Size(94, 17);
            this.rbtnDerivado.TabIndex = 26;
            this.rbtnDerivado.TabStop = true;
            this.rbtnDerivado.Text = "Viaje Derivado";
            this.rbtnDerivado.UseVisualStyleBackColor = true;
            // 
            // rbtnDesignado
            // 
            this.rbtnDesignado.AutoSize = true;
            this.rbtnDesignado.Location = new System.Drawing.Point(545, 41);
            this.rbtnDesignado.Name = "rbtnDesignado";
            this.rbtnDesignado.Size = new System.Drawing.Size(102, 17);
            this.rbtnDesignado.TabIndex = 27;
            this.rbtnDesignado.TabStop = true;
            this.rbtnDesignado.Text = "Viaje Designado";
            this.rbtnDesignado.UseVisualStyleBackColor = true;
            // 
            // rbtnOtro
            // 
            this.rbtnOtro.AutoSize = true;
            this.rbtnOtro.Location = new System.Drawing.Point(667, 41);
            this.rbtnOtro.Name = "rbtnOtro";
            this.rbtnOtro.Size = new System.Drawing.Size(135, 17);
            this.rbtnOtro.TabIndex = 28;
            this.rbtnOtro.TabStop = true;
            this.rbtnOtro.Text = "Otro tipo de comentario";
            this.rbtnOtro.UseVisualStyleBackColor = true;
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComentario.Location = new System.Drawing.Point(578, 77);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(42, 20);
            this.lblComentario.TabIndex = 29;
            this.lblComentario.Text = "label";
            this.lblComentario.Visible = false;
            // 
            // rtbComentarios
            // 
            this.rtbComentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbComentarios.Location = new System.Drawing.Point(445, 111);
            this.rtbComentarios.Name = "rtbComentarios";
            this.rtbComentarios.Size = new System.Drawing.Size(343, 112);
            this.rtbComentarios.TabIndex = 30;
            this.rtbComentarios.Text = "";
            this.rtbComentarios.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(429, 278);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(373, 68);
            this.btnAgregar.TabIndex = 31;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 294);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(133, 52);
            this.btnVolver.TabIndex = 32;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // ModificarViajesVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 358);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.rtbComentarios);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.rbtnOtro);
            this.Controls.Add(this.rbtnDesignado);
            this.Controls.Add(this.rbtnDerivado);
            this.Controls.Add(this.rbtnAfuera);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbMoviles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtViaje);
            this.Controls.Add(this.label1);
            this.Name = "ModificarViajesVista";
            this.Text = "Modificar Viaje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtViaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbMoviles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtnAfuera;
        private System.Windows.Forms.RadioButton rbtnDerivado;
        private System.Windows.Forms.RadioButton rbtnDesignado;
        private System.Windows.Forms.RadioButton rbtnOtro;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.RichTextBox rtbComentarios;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnVolver;
    }
}