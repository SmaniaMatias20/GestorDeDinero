namespace CapaPresentacion
{
    partial class UserControlInicio
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
            this.buttonMovimiento = new System.Windows.Forms.Button();
            this.labelCaja = new System.Windows.Forms.Label();
            this.richTextBoxReservas = new System.Windows.Forms.RichTextBox();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMovimiento
            // 
            this.buttonMovimiento.BackColor = System.Drawing.Color.Green;
            this.buttonMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMovimiento.FlatAppearance.BorderSize = 0;
            this.buttonMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMovimiento.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMovimiento.Location = new System.Drawing.Point(18, 150);
            this.buttonMovimiento.Name = "buttonMovimiento";
            this.buttonMovimiento.Size = new System.Drawing.Size(158, 38);
            this.buttonMovimiento.TabIndex = 0;
            this.buttonMovimiento.Text = "Realizar movimiento";
            this.buttonMovimiento.UseVisualStyleBackColor = false;
            this.buttonMovimiento.Click += new System.EventHandler(this.buttonMovimiento_Click);
            // 
            // labelCaja
            // 
            this.labelCaja.AutoSize = true;
            this.labelCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.labelCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCaja.Cursor = System.Windows.Forms.Cursors.No;
            this.labelCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaja.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelCaja.Location = new System.Drawing.Point(20, 76);
            this.labelCaja.Name = "labelCaja";
            this.labelCaja.Size = new System.Drawing.Size(268, 57);
            this.labelCaja.TabIndex = 1;
            this.labelCaja.Text = "$1.000.000";
            // 
            // richTextBoxReservas
            // 
            this.richTextBoxReservas.BackColor = System.Drawing.SystemColors.MenuBar;
            this.richTextBoxReservas.Location = new System.Drawing.Point(18, 207);
            this.richTextBoxReservas.Name = "richTextBoxReservas";
            this.richTextBoxReservas.ReadOnly = true;
            this.richTextBoxReservas.Size = new System.Drawing.Size(534, 238);
            this.richTextBoxReservas.TabIndex = 4;
            this.richTextBoxReservas.Text = "";
            // 
            // buttonModificar
            // 
            this.buttonModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonModificar.FlatAppearance.BorderSize = 0;
            this.buttonModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModificar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonModificar.Location = new System.Drawing.Point(396, 452);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(75, 23);
            this.buttonModificar.TabIndex = 6;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = false;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.BackColor = System.Drawing.Color.Maroon;
            this.buttonEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEliminar.FlatAppearance.BorderSize = 0;
            this.buttonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonEliminar.Location = new System.Drawing.Point(477, 452);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(75, 23);
            this.buttonEliminar.TabIndex = 7;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = false;
            // 
            // UserControlInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.richTextBoxReservas);
            this.Controls.Add(this.labelCaja);
            this.Controls.Add(this.buttonMovimiento);
            this.Name = "UserControlInicio";
            this.Size = new System.Drawing.Size(567, 496);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMovimiento;
        private System.Windows.Forms.Label labelCaja;
        private System.Windows.Forms.RichTextBox richTextBoxReservas;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonEliminar;
    }
}
