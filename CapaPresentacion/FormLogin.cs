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

        public FormLogin()
        {
            InitializeComponent();

            _userControlLogin = new UserControlLogin();
            MostrarUserControl(_userControlLogin);

        }

        private void MostrarUserControl(Control formulario)
        {
            // Limpia todos los controles existentes del panelInicio
            panelLogin.Controls.Clear();
            // Configura el nuevo formulario para que ocupe todo el panelInicio
            formulario.Dock = DockStyle.Fill;
            // Agrega el nuevo formulario a la colección de controles de panelInicio
            panelLogin.Controls.Add(formulario);
        }

        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _userControlLogin = new UserControlLogin();
            MostrarUserControl(_userControlLogin);
        }

        private void registrarseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _userControlRegistro = new UserControlRegistro();
            MostrarUserControl(_userControlRegistro);
        }
    }
}
