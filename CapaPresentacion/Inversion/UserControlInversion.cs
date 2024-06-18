using CapaEntidades;
using CapaServicios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlInversion : UserControl
    {
       
        // Propiedades
        public Usuario Usuario { get; set; }


        public UserControlInversion()
        {
            // Inicializa los componentes visuales del control de usuario
            InitializeComponent();

            textBoxImporte.KeyPress += CS_Config.textBox_KeyPress;
            textBoxMoneda.KeyPress += CS_Config.textBox_KeyPress;
            //textBoxConversion.KeyPress += CS_Config.textBox_KeyPress;

           
            // Configura el calendario
            CS_Config.ConfigurarDateTimePicker(dateTimePickerFecha);

           
        }

        public UserControlInversion(Usuario usuario) : this()
        {
            Usuario = usuario;
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            CS_Inversion.Simular(textBoxImporte, labelFecha, dateTimePickerFecha, labelTotalDias, labelTotal, labelInteres, labelTasa);
        }

        private void comboBoxConversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxConversion.Text != "")
            {
                CS_Inversion.Convertir(comboBoxMoneda, textBoxMoneda, comboBoxConversion, textBoxConversion);
            }
        }

        private void comboBoxMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxConversion.Text != "")
            {
                 CS_Inversion.Convertir(comboBoxMoneda, textBoxMoneda, comboBoxConversion, textBoxConversion);
            }
        }
    }
}
