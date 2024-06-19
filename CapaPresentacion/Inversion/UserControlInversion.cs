using CapaEntidades;
using CapaServicios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlInversion : UserControl
    {
       
        // Propiedades
        public Usuario Usuario { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserControlInversion()
        {
            // Inicializa los componentes visuales del control de usuario
            InitializeComponent();

            textBoxImporte.KeyPress += CS_Config.textBox_KeyPress;
            textBoxMoneda.KeyPress += CS_Config.textBox_KeyPress;

            // Configura el calendario
            CS_Config.ConfigurarDateTimePicker(dateTimePickerFecha);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        public UserControlInversion(Usuario usuario) : this()
        {
            Usuario = usuario;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            CS_Inversion.Simular(textBoxImporte, labelFecha, dateTimePickerFecha, labelTotalDias, labelTotal, labelInteres, labelTasa);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxConversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxConversion.Text) && !string.IsNullOrEmpty(comboBoxMoneda.Text) && !string.IsNullOrEmpty(textBoxMoneda.Text))
            {
                var (validacion, importe, mensaje) = CS_Config.ValidarTextBoxNumerico(textBoxMoneda.Text);
                if (validacion)
                {
                    CS_Inversion.Convertir(comboBoxMoneda, textBoxMoneda, comboBoxConversion, textBoxConversion, importe.ToString());
                }
                else
                {
                    MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(comboBoxConversion.Text) && !string.IsNullOrEmpty(comboBoxMoneda.Text) && !string.IsNullOrEmpty(textBoxMoneda.Text))
            {
                var (validacion, importe, mensaje) = CS_Config.ValidarTextBoxNumerico(textBoxMoneda.Text);
                if (validacion)
                {
                    CS_Inversion.Convertir(comboBoxMoneda, textBoxMoneda, comboBoxConversion, textBoxConversion, importe.ToString());
                }
                else
                {
                    MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxMoneda_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMoneda.Text))
            {
                textBoxMoneda.BackColor = Color.Red;
            }
            else
            {
                textBoxMoneda.BackColor = Color.White;
            }
        }

        private void textBoxMoneda_Leave(object sender, EventArgs e)
        {
            // Verificar si el texto es un número válido
            if (Double.TryParse(textBoxMoneda.Text, out double valor))
            {
                // Formatea el número como moneda con 2 decimales y actualiza el texto del cuadro de texto
                textBoxMoneda.Text = CS_Config.FormatearMoneda(valor, 2);
            }
        }

        private void textBoxImporte_Leave(object sender, EventArgs e)
        {
            // Verificar si el texto es un número válido
            if (Double.TryParse(textBoxImporte.Text, out double valor))
            {
                // Formatea el número como moneda con 2 decimales y actualiza el texto del cuadro de texto
                textBoxImporte.Text = CS_Config.FormatearMoneda(valor, 2);
            }
        }
    }
}
