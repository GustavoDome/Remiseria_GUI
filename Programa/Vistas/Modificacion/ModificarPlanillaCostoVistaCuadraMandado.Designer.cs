namespace Programa.Vistas.Modificacion
{
    partial class ModificarPlanillaCostoVistaCuadraMandado
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
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtCuadrasMandado = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.Location = new System.Drawing.Point(88, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Coloque el monto del mandado";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(272, 150);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(117, 42);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // txtCuadrasMandado
            // 
            this.txtCuadrasMandado.Location = new System.Drawing.Point(12, 83);
            this.txtCuadrasMandado.Name = "txtCuadrasMandado";
            this.txtCuadrasMandado.Size = new System.Drawing.Size(377, 20);
            this.txtCuadrasMandado.TabIndex = 2;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 150);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(117, 42);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // ModificarPlanillaCostoVistaCuadraMandado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 204);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtCuadrasMandado);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label1);
            this.Name = "ModificarPlanillaCostoVistaCuadraMandado";
            this.Text = "Modificar Mandado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtCuadrasMandado;
        private System.Windows.Forms.Button btnVolver;
    }
}