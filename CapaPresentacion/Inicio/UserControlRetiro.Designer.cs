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
            this.textBoxRetiro = new System.Windows.Forms.TextBox();
            this.buttonAceptarRetiro = new System.Windows.Forms.Button();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.labelFondos = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelRetiro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxRetiro
            // 
            this.textBoxRetiro.Location = new System.Drawing.Point(272, 152);
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
            this.buttonAceptarRetiro.Location = new System.Drawing.Point(272, 188);
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
            this.buttonBorrar.Location = new System.Drawing.Point(357, 188);
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
            this.labelFondos.Location = new System.Drawing.Point(269, 134);
            this.labelFondos.Name = "labelFondos";
            this.labelFondos.Size = new System.Drawing.Size(53, 15);
            this.labelFondos.TabIndex = 4;
            this.labelFondos.Text = "Fondos:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.retiro;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 231);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelRetiro);
            this.panel1.Location = new System.Drawing.Point(117, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 74);
            this.panel1.TabIndex = 14;
            // 
            // labelRetiro
            // 
            this.labelRetiro.AutoSize = true;
            this.labelRetiro.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRetiro.ForeColor = System.Drawing.Color.White;
            this.labelRetiro.Location = new System.Drawing.Point(59, 21);
            this.labelRetiro.Name = "labelRetiro";
            this.labelRetiro.Size = new System.Drawing.Size(117, 32);
            this.labelRetiro.TabIndex = 5;
            this.labelRetiro.Text = "Retirar...";
            // 
            // UserControlRetiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelFondos);
            this.Controls.Add(this.buttonBorrar);
            this.Controls.Add(this.buttonAceptarRetiro);
            this.Controls.Add(this.textBoxRetiro);
            this.Name = "UserControlRetiro";
            this.Size = new System.Drawing.Size(530, 258);
            this.Load += new System.EventHandler(this.UserControlRetiro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxRetiro;
        private System.Windows.Forms.Button buttonAceptarRetiro;
        private System.Windows.Forms.Button buttonBorrar;
        private System.Windows.Forms.Label labelFondos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelRetiro;
    }
}
