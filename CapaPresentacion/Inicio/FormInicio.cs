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
        private UserControlGastos _userControlGastos;
        private UserControlInversion _userControlInversion;

        //private Usuario _usuario = new Usuario();   

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
            MostrarUserControl(_userControlInicio);

            // Coloca el nombre de Usuario en el label
            labelNombreUsuario.Text = Usuario.Nombre;

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
        /// Limpia los controles actuales en el panelInicio y agrega un nuevo formulario a él.
        /// </summary>
        /// <param name="formulario">El Control que representa el formulario a mostrar en el panelInicio.</param>
        private void MostrarUserControl(Control control)
        {
            // Limpia todos los controles existentes del panelInicio
            panelInicio.Controls.Clear();
            // Configura el nuevo formulario para que ocupe todo el panelInicio
            control.Dock = DockStyle.Fill;
            // Agrega el nuevo formulario a la colección de controles de panelInicio
            panelInicio.Controls.Add(control);
        }


        private void panelInicio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxUsuario_Click(object sender, EventArgs e)
        {

        }

        private void buttonGastos_Click(object sender, EventArgs e)
        {
            // Crea una instancia del control de usuario para la pantalla de gastos
            _userControlGastos = new UserControlGastos(Usuario);

            // Muestra el control de inicio en el formulario
            MostrarUserControl(_userControlGastos);

            labelTitulo.Text = "Gastos";

        }

        private void buttonInicio_Click(object sender, EventArgs e)
        {
            // Crea una instancia del control de usuario para la pantalla de inicio
            _userControlInicio = new UserControlInicio(Usuario);

            // Muestra el control de inicio en el formulario
            MostrarUserControl(_userControlInicio);

            labelTitulo.Text = "Inicio";

        }

        private void buttonInversiones_Click(object sender, EventArgs e)
        {
            // Crea una instancia del control de usuario para la pantalla de inicio
            _userControlInversion = new UserControlInversion(Usuario);

            // Muestra el control de inicio en el formulario
            MostrarUserControl(_userControlInversion);

            labelTitulo.Text = "Inversiones";
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
