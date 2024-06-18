using CapaDatos;
using CapaEntidades;
using CapaPresentacion.Ajustes;
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
        private UserControlAjustes _userControlAjustes;
 
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

            // Oculta los paneles de los botones
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;

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
            //Conexion conexion = new Conexion();

            buttonInicio.MouseEnter += new EventHandler(button_MouseEnter);
            buttonInicio.MouseLeave += new EventHandler(button_MouseLeave);
            buttonGastos.MouseEnter += new EventHandler(button_MouseEnter);
            buttonGastos.MouseLeave += new EventHandler(button_MouseLeave);
            buttonAjustes.MouseEnter += new EventHandler(button_MouseEnter);
            buttonAjustes.MouseLeave += new EventHandler(button_MouseLeave);
            buttonInversiones.MouseEnter += new EventHandler(button_MouseEnter);
            buttonInversiones.MouseLeave += new EventHandler(button_MouseLeave);
            buttonSalir.MouseEnter += new EventHandler(button_MouseEnter);
            buttonSalir.MouseLeave += new EventHandler(button_MouseLeave);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MouseEnter(object sender, EventArgs e)
        {
            // Obtener el botón que activó el evento
            Button button = sender as Button;

            // Determinar qué panel corresponde al botón y hacerlo visible
            switch (button.Name)
            {
                case "buttonInicio":
                    panel1.Visible = true;
                    break;
                case "buttonGastos":
                    panel2.Visible = true;
                    break;
                case "buttonInversiones":
                    panel3.Visible = true;
                    break;
                case "buttonAjustes":
                    panel4.Visible = true;
                    break;
                case "buttonSalir":
                    panel5.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MouseLeave(object sender, EventArgs e)
        {
            // Obtener el botón que activó el evento
            Button button = sender as Button;

            // Determinar qué panel corresponde al botón y ocultarlo
            switch (button.Name)
            {
                case "buttonInicio":
                    panel1.Visible = false;
                    break;
                case "buttonGastos":
                    panel2.Visible = false;
                    break;
                case "buttonInversiones":
                    panel3.Visible = false;
                    break;
                case "buttonAjustes":
                    panel4.Visible = false;
                    break;
                case "buttonSalir":
                    panel5.Visible = false;
                    break;
            }
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

        private void buttonGastos_Click(object sender, EventArgs e)
        {
            // Crea una instancia del control de usuario para la pantalla de gastos
            _userControlGastos = new UserControlGastos(Usuario);

            // Muestra el control de inicio en el formulario
            MostrarUserControl(_userControlGastos);

            // Modifica el titulo 
            labelTitulo.Text = "Gastos";

        }

        private void buttonInicio_Click(object sender, EventArgs e)
        {
            // Crea una instancia del control de usuario para la pantalla de inicio
            _userControlInicio = new UserControlInicio(Usuario);

            // Muestra el control de inicio en el formulario
            MostrarUserControl(_userControlInicio);

            // Modifica el titulo 
            labelTitulo.Text = "Inicio";

        }

        private void buttonInversiones_Click(object sender, EventArgs e)
        {
            // Crea una instancia del control de usuario para la pantalla de inicio
            _userControlInversion = new UserControlInversion(Usuario);

            // Muestra el control de inicio en el formulario
            MostrarUserControl(_userControlInversion);

            // Modifica el titulo 
            labelTitulo.Text = "Inversion";
        }

        private void buttonAjustes_Click(object sender, EventArgs e)
        {
            // Crea una instancia del control de usuario para la pantalla de inicio
            _userControlAjustes = new UserControlAjustes(Usuario);

            // Muestra el control de inicio en el formulario
            MostrarUserControl(_userControlAjustes);

            // Modifica el titulo 
            labelTitulo.Text = "Ajustes";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que quieres salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Si el usuario hace clic en "Sí", cerrar la aplicación
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
