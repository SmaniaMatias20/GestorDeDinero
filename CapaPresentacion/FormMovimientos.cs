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
        private Usuario _usuario = new Usuario();    

        // Propiedades
        public Usuario Usuario { get; set; }

        // Constructores
        public FormMovimientos()
        {
            InitializeComponent();
        }

        public FormMovimientos(Usuario usuario) : this()
        { 
            Usuario = usuario;
            // Instancia un nuevo formulario de ingreso
            _userControlIngreso = new UserControlIngreso(Usuario);
            MostrarFormulario(_userControlIngreso);

            // Suscribir al evento AceptarClick del control de usuario (UserControlIngreso)
            _userControlIngreso.AceptarClick += UserControlIngreso_AceptarClick;
        } 

        private void FormMovimientos_Load(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion(); 
        }


        /// <summary>
        /// Limpia los controles actuales en el panelInicio y agrega un nuevo formulario a él.
        /// </summary>
        /// <param name="formulario">El Control que representa el formulario a mostrar en el panelInicio.</param>
        private void MostrarFormulario(Control formulario)
        {
            // Limpia todos los controles existentes del panelInicio
            panelIngreso.Controls.Clear();
            // Configura el nuevo formulario para que ocupe todo el panelInicio
            formulario.Dock = DockStyle.Fill;
            // Agrega el nuevo formulario a la colección de controles de panelInicio
            panelIngreso.Controls.Add(formulario);
        }

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instancia un nuevo formulario de ingreso
            _userControlIngreso = new UserControlIngreso();
            MostrarFormulario(_userControlIngreso);
        }

        private void reservarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instancia un nuevo formulario de reserva
            _userControlReserva = new UserControlReserva();
            MostrarFormulario(_userControlReserva);
        }

        private void retirarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instancia un nuevo formulario de retiro
            _userControlRetiro = new UserControlRetiro();
            MostrarFormulario(_userControlRetiro);
        }

        private void UserControlIngreso_AceptarClick(object sender, EventArgs e)
        {
            // Cerrar el formulario cuando se presiona el botón "Aceptar" en el control de usuario
            this.Close();
        }

    }
}
