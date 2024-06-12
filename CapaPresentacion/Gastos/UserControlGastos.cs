using CapaEntidades;
using CapaServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlGastos : UserControl
    {
        // Atributos
        private CS_Usuario _csUsuario;
        private CS_Gasto _csGasto;

        // Propiedades
        public Usuario Usuario { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserControlGastos()
        {
            // Inicializa los componentes visuales del control de usuario
            InitializeComponent();
            // Crea una nueva instancia de CS_Usuario para manejar la lógica relacionada con el usuario
            _csUsuario = new CS_Usuario();
            // Crea una nueva instancia de CS_Usuario para manejar la lógica relacionada con los gastos
            _csGasto = new CS_Gasto();  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        public UserControlGastos(Usuario usuario) : this()
        {
            // Asigna el usuario recibido por parámetro al atributo de la clase
            Usuario = usuario;
            // Actualiza y muestra los gastos
            ActualizarGastos();
            // Registra el controlador de eventos para el evento ColumnHeaderMouseClick
            dataGridViewGastos.ColumnHeaderMouseClick += DataGridViewGastos_ColumnHeaderMouseClick;
            // Deshabilita el boton modificar
            buttonModificar.Enabled = false;
            // Asigna el metodo para solamente poder ingresar numeros
            textBoxImporte.KeyPress += textBox_KeyPress;
        }
        private void UserControlGastos_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void ActualizarGastos()
        {
            // Obtener la lista de gastos para el usuario actual
            Usuario.Gastos = _csGasto.ObtenerGastosPorId(Usuario.Id);
            // Establecer la lista de gastos como la fuente de datos del DataGridView
            dataGridViewGastos.DataSource = Usuario.Gastos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewGastos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OrdenarDataGrid(e, Usuario.Gastos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <param name="datos"></param>
        private void OrdenarDataGrid<T>(DataGridViewCellMouseEventArgs e, List<T> datos)
        {
            // Obtiene la columna que se ha seleccionado
            DataGridViewColumn columnaSeleccionada = dataGridViewGastos.Columns[e.ColumnIndex];

            // Obtiene el nombre de la propiedad que corresponde a la columna seleccionada
            string nombrePropiedad = columnaSeleccionada.DataPropertyName;

            // Ordena los datos manualmente según la columna seleccionada
            if (columnaSeleccionada.SortMode != DataGridViewColumnSortMode.NotSortable)
            {
                // Obtiene el estado actual de ordenación del DataGridView
                SortOrder sortOrder = dataGridViewGastos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection;

                // Ordena los datos manualmente según la columna seleccionada
                if (sortOrder == SortOrder.Ascending)
                {
                    // Ordena los datos de forma descendente
                    dataGridViewGastos.DataSource = datos.OrderByDescending(x => x.GetType().GetProperty(nombrePropiedad).GetValue(x, null)).ToList();
                    // Actualiza el estado de ordenación del DataGridView a descendente
                    dataGridViewGastos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                }
                else
                {
                    // Ordena los datos de forma ascendente
                    dataGridViewGastos.DataSource = datos.OrderBy(x => x.GetType().GetProperty(nombrePropiedad).GetValue(x, null)).ToList();
                    // Actualiza el estado de ordenación del DataGridView a ascendente
                    dataGridViewGastos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                }
            }

        }

        /// <summary>
        /// Maneja el evento KeyPress del textBoxIngreso para permitir solo números, un punto decimal y la tecla de retroceso.
        /// </summary>
        /// <param name="sender">El control que generó el evento.</param>
        /// <param name="e">Los datos del evento KeyPress.</param>
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que quieres agregar un nuevo gasto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Si el usuario hace clic en "Sí"
            if (result == DialogResult.Yes)
            {
                // Registra el gasto
                string mensaje = _csGasto.RegistrarGasto(Usuario.Id, double.Parse(textBoxImporte.Text), comboBoxGasto.Text, dateTimePickerFecha.Text, comboBoxPago.Text,textBoxDescripcion.Text);

                // Notificar que los fondos han sido actualizados
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Vaciar los campos
                VaciarCampos();

                // Muestra y actualiza los gastos
                ActualizarGastos();
            }

        }

        private void VaciarCampos() 
        {
            textBoxDescripcion.Text = "";
            comboBoxGasto.Text = "";
            dateTimePickerFecha.Text = "";
            comboBoxPago.Text = "";
            textBoxImporte.Text = "";
            textBoxDescripcion.Text = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            // Realiza una pregunta al usuario
            DialogResult result = MessageBox.Show("¿Está seguro que quieres eliminar el gasto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Si el usuario hace clic en "Sí", cerrar la aplicación
            if (result == DialogResult.Yes)
            {
                // Eliminamos el gasto
                string mensaje = EliminarGasto();
                MessageBox.Show(mensaje, "Mensaje");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string EliminarGasto() 
        {
            // Obtiene los elementos seleccionados en el dataGrid
            List<(int Id, double Importe)> gastosAEliminar = ObtenerSeleccionadosDataGrid(dataGridViewGastos);
            if (gastosAEliminar.Count > 0)
            {
                // Recorre los elementos seleccionados
                foreach (var gasto in gastosAEliminar)
                {
                    // Elimina cada elemento seleccionado por su ID
                    _csGasto.EliminarGastoPorId(gasto.Id);
                }
                // Actualiza el dataGrid
                ActualizarGastos();
                return "Registro eliminado exitosamente...";
            }
            else
            {
                return "No ha seleccionado ningun registro...";
            }
        }

        /// <summary>
        /// Obtiene una lista de tuplas que contienen el ID y el importe de las filas seleccionadas en un DataGridView.
        /// </summary>
        /// <param name="dataGrid">El DataGridView del cual se obtendrán las filas seleccionadas.</param>
        /// <returns>Una lista de tuplas (int Id, double Importe) con los datos de las filas seleccionadas.</returns>
        private List<(int Id, double Importe)> ObtenerSeleccionadosDataGrid(DataGridView dataGrid)
        {
            // Crear una lista para almacenar los IDs y los importes de las reservas que se van a eliminar
            List<(int Id, double Importe)> elementosAEliminar = new List<(int, double)>();

            // Recorrer las filas seleccionadas en el DataGridView
            foreach (DataGridViewRow row in dataGridViewGastos.SelectedRows)
            {
                int id;
                double importe;
                // Intentar obtener el ID y el importe de las celdas correspondientes
                if (int.TryParse(row.Cells["Id"].Value.ToString(), out id) &&
                    double.TryParse(row.Cells["Importe"].Value.ToString(), out importe))
                {
                    // Retornar la lista de elementos seleccionados
                    elementosAEliminar.Add((id, importe));
                }
            }

            // Retorna la lista
            return elementosAEliminar;
        }
    }
}
