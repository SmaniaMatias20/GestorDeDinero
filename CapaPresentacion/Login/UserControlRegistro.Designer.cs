namespace CapaPresentacion
{
    partial class UserControlRegistro
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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.textBoxClave = new System.Windows.Forms.TextBox();
            this.textBoxClave2 = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelClave = new System.Windows.Forms.Label();
            this.labelClave2 = new System.Windows.Forms.Label();
            this.buttonRegistrarse = new System.Windows.Forms.Button();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.buttonOcultar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelTitulo.Location = new System.Drawing.Point(26, 58);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(172, 32);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Registrarse...";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(32, 135);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(160, 20);
            this.textBoxUsuario.TabIndex = 1;
            // 
            // textBoxClave
            // 
            this.textBoxClave.Location = new System.Drawing.Point(32, 195);
            this.textBoxClave.Name = "textBoxClave";
            this.textBoxClave.PasswordChar = 'o';
            this.textBoxClave.Size = new System.Drawing.Size(160, 20);
            this.textBoxClave.TabIndex = 2;
            // 
            // textBoxClave2
            // 
            this.textBoxClave2.Location = new System.Drawing.Point(32, 255);
            this.textBoxClave2.Name = "textBoxClave2";
            this.textBoxClave2.PasswordChar = 'o';
            this.textBoxClave2.Size = new System.Drawing.Size(160, 20);
            this.textBoxClave2.TabIndex = 3;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelUsuario.Location = new System.Drawing.Point(29, 108);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(50, 15);
            this.labelUsuario.TabIndex = 4;
            this.labelUsuario.Text = "Usuario";
            // 
            // labelClave
            // 
            this.labelClave.AutoSize = true;
            this.labelClave.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelClave.Location = new System.Drawing.Point(29, 166);
            this.labelClave.Name = "labelClave";
            this.labelClave.Size = new System.Drawing.Size(37, 15);
            this.labelClave.TabIndex = 5;
            this.labelClave.Text = "Clave";
            // 
            // labelClave2
            // 
            this.labelClave2.AutoSize = true;
            this.labelClave2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClave2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelClave2.Location = new System.Drawing.Point(32, 228);
            this.labelClave2.Name = "labelClave2";
            this.labelClave2.Size = new System.Drawing.Size(79, 15);
            this.labelClave2.TabIndex = 6;
            this.labelClave2.Text = "Repetir clave";
            // 
            // buttonRegistrarse
            // 
            this.buttonRegistrarse.BackColor = System.Drawing.Color.Green;
            this.buttonRegistrarse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRegistrarse.FlatAppearance.BorderSize = 0;
            this.buttonRegistrarse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistrarse.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegistrarse.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonRegistrarse.Location = new System.Drawing.Point(248, 161);
            this.buttonRegistrarse.Name = "buttonRegistrarse";
            this.buttonRegistrarse.Size = new System.Drawing.Size(88, 33);
            this.buttonRegistrarse.TabIndex = 7;
            this.buttonRegistrarse.Text = "Confirmar";
            this.buttonRegistrarse.UseVisualStyleBackColor = false;
            this.buttonRegistrarse.Click += new System.EventHandler(this.buttonRegistrarse_Click);
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.BackColor = System.Drawing.Color.Maroon;
            this.buttonBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBorrar.FlatAppearance.BorderSize = 0;
            this.buttonBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBorrar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBorrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBorrar.Location = new System.Drawing.Point(248, 219);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(88, 33);
            this.buttonBorrar.TabIndex = 8;
            this.buttonBorrar.Text = "Borrar";
            this.buttonBorrar.UseVisualStyleBackColor = false;
            this.buttonBorrar.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // buttonOcultar
            // 
            this.buttonOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOcultar.Location = new System.Drawing.Point(198, 255);
            this.buttonOcultar.Name = "buttonOcultar";
            this.buttonOcultar.Size = new System.Drawing.Size(23, 20);
            this.buttonOcultar.TabIndex = 9;
            this.buttonOcultar.UseVisualStyleBackColor = true;
            this.buttonOcultar.Click += new System.EventHandler(this.buttonOcultar_Click);
            // 
            // UserControlRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.buttonOcultar);
            this.Controls.Add(this.buttonBorrar);
            this.Controls.Add(this.buttonRegistrarse);
            this.Controls.Add(this.labelClave2);
            this.Controls.Add(this.labelClave);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.textBoxClave2);
            this.Controls.Add(this.textBoxClave);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.labelTitulo);
            this.Name = "UserControlRegistro";
            this.Size = new System.Drawing.Size(380, 334);
            this.Load += new System.EventHandler(this.UserControlRegistro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.TextBox textBoxClave;
        private System.Windows.Forms.TextBox textBoxClave2;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelClave;
        private System.Windows.Forms.Label labelClave2;
        private System.Windows.Forms.Button buttonRegistrarse;
        private System.Windows.Forms.Button buttonBorrar;
        private System.Windows.Forms.Button buttonOcultar;
    }
}
