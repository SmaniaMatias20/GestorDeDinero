using CapaEntidades;
using CapaServicios;
using System.Globalization;
using System;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json.Nodes;


namespace CapaPresentacion
{
    public partial class UserControlInversion : UserControl
    {
        private const double _tasa = 29.50;


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
            labelTasa.Text = $"{_tasa}%";
            // Configura el calendario
            ConfigurarDateTimePicker();

            JsonObject datosMonedas = (JsonObject)ConexionConAPI();
        }

        public UserControlInversion(Usuario usuario) : this()
        {
            // Asigna el usuario recibido por parámetro al atributo de la clase
            Usuario = usuario;
        }

        private void Convertir() 
        {
            var (validacion, importeIngresado, mensaje) = CS_Config.ValidarTextBoxNumerico(textBoxMoneda.Text);
            if (validacion)
            {

                
            }
            else
            {
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }



        private void buttonContinuar_Click(object sender, System.EventArgs e)
        {
            Simular();
        }

        private void Simular() 
        {
            var(validacion, importeIngresado, mensaje) = CS_Config.ValidarTextBoxNumerico(textBoxImporte.Text);
            if (validacion)
            {
                // Obtiene la fecha de final
                labelFecha.Text = dateTimePickerFecha.Text;
                // Obtiene los dias transcurridos
                double dias = ObtenerDias();
                // Muestra el total de dias
                labelTotalDias.Text = $"{dias} días";
                // Obtiene los intereses anuales
                double interesesAnuales = (double.Parse(textBoxImporte.Text) * _tasa) / 100;
                // Obtiene los intereses de acuerdo a los dias ingresados 
                double interesesGanados = (dias * interesesAnuales) / 365;
                // Obtiene el total de la suma del importe mas los intereses
                double total = importeIngresado + interesesGanados;
                // Muestra el total en el label
                labelTotal.Text = CS_Config.FormatearMoneda(total);
                // Muestra los intereses en el label
                labelInteres.Text = CS_Config.FormatearMoneda(interesesGanados);
            }
            else
            {
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void ConfigurarDateTimePicker() 
        {
            // Calcula la fecha mínima permitida (por ejemplo, un mes a partir de hoy)
            DateTime fechaMinima = DateTime.Today.AddMonths(1);

            // Configura el DateTimePicker para que permita seleccionar fechas a partir de la fecha mínima
            dateTimePickerFecha.MinDate = fechaMinima;

            // Calcula la fecha máxima permitida (un año a partir de hoy)
            DateTime fechaMaxima = DateTime.Today.AddYears(1);

            // Configura el DateTimePicker para que permita seleccionar fechas hasta la fecha máxima
            dateTimePickerFecha.MaxDate = fechaMaxima;
        }

        private string ConexionConAPI() 
        {
            string apiKey = "1dfd46d7fc-f346d50da8-sfa65n"; // Reemplaza con tu clave API de Open Exchange Rates

            // URL de la API de Open Exchange Rates para obtener las últimas tasas de cambio
            string apiUrl = $"https://api.fastforex.io/fetch-all?api_key={apiKey}";

            // Realizar la solicitud HTTP GET a la API
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta JSON
                    string json = response.Content.ReadAsStringAsync().Result;
                    return json;
                }
                else
                {
                    MessageBox.Show("Error");
                    return "";
                }
            }

        }

    }
}
