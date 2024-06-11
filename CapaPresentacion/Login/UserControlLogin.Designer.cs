namespace CapaPresentacion
{
    partial class UserControlLogin
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
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.buttonIniciar = new System.Windows.Forms.Button();
            this.textBoxClave = new System.Windows.Forms.TextBox();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.labelClave = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.buttonOcultar = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.BackColor = System.Drawing.Color.Maroon;
            this.buttonBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBorrar.FlatAppearance.BorderSize = 0;
            this.buttonBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBorrar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBorrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBorrar.Location = new System.Drawing.Point(254, 257);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(88, 33);
            this.buttonBorrar.TabIndex = 12;
            this.buttonBorrar.Text = "Borrar";
            this.buttonBorrar.UseVisualStyleBackColor = false;
            this.buttonBorrar.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // buttonIniciar
            // 
            this.buttonIniciar.BackColor = System.Drawing.Color.Green;
            this.buttonIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonIniciar.FlatAppearance.BorderSize = 0;
            this.buttonIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIniciar.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIniciar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonIniciar.Location = new System.Drawing.Point(254, 195);
            this.buttonIniciar.Name = "buttonIniciar";
            this.buttonIniciar.Size = new System.Drawing.Size(88, 33);
            this.buttonIniciar.TabIndex = 11;
            this.buttonIniciar.Text = "Iniciar";
            this.buttonIniciar.UseVisualStyleBackColor = false;
            this.buttonIniciar.Click += new System.EventHandler(this.buttonIniciar_Click);
            // 
            // textBoxClave
            // 
            this.textBoxClave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxClave.Location = new System.Drawing.Point(33, 263);
            this.textBoxClave.Name = "textBoxClave";
            this.textBoxClave.PasswordChar = 'o';
            this.textBoxClave.Size = new System.Drawing.Size(160, 20);
            this.textBoxClave.TabIndex = 10;
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxUsuario.Location = new System.Drawing.Point(33, 201);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(160, 20);
            this.textBoxUsuario.TabIndex = 9;
            this.textBoxUsuario.TextChanged += new System.EventHandler(this.textBoxUsuario_TextChanged);
            // 
            // labelClave
            // 
            this.labelClave.AutoSize = true;
            this.labelClave.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelClave.Location = new System.Drawing.Point(30, 233);
            this.labelClave.Name = "labelClave";
            this.labelClave.Size = new System.Drawing.Size(68, 15);
            this.labelClave.TabIndex = 8;
            this.labelClave.Text = "Contraseña";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelUsuario.Location = new System.Drawing.Point(30, 171);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(50, 15);
            this.labelUsuario.TabIndex = 7;
            this.labelUsuario.Text = "Usuario";
            // 
            // buttonOcultar
            // 
            this.buttonOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOcultar.Location = new System.Drawing.Point(199, 263);
            this.buttonOcultar.Name = "buttonOcultar";
            this.buttonOcultar.Size = new System.Drawing.Size(21, 20);
            this.buttonOcultar.TabIndex = 14;
            this.buttonOcultar.UseVisualStyleBackColor = true;
            this.buttonOcultar.Click += new System.EventHandler(this.buttonOcultar_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxLogo.Location = new System.Drawing.Point(33, 37);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(309, 104);
            this.pictureBoxLogo.TabIndex = 15;
            this.pictureBoxLogo.TabStop = false;
            // 
            // UserControlLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.buttonOcultar);
            this.Controls.Add(this.buttonBorrar);
            this.Controls.Add(this.buttonIniciar);
            this.Controls.Add(this.textBoxClave);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.labelClave);
            this.Controls.Add(this.labelUsuario);
            this.Name = "UserControlLogin";
            this.Size = new System.Drawing.Size(380, 334);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBorrar;
        private System.Windows.Forms.Button buttonIniciar;
        private System.Windows.Forms.TextBox textBoxClave;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.Label labelClave;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Button buttonOcultar;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}
