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
        private CS_Usuario _csUsuario;
        private CS_Movimiento _csMovimiento;
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
            // Crea una nueva instancia de CS_Usuario para manejar la lógica relacionada con el usuario
            _csUsuario = new CS_Usuario();
            // Crea una nueva instancia de CS_Usuario para manejar la lógica relacionada con los movimientos
            _csMovimiento = new CS_Movimiento();
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
            //
            MostrarMovimientos();
        }

        /// <summary>
        /// Maneja el evento de clic del botón "buttonMovimiento".
        /// Abre el formulario de movimientos si no está abierto ya, deshabilita el formulario principal y se suscribe al evento FormClosed del formulario de movimientos.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonMovimiento_Click(object sender, EventArgs e)
        {
            // Verifica si el formulario de movimientos no está abierto ya
            if (Application.OpenForms["formMovimientos"] == null)
            {
                // Crea una instancia del formulario de movimientos y lo muestra
                FormMovimientos formMovimientos = new FormMovimientos(Usuario);
                formMovimientos.Show();
                // Suscribe el método FormMovimientos_FormClosed al evento FormClosed del formulario de movimientos
                formMovimientos.FormClosed += FormMovimientos_FormClosed;
                // Deshabilita el formulario principal mientras el formulario de movimientos esté abierto
                this.Enabled = false;
            }
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
            // Muestra los movimientos del usuario.
            MostrarMovimientos();
        }

        /// <summary>
        /// Actualiza el valor mostrado en la caja de fondos.
        /// </summary>
        private void ActualizarValorEnCaja()
        {
            // Utiliza el método ObtenerFondosTotales de CS_Usuario para obtener los fondos totales del usuario.
            double fondosTotales = _csUsuario.ObtenerFondosTotales(Usuario);

            // Actualiza el texto del control labelCaja para mostrar los fondos totales formateados como moneda.
            labelCaja.Text = _csUsuario.FormatearMoneda(fondosTotales); ;
        }

        /// <summary>
        /// Muestra la lista de movimientos en el DataGridView.
        /// Obtiene la lista de movimientos para el usuario actual y la establece como la fuente de datos
        /// del DataGridView. También ajusta las columnas del DataGridView para que ocupen todo el ancho disponible.
        /// </summary>
        private void MostrarMovimientos() 
        {
            // Obtener la lista de movimientos para el usuario actual
            Usuario.Movimientos = _csMovimiento.ObtenerMovimientosPorId(Usuario.Id);
            // Ajustar las columnas del DataGridView para que ocupen todo el ancho disponible
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Establecer la lista de movimientos como la fuente de datos del DataGridView
            dataGridView1.DataSource = Usuario.Movimientos;
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
            // Crear una lista para almacenar los IDs de los movimientos que se van a eliminar
            List<int> idsMovimientosAEliminar = new List<int>();

            // Recorrer las filas seleccionadas en el DataGridView
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                // Evitar eliminar filas de nueva entrada
                if (!row.IsNewRow) 
                {
                    int idMovimiento;
                    // Intentar obtener el ID del movimiento de la celda correspondiente
                    if (int.TryParse(row.Cells["Id"].Value.ToString(), out idMovimiento))
                    {
                        // Agregar el ID del movimiento a la lista de movimientos a eliminar
                        idsMovimientosAEliminar.Add(idMovimiento);
                    }
                }
            }

            // Recorrer la lista de IDs de movimientos a eliminar
            foreach (int idMovimiento in idsMovimientosAEliminar)
            {
                // Llamar al método para eliminar el movimiento por su ID de la base de datos
                _csMovimiento.EliminarMovimientoPorId(idMovimiento);
            }

            // Actualizar el DataGridView
            MostrarMovimientos();
        }

        private void buttonOcultar_Click(object sender, EventArgs e)
        {
            _fondosVisibles = !_fondosVisibles;

            if (_fondosVisibles)
            {
                ActualizarValorEnCaja();
            }
            else 
            { 
                labelCaja.Text = "$******";
            }

        }
    }
}
