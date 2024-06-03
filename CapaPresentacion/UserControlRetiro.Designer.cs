namespace CapaPresentacion
{
    partial class UserControlRetiro
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelRetiro = new System.Windows.Forms.Label();
            this.textBoxRetiro = new System.Windows.Forms.TextBox();
            this.buttonAceptarRetiro = new System.Windows.Forms.Button();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.labelFondos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelRetiro
            // 
            this.labelRetiro.AutoSize = true;
            this.labelRetiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelRetiro.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRetiro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelRetiro.Location = new System.Drawing.Point(39, 103);
            this.labelRetiro.Name = "labelRetiro";
            this.labelRetiro.Size = new System.Drawing.Size(119, 34);
            this.labelRetiro.TabIndex = 0;
            this.labelRetiro.Text = "Retirar...";
            // 
            // textBoxRetiro
            // 
            this.textBoxRetiro.Location = new System.Drawing.Point(39, 171);
            this.textBoxRetiro.Name = "textBoxRetiro";
            this.textBoxRetiro.Size = new System.Drawing.Size(160, 20);
            this.textBoxRetiro.TabIndex = 1;
            this.textBoxRetiro.TextChanged += new System.EventHandler(this.textBoxRetiro_TextChanged);
            // 
            // buttonAceptarRetiro
            // 
            this.buttonAceptarRetiro.BackColor = System.Drawing.Color.Green;
            this.buttonAceptarRetiro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAceptarRetiro.FlatAppearance.BorderSize = 0;
            this.buttonAceptarRetiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAceptarRetiro.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAceptarRetiro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAceptarRetiro.Location = new System.Drawing.Point(39, 207);
            this.buttonAceptarRetiro.Name = "buttonAceptarRetiro";
            this.buttonAceptarRetiro.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptarRetiro.TabIndex = 2;
            this.buttonAceptarRetiro.Text = "Aceptar";
            this.buttonAceptarRetiro.UseVisualStyleBackColor = false;
            this.buttonAceptarRetiro.Click += new System.EventHandler(this.buttonAceptarRetiro_Click);
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.BackColor = System.Drawing.Color.Maroon;
            this.buttonBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBorrar.FlatAppearance.BorderSize = 0;
            this.buttonBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBorrar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBorrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBorrar.Location = new System.Drawing.Point(124, 207);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(75, 23);
            this.buttonBorrar.TabIndex = 3;
            this.buttonBorrar.Text = "Borrar";
            this.buttonBorrar.UseVisualStyleBackColor = false;
            this.buttonBorrar.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // labelFondos
            // 
            this.labelFondos.AutoSize = true;
            this.labelFondos.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFondos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelFondos.Location = new System.Drawing.Point(36, 153);
            this.labelFondos.Name = "labelFondos";
            this.labelFondos.Size = new System.Drawing.Size(53, 15);
            this.labelFondos.TabIndex = 4;
            this.labelFondos.Text = "Fondos:";
            // 
            // UserControlRetiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.labelFondos);
            this.Controls.Add(this.buttonBorrar);
            this.Controls.Add(this.buttonAceptarRetiro);
            this.Controls.Add(this.textBoxRetiro);
            this.Controls.Add(this.labelRetiro);
            this.Name = "UserControlRetiro";
            this.Size = new System.Drawing.Size(250, 350);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRetiro;
        private System.Windows.Forms.TextBox textBoxRetiro;
        private System.Windows.Forms.Button buttonAceptarRetiro;
        private System.Windows.Forms.Button buttonBorrar;
        private System.Windows.Forms.Label labelFondos;
    }
}
