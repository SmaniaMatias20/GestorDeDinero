using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CapaServicios
{
    public static class CS_Config
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string ObtenerApiKey()
        {
            // Leer la API key desde el archivo
            string filePath = "api_key.txt";
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath).Trim();
            }
            else
            {
                throw new FileNotFoundException("El archivo de la clave API no se encontró.");
            }
        }

        /// <summary>
        /// Formatea una cantidad numérica como una cadena en formato de moneda para la cultura de Argentina (es-AR).
        /// </summary>
        /// <param name="cantidad">La cantidad numérica a formatear.</param>
        /// <param name="decimales">El número de decimales a mostrar en el formato de moneda.</param>
        /// <returns>Una cadena que representa la cantidad formateada como moneda.</returns>
        public static string FormatearMoneda(double cantidad, int decimales)
        {
            // Obtiene el formato de número específico para la cultura de Argentina (es-AR)
            var nfi = new System.Globalization.CultureInfo("es-AR", false).NumberFormat;

            // Configura para que no se muestren decimales en el formato de moneda
            nfi.CurrencyDecimalDigits = decimales; //2

            // Convierte la cantidad a una cadena con formato de moneda utilizando la configuración de formato
            return cantidad.ToString("C", nfi);
        }

        /// <summary>
        /// Maneja el evento KeyPress del textBoxIngreso para permitir solo números, un punto decimal y la tecla de retroceso.
        /// </summary>
        /// <param name="sender">El control que generó el evento.</param>
        /// <param name="e">Los datos del evento KeyPress.</param>
        public static void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter no es una tecla de control, un dígito ni un punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Si ya hay un punto decimal en el texto y se presiona otro, se ignora el evento
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(','))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Ordena los datos en el DataGridView según la columna clicada.
        /// </summary>
        /// <typeparam name="T">El tipo de los datos en la lista.</typeparam>
        /// <param name="e">Los argumentos del evento del clic del encabezado de la columna.</param>
        /// <param name="datos">La lista de datos a ordenar.</param>
        public static void OrdenarDataGrid<T>(DataGridViewCellMouseEventArgs e, DataGridView dataGridView, List<T> datos)
        {
            // Obtiene la columna que se ha seleccionado
            DataGridViewColumn columnaSeleccionada = dataGridView.Columns[e.ColumnIndex];

            // Obtiene el nombre de la propiedad que corresponde a la columna seleccionada
            string nombrePropiedad = columnaSeleccionada.DataPropertyName;

            // Ordena los datos manualmente según la columna seleccionada
            if (columnaSeleccionada.SortMode != DataGridViewColumnSortMode.NotSortable)
            {
                // Obtiene el estado actual de ordenación del DataGridView
                SortOrder sortOrder = dataGridView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection;

                // Ordena los datos manualmente según la columna seleccionada
                if (sortOrder == SortOrder.Ascending)
                {
                    // Ordena los datos de forma descendente
                    dataGridView.DataSource = datos.OrderByDescending(x => x.GetType().GetProperty(nombrePropiedad).GetValue(x, null)).ToList();
                    // Actualiza el estado de ordenación del DataGridView a descendente
                    dataGridView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                }
                else
                {
                    // Ordena los datos de forma ascendente
                    dataGridView.DataSource = datos.OrderBy(x => x.GetType().GetProperty(nombrePropiedad).GetValue(x, null)).ToList();
                    // Actualiza el estado de ordenación del DataGridView a ascendente
                    dataGridView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                }
            }

        }

        /// <summary>
        /// Valida que un string no esté vacío, sea numérico y mayor a cero.
        /// </summary>
        /// <param name="importe">El string que representa el importe a validar.</param>
        /// <returns>Un tuple que contiene un booleano indicando si la validación pasó, 
        /// el importe validado como double y un mensaje descriptivo.</returns>
        public static (bool, double, string) ValidarTextBoxNumerico(string importe) 
        {
            // Verificar si el string está vacío o contiene solo espacios en blanco
            if (string.IsNullOrWhiteSpace(importe) || string.IsNullOrWhiteSpace(importe))
            {
                // Retorna false, 0 y un mensaje de error si el string está vacío
                return (false, 0, "Ingrese un importe");
            }
            // Intentar convertir el string a un valor numérico de tipo double
            if (!double.TryParse(importe, out double importeValidado))
            {
                // Retorna false, 0 y un mensaje de error si la conversión falla
                return (false, 0, "Ingrese un numero");
            }
            // Verificar si el valor numérico es mayor a 0
            if (importeValidado <= 0)
            {
                // Retorna false, 0 y un mensaje de error si el valor es menor o igual a 0
                return (false, 0, "Ingrese un numero mayor a 0(cero)");
            }
            // Si pasa las validaciones, retorna true, el valor numérico validado y "Ok"
            return (true, importeValidado, "Ok");
        }

        /// <summary>
        /// Valida que un string no esté vacío, sea alfanumérico y no contenga más de 20 caracteres.
        /// </summary>
        /// <param name="ingreso">El string a validar.</param>
        /// <returns>Un tuple que contiene un booleano indicando si la validación pasó y un mensaje.</returns>
        public static (bool, string) ValidarTextBoxAlfaNumerico(string ingreso)
        {
            // Verificar si el string está vacío o contiene solo espacios en blanco
            if (string.IsNullOrWhiteSpace(ingreso) || string.IsNullOrWhiteSpace(ingreso))
            {
                // Retorna false con un mensaje de error si el string está vacío
                return (false, "El campo no puede estar vacio");
            }
            // Verificar si el string contiene más de 20 caracteres
            if (ingreso.Length > 20)
            {
                // Retorna false con un mensaje de error si el string tiene más de 20 caracteres
                return (false, "El campo no puede contener más de 20 caracteres");
            }
            // Si pasa las validaciones, retorna true con el string de entrada
            return (true, ingreso);

        }

        /// <summary>
        /// Configura un control DateTimePicker para limitar las fechas seleccionables entre un mes a partir de hoy y un año a partir de hoy.
        /// </summary>
        /// <param name="dateTimePickerFecha">El control DateTimePicker que se va a configurar.</param>
        public static void ConfigurarDateTimePicker(DateTimePicker dateTimePickerFecha)
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

        /// <summary>
        /// Obtiene el número de decimales de una cantidad numérica.
        /// </summary>
        /// <param name="cantidad">La cantidad numérica de la cual se desea conocer los decimales.</param>
        /// <returns>El número de decimales de la cantidad.</returns>
        public static int ObtenerDecimales(double cantidad) 
        {
            // Declara la variable decimales
            int decimales;
            // Si la cantidad es menor que 1, se determina el número de decimales necesarios para representarla
            if (cantidad < 1)
            {
                // Asigna el valor de la cantidad recibida por parametro
                double valor = cantidad;
                // Inicializa la variable en 0
                decimales = 0;
                // Se incrementa el número de decimales hasta que el valor sea mayor o igual a 1
                while (valor < 1)
                {
                    // Multiplica por 10 el valor en cada vuelta
                    valor = valor * 10;
                    // Incrementa en 1 la variable en cada vuelta
                    decimales++;
                }
                // Retorna la cantidad de decimales
                return decimales;
            }
            else
            {
                // Retorna 2 decimales por defecto
                return 2;   
            }
        }

    }
}
