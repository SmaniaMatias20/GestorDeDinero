using CapaEntidades;
using CapaEntidades.Enums;
using CapaServicios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlIngreso : UserControl
    {
        // Eventos
        public event EventHandler AceptarClick;

        // Propiedades
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Constructor por defecto de la clase UserControlIngreso.
        /// Inicializa los componentes visuales y crea una nueva instancia de la clase CS_Usuario.
        /// </summary>
        public UserControlIngreso()
        {
            // Inicializa los componentes visuales del control de usuario
            InitializeComponent();
            // Asigna el metodo para solamente poder ingresar numeros
            textBoxIngreso.KeyPress += CS_Config.textBox_KeyPress;
        }

        /// <summary>
        /// Constructor con usuario
        /// </summary>
        /// <param name="usuario">El usuario actual</param>
        public UserControlIngreso(Usuario usuario) : this()
        {
            // Inicializa el Usuario
            Usuario = usuario;
            // Limpia el textBoxIngreso 
            textBoxIngreso.Text = "";


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxIngreso_Leave(object sender, EventArgs e)
        {
            // Verificar si el texto es un número válido
            if (Double.TryParse(textBoxIngreso.Text, out double valor))
            {
                textBoxIngreso.Text = CS_Config.FormatearMoneda(valor, 2);
            }
        }

        /// <summary>
        /// Maneja el evento Click del botón BorrarIngreso para limpiar el textBoxIngreso
        /// </summary>
        private void buttonBorrarIngreso_Click(object sender, EventArgs e)
        {
            // Vacia el TextBox de ingreso
            textBoxIngreso.Text = "";
        }

        /// <summary>
        /// Maneja el evento Click del botón AceptarIngreso para procesar el ingreso
        /// </summary>
        private void buttonAceptarIngreso_Click(object sender, EventArgs e)
        {
            // Pregunta si queremos realizar el ingreso
            DialogResult result = MessageBox.Show("¿Está seguro que quieres realizar el ingreso?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Si el usuario hace clic en "Sí"
            if (result == DialogResult.Yes)
            {
                // Registra el movimiento
                var (mensaje, usuario) = CS_Movimiento.RegistrarMovimiento(Usuario, textBoxIngreso.Text, ETipoMovimiento.Ingreso);

                // Notificar que los fondos han sido actualizados
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (mensaje == "Ok")
                {
                    // Dispara el evento AceptarClick cuando se presiona el botón "Aceptar"
                    AceptarClick?.Invoke(this, EventArgs.Empty);
                }
                
            }



        }


    }
}
