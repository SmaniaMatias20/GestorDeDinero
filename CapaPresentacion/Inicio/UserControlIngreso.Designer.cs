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
            this.textBoxIngreso = new System.Windows.Forms.TextBox();
            this.buttonAceptarIngreso = new System.Windows.Forms.Button();
            this.buttonBorrarIngreso = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelIngreso = new System.Windows.Forms.Label();
            this.labelImporte = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxIngreso
            // 
            this.textBoxIngreso.Location = new System.Drawing.Point(271, 153);
            this.textBoxIngreso.Name = "textBoxIngreso";
            this.textBoxIngreso.Size = new System.Drawing.Size(160, 20);
            this.textBoxIngreso.TabIndex = 1;
            this.textBoxIngreso.TextChanged += new System.EventHandler(this.textBoxIngreso_TextChanged);
            this.textBoxIngreso.Leave += new System.EventHandler(this.textBoxIngreso_Leave);
            // 
            // buttonAceptarIngreso
            // 
            this.buttonAceptarIngreso.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonAceptarIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAceptarIngreso.FlatAppearance.BorderSize = 0;
            this.buttonAceptarIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAceptarIngreso.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAceptarIngreso.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAceptarIngreso.Location = new System.Drawing.Point(271, 189);
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
            this.buttonBorrarIngreso.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBorrarIngreso.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBorrarIngreso.Location = new System.Drawing.Point(356, 189);
            this.buttonBorrarIngreso.Name = "buttonBorrarIngreso";
            this.buttonBorrarIngreso.Size = new System.Drawing.Size(75, 23);
            this.buttonBorrarIngreso.TabIndex = 3;
            this.buttonBorrarIngreso.Text = "Borrar";
            this.buttonBorrarIngreso.UseVisualStyleBackColor = false;
            this.buttonBorrarIngreso.Click += new System.EventHandler(this.buttonBorrarIngreso_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.ingreso;
            this.pictureBox1.Location = new System.Drawing.Point(0, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 237);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelIngreso);
            this.panel1.Location = new System.Drawing.Point(117, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 74);
            this.panel1.TabIndex = 14;
            // 
            // labelIngreso
            // 
            this.labelIngreso.AutoSize = true;
            this.labelIngreso.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIngreso.ForeColor = System.Drawing.Color.White;
            this.labelIngreso.Location = new System.Drawing.Point(59, 21);
            this.labelIngreso.Name = "labelIngreso";
            this.labelIngreso.Size = new System.Drawing.Size(132, 32);
            this.labelIngreso.TabIndex = 5;
            this.labelIngreso.Text = "Ingresar...";
            // 
            // labelImporte
            // 
            this.labelImporte.AutoSize = true;
            this.labelImporte.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImporte.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelImporte.Location = new System.Drawing.Point(268, 132);
            this.labelImporte.Name = "labelImporte";
            this.labelImporte.Size = new System.Drawing.Size(57, 15);
            this.labelImporte.TabIndex = 16;
            this.labelImporte.Text = "Importe";
            // 
            // UserControlIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.labelImporte);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonBorrarIngreso);
            this.Controls.Add(this.buttonAceptarIngreso);
            this.Controls.Add(this.textBoxIngreso);
            this.Name = "UserControlIngreso";
            this.Size = new System.Drawing.Size(530, 258);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxIngreso;
        private System.Windows.Forms.Button buttonAceptarIngreso;
        private System.Windows.Forms.Button buttonBorrarIngreso;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label labelIngreso;
        private Label labelImporte;
    }
}
