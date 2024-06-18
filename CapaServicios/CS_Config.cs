using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CapaServicios
{
    public static class CS_Config
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static string FormatearMoneda(double cantidad)
        {
            // Obtiene el formato de número específico para la cultura de Argentina (es-AR)
            var nfi = new System.Globalization.CultureInfo("es-AR", false).NumberFormat;

            // Configura para que no se muestren decimales en el formato de moneda
            nfi.CurrencyDecimalDigits = 2; //2

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
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(','))
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

    }
}
