using CapaEntidades;
using CapaEntidades.Enums;
using CapaServicios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlRetiro : UserControl
    {
        // Atributos
        //private Usuario _usuario = new Usuario();


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
            textBoxRetiro.KeyPress += CS_Config.textBox_KeyPress;


            // Actualizar el label con los fondos formateados
            double fondosActuales = CS_Usuario.ObtenerFondosTotales(Usuario);
            string fondosFormateados = CS_Config.FormatearMoneda(fondosActuales);
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

        /// <summary>
        /// Maneja el evento de clic del botón Aceptar Retiro.
        /// Valida el monto de retiro, actualiza los fondos del usuario,
        /// actualiza la visualización de los fondos y notifica al usuario.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonAceptarRetiro_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que quieres realizar el retiro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Si el usuario hace clic en "Sí"
            if (result == DialogResult.Yes) 
            { 
                // Actualizar los fondos del usuario
                double movimientoValidado = CS_Usuario.ActualizarFondos(Usuario.Nombre, textBoxRetiro.Text, ETipoMovimiento.Retiro);

                // Obtiene los fondos actuales del usuario después del retiro
                double fondosActuales = CS_Usuario.ObtenerFondosTotales(Usuario);

                // Formatea los fondos actuales a una representación de moneda
                string fondosFormateados = CS_Config.FormatearMoneda(fondosActuales);

                // Actualizar el label con los fondos formateados
                labelFondos.Text = $"Fondos: {fondosFormateados}";

                // Registra el movimiento
                string mensaje = CS_Movimiento.RegistrarMovimiento(Usuario.Id, movimientoValidado, ETipoMovimiento.Retiro);

                // Notificar que los fondos han sido actualizados
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (mensaje == "Fondos actualizados correctamente")
                {
                    // Dispara el evento AceptarClick cuando se presiona el botón "Aceptar"
                    AceptarClick?.Invoke(this, EventArgs.Empty);
                }
            }


        }

        private void UserControlRetiro_Load(object sender, EventArgs e)
        {

        }
    }
}
