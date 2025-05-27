namespace Programa.Vistas
{
    partial class ConfiguracionesVista
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cbTipoFuente = new System.Windows.Forms.ComboBox();
            this.tbTamanoFuente = new System.Windows.Forms.TextBox();
            this.cbTema = new System.Windows.Forms.ComboBox();
            this.cbAlarma = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(396, 300);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(84, 44);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(172, 300);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(84, 44);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // cbTipoFuente
            // 
            this.cbTipoFuente.FormattingEnabled = true;
            this.cbTipoFuente.Location = new System.Drawing.Point(254, 36);
            this.cbTipoFuente.Name = "cbTipoFuente";
            this.cbTipoFuente.Size = new System.Drawing.Size(226, 21);
            this.cbTipoFuente.TabIndex = 2;
            // 
            // tbTamanoFuente
            // 
            this.tbTamanoFuente.Location = new System.Drawing.Point(254, 99);
            this.tbTamanoFuente.Name = "tbTamanoFuente";
            this.tbTamanoFuente.Size = new System.Drawing.Size(226, 20);
            this.tbTamanoFuente.TabIndex = 3;
            // 
            // cbTema
            // 
            this.cbTema.FormattingEnabled = true;
            this.cbTema.Location = new System.Drawing.Point(254, 162);
            this.cbTema.Name = "cbTema";
            this.cbTema.Size = new System.Drawing.Size(226, 21);
            this.cbTema.TabIndex = 4;
            // 
            // cbAlarma
            // 
            this.cbAlarma.FormattingEnabled = true;
            this.cbAlarma.Location = new System.Drawing.Point(254, 223);
            this.cbAlarma.Name = "cbAlarma";
            this.cbAlarma.Size = new System.Drawing.Size(226, 21);
            this.cbAlarma.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(30, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tipo de Fuente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(30, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tamaño de Fuente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(30, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tema del Sistema";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(30, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tipo de Alarma";
            // 
            // ConfiguracionesVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 356);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAlarma);
            this.Controls.Add(this.cbTema);
            this.Controls.Add(this.tbTamanoFuente);
            this.Controls.Add(this.cbTipoFuente);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnVolver);
            this.Name = "ConfiguracionesVista";
            this.Text = "Configuraciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cbTipoFuente;
        private System.Windows.Forms.TextBox tbTamanoFuente;
        private System.Windows.Forms.ComboBox cbTema;
        private System.Windows.Forms.ComboBox cbAlarma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}