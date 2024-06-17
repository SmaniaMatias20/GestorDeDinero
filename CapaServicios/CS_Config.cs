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
            nfi.CurrencyDecimalDigits = 2;

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

        public static (bool, double, string) ValidarTextBoxNumerico(string importe) 
        {
            if (string.IsNullOrWhiteSpace(importe) || string.IsNullOrWhiteSpace(importe))
            {
                return (false, 0, "Ingrese un importe");
            }

            if (!double.TryParse(importe, out double importeValidado))
            {
                return (false, 0, "Ingrese un numero");
            }

            if (importeValidado <= 0)
            {
                return (false, 0, "Ingrese un numero mayor a 0(cero)");
            }

            return (true, importeValidado, "Ok");
        }

        public static (bool, string) ValidarTextBoxAlfaNumerico(string ingreso)
        {
            if (string.IsNullOrWhiteSpace(ingreso) || string.IsNullOrWhiteSpace(ingreso))
            {
                return (false, "El campo no puede estar vacio");
            }

            return (true, ingreso);

        }

    }
}
