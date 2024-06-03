using CapaDatos;
using CapaEntidades;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormInicio : Form
    {
        // Atributos
        private UserControlInicio _userControlInicio;
        private Usuario _usuario = new Usuario();   

        // Propiedades
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Constructor del formulario FormInicio.
        /// Inicializa los componentes y muestra el control de inicio en el formulario.
        /// </summary>
        public FormInicio()
        {
            // Inicializa los componentes del formulario
            InitializeComponent();

            DateTime ahora = DateTime.Now;
            labelFecha.Text = ahora.ToString("yyyy-MM-dd HH:mm");

        }

        /// <summary>
        /// Maneja el evento de carga del formulario FormInicio.
        /// Inicializa una nueva instancia de la clase Conexion.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormInicio_Load(object sender, EventArgs e)
        {
            // Inicializa una nueva instancia de la clase Conexion
            Conexion conexion = new Conexion(); 
        }

        /// <summary>
        /// Constructor para la clase FormInicio que acepta un objeto Usuario.
        /// Inicializa los componentes visuales del formulario y configura la pantalla de inicio con los datos del usuario.
        /// </summary>
        /// <param name="usuario">El objeto Usuario que representa al usuario actual.</param>
        public FormInicio(Usuario usuario) : this() 
        { 
            // Asigna el usuario recibido por parametro al atributo
            Usuario = usuario;

            // Crea una instancia del control de usuario para la pantalla de inicio
            _userControlInicio = new UserControlInicio(Usuario);

            // Muestra el control de inicio en el formulario
            MostrarFormulario(_userControlInicio);

            // Coloca el nombre de Usuario en el label
            labelNombreUsuario.Text = Usuario.NombreUsuario;

        }

        /// <summary>
        /// Limpia los controles actuales en el panelInicio y agrega un nuevo formulario a él.
        /// </summary>
        /// <param name="formulario">El Control que representa el formulario a mostrar en el panelInicio.</param>
        private void MostrarFormulario(Control formulario)
        {
            // Limpia todos los controles existentes del panelInicio
            panelInicio.Controls.Clear();
            // Configura el nuevo formulario para que ocupe todo el panelInicio
            formulario.Dock = DockStyle.Fill;
            // Agrega el nuevo formulario a la colección de controles de panelInicio
            panelInicio.Controls.Add(formulario);
        }


        private void panelInicio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxUsuario_Click(object sender, EventArgs e)
        {

        }

    }
}
