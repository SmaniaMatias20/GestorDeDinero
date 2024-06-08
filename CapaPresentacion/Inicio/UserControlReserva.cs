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
        private bool modificarReserva = false;  

        // Eventos
        public event EventHandler AceptarClick;

        // Propiedades
        public Usuario Usuario { get; set; }
        public Reserva Reserva { get; set; }


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
            MostrarFondosActuales();
        }

        public UserControlReserva(Usuario usuario, Reserva reserva) : this(usuario)
        {
            Reserva = reserva;
            // Asignar valores a los TextBox
            textBoxNombre.Text = reserva.Nombre;
            textBoxReserva.Text = reserva.Importe.ToString();

            modificarReserva = true;
        }

        private void textBoxReserva_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            // Establece el texto del cuadro de texto textBoxReserva a una cadena vacía, limpiando su contenido.
            textBoxReserva.Text = "";
        }

        private void buttonAceptarReserva_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que quieres realizar la reserva?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Si el usuario hace clic en "Sí"
            if (result == DialogResult.Yes)
            {

                string mensaje = GestionarReserva();

                MostrarFondosActuales();

                // Notificar que los fondos han sido actualizados
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (mensaje == "Fondos actualizados correctamente")
                {
                    // Dispara el evento AceptarClick cuando se presiona el botón "Aceptar"
                    AceptarClick?.Invoke(this, EventArgs.Empty);
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

        private void MostrarFondosActuales() 
        {
            // Obtiene los fondos actuales del usuario después del retiro
            double fondosActuales = _csUsuario.ObtenerFondosTotales(Usuario);

            // Formatea los fondos actuales a una representación de moneda
            string fondosFormateados = _csUsuario.FormatearMoneda(fondosActuales);

            // Actualizar el label con los fondos formateados
            labelFondos.Text = $"Fondos: {fondosFormateados}";
        }

        private string GestionarReserva() 
        {
            string mensaje = "";
            if (!modificarReserva)
            {
                // Actualizar los fondos del usuario
                double movimientoValidado = _csUsuario.ActualizarFondos(Usuario.Nombre, textBoxReserva.Text, ETipoMovimiento.Reserva);
                // Registra el movimiento
                mensaje = _csReserva.RegistrarReserva(textBoxNombre.Text, movimientoValidado, Usuario.Id);
            }
            else
            {
                _csUsuario.ActualizarFondos(Usuario.Nombre, Reserva.Importe.ToString(), ETipoMovimiento.Ingreso);

                // Actualizar los fondos del usuario
                double movimientoValidado = _csUsuario.ActualizarFondos(Usuario.Nombre, textBoxReserva.Text, ETipoMovimiento.Reserva);

                mensaje = _csReserva.RegistrarReserva(textBoxNombre.Text, movimientoValidado, Usuario.Id, Reserva.Id, modificar: modificarReserva);
            }

            return mensaje;
        }
    }
}
