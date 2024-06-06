namespace CapaPresentacion
{
    partial class UserControlReserva
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
            this.labelFondos = new System.Windows.Forms.Label();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.buttonAceptarReserva = new System.Windows.Forms.Button();
            this.textBoxReserva = new System.Windows.Forms.TextBox();
            this.labelReserva = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFondos
            // 
            this.labelFondos.AutoSize = true;
            this.labelFondos.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFondos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelFondos.Location = new System.Drawing.Point(33, 179);
            this.labelFondos.Name = "labelFondos";
            this.labelFondos.Size = new System.Drawing.Size(53, 15);
            this.labelFondos.TabIndex = 9;
            this.labelFondos.Text = "Fondos:";
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.BackColor = System.Drawing.Color.Maroon;
            this.buttonBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBorrar.FlatAppearance.BorderSize = 0;
            this.buttonBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBorrar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBorrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBorrar.Location = new System.Drawing.Point(121, 242);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(75, 23);
            this.buttonBorrar.TabIndex = 8;
            this.buttonBorrar.Text = "Borrar";
            this.buttonBorrar.UseVisualStyleBackColor = false;
            this.buttonBorrar.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // buttonAceptarReserva
            // 
            this.buttonAceptarReserva.BackColor = System.Drawing.Color.Green;
            this.buttonAceptarReserva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAceptarReserva.FlatAppearance.BorderSize = 0;
            this.buttonAceptarReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAceptarReserva.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAceptarReserva.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAceptarReserva.Location = new System.Drawing.Point(36, 242);
            this.buttonAceptarReserva.Name = "buttonAceptarReserva";
            this.buttonAceptarReserva.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptarReserva.TabIndex = 7;
            this.buttonAceptarReserva.Text = "Aceptar";
            this.buttonAceptarReserva.UseVisualStyleBackColor = false;
            this.buttonAceptarReserva.Click += new System.EventHandler(this.buttonAceptarReserva_Click);
            // 
            // textBoxReserva
            // 
            this.textBoxReserva.Location = new System.Drawing.Point(36, 206);
            this.textBoxReserva.Name = "textBoxReserva";
            this.textBoxReserva.Size = new System.Drawing.Size(160, 20);
            this.textBoxReserva.TabIndex = 6;
            this.textBoxReserva.TextChanged += new System.EventHandler(this.textBoxReserva_TextChanged);
            // 
            // labelReserva
            // 
            this.labelReserva.AutoSize = true;
            this.labelReserva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelReserva.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReserva.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelReserva.Location = new System.Drawing.Point(36, 65);
            this.labelReserva.Name = "labelReserva";
            this.labelReserva.Size = new System.Drawing.Size(140, 34);
            this.labelReserva.TabIndex = 5;
            this.labelReserva.Text = "Reservar...";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(36, 144);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(160, 20);
            this.textBoxNombre.TabIndex = 10;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNombre.Location = new System.Drawing.Point(33, 118);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(126, 14);
            this.labelNombre.TabIndex = 11;
            this.labelNombre.Text = "Nombre de la reserva";
            // 
            // UserControlReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelFondos);
            this.Controls.Add(this.buttonBorrar);
            this.Controls.Add(this.buttonAceptarReserva);
            this.Controls.Add(this.textBoxReserva);
            this.Controls.Add(this.labelReserva);
            this.Name = "UserControlReserva";
            this.Size = new System.Drawing.Size(234, 334);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFondos;
        private System.Windows.Forms.Button buttonBorrar;
        private System.Windows.Forms.Button buttonAceptarReserva;
        private System.Windows.Forms.TextBox textBoxReserva;
        private System.Windows.Forms.Label labelReserva;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelNombre;
    }
}
