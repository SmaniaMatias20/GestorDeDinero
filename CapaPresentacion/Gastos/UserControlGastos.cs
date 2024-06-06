using CapaEntidades;
using CapaServicios;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlGastos : UserControl
    {
        // Atributos
        private CS_Usuario _csUsuario;
        private CS_Movimiento _csMovimiento;
        private bool _fondosVisibles = true;

        // Propiedades
        public Usuario Usuario { get; set; }


        public UserControlGastos()
        {
            // Inicializa los componentes visuales del control de usuario
            InitializeComponent();
            // Crea una nueva instancia de CS_Usuario para manejar la lógica relacionada con el usuario
            _csUsuario = new CS_Usuario();
            // Crea una nueva instancia de CS_Usuario para manejar la lógica relacionada con los movimientos
            _csMovimiento = new CS_Movimiento();
        }

        public UserControlGastos(Usuario usuario) : this()
        {
            // Asigna el usuario recibido por parámetro al atributo de la clase
            Usuario = usuario;

        }

    }
}
