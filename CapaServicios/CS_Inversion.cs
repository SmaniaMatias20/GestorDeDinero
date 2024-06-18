using System.Globalization;
using System;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using System.Net.Http;
using System.Collections.Generic;
using CapaEntidades.Entidades;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace CapaServicios
{
    public static class CS_Inversion
    {
        private const double _tasa = 29.50;
        private static List<Moneda> _monedas;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textBoxImporte"></param>
        /// <param name="labelFecha"></param>
        /// <param name="dateTimePickerFecha"></param>
        /// <param name="labelTotalDias"></param>
        /// <param name="labelTotal"></param>
        /// <param name="labelInteres"></param>
        /// <param name="labelTasa"></param>
        public static void Simular(TextBox textBoxImporte, Label labelFecha, DateTimePicker dateTimePickerFecha, Label labelTotalDias, Label labelTotal, Label labelInteres, Label labelTasa)
        {
            // Valida lo ingresado en el textbox
            var (validacion, importeIngresado, mensaje) = CS_Config.ValidarTextBoxNumerico(textBoxImporte.Text);
            // Si pasa la validacion entra al condicional
            if (validacion)
            {
                // Obtiene la fecha de final
                labelFecha.Text = dateTimePickerFecha.Text;
                // Muestra la tasa de interes anual
                labelTasa.Text = $"{_tasa}%";
                // Obtiene los dias transcurridos
                double dias = ObtenerDias(dateTimePickerFecha);
                // Muestra el total de dias
                labelTotalDias.Text = $"{dias} días";
                // Obtiene los intereses anuales
                double interesesAnuales = (double.Parse(textBoxImporte.Text) * _tasa) / 100;
                // Obtiene los intereses de acuerdo a los dias ingresados 
                double interesesGanados = (dias * interesesAnuales) / 365;
                // Obtiene el total de la suma del importe mas los intereses
                double total = importeIngresado + interesesGanados;
                // Muestra el total en el label
                labelTotal.Text = CS_Config.FormatearMoneda(total, 2);
                // Muestra los intereses en el label
                labelInteres.Text = CS_Config.FormatearMoneda(interesesGanados, 2);
            }
            else
            {
                // Mensaje de advertencia
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTimePickerFecha"></param>
        /// <returns></returns>
        private static double ObtenerDias(DateTimePicker dateTimePickerFecha)
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
                // Retorna los dias transcurridos
                return diasTranscurridos;
            }

            return 30;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="textBox"></param>
        /// <param name="comboBox2"></param>
        /// <param name="textBox2"></param>
        public static void Convertir(ComboBox comboBox, TextBox textBox, ComboBox comboBox2, TextBox textBox2)
        {
            // Obtiene el listado de monedas
            _monedas = ObtenerListadoDeMonedas();

            // Asegúrate de que _monedas esté inicializado y contenga datos
            if (_monedas == null || _monedas.Count == 0)
            {
                MessageBox.Show("No se han cargado las tasas de cambio.");
                return;
            }

            // Crear un diccionario para facilitar la búsqueda de tasas de cambio
            var tasasDeCambio = _monedas.ToDictionary(m => m.Nombre, m => m.Valor);

            // Obtener las monedas seleccionadas y la cantidad a convertir
            string monedaOrigen = comboBox.Text;
            string monedaDestino = comboBox2.Text;
            if (!double.TryParse(textBox.Text, out double cantidad))
            {
                MessageBox.Show("Cantidad inválida.");
                return;
            }

            // Verificar que ambas monedas existen en la lista de tasas de cambio
            if (!tasasDeCambio.ContainsKey(monedaOrigen) || !tasasDeCambio.ContainsKey(monedaDestino))
            {
                MessageBox.Show("Moneda no encontrada en las tasas de cambio.");
                return;
            }

            // Obtener las tasas de cambio para las monedas seleccionadas
            double tasaOrigen = tasasDeCambio[monedaOrigen];
            double tasaDestino = tasasDeCambio[monedaDestino];

            // Calcular la cantidad convertida
            double cantidadConvertida = cantidad * (tasaDestino / tasaOrigen);
            // Obtiene la cantidad de decimales necesarias para evitar 0,00
            int decimales = CS_Config.ObtenerDecimales(cantidadConvertida);
            // Muestra el resultado en el textbox
            textBox2.Text = CS_Config.FormatearMoneda(cantidadConvertida, decimales);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string ConexionConAPI()
        {
            // Obtiene la APIKEY
            string apiKey = CS_Config.ObtenerApiKey(); 

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
                    // Retorna los datos
                    return json;
                }
                else
                {
                    // Mensaje de error al conectar con la API
                    MessageBox.Show("Error al conectar con la API");
                    // Retorna un null
                    return null;
                }
            }

        }

        public static List<Moneda> ObtenerListadoDeMonedas() 
        {

            string json = ConexionConAPI();

            // Verificar que el JSON no esté vacío o nulo
            if (string.IsNullOrEmpty(json))
            {
                throw new Exception("El JSON recibido está vacío o es nulo.");
            }

            // Deserializar solo el objeto "results" del JSON en un diccionario
            var resultados = JObject.Parse(json)["results"].ToObject<Dictionary<string, double>>();

            // Crear una lista de Moneda
            List<Moneda> listaMonedas = new List<Moneda>();

            foreach (var item in resultados)
            {
                listaMonedas.Add(new Moneda { Nombre = item.Key, Valor = item.Value });
            }

            return listaMonedas;
        }

    }
}
