using CapaServicios;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlRegistro : UserControl
    {
        // Atributos
        private CS_Usuario csUsuario;

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

        private void buttonRegistrarse_Click(object sender, System.EventArgs e)
        {
            string mensaje = csUsuario.RegistrarUsuario(textBoxUsuario.Text, textBoxClave.Text, textBoxClave2.Text);
            MessageBox.Show(mensaje);  
        }

        private void buttonBorrar_Click(object sender, System.EventArgs e)
        {
            textBoxUsuario.Text = "";
            textBoxClave.Text = "";
            textBoxClave2.Text = "";
        }
    }
}
