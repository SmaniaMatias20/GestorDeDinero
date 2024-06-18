using CapaEntidades;
using CapaServicios;
using System.Globalization;
using System;
using System.Linq;
using System.Threading.Tasks;
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
            textBoxConversion.KeyPress += CS_Config.textBox_KeyPress;

            // Tasa de interés actual
            labelTasa.Text = "29,50%";

            // Calcula la fecha mínima permitida (por ejemplo, un mes a partir de hoy)
            DateTime fechaMinima = DateTime.Today.AddMonths(1);

            // Configura el DateTimePicker para que permita seleccionar fechas a partir de la fecha mínima
            dateTimePickerFecha.MinDate = fechaMinima;


        }

        public UserControlInversion(Usuario usuario) : this()
        {
            // Asigna el usuario recibido por parámetro al atributo de la clase
            Usuario = usuario;
        }



        private void buttonContinuar_Click(object sender, System.EventArgs e)
        {
            Simular();
        }

        private double ConvertirLabelTasa() 
        {
            string tasa = "";
            if (labelTasa.Text.Contains("%"))
            {
                tasa = labelTasa.Text.Replace("%", "");
            }

            if (double.TryParse(tasa, out double importeTasa))
            {
            }

            return importeTasa;
        }

        private void Simular() 
        {
            // Obtiene la fecha de final
            labelFecha.Text = dateTimePickerFecha.Text;
            // Obtiene los dias transcurridos
            double dias = ObtenerDias();
            // Convierte la tasa en importe
            double importeTasa = ConvertirLabelTasa();
            // Obtiene los intereses anuales
            double interesesAnuales = (double.Parse(textBoxImporte.Text) * importeTasa) / 100;
            // Obtiene los intereses de acuerdo a los dias ingresados 
            double interesesGanados = (dias * interesesAnuales) / 365;
            // Obtiene el total de la suma del importe mas los intereses
            double total = double.Parse(textBoxImporte.Text) + interesesGanados;
            // Muestra el total en el label
            labelTotal.Text = CS_Config.FormatearMoneda(total);
            // Muestra los intereses en el label
            labelInteres.Text = CS_Config.FormatearMoneda(interesesGanados);
        }

        private double ObtenerDias() 
        {
            // Obtener la fecha de hoy
            DateTime fechaDeHoy = DateTime.Today;

            // Obtener la fecha del label y convertirla a DateTime
            DateTime fechaDesdeLabel;
            if (DateTime.TryParseExact(dateTimePickerFecha.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDesdeLabel))
            {
                // Calcular los días transcurridos
                TimeSpan diferencia = fechaDesdeLabel - fechaDeHoy;
                double diasTranscurridos = diferencia.TotalDays;

                return diasTranscurridos;
            }

            return 30;
        }
    }
}
