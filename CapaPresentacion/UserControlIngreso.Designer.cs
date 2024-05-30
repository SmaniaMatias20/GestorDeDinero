using System.Windows.Forms;

namespace CapaPresentacion
{
    partial class UserControlIngreso
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
            this.labelIngresoTitulo = new System.Windows.Forms.Label();
            this.textBoxIngreso = new System.Windows.Forms.TextBox();
            this.buttonAceptarIngreso = new System.Windows.Forms.Button();
            this.buttonBorrarIngreso = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIngresoTitulo
            // 
            this.labelIngresoTitulo.AutoSize = true;
            this.labelIngresoTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelIngresoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIngresoTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelIngresoTitulo.Location = new System.Drawing.Point(34, 100);
            this.labelIngresoTitulo.Name = "labelIngresoTitulo";
            this.labelIngresoTitulo.Size = new System.Drawing.Size(161, 27);
            this.labelIngresoTitulo.TabIndex = 0;
            this.labelIngresoTitulo.Text = "Ingresar Dinero";
            // 
            // textBoxIngreso
            // 
            this.textBoxIngreso.Location = new System.Drawing.Point(39, 165);
            this.textBoxIngreso.Name = "textBoxIngreso";
            this.textBoxIngreso.Size = new System.Drawing.Size(154, 20);
            this.textBoxIngreso.TabIndex = 1;
            this.textBoxIngreso.TextChanged += new System.EventHandler(this.textBoxIngreso_TextChanged);
            // 
            // buttonAceptarIngreso
            // 
            this.buttonAceptarIngreso.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonAceptarIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAceptarIngreso.FlatAppearance.BorderSize = 0;
            this.buttonAceptarIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAceptarIngreso.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAceptarIngreso.Location = new System.Drawing.Point(39, 207);
            this.buttonAceptarIngreso.Name = "buttonAceptarIngreso";
            this.buttonAceptarIngreso.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptarIngreso.TabIndex = 2;
            this.buttonAceptarIngreso.Text = "Aceptar";
            this.buttonAceptarIngreso.UseVisualStyleBackColor = false;
            this.buttonAceptarIngreso.Click += new System.EventHandler(this.buttonAceptarIngreso_Click);
            // 
            // buttonBorrarIngreso
            // 
            this.buttonBorrarIngreso.BackColor = System.Drawing.Color.Maroon;
            this.buttonBorrarIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBorrarIngreso.FlatAppearance.BorderSize = 0;
            this.buttonBorrarIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBorrarIngreso.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBorrarIngreso.Location = new System.Drawing.Point(118, 207);
            this.buttonBorrarIngreso.Name = "buttonBorrarIngreso";
            this.buttonBorrarIngreso.Size = new System.Drawing.Size(75, 23);
            this.buttonBorrarIngreso.TabIndex = 3;
            this.buttonBorrarIngreso.Text = "Borrar";
            this.buttonBorrarIngreso.UseVisualStyleBackColor = false;
            this.buttonBorrarIngreso.Click += new System.EventHandler(this.buttonBorrarIngreso_Click);
            // 
            // UserControlIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.buttonBorrarIngreso);
            this.Controls.Add(this.buttonAceptarIngreso);
            this.Controls.Add(this.textBoxIngreso);
            this.Controls.Add(this.labelIngresoTitulo);
            this.Name = "UserControlIngreso";
            this.Size = new System.Drawing.Size(250, 350);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIngresoTitulo;
        private System.Windows.Forms.TextBox textBoxIngreso;
        private System.Windows.Forms.Button buttonAceptarIngreso;
        private System.Windows.Forms.Button buttonBorrarIngreso;

    }
}
