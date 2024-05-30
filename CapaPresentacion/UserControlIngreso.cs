using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlIngreso : UserControl
    {
        // Atributos
        private Usuario _usuario = new Usuario();
        private CD_Usuario cdUsuario;
        public event EventHandler AceptarClick;

        // Propiedades
        public Usuario Usuario { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public UserControlIngreso()
        {
            InitializeComponent();
            cdUsuario = new CD_Usuario();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        public UserControlIngreso(Usuario usuario) : this()
        {
            Usuario = usuario;
            // Limpia el textBoxIngreso 
            textBoxIngreso.Text = "";
            // Asigna el metodo para solamente poder ingresar numeros
            textBoxIngreso.KeyPress += textBox_KeyPress;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxIngreso_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solamente números y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBorrarIngreso_Click(object sender, EventArgs e)
        {
            //
            textBoxIngreso.Text = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAceptarIngreso_Click(object sender, EventArgs e)
        {
            // Validar que el campo de ingreso no esté vacío
            if (string.IsNullOrWhiteSpace(textBoxIngreso.Text))
            {
                MessageBox.Show("Por favor ingrese un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el campo de ingreso contenga un número válido
            if (!double.TryParse(textBoxIngreso.Text, out double ingreso))
            {
                MessageBox.Show("Ingrese un número válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            // Obtener la lista de usuarios desde la base de datos
            List<Usuario> listaDeUsuarios = cdUsuario.ListarUsuarios();

            foreach (Usuario usuario in listaDeUsuarios)
            {
                // Operador ==() clase Usuario
                if (Usuario == usuario)
                {
                    // Actualizar el fondo del usuario en la base de datos
                    cdUsuario.ActualizarFondos(usuario.NombreUsuario, usuario.FondosTotales + ingreso);
                }
            }

            // Notificar que los fondos han sido actualizados
            MessageBox.Show("Los fondos han sido actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Dispara el evento AceptarClick cuando se presiona el botón "Aceptar"
            AceptarClick?.Invoke(this, EventArgs.Empty);
        }

    }
}
