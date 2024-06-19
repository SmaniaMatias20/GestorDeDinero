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
        /// Configura los eventos MouseEnter y MouseLeave para varios botones.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormInicio_Load(object sender, EventArgs e)
        {
            // Asocia el evento MouseEnter de cada botón con el método button_MouseEnter
            buttonInicio.MouseEnter += new EventHandler(button_MouseEnter);
            buttonGastos.MouseEnter += new EventHandler(button_MouseEnter);
            buttonAjustes.MouseEnter += new EventHandler(button_MouseEnter);
            buttonInversiones.MouseEnter += new EventHandler(button_MouseEnter);
            buttonSalir.MouseEnter += new EventHandler(button_MouseEnter);

            // Asocia el evento MouseLeave de cada botón con el método button_MouseLeave
            buttonInicio.MouseLeave += new EventHandler(button_MouseLeave);
            buttonGastos.MouseLeave += new EventHandler(button_MouseLeave);
            buttonAjustes.MouseLeave += new EventHandler(button_MouseLeave);
            buttonInversiones.MouseLeave += new EventHandler(button_MouseLeave);
            buttonSalir.MouseLeave += new EventHandler(button_MouseLeave);
        }

        /// <summary>
        /// Maneja el evento cuando el cursor entra en un botón en el formulario.
        /// Hace visible el panel correspondiente al botón.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (en este caso, el botón).</param>
        /// <param name="e">Los argumentos del evento.</param>
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
        /// Maneja el evento cuando el cursor sale de un botón en el formulario.
        /// Oculta el panel correspondiente al botón.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (en este caso, el botón).</param>
        /// <param name="e">Los argumentos del evento.</param>
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

        /// <summary>
        /// Maneja el evento de clic en el botón "Gastos".
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (en este caso, el botón).</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void buttonGastos_Click(object sender, EventArgs e)
        {
            // Crea una instancia del control de usuario para la pantalla de gastos
            _userControlGastos = new UserControlGastos(Usuario);

            // Muestra el control de inicio en el formulario
            MostrarUserControl(_userControlGastos);

            // Modifica el titulo 
            labelTitulo.Text = "Gastos";

        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Inicio".
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (en este caso, el botón).</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void buttonInicio_Click(object sender, EventArgs e)
        {
            // Crea una instancia del control de usuario para la pantalla de inicio
            _userControlInicio = new UserControlInicio(Usuario);

            // Muestra el control de inicio en el formulario
            MostrarUserControl(_userControlInicio);

            // Modifica el titulo 
            labelTitulo.Text = "Inicio";

        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Inversiones".
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (en este caso, el botón).</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void buttonInversiones_Click(object sender, EventArgs e)
        {
            // Crea una instancia del control de usuario para la pantalla de inicio
            _userControlInversion = new UserControlInversion(Usuario);

            // Muestra el control de inicio en el formulario
            MostrarUserControl(_userControlInversion);

            // Modifica el titulo 
            labelTitulo.Text = "Inversión";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Ajustes".
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (en este caso, el botón).</param>
        /// <param name="e">Los argumentos del evento.</param>
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
        /// Maneja el evento de clic en el botón "Salir".
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (en este caso, el botón).</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            // Muestra un cuadro de diálogo para confirmar si el usuario quiere salir
            DialogResult result = MessageBox.Show("¿Está seguro que quieres salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Si el usuario hace clic en "Sí", cerrar la aplicación
            if (result == DialogResult.Yes)
            {
                // Cierra la ventana actual del formulario
                this.Close();
            }
        }
    }
}
