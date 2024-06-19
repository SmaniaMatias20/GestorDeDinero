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
        // Atributos
        private const double _tasa = 29.50;
        private static List<Moneda> _monedas;

        /// <summary>
        /// Realiza una simulación de cálculo de intereses y muestra los resultados en controles específicos.
        /// </summary>
        /// <param name="textBoxImporte">El TextBox que contiene el importe a simular.</param>
        /// <param name="labelFecha">El Label donde se mostrará la fecha seleccionada.</param>
        /// <param name="dateTimePickerFecha">El DateTimePicker que proporciona la fecha seleccionada.</param>
        /// <param name="labelTotalDias">El Label donde se mostrará el total de días calculados.</param>
        /// <param name="labelTotal">El Label donde se mostrará el total calculado (importe + intereses).</param>
        /// <param name="labelInteres">El Label donde se mostrarán los intereses calculados.</param>
        /// <param name="labelTasa">El Label donde se mostrará la tasa de interés utilizada.</param>
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
        /// Obtiene el número de días transcurridos entre la fecha seleccionada en un DateTimePicker y la fecha actual.
        /// </summary>
        /// <param name="dateTimePickerFecha">El DateTimePicker que proporciona la fecha seleccionada.</param>
        /// <returns>El número de días transcurridos como un valor double.</returns>
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

            // Retorna 30 dias por defecto
            return 30;
        }

        /// <summary>
        /// Realiza la conversión de una cantidad de dinero de una moneda a otra, utilizando las tasas de cambio disponibles.
        /// </summary>
        /// <param name="comboBox">El ComboBox que contiene la selección de la moneda de origen.</param>
        /// <param name="textBox">El TextBox que contiene la cantidad a convertir.</param>
        /// <param name="comboBox2">El ComboBox que contiene la selección de la moneda de destino.</param>
        /// <param name="textBox2">El TextBox donde se mostrará el resultado de la conversión.</param>
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
        /// Realiza una conexión a una API externa para obtener las últimas tasas de cambio utilizando una clave de API.
        /// </summary>
        /// <returns>Una cadena JSON que contiene las tasas de cambio o null si hay un error.</returns>
        public static string ConexionConAPI()
        {
            // Obtiene la APIKEY
            string apiKey = CS_Config.ObtenerApiKey(); 

            // URL de la API de Open Exchange Rates para obtener las últimas tasas de cambio
            string apiUrl = $"https://api.fastforex.io/fetch-all?api_key={apiKey}";

            // Realizar la solicitud HTTP GET a la API
            using (HttpClient client = new HttpClient())
            {
                // Realiza la solicitud GET asincrónica
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                // Verifica si la solicitud fue exitosa
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

        /// <summary>
        /// Obtiene un listado de monedas con sus valores de cambio desde una API externa.
        /// </summary>
        /// <returns>Una lista de objetos Moneda que representa las monedas y sus valores.</returns>
        /// <exception cref="Exception">Se lanza si el JSON recibido está vacío o nulo.</exception>
        public static List<Moneda> ObtenerListadoDeMonedas() 
        {
            try
            {
                // Realiza la conexión a la API para obtener el JSON con las tasas de cambio
                string json = ConexionConAPI();

                // Verifica que el JSON no esté vacío o nulo
                if (string.IsNullOrEmpty(json))
                {
                    throw new Exception("El JSON recibido está vacío o es nulo.");
                }

                // Deserializa solo el objeto "results" del JSON en un diccionario de string (nombre de la moneda) a double (valor de cambio)
                var resultados = JObject.Parse(json)["results"].ToObject<Dictionary<string, double>>();

                // Crea una lista para almacenar las monedas
                List<Moneda> listaMonedas = new List<Moneda>();

                // Recorre el diccionario de resultados y crea objetos Moneda con cada par nombre-valor
                foreach (var item in resultados)
                {
                    listaMonedas.Add(new Moneda { Nombre = item.Key, Valor = item.Value });
                }

                // Retorna la lista de monedas
                return listaMonedas;
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción y la lanza de nuevo con un mensaje específico
                throw new Exception("Error al obtener el listado de monedas desde la API.", ex);
            }

            //string json = ConexionConAPI();

            //// Verificar que el JSON no esté vacío o nulo
            //if (string.IsNullOrEmpty(json))
            //{
            //    throw new Exception("El JSON recibido está vacío o es nulo.");
            //}

            //// Deserializar solo el objeto "results" del JSON en un diccionario
            //var resultados = JObject.Parse(json)["results"].ToObject<Dictionary<string, double>>();

            //// Crear una lista de Moneda
            //List<Moneda> listaMonedas = new List<Moneda>();

            //foreach (var item in resultados)
            //{
            //    listaMonedas.Add(new Moneda { Nombre = item.Key, Valor = item.Value });
            //}

            //return listaMonedas;
        }

    }
}
