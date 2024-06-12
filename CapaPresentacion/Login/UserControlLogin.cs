using CapaEntidades;
using System;
using System.Windows.Forms;
using CapaServicios;

namespace CapaPresentacion
{
    public partial class UserControlLogin : UserControl
    {
        // Atributos
        //private Usuario _usuario = new Usuario();
        private CS_Usuario _csUsuario;
        private bool _claveVisible = false;

        // Propiedades
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Constructor por defecto de la clase UserControlLogin.
        /// Inicializa los componentes visuales del control y crea una nueva instancia de CS_Usuario.
        /// </summary>
        public UserControlLogin()
        {
            // Inicializa los componentes visuales del control de usuario
            InitializeComponent();
            // Crea una nueva instancia de CS_Usuario para manejar la lógica relacionada con el usuario
            _csUsuario = new CS_Usuario();
        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Maneja el evento de clic en el botón "buttonIniciar".
        /// Valida las credenciales del usuario y muestra el formulario principal si son correctas.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            if (ValidarUsuario())
            {
                // Crea una nueva instancia del formulario principal
                FormInicio formInicio = new FormInicio(Usuario);

                // Muestra el formulario principal
                formInicio.Show();

                // Registra el acceso del usuario actual
                _csUsuario.RegistrarAccesoUsuario(textBoxUsuario.Text);

                // Oculta el formulario de inicio de sesión actual
                this.Hide();

                // Agrega un manejador para el evento de cierre del formulario principal
                formInicio.FormClosing += frm_closing;
            }
            else
            {
                // Muestra un mensaje de error si las credenciales son incorrectas
                MessageBox.Show("Error al ingresar el Usuario/Clave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Maneja el evento de cierre del formulario, limpiando los campos de texto de usuario y clave, y mostrando el formulario actual.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento de cierre del formulario.</param>
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            // Limpia el contenido del cuadro de texto de usuario
            textBoxUsuario.Text = "";

            // Limpia el contenido del cuadro de texto de clave
            textBoxClave.Text = "";

            // Muestra el formulario actual
            this.Show();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "buttonBorrar".
        /// Limpia el contenido del cuadro de texto de usuario y del cuadro de texto de clave.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            // Limpia el contenido del cuadro de texto de usuario
            textBoxUsuario.Text = "";

            // Limpia el contenido del cuadro de texto de clave
            textBoxClave.Text = "";
        }

        /// <summary>
        /// Valida las credenciales del usuario ingresadas en los campos de texto.
        /// </summary>
        /// <returns>True si las credenciales son válidas y se encontró el usuario en la base de datos; False en caso contrario.</returns>
        private bool ValidarUsuario()
        {
            // Utiliza el método ValidarUsuario de CS_Usuario para verificar las credenciales ingresadas
            Usuario usuario = _csUsuario.ValidarUsuarioIniciarSesion(textBoxUsuario.Text, textBoxClave.Text);
            // Si se encontró un usuario válido, actualiza el atributo Usuario de la clase y devuelve true
            if (usuario != null)
            {
                Usuario = usuario;
                return true;
            }
            // Si no se encontró un usuario válido, devuelve false
            return false;
        }

        /// <summary>
        /// Maneja el evento Click del botón "Ocultar".
        /// Este método alterna la visibilidad de la contraseña en el TextBox textBoxClave.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (en este caso, el botón "Ocultar").</param>
        /// <param name="e">Argumentos del evento.</param>
        private void buttonOcultar_Click(object sender, EventArgs e)
        {
            // Alterna el estado de visibilidad de la contraseña
            _claveVisible = !_claveVisible;

            // Verifica el estado de visibilidad de la contraseña y ajusta la propiedad PasswordChar en consecuencia.
            if (!_claveVisible) 
            {
                // Si la contraseña no está visible, se establece un carácter de contraseña para ocultarla.
                textBoxClave.PasswordChar = 'o';
            }
            else
            {
                // Si la contraseña está visible, se elimina cualquier carácter de contraseña para que sea visible.
                textBoxClave.PasswordChar = '\0';
            }
        }
    }
}
