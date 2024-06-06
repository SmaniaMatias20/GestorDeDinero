using CapaEntidades;
using CapaEntidades.Enums;
using CapaServicios;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlRetiro : UserControl
    {
        // Atributos
        private Usuario _usuario = new Usuario();
        private CS_Usuario _csUsuario;
        private CS_Movimiento _csMovimiento;

        // Eventos
        public event EventHandler AceptarClick;

        // Propiedades
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Constructor para la clase UserControlRetiro.
        /// Inicializa los componentes visuales y crea una instancia de la clase CS_Usuario.
        /// </summary>
        public UserControlRetiro()
        {
            // Llama al método que inicializa los componentes visuales del control de usuario.
            InitializeComponent();
            // Crea una instancia de la clase CS_Usuario para manejar la lógica relacionada con el usuario.
            _csUsuario = new CS_Usuario();
            _csMovimiento = new CS_Movimiento();
        }

        /// <summary>
        /// Constructor con usuario
        /// </summary>
        /// <param name="usuario">El usuario actual</param>
        public UserControlRetiro(Usuario usuario) : this()
        {
            Usuario = usuario;
            // Limpia el textBoxIngreso 
            textBoxRetiro.Text = "";
            // Asigna el metodo para solamente poder ingresar numeros
            textBoxRetiro.KeyPress += textBox_KeyPress;


            // Actualizar el label con los fondos formateados
            double fondosActuales = _csUsuario.ObtenerFondosTotales(Usuario);
            string fondosFormateados = _csUsuario.FormatearMoneda(fondosActuales);
            labelFondos.Text = $"Fondos: {fondosFormateados}";
        }

        /// <summary>
        /// Maneja el evento de clic del botón Borrar.
        /// Limpia el contenido del cuadro de texto textBoxRetiro.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            // Establece el texto del cuadro de texto textBoxRetiro a una cadena vacía, limpiando su contenido.
            textBoxRetiro.Text = "";
        }

        private void textBoxRetiro_TextChanged(object sender, EventArgs e)
        {

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
        /// Maneja el evento de clic del botón Aceptar Retiro.
        /// Valida el monto de retiro, actualiza los fondos del usuario,
        /// actualiza la visualización de los fondos y notifica al usuario.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonAceptarRetiro_Click(object sender, EventArgs e)
        {
            // Actualizar los fondos del usuario
            double movimientoValidado = _csUsuario.ActualizarFondos(Usuario.Nombre, textBoxRetiro.Text, ETipoMovimiento.Retiro);

            // Obtiene los fondos actuales del usuario después del retiro
            double fondosActuales = _csUsuario.ObtenerFondosTotales(Usuario);

            // Formatea los fondos actuales a una representación de moneda
            string fondosFormateados = _csUsuario.FormatearMoneda(fondosActuales);

            // Actualizar el label con los fondos formateados
            labelFondos.Text = $"Fondos: {fondosFormateados}";

            // Registra el movimiento
            string mensaje = _csMovimiento.RegistrarMovimiento(Usuario.Id, movimientoValidado, ETipoMovimiento.Retiro);

            // Notificar que los fondos han sido actualizados
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Dispara el evento AceptarClick cuando se presiona el botón "Aceptar"
            AceptarClick?.Invoke(this, EventArgs.Empty);


        }


    }
}
