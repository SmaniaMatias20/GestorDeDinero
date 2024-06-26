﻿using CapaDatos;
using CapaEntidades;
using CapaServicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlInicio : UserControl
    {
        // Atributos
        private bool _fondosVisibles = true;

        // Propiedades
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Constructor por defecto de la clase UserControlInicio.
        /// Inicializa los componentes visuales del control y crea una nueva instancia de CS_Usuario.
        /// </summary>
        public UserControlInicio()
        {
            // Inicializa los componentes visuales del control de usuario
            InitializeComponent();
        }

        /// <summary>
        /// Constructor de la clase UserControlInicio que acepta un objeto Usuario.
        /// Inicializa los componentes visuales del control y actualiza el valor en la caja.
        /// </summary>
        /// <param name="usuario">El objeto Usuario que representa al usuario actual.</param>
        public UserControlInicio(Usuario usuario) : this()
        {
            // Asigna el usuario recibido por parámetro al atributo de la clase
            Usuario = usuario;
            // Actualiza el valor en la caja al inicializar el control
            ActualizarValorEnCaja();
            // Setea en true el radiobutton de movimientos
            radioButtonMovimientos.Checked = true;
            // Mostrar los movimientos 
            ActualizarMovimientos();
            // Registra el controlador de eventos para el evento ColumnHeaderMouseClick
            dataGridViewMovimientos.ColumnHeaderMouseClick += DataGridViewMovimientos_ColumnHeaderMouseClick;
       
        }

        /// <summary>
        /// Maneja el evento de clic del botón "buttonMovimiento".
        /// Abre el formulario de movimientos si no está abierto ya, deshabilita el formulario principal y se suscribe al evento FormClosed del formulario de movimientos.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonMovimiento_Click(object sender, EventArgs e)
        {
            // Abre el formulario movimiento
            AbrirFormularioMovimiento();
        }

        private FormMovimientos AbrirFormularioMovimiento() 
        {
            // Verifica si el formulario de movimientos no está abierto ya
            if (Application.OpenForms["formMovimientos"] == null)
            {
                // Crea una instancia del formulario de movimientos
                FormMovimientos formMovimientos = new FormMovimientos(Usuario);
                // Muestra el formulario movimientos
                formMovimientos.Show();
                // Suscribe el método FormMovimientos_FormClosed al evento FormClosed del formulario de movimientos
                formMovimientos.FormClosed += FormMovimientos_FormClosed;
                // Deshabilita el formulario principal mientras el formulario de movimientos esté abierto
                this.Enabled = false;

                return formMovimientos;
            }

            return null;
        }

        /// <summary>
        /// Maneja el evento de cierre del formulario FormMovimientos.
        /// Habilita el formulario principal y actualiza el valor en la caja al cerrar el formulario de movimientos.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormMovimientos_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Habilita el formulario principal al cerrar el formulario de movimientos.
            this.Enabled = true;
            // Actualiza el valor en la caja al cerrar el formulario de movimientos.
            ActualizarValorEnCaja();
            // Chequea el radioButton chequeado y muestra/actualiza movimientos/reservas
            VerificarRadioButton();       
        }

        /// <summary>
        /// Actualiza el valor mostrado en la caja de fondos.
        /// </summary>
        private void ActualizarValorEnCaja()
        {
            // Utiliza el método ObtenerFondosTotales de CS_Usuario para obtener los fondos totales del usuario.
            double fondosTotales = CS_Usuario.ObtenerFondosTotales(Usuario);

            // Actualiza el texto del control labelCaja para mostrar los fondos totales formateados como moneda.
            labelCaja.Text = CS_Config.FormatearMoneda(fondosTotales, 2);
        }

        /// <summary>
        /// Muestra la lista de movimientos en el DataGridView.
        /// Obtiene la lista de movimientos para el usuario actual y la establece como la fuente de datos
        /// del DataGridView. También ajusta las columnas del DataGridView para que ocupen todo el ancho disponible.
        /// </summary>
        private void ActualizarMovimientos() 
        {
            // Obtener la lista de movimientos para el usuario actual
            Usuario.Movimientos = CS_Movimiento.ObtenerMovimientosPorId(Usuario.Id);
            // Establecer la lista de movimientos como la fuente de datos del DataGridView
            dataGridViewMovimientos.DataSource = Usuario.Movimientos;
            // Deshabilita el boton modificar
            buttonModificar.Enabled = false;
        }
        private void ActualizarReservas() 
        {
            // Obtener la lista de movimientos para el usuario actual
            Usuario.Reservas = CS_Reserva.ObtenerReservasPorId(Usuario.Id);
            // Establecer la lista de movimientos como la fuente de datos del DataGridView
            dataGridViewMovimientos.DataSource = Usuario.Reservas;
            // Habilita el boton modificar
            buttonModificar.Enabled = true;

            // Ocultar la columna 'Modificacion'
            if (dataGridViewMovimientos.Columns["Modificacion"] != null)
            {
                dataGridViewMovimientos.Columns["Modificacion"].Visible = false;
            }
        }

        /// <summary>
        /// Maneja el evento Click del botón de eliminar.
        /// Recorre las filas seleccionadas en el DataGridView, elimina los movimientos correspondientes
        /// de la base de datos y actualiza el DataGridView.
        /// </summary>
        /// <param name="sender">El origen del evento, generalmente el botón de eliminar.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            // Si el radioButtonMovimientos está checkeado
            if (radioButtonMovimientos.Checked)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que quieres eliminar el movimiento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Si el usuario hace clic en "Sí", cerrar la aplicación
                if (result == DialogResult.Yes)
                {
                    // Eliminamos el movimiento
                    EliminarMovimiento();
                }

            }
            else if (radioButtonReservas.Checked) // Si el radioButtonReservas está checkeado
            {
                //
                DialogResult result = MessageBox.Show("¿Está seguro que quieres eliminar la reserva?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Si el usuario hace clic en "Sí", cerrar la aplicación
                if (result == DialogResult.Yes)
                {
                    // Eliminamos la reserva
                    EliminarReserva();
                }
                
            }
            
        }

        private void EliminarMovimiento() 
        {
            List<(int Id, double Importe)> MovimientosAEliminar = ObtenerSeleccionadosDataGrid(dataGridViewMovimientos);
            // Recorrer la lista de IDs de movimientos a eliminar
            foreach (var Movimiento in MovimientosAEliminar)
            {
                // Llamar al método para eliminar el movimiento por su ID de la base de datos
                CS_Movimiento.EliminarMovimientoPorId(Movimiento.Id);
            }

            // Actualizar el DataGridView
            ActualizarMovimientos();

        }

        private void EliminarReserva()
        {
            List<(int IdReserva, double Importe)> reservasAEliminar = ObtenerSeleccionadosDataGrid(dataGridViewMovimientos);

            // Recorre la lista de reservas a eliminar
            foreach (var reserva in reservasAEliminar)
            {
                // Llamar al método para eliminar la reserva por su ID de la base de datos
                CS_Reserva.EliminarReservaPorId(reserva.IdReserva);
                // Actualiza los fondos del usuario
                CS_Usuario.ActualizarFondos(Usuario.Nombre, reserva.Importe, CapaEntidades.Enums.ETipoMovimiento.Ingreso);
                // Actualiza el valor de la caja
                ActualizarValorEnCaja();
            }

            // Muestra las reservas
            ActualizarReservas();
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
            foreach (DataGridViewRow row in dataGridViewMovimientos.SelectedRows)
            {
                int id;
                double importe;
                // Intentar obtener el ID y el importe de las celdas correspondientes
                if (int.TryParse(row.Cells["Id"].Value.ToString(), out id) &&
                    double.TryParse(row.Cells["Importe"].Value.ToString(), out importe))
                {
                    // Agregar el ID del movimiento y el importe a la lista de reservas a eliminar
                    elementosAEliminar.Add((id, importe));
                }
            }

            // Retornar la lista de elementos seleccionados
            return elementosAEliminar;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Ocultar/Ver".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void buttonOcultar_Click(object sender, EventArgs e)
        {
            // Cambia el estado de la visibilidad de los fondos
            _fondosVisibles = !_fondosVisibles;

            // Si los fondos son visibles
            if (_fondosVisibles)
            {
                // Actualiza el valor en la caja de texto
                ActualizarValorEnCaja();
                // Cambia el texto del botón a "Ocultar"
                buttonOcultar.Text = "Ocultar";
            }
            else // Si los fondos están ocultos
            {
                // Actualiza el texto de la etiqueta de la caja a "$******"
                labelCaja.Text = "$******";
                // Cambia el texto del botón a "Ver"
                buttonOcultar.Text = "Ver";
            }

        }

        /// <summary>
        /// Maneja el evento de clic en el encabezado de columna del DataGridView para ordenar los datos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void DataGridViewMovimientos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Verifica si el radio button de Movimientos está seleccionado
            if (radioButtonMovimientos.Checked)
            {
                // Si está seleccionado, ordena los datos de movimientos
                CS_Config.OrdenarDataGrid(e, dataGridViewMovimientos, Usuario.Movimientos);
            }
            else
            {
                // Si no está seleccionado, ordena los datos de reservas
                CS_Config.OrdenarDataGrid(e, dataGridViewMovimientos, Usuario.Reservas);
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de selección del radio button de Movimientos.
        /// Llama al método VerificarRadioButton para realizar las acciones necesarias cuando
        /// el estado del radio button cambia.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void radioButtonMovimientos_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar el estado del radio button y realizar las acciones correspondientes
            VerificarRadioButton();
        }

        /// <summary>
        /// Maneja el evento de cambio de selección del radio button de Reservas.
        /// Llama al método VerificarRadioButton para realizar las acciones necesarias cuando
        /// el estado del radio button cambia.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void radioButtonReservas_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar el estado del radio button y realizar las acciones correspondientes
            VerificarRadioButton();
        }

        /// <summary>
        /// Evento click del botón para modificar una reserva.
        /// Llama al método ModificarReserva para manejar la modificación de la reserva seleccionada.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            // Modifica la reserva seleccionada
            ModificarReserva();
        }

        /// <summary>
        /// Maneja la modificación de una reserva seleccionada del DataGridView.
        /// Si una reserva está seleccionada, extrae los datos de la reserva de la fila seleccionada,
        /// abre un formulario para modificar la reserva y actualiza la visualización de las reservas.
        /// </summary>
        private void ModificarReserva() 
        {
            //
            if (dataGridViewMovimientos.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridViewMovimientos.SelectedRows[0];

                // Extraer los datos de la reserva desde la fila seleccionada
                Reserva reservaSeleccionada = new Reserva
                {
                    Id = Convert.ToInt32(filaSeleccionada.Cells["id"].Value),
                    Nombre = Convert.ToString(filaSeleccionada.Cells["nombre"].Value),
                    Importe = Convert.ToDouble(filaSeleccionada.Cells["importe"].Value),
                    Fecha = Convert.ToString(filaSeleccionada.Cells["fecha"].Value)
                };

                // Crear una instancia del formulario de movimientos
                FormMovimientos formMovimientos = AbrirFormularioMovimiento();

                // Crear una instancia del UserControlReserva con el usuario actual y los datos de la reserva
                UserControlReserva userControlReserva = new UserControlReserva(Usuario, reservaSeleccionada);

                // Mostrar el UserControlReserva en el FormMovimientos
                formMovimientos.MostrarUserControl(userControlReserva);

                // Cerrar el formMovimientos
                userControlReserva.AceptarClick += formMovimientos.UserControlReserva_AceptarClick;

                // Mostrar las reservas actualizadas
                ActualizarReservas();
            }

        }

        /// <summary>
        /// Verifica cuál radio button está seleccionado y realiza la acción correspondiente.
        /// Si el radio button de Reservas está seleccionado, muestra las reservas.
        /// Si el radio button de Movimientos está seleccionado, muestra los movimientos.
        /// </summary>
        private void VerificarRadioButton() 
        {
            // Verifica si el radio button de Reservas está seleccionado
            if (radioButtonReservas.Checked)
            {
                // Si está seleccionado, muestra las reservas
                ActualizarReservas();
            }
            else if (radioButtonMovimientos.Checked) // Verifica si el radio button de Movimientos está seleccionado
            {
                // Si está seleccionado, muestra los movimientos
                ActualizarMovimientos();
            }

        }

    }
}
