using CapaEntidades;
using CapaServicios;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlRegistro : UserControl
    {
        // Atributos
        //private Usuario _usuario = new Usuario();
        private CS_Usuario csUsuario;

        // Propiedades
        //public Usuario Usuario { get; set; }

        public UserControlRegistro()
        {
            //
            InitializeComponent();

            // Crea una nueva instancia de CS_Usuario para manejar la lógica relacionada con el usuario
            csUsuario = new CS_Usuario();
           
        }

        private void buttonRegistrarse_Click(object sender, System.EventArgs e)
        {

            // Optimizar
            if (textBoxUsuario.Text != "")
            {
                if (textBoxClave.Text != "" || textBoxClave2.Text != "")
                {
                    if (textBoxClave.Text == textBoxClave2.Text)
                    {
                        string mensaje = csUsuario.RegistrarUsuario(textBoxUsuario.Text, textBoxClave.Text);
                        MessageBox.Show(mensaje);  
                    }
                    else
                    {
                        MessageBox.Show("Las contrseñas no coinciden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el campo de contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            
        }
    }
}
