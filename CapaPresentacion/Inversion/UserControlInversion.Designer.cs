﻿namespace CapaPresentacion
{
    partial class UserControlInversion
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
            this.textBoxMoneda = new System.Windows.Forms.TextBox();
            this.textBoxConversion = new System.Windows.Forms.TextBox();
            this.comboBoxMoneda = new System.Windows.Forms.ComboBox();
            this.comboBoxConversion = new System.Windows.Forms.ComboBox();
            this.groupBoxConversion = new System.Windows.Forms.GroupBox();
            this.buttonContinuar = new System.Windows.Forms.Button();
            this.panelResultado = new System.Windows.Forms.Panel();
            this.labelFecha = new System.Windows.Forms.Label();
            this.labelInteres = new System.Windows.Forms.Label();
            this.labelTasa = new System.Windows.Forms.Label();
            this.labelHasta = new System.Windows.Forms.Label();
            this.labelGanancias = new System.Windows.Forms.Label();
            this.labelTNA = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.pictureBoxImagen = new System.Windows.Forms.PictureBox();
            this.textBoxImporte = new System.Windows.Forms.TextBox();
            this.labelImporte = new System.Windows.Forms.Label();
            this.labelDias = new System.Windows.Forms.Label();
            this.groupBoxSimulador = new System.Windows.Forms.GroupBox();
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxConversion.SuspendLayout();
            this.panelResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).BeginInit();
            this.groupBoxSimulador.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMoneda
            // 
            this.textBoxMoneda.Location = new System.Drawing.Point(19, 20);
            this.textBoxMoneda.Name = "textBoxMoneda";
            this.textBoxMoneda.Size = new System.Drawing.Size(130, 22);
            this.textBoxMoneda.TabIndex = 0;
            // 
            // textBoxConversion
            // 
            this.textBoxConversion.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConversion.Location = new System.Drawing.Point(285, 19);
            this.textBoxConversion.Name = "textBoxConversion";
            this.textBoxConversion.Size = new System.Drawing.Size(130, 22);
            this.textBoxConversion.TabIndex = 1;
            // 
            // comboBoxMoneda
            // 
            this.comboBoxMoneda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxMoneda.FormattingEnabled = true;
            this.comboBoxMoneda.Location = new System.Drawing.Point(155, 20);
            this.comboBoxMoneda.Name = "comboBoxMoneda";
            this.comboBoxMoneda.Size = new System.Drawing.Size(100, 22);
            this.comboBoxMoneda.TabIndex = 2;
            // 
            // comboBoxConversion
            // 
            this.comboBoxConversion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxConversion.FormattingEnabled = true;
            this.comboBoxConversion.Location = new System.Drawing.Point(421, 19);
            this.comboBoxConversion.Name = "comboBoxConversion";
            this.comboBoxConversion.Size = new System.Drawing.Size(100, 22);
            this.comboBoxConversion.TabIndex = 3;
            // 
            // groupBoxConversion
            // 
            this.groupBoxConversion.Controls.Add(this.comboBoxConversion);
            this.groupBoxConversion.Controls.Add(this.comboBoxMoneda);
            this.groupBoxConversion.Controls.Add(this.textBoxConversion);
            this.groupBoxConversion.Controls.Add(this.textBoxMoneda);
            this.groupBoxConversion.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxConversion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxConversion.Location = new System.Drawing.Point(16, 17);
            this.groupBoxConversion.Name = "groupBoxConversion";
            this.groupBoxConversion.Size = new System.Drawing.Size(542, 57);
            this.groupBoxConversion.TabIndex = 0;
            this.groupBoxConversion.TabStop = false;
            this.groupBoxConversion.Text = "Conversión de moneda";
            // 
            // buttonContinuar
            // 
            this.buttonContinuar.BackColor = System.Drawing.Color.Green;
            this.buttonContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonContinuar.FlatAppearance.BorderSize = 0;
            this.buttonContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContinuar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContinuar.Location = new System.Drawing.Point(19, 328);
            this.buttonContinuar.Name = "buttonContinuar";
            this.buttonContinuar.Size = new System.Drawing.Size(161, 37);
            this.buttonContinuar.TabIndex = 0;
            this.buttonContinuar.Text = "Continuar";
            this.buttonContinuar.UseVisualStyleBackColor = false;
            this.buttonContinuar.Click += new System.EventHandler(this.buttonContinuar_Click);
            // 
            // panelResultado
            // 
            this.panelResultado.BackColor = System.Drawing.Color.White;
            this.panelResultado.Controls.Add(this.labelFecha);
            this.panelResultado.Controls.Add(this.labelInteres);
            this.panelResultado.Controls.Add(this.labelTasa);
            this.panelResultado.Controls.Add(this.labelHasta);
            this.panelResultado.Controls.Add(this.labelGanancias);
            this.panelResultado.Controls.Add(this.labelTNA);
            this.panelResultado.Controls.Add(this.labelTotal);
            this.panelResultado.Controls.Add(this.labelTitulo);
            this.panelResultado.Controls.Add(this.pictureBoxImagen);
            this.panelResultado.Location = new System.Drawing.Point(19, 168);
            this.panelResultado.Name = "panelResultado";
            this.panelResultado.Size = new System.Drawing.Size(502, 154);
            this.panelResultado.TabIndex = 1;
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelFecha.Location = new System.Drawing.Point(371, 114);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(87, 15);
            this.labelFecha.TabIndex = 8;
            this.labelFecha.Text = "dd/MM/yyyy";
            // 
            // labelInteres
            // 
            this.labelInteres.AutoSize = true;
            this.labelInteres.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInteres.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelInteres.Location = new System.Drawing.Point(243, 114);
            this.labelInteres.Name = "labelInteres";
            this.labelInteres.Size = new System.Drawing.Size(22, 15);
            this.labelInteres.TabIndex = 7;
            this.labelInteres.Text = "$0";
            // 
            // labelTasa
            // 
            this.labelTasa.AutoSize = true;
            this.labelTasa.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTasa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTasa.Location = new System.Drawing.Point(179, 114);
            this.labelTasa.Name = "labelTasa";
            this.labelTasa.Size = new System.Drawing.Size(28, 15);
            this.labelTasa.TabIndex = 6;
            this.labelTasa.Text = "0%";
            // 
            // labelHasta
            // 
            this.labelHasta.AutoSize = true;
            this.labelHasta.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHasta.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelHasta.Location = new System.Drawing.Point(371, 88);
            this.labelHasta.Name = "labelHasta";
            this.labelHasta.Size = new System.Drawing.Size(64, 15);
            this.labelHasta.TabIndex = 5;
            this.labelHasta.Text = "Hasta el...";
            // 
            // labelGanancias
            // 
            this.labelGanancias.AutoSize = true;
            this.labelGanancias.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGanancias.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelGanancias.Location = new System.Drawing.Point(243, 88);
            this.labelGanancias.Name = "labelGanancias";
            this.labelGanancias.Size = new System.Drawing.Size(98, 15);
            this.labelGanancias.TabIndex = 4;
            this.labelGanancias.Text = "Interés ganado";
            // 
            // labelTNA
            // 
            this.labelTNA.AutoSize = true;
            this.labelTNA.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTNA.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelTNA.Location = new System.Drawing.Point(179, 88);
            this.labelTNA.Name = "labelTNA";
            this.labelTNA.Size = new System.Drawing.Size(32, 15);
            this.labelTNA.TabIndex = 3;
            this.labelTNA.Text = "TNA";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labelTotal.Location = new System.Drawing.Point(176, 46);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(45, 32);
            this.labelTotal.TabIndex = 2;
            this.labelTotal.Text = "$0";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelTitulo.Location = new System.Drawing.Point(179, 16);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(184, 15);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Al final del plazo fijo, recibis...";
            // 
            // pictureBoxImagen
            // 
            this.pictureBoxImagen.BackColor = System.Drawing.Color.Navy;
            this.pictureBoxImagen.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImagen.Name = "pictureBoxImagen";
            this.pictureBoxImagen.Size = new System.Drawing.Size(161, 154);
            this.pictureBoxImagen.TabIndex = 0;
            this.pictureBoxImagen.TabStop = false;
            // 
            // textBoxImporte
            // 
            this.textBoxImporte.Location = new System.Drawing.Point(19, 68);
            this.textBoxImporte.Name = "textBoxImporte";
            this.textBoxImporte.Size = new System.Drawing.Size(211, 23);
            this.textBoxImporte.TabIndex = 2;
            // 
            // labelImporte
            // 
            this.labelImporte.AutoSize = true;
            this.labelImporte.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImporte.Location = new System.Drawing.Point(15, 33);
            this.labelImporte.Name = "labelImporte";
            this.labelImporte.Size = new System.Drawing.Size(223, 22);
            this.labelImporte.TabIndex = 3;
            this.labelImporte.Text = "¿Cuánto querés invertir?";
            // 
            // labelDias
            // 
            this.labelDias.AutoSize = true;
            this.labelDias.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDias.Location = new System.Drawing.Point(15, 97);
            this.labelDias.Name = "labelDias";
            this.labelDias.Size = new System.Drawing.Size(152, 22);
            this.labelDias.TabIndex = 4;
            this.labelDias.Text = "¿A cuántos días?";
            // 
            // groupBoxSimulador
            // 
            this.groupBoxSimulador.Controls.Add(this.label1);
            this.groupBoxSimulador.Controls.Add(this.dateTimePickerFecha);
            this.groupBoxSimulador.Controls.Add(this.labelDias);
            this.groupBoxSimulador.Controls.Add(this.labelImporte);
            this.groupBoxSimulador.Controls.Add(this.textBoxImporte);
            this.groupBoxSimulador.Controls.Add(this.panelResultado);
            this.groupBoxSimulador.Controls.Add(this.buttonContinuar);
            this.groupBoxSimulador.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSimulador.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxSimulador.Location = new System.Drawing.Point(16, 93);
            this.groupBoxSimulador.Name = "groupBoxSimulador";
            this.groupBoxSimulador.Size = new System.Drawing.Size(542, 380);
            this.groupBoxSimulador.TabIndex = 1;
            this.groupBoxSimulador.TabStop = false;
            this.groupBoxSimulador.Text = "Simulador de Plazo Fijo";
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePickerFecha.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFecha.Location = new System.Drawing.Point(19, 132);
            this.dateTimePickerFecha.MinDate = new System.DateTime(2023, 12, 10, 0, 0, 0, 0);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(116, 23);
            this.dateTimePickerFecha.TabIndex = 5;
            this.dateTimePickerFecha.Value = new System.DateTime(2024, 6, 18, 10, 47, 58, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "0 días";
            // 
            // UserControlInversion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBoxSimulador);
            this.Controls.Add(this.groupBoxConversion);
            this.Name = "UserControlInversion";
            this.Size = new System.Drawing.Size(577, 490);
            this.groupBoxConversion.ResumeLayout(false);
            this.groupBoxConversion.PerformLayout();
            this.panelResultado.ResumeLayout(false);
            this.panelResultado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).EndInit();
            this.groupBoxSimulador.ResumeLayout(false);
            this.groupBoxSimulador.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMoneda;
        private System.Windows.Forms.TextBox textBoxConversion;
        private System.Windows.Forms.ComboBox comboBoxMoneda;
        private System.Windows.Forms.ComboBox comboBoxConversion;
        private System.Windows.Forms.GroupBox groupBoxConversion;
        private System.Windows.Forms.Button buttonContinuar;
        private System.Windows.Forms.Panel panelResultado;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelInteres;
        private System.Windows.Forms.Label labelTasa;
        private System.Windows.Forms.Label labelHasta;
        private System.Windows.Forms.Label labelGanancias;
        private System.Windows.Forms.Label labelTNA;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.PictureBox pictureBoxImagen;
        private System.Windows.Forms.TextBox textBoxImporte;
        private System.Windows.Forms.Label labelImporte;
        private System.Windows.Forms.Label labelDias;
        private System.Windows.Forms.GroupBox groupBoxSimulador;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
        private System.Windows.Forms.Label label1;
    }
}
