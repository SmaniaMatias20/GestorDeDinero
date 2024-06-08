using CapaServicios;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlRegistro : UserControl
    {
        // Atributos
        private CS_Usuario csUsuario;
        private bool _claveVisible = false;

        /// <summary>
        /// Constructor del control de usuario UserControlRegistro.
        /// </summary>
        public UserControlRegistro()
        {
            // Inicializa los componentes visuales del control de usuario.
            InitializeComponent();

            // Crea una nueva instancia de CS_Usuario para manejar la lógica relacionada con el usuario
            csUsuario = new CS_Usuario();
           
        }
        private void UserControlRegistro_Load(object sender, System.EventArgs e)
        {
        }

        private void buttonRegistrarse_Click(object sender, System.EventArgs e)
        {
            string mensaje = csUsuario.RegistrarUsuario(textBoxUsuario.Text, textBoxClave.Text, textBoxClave2.Text);
            MessageBox.Show(mensaje, "Mensaje");  
        }

        private void buttonBorrar_Click(object sender, System.EventArgs e)
        {
            textBoxUsuario.Text = "";
            textBoxClave.Text = "";
            textBoxClave2.Text = "";
        }

        private void buttonOcultar_Click(object sender, System.EventArgs e)
        {
            // Alterna el estado de visibilidad de la contraseña
            _claveVisible = !_claveVisible;

            // Verifica el estado de visibilidad de la contraseña y ajusta la propiedad PasswordChar en consecuencia.
            if (!_claveVisible)
            {
                // Si la contraseña no está visible, se establece un carácter de contraseña para ocultarla.
                textBoxClave.PasswordChar = 'o';
                textBoxClave2.PasswordChar = 'o';
            }
            else
            {
                // Si la contraseña está visible, se elimina cualquier carácter de contraseña para que sea visible.
                textBoxClave.PasswordChar = '\0';
                textBoxClave2.PasswordChar = '\0';
            }
        }

    }
}
