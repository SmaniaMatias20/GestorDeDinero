
using CapaEntidades;
using CapaEntidades.Enums;
using CapaServicios;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlReserva : UserControl
    {
        // Atributos
        private Usuario _usuario = new Usuario();
        private CS_Usuario _csUsuario;
        private CS_Reserva _csReserva;

        // Eventos
        public event EventHandler AceptarClick;

        // Propiedades
        public Usuario Usuario { get; set; }


        public UserControlReserva()
        {
            InitializeComponent();
            // Crea una instancia de la clase CS_Usuario para manejar la lógica relacionada con el usuario.
            _csUsuario = new CS_Usuario();
            _csReserva = new CS_Reserva();
        }

        public UserControlReserva(Usuario usuario) : this() 
        {
            Usuario = usuario;
            // Limpia el textBoxIngreso 
            textBoxReserva.Text = "";
            // Asigna el metodo para solamente poder ingresar numeros
            textBoxReserva.KeyPress += textBox_KeyPress;


            // Actualizar el label con los fondos formateados
            double fondosActuales = _csUsuario.ObtenerFondosTotales(Usuario);
            string fondosFormateados = _csUsuario.FormatearMoneda(fondosActuales);
            labelFondos.Text = $"Fondos: {fondosFormateados}";
        }

        private void textBoxReserva_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void buttonBorrar_Click(object sender, System.EventArgs e)
        {
            // Establece el texto del cuadro de texto textBoxReserva a una cadena vacía, limpiando su contenido.
            textBoxReserva.Text = "";
        }

        private void buttonAceptarReserva_Click(object sender, System.EventArgs e)
        {
            // Valida el contenido del TextBox de reserva y lo convierte a un valor de tipo double
            double retiro = ValidarTextBoxReserva();

            // Actualizar los fondos del usuario
            _csUsuario.ActualizarFondos(Usuario.Nombre, retiro, false);

            // Obtiene los fondos actuales del usuario después del retiro
            double fondosActuales = _csUsuario.ObtenerFondosTotales(Usuario);

            // Formatea los fondos actuales a una representación de moneda
            string fondosFormateados = _csUsuario.FormatearMoneda(fondosActuales);

            // Actualizar el label con los fondos formateados
            labelFondos.Text = $"Fondos: {fondosFormateados}";

            // Registra el movimiento
            string mensaje = _csReserva.RegistrarReserva(Usuario.Id, retiro, textBoxNombre.Text);

            // Notificar que los fondos han sido actualizados
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Dispara el evento AceptarClick cuando se presiona el botón "Aceptar"
            AceptarClick?.Invoke(this, EventArgs.Empty);

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

        private double ValidarTextBoxReserva()
        {
            // Validar que el campo de ingreso no esté vacío
            if (string.IsNullOrWhiteSpace(textBoxReserva.Text))
            {
                MessageBox.Show("Por favor ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            // Validar que el campo de ingreso contenga un número válido
            if (!double.TryParse(textBoxReserva.Text, out double retiro))
            {
                MessageBox.Show("Ingrese un número válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            // Actualizar el label con los fondos formateados
            double fondosActuales = _csUsuario.ObtenerFondosTotales(Usuario);
            // Validar que el retiro sea menor o igual a los fondos totales actualmente
            if (retiro <= fondosActuales)
            {
                return retiro;
            }
            else
            {
                MessageBox.Show("Ingrese un número menor al total de fondos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return 0;
        }
    }
}
