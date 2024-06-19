using CapaEntidades;
using CapaServicios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlReserva : UserControl
    {

        // Eventos
        public event EventHandler AceptarClick;

        // Propiedades
        public Usuario Usuario { get; set; }
        public Reserva Reserva { get; set; }

        /// <summary>
        /// Constructor de la clase UserControlReserva.
        /// </summary>
        public UserControlReserva()
        {
            // Inicializa los componentes del control de usuario
            InitializeComponent();
        }

        /// <summary>
        /// Constructor de la clase UserControlReserva que inicializa el control de usuario con un usuario específico.
        /// </summary>
        /// <param name="usuario">El usuario para el cual se está mostrando el control de reserva.</param>
        public UserControlReserva(Usuario usuario) : this() 
        {
            // Asigna el valor a Usuario
            Usuario = usuario;
            // Limpia el textBoxIngreso 
            textBoxReserva.Text = "";
            // Asigna el metodo para solamente poder ingresar numeros
            textBoxReserva.KeyPress += CS_Config.textBox_KeyPress;
            // Actualizar el label con los fondos formateados
            MostrarFondosActuales();
            // Inicializa una nueva instancia de Reserva
            Reserva = new Reserva();    
        }

        /// <summary>
        /// Constructor de la clase UserControlReserva que inicializa el control de usuario con un usuario y una reserva específicos.
        /// </summary>
        /// <param name="usuario">El usuario para el cual se está mostrando el control de reserva.</param>
        /// <param name="reserva">La reserva que se está modificando o mostrando en el control.</param>
        public UserControlReserva(Usuario usuario, Reserva reserva) : this(usuario)
        {
            // Asigna el valor de la reserva
            Reserva = new Reserva(reserva.Nombre, reserva.Importe, reserva.Fecha, reserva.Id);
            // Indica que la reserva está en modo de modificación
            Reserva.Modificacion = true;
            // Asignar valores a los TextBoxNombre
            textBoxNombre.Text = reserva.Nombre;
            //  // Asignar valores a los TextBoxReserva
            textBoxReserva.Text = reserva.Importe.ToString();
        }

        /// <summary>
        /// Maneja el evento de salir del cuadro de texto "textBoxReserva".
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void textBoxReserva_Leave(object sender, EventArgs e)
        {
            // Verificar si el texto es un número válido
            if (Double.TryParse(textBoxReserva.Text, out double valor))
            {
                // Formatea el número como moneda con 2 decimales y actualiza el texto del cuadro de texto
                textBoxReserva.Text = CS_Config.FormatearMoneda(valor, 2);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Borrar".
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            // Establece el texto del cuadro de texto textBoxReserva a una cadena vacía, limpiando su contenido.
            textBoxReserva.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Aceptar Reserva".
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonAceptarReserva_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que quieres realizar la reserva?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Si el usuario hace clic en "Sí"
            if (result == DialogResult.Yes)
            {
                // Gestiona y registra la reserva
                var (registroReserva, mensaje) = GestionarReserva();

                // Muestra los fondos actuales
                MostrarFondosActuales();

                // Notificar que los fondos han sido actualizados
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Si se registro la reserva disparamos el evento y cerramos el formulario
                if (registroReserva)
                {
                    // Dispara el evento AceptarClick cuando se presiona el botón "Aceptar"
                    AceptarClick?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Muestra los fondos actuales del usuario después de realizar un retiro.
        /// </summary>
        private void MostrarFondosActuales() 
        {
            // Obtiene los fondos actuales del usuario después del retiro
            double fondosActuales = CS_Usuario.ObtenerFondosTotales(Usuario);

            // Formatea los fondos actuales a una representación de moneda
            string fondosFormateados =  CS_Config.FormatearMoneda(fondosActuales, 2);

            // Actualizar el label con los fondos formateados
            labelFondos.Text = $"Fondos: {fondosFormateados}";
        }

        /// <summary>
        /// Gestiona el proceso de reserva, ya sea registrando una nueva reserva o modificando una existente.
        /// </summary>
        /// <returns>Una tupla que contiene un booleano que indica éxito y un string con un mensaje.</returns>
        private (bool, string) GestionarReserva() 
        {
            // Verifica si la reserva no está en modo de modificación
            if (!Reserva.Modificacion)
            {
                // Registra una nueva reserva y obtiene el resultado y el mensaje
                var (registroReserva, mensaje) = CS_Reserva.RegistrarReserva(Usuario, textBoxNombre.Text, textBoxReserva.Text);
                // Retorna el resultado del registro y el mensaje
                return (registroReserva, mensaje);
            }
            else
            {
                // Modifica una reserva existente y obtiene el resultado y el mensaje
                var (registroReserva, mensaje) = CS_Reserva.RegistrarReserva(Usuario, textBoxNombre.Text, textBoxReserva.Text, Reserva);
                // Retorna el resultado de la modificación y el mensaje
                return (registroReserva, mensaje);
            }
        }
    }
}
