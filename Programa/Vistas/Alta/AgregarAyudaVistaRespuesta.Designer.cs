namespace Programa.Vistas.Alta
{
    partial class AgregarAyudaVistaRespuesta
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
            this.btnAgregarArchivo = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.ofdBuscarArchivo = new System.Windows.Forms.OpenFileDialog();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trbRespuesta = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnAgregarArchivo
            // 
            this.btnAgregarArchivo.Location = new System.Drawing.Point(124, 215);
            this.btnAgregarArchivo.Name = "btnAgregarArchivo";
            this.btnAgregarArchivo.Size = new System.Drawing.Size(225, 44);
            this.btnAgregarArchivo.TabIndex = 0;
            this.btnAgregarArchivo.Text = "Agregar Archivo";
            this.btnAgregarArchivo.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 215);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(106, 44);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // ofdBuscarArchivo
            // 
            this.ofdBuscarArchivo.FileName = "ofdBuscarArchivo";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(355, 215);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(106, 44);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ingrese la respuesta o el nombre de la respuesta";
            // 
            // trbRespuesta
            // 
            this.trbRespuesta.Location = new System.Drawing.Point(16, 32);
            this.trbRespuesta.Name = "trbRespuesta";
            this.trbRespuesta.Size = new System.Drawing.Size(445, 150);
            this.trbRespuesta.TabIndex = 5;
            this.trbRespuesta.Text = "";
            // 
            // AgregarAyudaVistaRespuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 271);
            this.Controls.Add(this.trbRespuesta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAgregarArchivo);
            this.Name = "AgregarAyudaVistaRespuesta";
            this.Text = "Agregar Respuesta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarArchivo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.OpenFileDialog ofdBuscarArchivo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox trbRespuesta;
    }
}