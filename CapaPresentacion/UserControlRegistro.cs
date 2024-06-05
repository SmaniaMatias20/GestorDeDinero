using CapaEntidades;
using CapaServicios;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlRegistro : UserControl
    {
        // Atributos
        private Usuario _usuario = new Usuario();
        private CS_Usuario csUsuario;

        // Propiedades
        public Usuario Usuario { get; set; }

        public UserControlRegistro()
        {
            //
            InitializeComponent();

            // Crea una nueva instancia de CS_Usuario para manejar la lógica relacionada con el usuario
            csUsuario = new CS_Usuario();
           
        }

        private void buttonRegistrarse_Click(object sender, System.EventArgs e)
        {
            if (textBoxUsuario.Text != "")
            {
                if (textBoxClave.Text == textBoxClave2.Text && textBoxClave.Text != "")
                {
                    Usuario.Nombre = textBoxUsuario.Text; 
                    Usuario.Clave = textBoxClave.Text;

                    string mensaje = csUsuario.RegistrarUsuario(Usuario.Nombre, Usuario.Clave);
                    MessageBox.Show(mensaje);
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");

                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de usuario");
            }



            
        }
    }
}
