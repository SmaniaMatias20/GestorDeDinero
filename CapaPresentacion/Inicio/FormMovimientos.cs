using CapaDatos;
using CapaEntidades;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormMovimientos : Form
    {
        // Atributos
        private UserControlIngreso _userControlIngreso;
        private UserControlReserva _userControlReserva;
        private UserControlRetiro _userControlRetiro;    

        // Propiedades
        public Usuario Usuario { get; set; }
        public UserControlReserva UserControlReserva { get; }

        /// <summary>
        /// Constructor para la clase FormMovimientos.
        /// Inicializa los componentes visuales del formulario.
        /// </summary>
        public FormMovimientos()
        {
            // Llama al método que inicializa los componentes visuales del formulario
            InitializeComponent();
        }

        /// <summary>
        /// Constructor para la clase FormMovimientos que acepta un objeto Usuario.
        /// Inicializa los componentes visuales y configura el formulario para manejar ingresos.
        /// </summary>
        /// <param name="usuario">El objeto Usuario para el cual se gestionan los movimientos.</param>
        public FormMovimientos(Usuario usuario) : this()
        {
            // Asigna el objeto Usuario proporcionado al campo Usuario de la clase
            Usuario = usuario;

            // Instancia un nuevo formulario de ingreso
            _userControlIngreso = new UserControlIngreso(Usuario);

            // Muestra el control de usuario de ingreso en el formulario
            MostrarUserControl(_userControlIngreso);

            // Suscribe el método UserControlIngreso_AceptarClick al evento AceptarClick del control de usuario
            _userControlIngreso.AceptarClick += UserControlIngreso_AceptarClick;
            
        }

        /// <summary>
        /// Maneja el evento de carga del formulario FormMovimientos.
        /// Inicializa una nueva instancia de la clase Conexion.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormMovimientos_Load(object sender, EventArgs e)
        {
            // Inicializa una nueva instancia de la clase Conexion
            //Conexion conexion = new Conexion(); 
            Conexion.ObtenerConexion();
        }


        /// <summary>
        /// Limpia los controles actuales en el panelInicio y agrega un nuevo formulario a él.
        /// </summary>
        /// <param name="control">El Control que representa el formulario a mostrar en el panelInicio.</param>
        public void MostrarUserControl(Control control)
        {
            // Limpia todos los controles existentes del panelInicio
            panelIngreso.Controls.Clear();
            // Configura el nuevo formulario para que ocupe todo el panelInicio
            control.Dock = DockStyle.Fill;
            // Agrega el nuevo formulario a la colección de controles de panelInicio
            panelIngreso.Controls.Add(control);
        }

        /// <summary>
        /// Maneja el evento de clic en el menú "Ingresar".
        /// Crea e instancia un nuevo formulario de ingreso y lo muestra en el formulario principal.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instancia un nuevo control de usuario para el ingreso
            _userControlIngreso = new UserControlIngreso();
            // Muestra el control de usuario de ingreso en el formulario principal
            MostrarUserControl(_userControlIngreso);
        }

        /// <summary>
        /// Maneja el evento de clic en el menú "Reservar".
        /// Crea e instancia un nuevo formulario de reserva y lo muestra en el formulario principal.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void reservarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instancia un nuevo control de usuario para la reserva
            _userControlReserva = new UserControlReserva(Usuario);
            // Muestra el control de usuario de reserva en el formulario principal
            MostrarUserControl(_userControlReserva);
            // Suscribe el método UserControlRetiro_AceptarClick al evento AceptarClick del control de usuario de reserva
            _userControlReserva.AceptarClick += UserControlReserva_AceptarClick;
        }

        /// <summary>
        /// Maneja el evento de clic en el menú "Retirar".
        /// Crea e instancia un nuevo formulario de retiro, lo muestra en el formulario principal
        /// y suscribe el método UserControlRetiro_AceptarClick al evento AceptarClick del formulario de retiro.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void retirarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instancia un nuevo control de usuario para el retiro, pasando el objeto Usuario
            _userControlRetiro = new UserControlRetiro(Usuario);
            // Muestra el control de usuario de retiro en el formulario principal
            MostrarUserControl(_userControlRetiro);
            // Suscribe el método UserControlRetiro_AceptarClick al evento AceptarClick del control de usuario de retiro
            _userControlRetiro.AceptarClick += UserControlRetiro_AceptarClick;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Aceptar" del control de usuario de ingreso.
        /// Cierra el formulario principal cuando se presiona el botón "Aceptar" en el control de usuario.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void UserControlIngreso_AceptarClick(object sender, EventArgs e)
        {
            // Cierra el formulario principal cuando se presiona el botón "Aceptar" en el control de usuario de ingreso
            this.Close();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Aceptar" del control de usuario de retiro.
        /// Cierra el formulario principal cuando se presiona el botón "Aceptar" en el control de usuario.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void UserControlRetiro_AceptarClick(object sender, EventArgs e)
        {
            // Cierra el formulario principal cuando se presiona el botón "Aceptar" en el control de usuario de retiro
            this.Close();
        }

        public void UserControlReserva_AceptarClick(object sender, EventArgs e)
        {
            // Cierra el formulario principal cuando se presiona el botón "Aceptar" en el control de usuario de reserva
            this.Close();
        }
    }
}
