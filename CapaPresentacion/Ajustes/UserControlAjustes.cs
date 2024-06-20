using CapaEntidades;
using CapaServicios;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Ajustes
{
    public partial class UserControlAjustes : UserControl
    {
        // Atributos
        private bool _claveVisible = false;
        private bool _modificar = false;
        private List<Control> _listaDeControles;

        // Propiedades
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Constructor para inicializar una nueva instancia del control de usuario UserControlAjustes.
        /// </summary>
        public UserControlAjustes()
        {
            // Inicializa los componentes visuales del control de usuario
            InitializeComponent();
            // Inicializa la lista de controles (para habilitar/deshabilitar)
            _listaDeControles = new List<Control>
            {
                textBoxUsuario,
                textBoxClave,
                textBoxClave2,
                buttonAceptar
            };   
        }

        /// <summary>
        /// Inicializa una nueva instancia del control de usuario UserControlAjustes con un usuario específico.
        /// </summary>
        /// <param name="usuario">El objeto Usuario que se utilizará para inicializar el control.</param>
        public UserControlAjustes(Usuario usuario) : this()
        {
            // Asigna el usuario recibido por parámetro al atributo de la clase
            Usuario = usuario;
            // Muestra los datos del usuario
            MostrarDatosUsuario();
        }

        /// <summary>
        /// Muestra los datos del usuario
        /// </summary>
        private void MostrarDatosUsuario()
        {
            textBoxUsuario.Text = Usuario.Nombre;
            textBoxClave.Text = Usuario.Clave;
            textBoxClave2.Text = Usuario.Clave;
        }

        /// <summary>
        /// Maneja el evento de clic del botón para alternar la visibilidad de la contraseña.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonOcultar_Click(object sender, System.EventArgs e)
        {
            // Alterna el estado de visibilidad de la contraseña
            _claveVisible = !_claveVisible;
            // Ocultar-Mostrar clave
            CS_Config.OcultarMostrarClave(_claveVisible, textBoxClave, textBoxClave2);
        }

        /// <summary>
        /// Maneja el evento de clic del botón para alternar entre el modo de modificación y visualización.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonModificar_Click(object sender, System.EventArgs e)
        {
            // Alterna el estado de la variable _modificar.
            _modificar = !_modificar;
            // Si _modificar es true, habilita los campos para modificar los datos del usuario.
            if (_modificar) 
            {
                // Llama al método para habilitar los campos de entrada.
                CS_Config.HabilitarControles(_listaDeControles);
                // Modifica la apariencia del boton
                CS_Config.ModificarBoton(buttonModificar, "Cancelar", Color.Maroon);
            }
            else
            {
                // Llama al método para deshabilitar los campos de entrada.
                CS_Config.DeshabilitarControles(_listaDeControles);
                // Restaura los datos del usuario en los campos.
                MostrarDatosUsuario();
                // Modifica la apariencia del boton
                CS_Config.ModificarBoton(buttonModificar, "Modificar", Color.FromArgb(192, 192, 0));
            }
        }

        /// <summary>
        /// Maneja el evento de clic del botón para aceptar las modificaciones del usuario.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonAceptar_Click(object sender, System.EventArgs e)
        {
            // Muestra un cuadro de diálogo de confirmación para asegurar que el usuario desea actualizar los datos.
            DialogResult result = MessageBox.Show("¿Está seguro que desea actualizar los datos del usuario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            // Verifica si el usuario seleccionó "Sí" en el cuadro de diálogo de confirmación.
            if (result == DialogResult.Yes) 
            {
                // Verifica si el nombre de usuario o la clave han sido modificados.
                if (textBoxUsuario.Text != Usuario.Nombre || textBoxClave.Text != Usuario.Clave)
                {
                    // En el caso de pasar las validaciones, actualiza el usuario con los nuevos datos
                    string mensaje = CS_Usuario.ActualizarUsuarioPorId(Usuario.Id, textBoxUsuario.Text, textBoxClave.Text, textBoxClave2.Text);
                    // Muestra un mensaje de confirmacion 
                    MessageBox.Show(mensaje, "Mensaje");
                }
                else
                {
                    // Muestra un mensaje de advertencia
                    MessageBox.Show("Debe modificar el nombre de usuario o la clave", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonEliminar_Click(object sender, System.EventArgs e)
        {
            // Muestra un cuadro de diálogo de confirmación para asegurar que el usuario desea actualizar los datos.
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar su cuenta?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            // Verifica si el usuario seleccionó "Sí" en el cuadro de diálogo de confirmación.
            if (result == DialogResult.Yes)
            {
                string mensaje = CS_Usuario.EliminarUsuarioPorId(Usuario.Id);
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }

            // Salir de la sesion


        }
    }
}
