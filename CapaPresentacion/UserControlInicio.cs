using CapaEntidades;
using CapaServicios;
using System;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class UserControlInicio : UserControl
    {

        private Usuario _usuario = new Usuario();
        private CS_Usuario csUsuario;

        public Usuario Usuario { get; set; }

        public UserControlInicio()
        {
            InitializeComponent();
            csUsuario = new CS_Usuario();
        }

        public UserControlInicio(Usuario usuario) : this()
        {
            Usuario = usuario;
            ActualizarValorEnCaja(); // Actualizamos el valor en la caja al inicializar el control.
        }

        private void buttonMovimiento_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["formMovimientos"] == null)
            {
                FormMovimientos formMovimientos = new FormMovimientos(Usuario);
                formMovimientos.Show();
                formMovimientos.FormClosed += FormMovimientos_FormClosed;
                this.Enabled = false;
            }
        }

        private void FormMovimientos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            ActualizarValorEnCaja(); // Actualizamos el valor en la caja al cerrar el formulario de movimientos.
        }

        private void ActualizarValorEnCaja()
        {
            // Utilizamos el método ObtenerFondosTotales de CS_Usuario para obtener los fondos totales del usuario.
            double fondosTotales = csUsuario.ObtenerFondosTotales(Usuario);
            labelCaja.Text = $"${fondosTotales}";
        }
    }
}
