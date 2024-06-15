using CapaEntidades;
using CapaEntidades.Enums;
using CapaServicios;
using System;
using System.Messaging;
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


        public UserControlReserva()
        {
            //
            InitializeComponent();
        }

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
            //
            Reserva = new Reserva();    
        }

        public UserControlReserva(Usuario usuario, Reserva reserva) : this(usuario)
        {
            // Asigna el valor de la reserva
            Reserva = new Reserva(reserva.Nombre, reserva.Importe, reserva.Fecha, reserva.Id);
            Reserva.Modificacion = true;
            // Asignar valores a los TextBox
            textBoxNombre.Text = reserva.Nombre;
            textBoxReserva.Text = reserva.Importe.ToString();

            
        }

        private void textBoxReserva_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            // Establece el texto del cuadro de texto textBoxReserva a una cadena vacía, limpiando su contenido.
            textBoxReserva.Text = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAceptarReserva_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que quieres realizar la reserva?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Si el usuario hace clic en "Sí"
            if (result == DialogResult.Yes)
            {
                //
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

        private void MostrarFondosActuales() 
        {
            // Obtiene los fondos actuales del usuario después del retiro
            double fondosActuales = CS_Usuario.ObtenerFondosTotales(Usuario);

            // Formatea los fondos actuales a una representación de moneda
            string fondosFormateados =  CS_Config.FormatearMoneda(fondosActuales);

            // Actualizar el label con los fondos formateados
            labelFondos.Text = $"Fondos: {fondosFormateados}";
        }

        private (bool, string) GestionarReserva() 
        {
            if (!Reserva.Modificacion)
            {
                var(registroReserva, mensaje) = CS_Reserva.RegistrarReserva(Usuario, textBoxNombre.Text, textBoxReserva.Text);
                // Retorna el mensaje
                return (registroReserva, mensaje);
            }
            else
            {
                var (registroReserva, mensaje) = CS_Reserva.RegistrarReserva(Usuario, textBoxNombre.Text, textBoxReserva.Text, Reserva);
                // Retorna el mensaje
                return (registroReserva, mensaje);
            }

            
        }
    }
}
