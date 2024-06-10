using CapaEntidades;
using CapaServicios;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlInversion : UserControl
    {
        // Atributos
        private CS_Usuario _csUsuario;
        private CS_Movimiento _csMovimiento;

        // Propiedades
        public Usuario Usuario { get; set; }


        public UserControlInversion()
        {
            // Inicializa los componentes visuales del control de usuario
            InitializeComponent();
            // Crea una nueva instancia de CS_Usuario para manejar la lógica relacionada con el usuario
            _csUsuario = new CS_Usuario();
            // Crea una nueva instancia de CS_Usuario para manejar la lógica relacionada con los movimientos
            _csMovimiento = new CS_Movimiento();
        }

        public UserControlInversion(Usuario usuario) : this()
        {
            // Asigna el usuario recibido por parámetro al atributo de la clase
            Usuario = usuario;

        }

        private void label6_Click(object sender, System.EventArgs e)
        {

        }
    }
}
