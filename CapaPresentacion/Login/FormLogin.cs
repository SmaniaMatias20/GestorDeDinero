using System;
using System.IO;
using System.Windows.Forms;
using CapaEntidades;
using System.Collections.Generic;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        // Atributos
        private UserControlLogin _userControlLogin;
        private UserControlRegistro _userControlRegistro;

        /// <summary>
        /// Constructor de la clase FormLogin.
        /// Inicializa los componentes visuales del formulario y muestra el control de usuario de inicio de sesión.
        /// </summary>
        public FormLogin()
        {
            // Inicializa los componentes visuales del formulario
            InitializeComponent();

            // Crea una instancia del control de usuario de inicio de sesión
            _userControlLogin = new UserControlLogin();

            // Muestra el control de usuario de inicio de sesión en el formulario
            MostrarUserControl(_userControlLogin);

        }

        /// <summary>
        /// Muestra un control específico en el panel de login.
        /// </summary>
        /// <param name="formulario">El control que se va a mostrar en el panel de login.</param>
        private void MostrarUserControl(Control formulario)
        {
            // Limpia todos los controles existentes del panelInicio
            panelLogin.Controls.Clear();
            // Configura el nuevo formulario para que ocupe todo el panelInicio
            formulario.Dock = DockStyle.Fill;
            // Agrega el nuevo formulario a la colección de controles de panelInicio
            panelLogin.Controls.Add(formulario);
        }

        /// <summary>
        /// Maneja el evento de clic en el elemento de menú "Iniciar Sesión".
        /// Crea una instancia del control de usuario de inicio de sesión y lo muestra en el panel de login.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del control de usuario de inicio de sesión
            _userControlLogin = new UserControlLogin();
            // Muestra el control de usuario de inicio de sesión en el panel de login
            MostrarUserControl(_userControlLogin);
        }

        /// <summary>
        /// Maneja el evento de clic en el elemento de menú "Registrarse".
        /// Crea una instancia del control de usuario de registro y lo muestra en el panel de login.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void registrarseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del control de usuario de registro
            _userControlRegistro = new UserControlRegistro();
            // Muestra el control de usuario de registro en el panel de login
            MostrarUserControl(_userControlRegistro);
        }
    }
}
