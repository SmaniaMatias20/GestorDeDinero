using CapaEntidades;
using CapaServicios;
using System.Windows.Forms;

namespace CapaPresentacion.Ajustes
{
    public partial class UserControlAjustes : UserControl
    {
        // Propiedades
        public Usuario Usuario { get; set; }


        public UserControlAjustes()
        {
            // Inicializa los componentes visuales del control de usuario
            InitializeComponent();
        }

        public UserControlAjustes(Usuario usuario) : this()
        {
            // Asigna el usuario recibido por parámetro al atributo de la clase
            Usuario = usuario;

        }
    }
}
