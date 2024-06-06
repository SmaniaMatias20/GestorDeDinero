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
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonOcultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMovimiento
            // 
            this.buttonMovimiento.BackColor = System.Drawing.Color.Green;
            this.buttonMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMovimiento.FlatAppearance.BorderSize = 0;
            this.buttonMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMovimiento.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMovimiento.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMovimiento.Location = new System.Drawing.Point(18, 150);
            this.buttonMovimiento.Name = "buttonMovimiento";
            this.buttonMovimiento.Size = new System.Drawing.Size(158, 38);
            this.buttonMovimiento.TabIndex = 0;
            this.buttonMovimiento.Text = "Movimiento";
            this.buttonMovimiento.UseVisualStyleBackColor = false;
            this.buttonMovimiento.Click += new System.EventHandler(this.buttonMovimiento_Click);
            // 
            // labelCaja
            // 
            this.labelCaja.AutoSize = true;
            this.labelCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.labelCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCaja.Cursor = System.Windows.Forms.Cursors.No;
            this.labelCaja.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaja.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelCaja.Location = new System.Drawing.Point(20, 76);
            this.labelCaja.Name = "labelCaja";
            this.labelCaja.Size = new System.Drawing.Size(271, 59);
            this.labelCaja.TabIndex = 1;
            this.labelCaja.Text = "$1.000.000";
            // 
            // buttonModificar
            // 
            this.buttonModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonModificar.FlatAppearance.BorderSize = 0;
            this.buttonModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModificar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.buttonEliminar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonEliminar.Location = new System.Drawing.Point(477, 452);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(75, 23);
            this.buttonEliminar.TabIndex = 7;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(534, 224);
            this.dataGridView1.TabIndex = 8;
            // 
            // buttonOcultar
            // 
            this.buttonOcultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.buttonOcultar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonOcultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOcultar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonOcultar.Location = new System.Drawing.Point(20, 50);
            this.buttonOcultar.Name = "buttonOcultar";
            this.buttonOcultar.Size = new System.Drawing.Size(62, 23);
            this.buttonOcultar.TabIndex = 9;
            this.buttonOcultar.Text = "Ocultar";
            this.buttonOcultar.UseVisualStyleBackColor = false;
            this.buttonOcultar.Click += new System.EventHandler(this.buttonOcultar_Click);
            // 
            // UserControlInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonOcultar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.labelCaja);
            this.Controls.Add(this.buttonMovimiento);
            this.Name = "UserControlInicio";
            this.Size = new System.Drawing.Size(569, 498);
            this.Load += new System.EventHandler(this.UserControlInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMovimiento;
        private System.Windows.Forms.Label labelCaja;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonOcultar;
    }
}
