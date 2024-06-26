﻿using CapaServicios;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlRegistro : UserControl
    {
        // Atributos
        private bool _claveVisible = false;

        /// <summary>
        /// Constructor del control de usuario UserControlRegistro.
        /// </summary>
        public UserControlRegistro()
        {
            // Inicializa los componentes visuales del control de usuario.
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el evento de clic para el botón "Registrarse".
        /// Este método se llama cuando el usuario hace clic en el botón "Registrarse" en el formulario.
        /// Intenta registrar un nuevo usuario con el nombre de usuario y las contraseñas proporcionadas.
        /// </summary>
        /// <param name="sender">La fuente del evento, típicamente el botón que se hizo clic.</param>
        /// <param name="e">Una instancia que contiene los datos del evento.</param>
        private void buttonRegistrarse_Click(object sender, System.EventArgs e)
        {
            // Llama al método RegistrarUsuario de la clase csUsuario para registrar al usuario.
            string mensaje = CS_Usuario.RegistrarUsuario(textBoxUsuario.Text, textBoxClave.Text, textBoxClave2.Text);
            // Muestra un cuadro de mensaje con el resultado del intento de registro.
            MessageBox.Show(mensaje, "Mensaje");  
        }

        /// <summary>
        /// Maneja el evento de clic para el botón "Borrar".
        /// Este método se llama cuando el usuario hace clic en el botón "Borrar" en el formulario.
        /// Limpia los campos de texto de nombre de usuario y contraseñas.
        /// </summary>
        /// <param name="sender">La fuente del evento, típicamente el botón que se hizo clic.</param>
        /// <param name="e">Una instancia que contiene los datos del evento.</param>
        private void buttonBorrar_Click(object sender, System.EventArgs e)
        {
            // Limpia el texto en textBoxUsuario, textBoxClave y textBoxClave2.
            textBoxUsuario.Text = "";
            textBoxClave.Text = "";
            textBoxClave2.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic para el botón "Ocultar".
        /// Este método se llama cuando el usuario hace clic en el botón "Ocultar" en el formulario.
        /// Alterna la visibilidad de las contraseñas en los campos de texto.
        /// </summary>
        /// <param name="sender">La fuente del evento, típicamente el botón que se hizo clic.</param>
        /// <param name="e">Una instancia que contiene los datos del evento.</param>
        private void buttonOcultar_Click(object sender, System.EventArgs e)
        {
            // Alterna el estado de visibilidad de la contraseña
            _claveVisible = !_claveVisible;
            // Oculta-Muestra las claves
            CS_Config.OcultarMostrarClave(_claveVisible, textBoxClave, textBoxClave2);
        }

    }
}
