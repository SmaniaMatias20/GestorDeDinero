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
        /// Constructor sin parámetros de la clase UserControlInversion.
        /// Inicializa los componentes visuales del control de usuario y configura las restricciones de entrada y el calendario.
        /// </summary>
        public UserControlInversion()
        {
            // Inicializa los componentes visuales del control de usuario
            InitializeComponent();
            // Para ingresar solo numeros en el textbox
            textBoxImporte.KeyPress += CS_Config.textBox_KeyPress;
            // Para ingresar solo numeros en el textbox
            textBoxMoneda.KeyPress += CS_Config.textBox_KeyPress;
            // Configura el calendario
            CS_Config.ConfigurarDateTimePicker(dateTimePickerFecha);
        }

        /// <summary>
        /// Constructor de la clase UserControlInversion.
        /// Inicializa una nueva instancia de la clase y asigna el usuario.
        /// </summary>
        public UserControlInversion(Usuario usuario) : this()
        {
            // Asigna el usuario recibido por parámetro al atributo de la clase
            Usuario = usuario;
        }

        /// <summary>
        /// Maneja el evento de clic para el botón "Continuar".
        /// Inicia la simulación del plazo fijo utilizando los datos proporcionados.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            // Simula el plazo fijo utilizando los datos proporcionados en los controles de la interfaz
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
        /// Maneja el evento de cambio de selección para el comboBoxMoneda.
        /// Valida la entrada y realiza la conversión de moneda si todos los campos necesarios están completos.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void comboBoxMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica que los campos de texto y comboBox no estén vacíos
            if (!string.IsNullOrEmpty(comboBoxConversion.Text) && !string.IsNullOrEmpty(comboBoxMoneda.Text) && !string.IsNullOrEmpty(textBoxMoneda.Text))
            {
                // Valida que el contenido de textBoxMoneda sea un número válido
                var (validacion, importe, mensaje) = CS_Config.ValidarTextBoxNumerico(textBoxMoneda.Text);
                // Si la validación es exitosa
                if (validacion)
                {
                    // Realiza la conversión de moneda utilizando los datos proporcionados
                    CS_Inversion.Convertir(comboBoxMoneda, textBoxMoneda, comboBoxConversion, textBoxConversion, importe.ToString());
                }
                else
                {
                    // Muestra un mensaje de advertencia si la validación falla
                    MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de texto para el textBoxMoneda.
        /// Cambia el color de fondo del campo de texto dependiendo de si está vacío o no.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void textBoxMoneda_TextChanged(object sender, EventArgs e)
        {
            // Verifica si el campo de texto está vacío
            if (string.IsNullOrEmpty(textBoxMoneda.Text))
            {
                // Si el campo de texto está vacío, cambia el color de fondo a rojo
                textBoxMoneda.BackColor = Color.Red;
            }
            else
            {
                // Si el campo de texto no está vacío, cambia el color de fondo a blanco
                textBoxMoneda.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Maneja el evento de pérdida de foco para el textBoxMoneda.
        /// Formatea el contenido del campo de texto como una cantidad de dinero si es un número válido al perder el foco.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void textBoxMoneda_Leave(object sender, EventArgs e)
        {
            // Verificar si el texto es un número válido
            if (Double.TryParse(textBoxMoneda.Text, out double valor))
            {
                // Formatea el número como moneda con 2 decimales y actualiza el texto del cuadro de texto
                textBoxMoneda.Text = CS_Config.FormatearMoneda(valor, 2);
            }
        }

        /// <summary>
        /// Maneja el evento de pérdida de foco para el textBoxImporte.
        /// Formatea el contenido del campo de texto como una cantidad de dinero si es un número válido al perder el foco.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
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
