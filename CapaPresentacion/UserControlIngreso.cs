using CapaDatos;
using CapaEntidades;
using CapaServicios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlIngreso : UserControl
    {
        // Atributos
        private Usuario _usuario = new Usuario();
        private CS_Usuario csUsuario; // Cambio: Utiliza CS_Usuario en lugar de CD_Usuario
        public event EventHandler AceptarClick;

        // Propiedades
        public Usuario Usuario { get; set; }


        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public UserControlIngreso()
        {
            InitializeComponent();
            csUsuario = new CS_Usuario();
        }

        /// <summary>
        /// Constructor con usuario
        /// </summary>
        /// <param name="usuario">El usuario actual</param>
        public UserControlIngreso(Usuario usuario) : this()
        {
            Usuario = usuario;
            // Limpia el textBoxIngreso 
            textBoxIngreso.Text = "";
            // Asigna el metodo para solamente poder ingresar numeros
            textBoxIngreso.KeyPress += textBox_KeyPress;

        }

        /// <summary>
        /// Maneja el evento TextChanged del textBoxIngreso
        /// </summary>
        private void textBoxIngreso_TextChanged(object sender, EventArgs e)
        {
            // Aquí puedes agregar código si deseas realizar alguna acción cuando cambia el texto del textBoxIngreso
        }

        /// <summary>
        /// Maneja el evento KeyPress del textBoxIngreso para permitir solo números y la tecla de retroceso
        /// </summary>
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Maneja el evento Click del botón BorrarIngreso para limpiar el textBoxIngreso
        /// </summary>
        private void buttonBorrarIngreso_Click(object sender, EventArgs e)
        {
            textBoxIngreso.Text = "";
        }

        /// <summary>
        /// Maneja el evento Click del botón AceptarIngreso para procesar el ingreso
        /// </summary>
        private void buttonAceptarIngreso_Click(object sender, EventArgs e)
        {
            // Validar que el campo de ingreso no esté vacío
            if (string.IsNullOrWhiteSpace(textBoxIngreso.Text))
            {
                MessageBox.Show("Por favor ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el campo de ingreso contenga un número válido
            if (!double.TryParse(textBoxIngreso.Text, out double ingreso))
            {
                MessageBox.Show("Ingrese un número válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Actualizar los fondos del usuario
            csUsuario.ActualizarFondos(Usuario.NombreUsuario, ingreso); // Cambio: Utiliza CS_Usuario en lugar de CD_Usuario

            // Notificar que los fondos han sido actualizados
            MessageBox.Show("Los fondos han sido actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Dispara el evento AceptarClick cuando se presiona el botón "Aceptar"
            AceptarClick?.Invoke(this, EventArgs.Empty);
        }

    }
}
