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
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.groupBoxGastos = new System.Windows.Forms.GroupBox();
            this.buttonEliminar = new System.Windows.Forms.Button();
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
            this.groupBoxFiltro = new System.Windows.Forms.GroupBox();
            this.labelFiltroImporteMin = new System.Windows.Forms.Label();
            this.textBoxFiltroImporteMin = new System.Windows.Forms.TextBox();
            this.labelFiltroImporteMax = new System.Windows.Forms.Label();
            this.labelFiltroGasto = new System.Windows.Forms.Label();
            this.labelFiltroPago = new System.Windows.Forms.Label();
            this.comboBoxFiltroGasto = new System.Windows.Forms.ComboBox();
            this.textBoxFiltroImporteMax = new System.Windows.Forms.TextBox();
            this.comboBoxFiltroPago = new System.Windows.Forms.ComboBox();
            this.buttonFiltrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGastos)).BeginInit();
            this.groupBoxGastos.SuspendLayout();
            this.groupBoxFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewGastos
            // 
            this.dataGridViewGastos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGastos.Location = new System.Drawing.Point(13, 299);
            this.dataGridViewGastos.Name = "dataGridViewGastos";
            this.dataGridViewGastos.Size = new System.Drawing.Size(547, 179);
            this.dataGridViewGastos.TabIndex = 0;
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFecha.Location = new System.Drawing.Point(15, 197);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(247, 23);
            this.dateTimePickerFecha.TabIndex = 1;
            // 
            // groupBoxGastos
            // 
            this.groupBoxGastos.Controls.Add(this.buttonEliminar);
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
            this.groupBoxGastos.Controls.Add(this.dateTimePickerFecha);
            this.groupBoxGastos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxGastos.Location = new System.Drawing.Point(13, 3);
            this.groupBoxGastos.Name = "groupBoxGastos";
            this.groupBoxGastos.Size = new System.Drawing.Size(329, 290);
            this.groupBoxGastos.TabIndex = 2;
            this.groupBoxGastos.TabStop = false;
            this.groupBoxGastos.Text = "Registro de gastos";
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.BackColor = System.Drawing.Color.Maroon;
            this.buttonEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEliminar.FlatAppearance.BorderSize = 0;
            this.buttonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminar.Location = new System.Drawing.Point(210, 146);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(104, 23);
            this.buttonEliminar.TabIndex = 13;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonModificar.FlatAppearance.BorderSize = 0;
            this.buttonModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModificar.Location = new System.Drawing.Point(210, 97);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(104, 23);
            this.buttonModificar.TabIndex = 12;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = false;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.BackColor = System.Drawing.Color.Green;
            this.buttonAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAceptar.FlatAppearance.BorderSize = 0;
            this.buttonAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAceptar.Location = new System.Drawing.Point(210, 49);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(104, 23);
            this.buttonAceptar.TabIndex = 11;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = false;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Location = new System.Drawing.Point(12, 179);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(41, 15);
            this.labelFecha.TabIndex = 10;
            this.labelFecha.Text = "Fecha";
            // 
            // labelPago
            // 
            this.labelPago.AutoSize = true;
            this.labelPago.Location = new System.Drawing.Point(12, 129);
            this.labelPago.Name = "labelPago";
            this.labelPago.Size = new System.Drawing.Size(102, 15);
            this.labelPago.TabIndex = 9;
            this.labelPago.Text = "Metodo de pago";
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(12, 228);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(78, 15);
            this.labelDescripcion.TabIndex = 8;
            this.labelDescripcion.Text = "Descripcion";
            // 
            // labelGasto
            // 
            this.labelGasto.AutoSize = true;
            this.labelGasto.Location = new System.Drawing.Point(12, 80);
            this.labelGasto.Name = "labelGasto";
            this.labelGasto.Size = new System.Drawing.Size(87, 15);
            this.labelGasto.TabIndex = 7;
            this.labelGasto.Text = "Tipo de gasto";
            // 
            // labelImporte
            // 
            this.labelImporte.AutoSize = true;
            this.labelImporte.Location = new System.Drawing.Point(12, 31);
            this.labelImporte.Name = "labelImporte";
            this.labelImporte.Size = new System.Drawing.Size(57, 15);
            this.labelImporte.TabIndex = 6;
            this.labelImporte.Text = "Importe";
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(15, 246);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(247, 23);
            this.textBoxDescripcion.TabIndex = 5;
            // 
            // textBoxImporte
            // 
            this.textBoxImporte.Location = new System.Drawing.Point(15, 49);
            this.textBoxImporte.Name = "textBoxImporte";
            this.textBoxImporte.Size = new System.Drawing.Size(177, 23);
            this.textBoxImporte.TabIndex = 4;
            // 
            // comboBoxGasto
            // 
            this.comboBoxGasto.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxGasto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGasto.FormattingEnabled = true;
            this.comboBoxGasto.Items.AddRange(new object[] {
            "Alquiler",
            "Servicios",
            "Transporte",
            "Alimentacion",
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
            "Otros",
            ""});
            this.comboBoxGasto.Location = new System.Drawing.Point(15, 98);
            this.comboBoxGasto.Name = "comboBoxGasto";
            this.comboBoxGasto.Size = new System.Drawing.Size(177, 23);
            this.comboBoxGasto.TabIndex = 3;
            // 
            // comboBoxPago
            // 
            this.comboBoxPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPago.FormattingEnabled = true;
            this.comboBoxPago.Items.AddRange(new object[] {
            "Efectivo",
            "Credito",
            "Debito",
            "Transferencia",
            "MercadoPago",
            ""});
            this.comboBoxPago.Location = new System.Drawing.Point(15, 147);
            this.comboBoxPago.Name = "comboBoxPago";
            this.comboBoxPago.Size = new System.Drawing.Size(177, 23);
            this.comboBoxPago.TabIndex = 2;
            // 
            // groupBoxFiltro
            // 
            this.groupBoxFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.groupBoxFiltro.Controls.Add(this.labelFiltroImporteMin);
            this.groupBoxFiltro.Controls.Add(this.textBoxFiltroImporteMin);
            this.groupBoxFiltro.Controls.Add(this.labelFiltroImporteMax);
            this.groupBoxFiltro.Controls.Add(this.labelFiltroGasto);
            this.groupBoxFiltro.Controls.Add(this.labelFiltroPago);
            this.groupBoxFiltro.Controls.Add(this.comboBoxFiltroGasto);
            this.groupBoxFiltro.Controls.Add(this.textBoxFiltroImporteMax);
            this.groupBoxFiltro.Controls.Add(this.comboBoxFiltroPago);
            this.groupBoxFiltro.Controls.Add(this.buttonFiltrar);
            this.groupBoxFiltro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxFiltro.Location = new System.Drawing.Point(348, 3);
            this.groupBoxFiltro.Name = "groupBoxFiltro";
            this.groupBoxFiltro.Size = new System.Drawing.Size(212, 290);
            this.groupBoxFiltro.TabIndex = 3;
            this.groupBoxFiltro.TabStop = false;
            this.groupBoxFiltro.Text = "Buscar";
            // 
            // labelFiltroImporteMin
            // 
            this.labelFiltroImporteMin.AutoSize = true;
            this.labelFiltroImporteMin.Location = new System.Drawing.Point(39, 139);
            this.labelFiltroImporteMin.Name = "labelFiltroImporteMin";
            this.labelFiltroImporteMin.Size = new System.Drawing.Size(96, 15);
            this.labelFiltroImporteMin.TabIndex = 33;
            this.labelFiltroImporteMin.Text = "Importe desde";
            // 
            // textBoxFiltroImporteMin
            // 
            this.textBoxFiltroImporteMin.Location = new System.Drawing.Point(42, 157);
            this.textBoxFiltroImporteMin.Name = "textBoxFiltroImporteMin";
            this.textBoxFiltroImporteMin.Size = new System.Drawing.Size(134, 23);
            this.textBoxFiltroImporteMin.TabIndex = 32;
            // 
            // labelFiltroImporteMax
            // 
            this.labelFiltroImporteMax.AutoSize = true;
            this.labelFiltroImporteMax.Location = new System.Drawing.Point(39, 183);
            this.labelFiltroImporteMax.Name = "labelFiltroImporteMax";
            this.labelFiltroImporteMax.Size = new System.Drawing.Size(93, 15);
            this.labelFiltroImporteMax.TabIndex = 30;
            this.labelFiltroImporteMax.Text = "Importe hasta";
            // 
            // labelFiltroGasto
            // 
            this.labelFiltroGasto.AutoSize = true;
            this.labelFiltroGasto.Location = new System.Drawing.Point(39, 91);
            this.labelFiltroGasto.Name = "labelFiltroGasto";
            this.labelFiltroGasto.Size = new System.Drawing.Size(87, 15);
            this.labelFiltroGasto.TabIndex = 27;
            this.labelFiltroGasto.Text = "Tipo de gasto";
            // 
            // labelFiltroPago
            // 
            this.labelFiltroPago.AutoSize = true;
            this.labelFiltroPago.Location = new System.Drawing.Point(39, 43);
            this.labelFiltroPago.Name = "labelFiltroPago";
            this.labelFiltroPago.Size = new System.Drawing.Size(102, 15);
            this.labelFiltroPago.TabIndex = 26;
            this.labelFiltroPago.Text = "Metodo de pago";
            // 
            // comboBoxFiltroGasto
            // 
            this.comboBoxFiltroGasto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxFiltroGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltroGasto.FormattingEnabled = true;
            this.comboBoxFiltroGasto.Items.AddRange(new object[] {
            "Alquiler",
            "Servicios",
            "Transporte",
            "Alimentacion",
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
            "Otros",
            ""});
            this.comboBoxFiltroGasto.Location = new System.Drawing.Point(42, 109);
            this.comboBoxFiltroGasto.Name = "comboBoxFiltroGasto";
            this.comboBoxFiltroGasto.Size = new System.Drawing.Size(134, 23);
            this.comboBoxFiltroGasto.TabIndex = 24;
            // 
            // textBoxFiltroImporteMax
            // 
            this.textBoxFiltroImporteMax.Location = new System.Drawing.Point(42, 201);
            this.textBoxFiltroImporteMax.Name = "textBoxFiltroImporteMax";
            this.textBoxFiltroImporteMax.Size = new System.Drawing.Size(134, 23);
            this.textBoxFiltroImporteMax.TabIndex = 23;
            // 
            // comboBoxFiltroPago
            // 
            this.comboBoxFiltroPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxFiltroPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltroPago.FormattingEnabled = true;
            this.comboBoxFiltroPago.Items.AddRange(new object[] {
            "Efectivo",
            "Credito",
            "Debito",
            "Transferencia",
            "MercadoPago",
            ""});
            this.comboBoxFiltroPago.Location = new System.Drawing.Point(42, 61);
            this.comboBoxFiltroPago.Name = "comboBoxFiltroPago";
            this.comboBoxFiltroPago.Size = new System.Drawing.Size(134, 23);
            this.comboBoxFiltroPago.TabIndex = 20;
            // 
            // buttonFiltrar
            // 
            this.buttonFiltrar.BackColor = System.Drawing.Color.DimGray;
            this.buttonFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFiltrar.FlatAppearance.BorderSize = 0;
            this.buttonFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFiltrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonFiltrar.Location = new System.Drawing.Point(42, 239);
            this.buttonFiltrar.Name = "buttonFiltrar";
            this.buttonFiltrar.Size = new System.Drawing.Size(134, 30);
            this.buttonFiltrar.TabIndex = 21;
            this.buttonFiltrar.Text = "Buscar";
            this.buttonFiltrar.UseVisualStyleBackColor = false;
            this.buttonFiltrar.Click += new System.EventHandler(this.buttonFiltrar_Click);
            // 
            // UserControlGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBoxFiltro);
            this.Controls.Add(this.groupBoxGastos);
            this.Controls.Add(this.dataGridViewGastos);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "UserControlGastos";
            this.Size = new System.Drawing.Size(577, 490);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGastos)).EndInit();
            this.groupBoxGastos.ResumeLayout(false);
            this.groupBoxGastos.PerformLayout();
            this.groupBoxFiltro.ResumeLayout(false);
            this.groupBoxFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGastos;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
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
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.GroupBox groupBoxFiltro;
        private System.Windows.Forms.Label labelFiltroImporteMax;
        private System.Windows.Forms.Label labelFiltroGasto;
        private System.Windows.Forms.Label labelFiltroPago;
        private System.Windows.Forms.ComboBox comboBoxFiltroGasto;
        private System.Windows.Forms.TextBox textBoxFiltroImporteMax;
        private System.Windows.Forms.ComboBox comboBoxFiltroPago;
        private System.Windows.Forms.Button buttonFiltrar;
        private System.Windows.Forms.Label labelFiltroImporteMin;
        private System.Windows.Forms.TextBox textBoxFiltroImporteMin;
    }
}
