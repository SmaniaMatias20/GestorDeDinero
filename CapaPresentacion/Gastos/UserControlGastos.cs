using CapaEntidades;
using CapaEntidades.Entidades;
using CapaServicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class UserControlGastos : UserControl
    {
        public bool estadoModificacion = false;
        public int idGasto = 0;

        // Propiedades
        public Usuario Usuario { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public UserControlGastos()
        {
            // Inicializa los componentes visuales del control de usuario
            InitializeComponent();
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
            // Asigna el metodo para solamente poder ingresar numeros
            textBoxImporte.KeyPress += CS_Config.textBox_KeyPress;
            textBoxFiltroImporteMax.KeyPress += CS_Config.textBox_KeyPress;   
            textBoxFiltroImporteMin.KeyPress += CS_Config.textBox_KeyPress;
        }

        /// <summary>
        /// Actualiza los gastos del usuario actual y establece la fuente de datos del DataGridView a la lista de gastos actualizada.
        /// </summary>
        private void ActualizarGastos()
        {
            // Obtener la lista de gastos para el usuario actual
            Usuario.Gastos = CS_Gasto.ObtenerGastosPorId(Usuario.Id);
            // Establecer la lista de gastos como la fuente de datos del DataGridView
            dataGridViewGastos.DataSource = Usuario.Gastos;
        }

        /// <summary>
        /// Maneja el evento de clic del encabezado de columna del DataGridView de gastos.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento del clic en el encabezado de columna del DataGridView.</param>
        private void DataGridViewGastos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Llama al método OrdenarDataGrid con los parámetros del evento y la lista de gastos del usuario
            CS_Config.OrdenarDataGrid(e, dataGridViewGastos, Usuario.Gastos);
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Aceptar".
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            const string GastoRegistrado = "Gasto registrado";
            const string GastoModificado = "Gasto modificado";

            // Registra el gasto
            string mensaje = CS_Gasto.RegistrarGasto(Usuario.Id, textBoxImporte.Text, comboBoxGasto.Text, dateTimePickerFecha.Text, comboBoxPago.Text, textBoxDescripcion.Text, estadoModificacion, idGasto);

            // Notificar que los fondos han sido actualizados
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (mensaje == GastoRegistrado || mensaje == GastoModificado)
            {
                //Vaciar los campos
                VaciarCampos();
                // Muestra y actualiza los gastos
                ActualizarGastos();
                // Cambia el estado de modificacion
                estadoModificacion = false;
            }

        }

        /// <summary>
        /// Vacía los campos del formulario de registro de gastos.
        /// </summary>
        private void VaciarCampos()
        {
            // Limpiar el campo de texto de la descripción
            textBoxDescripcion.Text = "";
            // Limpiar la selección del comboBox de gasto
            comboBoxGasto.Text = "";
            // Limpiar la selección del comboBox de pago
            comboBoxPago.Text = "";
            // Limpiar el campo de texto del importe
            textBoxImporte.Text = "";
            // Limpiar nuevamente el campo de texto de la descripción (esto es redundante)
            textBoxDescripcion.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Eliminar".
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            // Realiza una pregunta al usuario
            DialogResult result = MessageBox.Show("¿Está seguro que quieres eliminar el gasto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Si el usuario hace clic en "Sí", cerrar la aplicación
            if (result == DialogResult.Yes)
            {
                // Elimina el gasto
                string mensaje = EliminarGasto();
                // Muestra un mensaje indicando el resultado de la eliminación
                MessageBox.Show(mensaje, "Mensaje");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string EliminarGasto()
        {
            const string RegistroEliminado = "Registro eliminado exitosamente...";
            const string ErrorAlEliminar = "No ha seleccionado ningun registro...";

            // Obtiene los elementos seleccionados en el dataGrid
            List<(int Id, double Importe)> gastosAEliminar = ObtenerSeleccionadosDataGrid(dataGridViewGastos);
            // Verifica si hay elementos seleccionados
            if (gastosAEliminar.Count > 0)
            {
                // Recorre los elementos seleccionados
                foreach (var gasto in gastosAEliminar)
                {
                    // Elimina cada elemento seleccionado por su ID
                    CS_Gasto.EliminarGastoPorId(gasto.Id);
                }
                // Actualiza el dataGrid
                ActualizarGastos();
                // Retorna un mensaje
                return RegistroEliminado;
            }
            else
            {
                // Retorna un mensaje
                return ErrorAlEliminar;
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

        /// <summary>
        /// Maneja el evento de clic del botón "Modificar".
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            // Cambia el estado de modificación a verdadero
            estadoModificacion = true;
            // Obtiene el ID del gasto a modificar llamando al método ModificarGasto
            idGasto = ModificarGasto();
        }

        /// <summary>
        /// Obtiene el gasto seleccionado y llena los campos del formulario con sus datos para su modificación.
        /// </summary>
        /// <returns>El ID del gasto seleccionado o 0 si no hay una selección válida.</returns>
        private int ModificarGasto()
        {
            // Verifica si hay filas seleccionadas en el DataGridView
            if (dataGridViewGastos.SelectedRows.Count > 0)
            {
                // Obtiene la primera fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridViewGastos.SelectedRows[0];
                // Obtiene el ID del gasto seleccionado de la celda "id"
                int idGastoSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["id"].Value);
                // Obtiene el gasto de la base de datos utilizando el ID
                Gasto gasto = CS_Gasto.ObtenerGastoPorId(idGastoSeleccionado);

                // Llena los campos del formulario con los datos del gasto obtenido
                textBoxImporte.Text = gasto.Importe.ToString();
                textBoxDescripcion.Text = gasto.Descripcion;
                comboBoxGasto.Text = gasto.Tipo.ToString();
                comboBoxPago.Text = gasto.Pago.ToString();  
                dateTimePickerFecha.Text = gasto.Fecha.ToString();
                // Retorna el ID del gasto seleccionado
                return gasto.Id;
            }
            // Si no hay filas seleccionadas, retorna 0
            return 0;
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            dataGridViewGastos.DataSource = CS_Gasto.BuscarGastoFiltrado(
                Usuario.Id,
                textBoxFiltroImporteMin.Text,
                textBoxFiltroImporteMax.Text,
                comboBoxFiltroGasto.Text,
                comboBoxFiltroPago.Text
            );
        }

        
        
    }
}
