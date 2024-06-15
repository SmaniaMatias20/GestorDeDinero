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
            this.dataGridViewMovimientos = new System.Windows.Forms.DataGridView();
            this.buttonOcultar = new System.Windows.Forms.Button();
            this.groupBoxInicio = new System.Windows.Forms.GroupBox();
            this.radioButtonReservas = new System.Windows.Forms.RadioButton();
            this.radioButtonMovimientos = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovimientos)).BeginInit();
            this.groupBoxInicio.SuspendLayout();
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
            this.buttonMovimiento.Location = new System.Drawing.Point(24, 162);
            this.buttonMovimiento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonMovimiento.Name = "buttonMovimiento";
            this.buttonMovimiento.Size = new System.Drawing.Size(211, 44);
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
            this.labelCaja.Location = new System.Drawing.Point(27, 77);
            this.labelCaja.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.buttonModificar.Location = new System.Drawing.Point(345, 449);
            this.buttonModificar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(100, 27);
            this.buttonModificar.TabIndex = 6;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = false;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.BackColor = System.Drawing.Color.Maroon;
            this.buttonEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEliminar.FlatAppearance.BorderSize = 0;
            this.buttonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonEliminar.Location = new System.Drawing.Point(453, 449);
            this.buttonEliminar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(100, 27);
            this.buttonEliminar.TabIndex = 7;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // dataGridViewMovimientos
            // 
            this.dataGridViewMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMovimientos.Location = new System.Drawing.Point(24, 227);
            this.dataGridViewMovimientos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridViewMovimientos.Name = "dataGridViewMovimientos";
            this.dataGridViewMovimientos.ReadOnly = true;
            this.dataGridViewMovimientos.Size = new System.Drawing.Size(529, 216);
            this.dataGridViewMovimientos.TabIndex = 8;
            // 
            // buttonOcultar
            // 
            this.buttonOcultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.buttonOcultar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonOcultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOcultar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonOcultar.Location = new System.Drawing.Point(27, 47);
            this.buttonOcultar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOcultar.Name = "buttonOcultar";
            this.buttonOcultar.Size = new System.Drawing.Size(83, 27);
            this.buttonOcultar.TabIndex = 9;
            this.buttonOcultar.Text = "Ocultar";
            this.buttonOcultar.UseVisualStyleBackColor = false;
            this.buttonOcultar.Click += new System.EventHandler(this.buttonOcultar_Click);
            // 
            // groupBoxInicio
            // 
            this.groupBoxInicio.Controls.Add(this.radioButtonReservas);
            this.groupBoxInicio.Controls.Add(this.radioButtonMovimientos);
            this.groupBoxInicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxInicio.Location = new System.Drawing.Point(345, 149);
            this.groupBoxInicio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxInicio.Name = "groupBoxInicio";
            this.groupBoxInicio.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxInicio.Size = new System.Drawing.Size(208, 72);
            this.groupBoxInicio.TabIndex = 10;
            this.groupBoxInicio.TabStop = false;
            this.groupBoxInicio.Text = "Elección";
            // 
            // radioButtonReservas
            // 
            this.radioButtonReservas.AutoSize = true;
            this.radioButtonReservas.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButtonReservas.Location = new System.Drawing.Point(84, 45);
            this.radioButtonReservas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonReservas.Name = "radioButtonReservas";
            this.radioButtonReservas.Size = new System.Drawing.Size(80, 19);
            this.radioButtonReservas.TabIndex = 11;
            this.radioButtonReservas.TabStop = true;
            this.radioButtonReservas.Text = "Reservas";
            this.radioButtonReservas.UseVisualStyleBackColor = true;
            this.radioButtonReservas.CheckedChanged += new System.EventHandler(this.radioButtonReservas_CheckedChanged);
            // 
            // radioButtonMovimientos
            // 
            this.radioButtonMovimientos.AutoSize = true;
            this.radioButtonMovimientos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButtonMovimientos.Location = new System.Drawing.Point(84, 18);
            this.radioButtonMovimientos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonMovimientos.Name = "radioButtonMovimientos";
            this.radioButtonMovimientos.Size = new System.Drawing.Size(103, 19);
            this.radioButtonMovimientos.TabIndex = 0;
            this.radioButtonMovimientos.TabStop = true;
            this.radioButtonMovimientos.Text = "Movimientos";
            this.radioButtonMovimientos.UseVisualStyleBackColor = true;
            this.radioButtonMovimientos.CheckedChanged += new System.EventHandler(this.radioButtonMovimientos_CheckedChanged);
            // 
            // UserControlInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBoxInicio);
            this.Controls.Add(this.buttonOcultar);
            this.Controls.Add(this.dataGridViewMovimientos);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.labelCaja);
            this.Controls.Add(this.buttonMovimiento);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "UserControlInicio";
            this.Size = new System.Drawing.Size(577, 490);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovimientos)).EndInit();
            this.groupBoxInicio.ResumeLayout(false);
            this.groupBoxInicio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMovimiento;
        private System.Windows.Forms.Label labelCaja;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.DataGridView dataGridViewMovimientos;
        private System.Windows.Forms.Button buttonOcultar;
        private System.Windows.Forms.GroupBox groupBoxInicio;
        private System.Windows.Forms.RadioButton radioButtonMovimientos;
        private System.Windows.Forms.RadioButton radioButtonReservas;
    }
}
