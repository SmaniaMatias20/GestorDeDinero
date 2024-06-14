using CapaEntidades;
using CapaServicios;
using System.Linq;
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
            //
            textBoxImporte.KeyPress += CS_Config.textBox_KeyPress;
            textBoxMoneda.KeyPress += CS_Config.textBox_KeyPress;
            textBoxConversion.KeyPress += CS_Config.textBox_KeyPress;
        }

        public UserControlInversion(Usuario usuario) : this()
        {
            // Asigna el usuario recibido por parámetro al atributo de la clase
            Usuario = usuario;
        }



        private void buttonContinuar_Click(object sender, System.EventArgs e)
        {

        }
    }
}
