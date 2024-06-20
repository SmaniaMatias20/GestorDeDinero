namespace CapaPresentacion.Ajustes
{
    partial class UserControlAjustes
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
            this.groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.labelRepetirClave = new System.Windows.Forms.Label();
            this.labelClave = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonOcultar = new System.Windows.Forms.Button();
            this.textBoxClave2 = new System.Windows.Forms.TextBox();
            this.textBoxClave = new System.Windows.Forms.TextBox();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.groupBoxDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDatos
            // 
            this.groupBoxDatos.Controls.Add(this.buttonEliminar);
            this.groupBoxDatos.Controls.Add(this.buttonAceptar);
            this.groupBoxDatos.Controls.Add(this.labelRepetirClave);
            this.groupBoxDatos.Controls.Add(this.labelClave);
            this.groupBoxDatos.Controls.Add(this.labelUsuario);
            this.groupBoxDatos.Controls.Add(this.buttonModificar);
            this.groupBoxDatos.Controls.Add(this.buttonOcultar);
            this.groupBoxDatos.Controls.Add(this.textBoxClave2);
            this.groupBoxDatos.Controls.Add(this.textBoxClave);
            this.groupBoxDatos.Controls.Add(this.textBoxUsuario);
            this.groupBoxDatos.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDatos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxDatos.Location = new System.Drawing.Point(91, 80);
            this.groupBoxDatos.Name = "groupBoxDatos";
            this.groupBoxDatos.Size = new System.Drawing.Size(366, 307);
            this.groupBoxDatos.TabIndex = 0;
            this.groupBoxDatos.TabStop = false;
            this.groupBoxDatos.Text = "Datos del usuario";
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.BackColor = System.Drawing.Color.Maroon;
            this.buttonEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEliminar.FlatAppearance.BorderSize = 0;
            this.buttonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonEliminar.Location = new System.Drawing.Point(241, 266);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(119, 34);
            this.buttonEliminar.TabIndex = 9;
            this.buttonEliminar.Text = "Eliminar usuario";
            this.buttonEliminar.UseVisualStyleBackColor = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.BackColor = System.Drawing.Color.Green;
            this.buttonAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAceptar.Enabled = false;
            this.buttonAceptar.FlatAppearance.BorderSize = 0;
            this.buttonAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAceptar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAceptar.Location = new System.Drawing.Point(258, 116);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(88, 34);
            this.buttonAceptar.TabIndex = 8;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = false;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // labelRepetirClave
            // 
            this.labelRepetirClave.AutoSize = true;
            this.labelRepetirClave.Location = new System.Drawing.Point(18, 199);
            this.labelRepetirClave.Name = "labelRepetirClave";
            this.labelRepetirClave.Size = new System.Drawing.Size(87, 15);
            this.labelRepetirClave.TabIndex = 7;
            this.labelRepetirClave.Text = "Repetir clave";
            // 
            // labelClave
            // 
            this.labelClave.AutoSize = true;
            this.labelClave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelClave.Location = new System.Drawing.Point(18, 134);
            this.labelClave.Name = "labelClave";
            this.labelClave.Size = new System.Drawing.Size(39, 15);
            this.labelClave.TabIndex = 6;
            this.labelClave.Text = "Clave";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(18, 67);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(123, 15);
            this.labelUsuario.TabIndex = 5;
            this.labelUsuario.Text = "Nombre de usuario";
            // 
            // buttonModificar
            // 
            this.buttonModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonModificar.FlatAppearance.BorderSize = 0;
            this.buttonModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModificar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificar.Location = new System.Drawing.Point(258, 174);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(88, 34);
            this.buttonModificar.TabIndex = 4;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = false;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonOcultar
            // 
            this.buttonOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOcultar.Location = new System.Drawing.Point(213, 217);
            this.buttonOcultar.Name = "buttonOcultar";
            this.buttonOcultar.Size = new System.Drawing.Size(24, 23);
            this.buttonOcultar.TabIndex = 3;
            this.buttonOcultar.UseVisualStyleBackColor = true;
            this.buttonOcultar.Click += new System.EventHandler(this.buttonOcultar_Click);
            // 
            // textBoxClave2
            // 
            this.textBoxClave2.Enabled = false;
            this.textBoxClave2.Location = new System.Drawing.Point(21, 217);
            this.textBoxClave2.Name = "textBoxClave2";
            this.textBoxClave2.PasswordChar = 'o';
            this.textBoxClave2.Size = new System.Drawing.Size(186, 23);
            this.textBoxClave2.TabIndex = 2;
            // 
            // textBoxClave
            // 
            this.textBoxClave.Enabled = false;
            this.textBoxClave.Location = new System.Drawing.Point(21, 152);
            this.textBoxClave.Name = "textBoxClave";
            this.textBoxClave.PasswordChar = 'o';
            this.textBoxClave.Size = new System.Drawing.Size(186, 23);
            this.textBoxClave.TabIndex = 1;
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Enabled = false;
            this.textBoxUsuario.Location = new System.Drawing.Point(21, 85);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(186, 23);
            this.textBoxUsuario.TabIndex = 0;
            // 
            // UserControlAjustes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.groupBoxDatos);
            this.Name = "UserControlAjustes";
            this.Size = new System.Drawing.Size(577, 490);
            this.groupBoxDatos.ResumeLayout(false);
            this.groupBoxDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.TextBox textBoxClave2;
        private System.Windows.Forms.TextBox textBoxClave;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.Button buttonOcultar;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Label labelRepetirClave;
        private System.Windows.Forms.Label labelClave;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonEliminar;
    }
}
