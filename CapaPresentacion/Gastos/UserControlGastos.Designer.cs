namespace CapaPresentacion
{
    partial class UserControlGastos
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
            this.dataGridViewGastos = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBoxGastos = new System.Windows.Forms.GroupBox();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.labelFecha = new System.Windows.Forms.Label();
            this.labelPago = new System.Windows.Forms.Label();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.labelGasto = new System.Windows.Forms.Label();
            this.labelImporte = new System.Windows.Forms.Label();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.textBoxImporte = new System.Windows.Forms.TextBox();
            this.comboBoxGasto = new System.Windows.Forms.ComboBox();
            this.comboBoxPago = new System.Windows.Forms.ComboBox();
            this.buttonFiltrar = new System.Windows.Forms.Button();
            this.comboBoxFiltro = new System.Windows.Forms.ComboBox();
            this.textBoxEleccion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGastos)).BeginInit();
            this.groupBoxGastos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewGastos
            // 
            this.dataGridViewGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGastos.Location = new System.Drawing.Point(14, 226);
            this.dataGridViewGastos.Name = "dataGridViewGastos";
            this.dataGridViewGastos.Size = new System.Drawing.Size(547, 251);
            this.dataGridViewGastos.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(248, 46);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(246, 23);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // groupBoxGastos
            // 
            this.groupBoxGastos.Controls.Add(this.buttonBorrar);
            this.groupBoxGastos.Controls.Add(this.buttonModificar);
            this.groupBoxGastos.Controls.Add(this.buttonAceptar);
            this.groupBoxGastos.Controls.Add(this.labelFecha);
            this.groupBoxGastos.Controls.Add(this.labelPago);
            this.groupBoxGastos.Controls.Add(this.labelDescripcion);
            this.groupBoxGastos.Controls.Add(this.labelGasto);
            this.groupBoxGastos.Controls.Add(this.labelImporte);
            this.groupBoxGastos.Controls.Add(this.textBoxDescripcion);
            this.groupBoxGastos.Controls.Add(this.textBoxImporte);
            this.groupBoxGastos.Controls.Add(this.comboBoxGasto);
            this.groupBoxGastos.Controls.Add(this.comboBoxPago);
            this.groupBoxGastos.Controls.Add(this.dateTimePicker1);
            this.groupBoxGastos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxGastos.Location = new System.Drawing.Point(14, 3);
            this.groupBoxGastos.Name = "groupBoxGastos";
            this.groupBoxGastos.Size = new System.Drawing.Size(547, 179);
            this.groupBoxGastos.TabIndex = 2;
            this.groupBoxGastos.TabStop = false;
            this.groupBoxGastos.Text = "Registro de gastos";
            this.groupBoxGastos.Enter += new System.EventHandler(this.groupBoxGastos_Enter);
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.BackColor = System.Drawing.Color.Maroon;
            this.buttonBorrar.FlatAppearance.BorderSize = 0;
            this.buttonBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBorrar.Location = new System.Drawing.Point(429, 144);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(104, 23);
            this.buttonBorrar.TabIndex = 13;
            this.buttonBorrar.Text = "Borrar";
            this.buttonBorrar.UseVisualStyleBackColor = false;
            // 
            // buttonModificar
            // 
            this.buttonModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonModificar.FlatAppearance.BorderSize = 0;
            this.buttonModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModificar.Location = new System.Drawing.Point(319, 144);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(104, 23);
            this.buttonModificar.TabIndex = 12;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = false;
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.BackColor = System.Drawing.Color.Green;
            this.buttonAceptar.FlatAppearance.BorderSize = 0;
            this.buttonAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAceptar.Location = new System.Drawing.Point(209, 144);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(104, 23);
            this.buttonAceptar.TabIndex = 11;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = false;
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Location = new System.Drawing.Point(245, 23);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(41, 15);
            this.labelFecha.TabIndex = 10;
            this.labelFecha.Text = "Fecha";
            // 
            // labelPago
            // 
            this.labelPago.AutoSize = true;
            this.labelPago.Location = new System.Drawing.Point(15, 126);
            this.labelPago.Name = "labelPago";
            this.labelPago.Size = new System.Drawing.Size(102, 15);
            this.labelPago.TabIndex = 9;
            this.labelPago.Text = "Metodo de pago";
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(245, 75);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(78, 15);
            this.labelDescripcion.TabIndex = 8;
            this.labelDescripcion.Text = "Descripcion";
            // 
            // labelGasto
            // 
            this.labelGasto.AutoSize = true;
            this.labelGasto.Location = new System.Drawing.Point(15, 75);
            this.labelGasto.Name = "labelGasto";
            this.labelGasto.Size = new System.Drawing.Size(87, 15);
            this.labelGasto.TabIndex = 7;
            this.labelGasto.Text = "Tipo de gasto";
            // 
            // labelImporte
            // 
            this.labelImporte.AutoSize = true;
            this.labelImporte.Location = new System.Drawing.Point(15, 23);
            this.labelImporte.Name = "labelImporte";
            this.labelImporte.Size = new System.Drawing.Size(57, 15);
            this.labelImporte.TabIndex = 6;
            this.labelImporte.Text = "Importe";
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(248, 95);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(246, 23);
            this.textBoxDescripcion.TabIndex = 5;
            // 
            // textBoxImporte
            // 
            this.textBoxImporte.Location = new System.Drawing.Point(15, 46);
            this.textBoxImporte.Name = "textBoxImporte";
            this.textBoxImporte.Size = new System.Drawing.Size(178, 23);
            this.textBoxImporte.TabIndex = 4;
            // 
            // comboBoxGasto
            // 
            this.comboBoxGasto.FormattingEnabled = true;
            this.comboBoxGasto.Items.AddRange(new object[] {
            "Alquiler,",
            "Servicios,",
            "Transporte,",
            "Alimentacion,",
            "Ropa",
            "Entretenimiento",
            "Vacaciones",
            "Hobbies",
            "Electronica",
            "Salud",
            "Educacion",
            "Ahorro",
            "Deudas",
            "Mantenimiento",
            "Mobiliario",
            "Regalos",
            "Mascotas",
            "Otros"});
            this.comboBoxGasto.Location = new System.Drawing.Point(15, 95);
            this.comboBoxGasto.Name = "comboBoxGasto";
            this.comboBoxGasto.Size = new System.Drawing.Size(178, 23);
            this.comboBoxGasto.TabIndex = 3;
            // 
            // comboBoxPago
            // 
            this.comboBoxPago.FormattingEnabled = true;
            this.comboBoxPago.Items.AddRange(new object[] {
            "Efectivo",
            "Credito",
            "Debito",
            "Transferencia"});
            this.comboBoxPago.Location = new System.Drawing.Point(15, 144);
            this.comboBoxPago.Name = "comboBoxPago";
            this.comboBoxPago.Size = new System.Drawing.Size(178, 23);
            this.comboBoxPago.TabIndex = 2;
            // 
            // buttonFiltrar
            // 
            this.buttonFiltrar.BackColor = System.Drawing.Color.DimGray;
            this.buttonFiltrar.FlatAppearance.BorderSize = 0;
            this.buttonFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFiltrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonFiltrar.Location = new System.Drawing.Point(457, 197);
            this.buttonFiltrar.Name = "buttonFiltrar";
            this.buttonFiltrar.Size = new System.Drawing.Size(104, 23);
            this.buttonFiltrar.TabIndex = 14;
            this.buttonFiltrar.Text = "Filtrar";
            this.buttonFiltrar.UseVisualStyleBackColor = false;
            // 
            // comboBoxFiltro
            // 
            this.comboBoxFiltro.FormattingEnabled = true;
            this.comboBoxFiltro.Items.AddRange(new object[] {
            "Tipo de gasto",
            "Metodo de pago"});
            this.comboBoxFiltro.Location = new System.Drawing.Point(14, 197);
            this.comboBoxFiltro.Name = "comboBoxFiltro";
            this.comboBoxFiltro.Size = new System.Drawing.Size(180, 23);
            this.comboBoxFiltro.TabIndex = 14;
            // 
            // textBoxEleccion
            // 
            this.textBoxEleccion.Location = new System.Drawing.Point(198, 197);
            this.textBoxEleccion.Name = "textBoxEleccion";
            this.textBoxEleccion.Size = new System.Drawing.Size(180, 23);
            this.textBoxEleccion.TabIndex = 15;
            // 
            // UserControlGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textBoxEleccion);
            this.Controls.Add(this.comboBoxFiltro);
            this.Controls.Add(this.buttonFiltrar);
            this.Controls.Add(this.groupBoxGastos);
            this.Controls.Add(this.dataGridViewGastos);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "UserControlGastos";
            this.Size = new System.Drawing.Size(577, 490);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGastos)).EndInit();
            this.groupBoxGastos.ResumeLayout(false);
            this.groupBoxGastos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGastos;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBoxGastos;
        private System.Windows.Forms.ComboBox comboBoxPago;
        private System.Windows.Forms.ComboBox comboBoxGasto;
        private System.Windows.Forms.TextBox textBoxImporte;
        private System.Windows.Forms.Label labelPago;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.Label labelGasto;
        private System.Windows.Forms.Label labelImporte;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Button buttonBorrar;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonFiltrar;
        private System.Windows.Forms.ComboBox comboBoxFiltro;
        private System.Windows.Forms.TextBox textBoxEleccion;
    }
}
