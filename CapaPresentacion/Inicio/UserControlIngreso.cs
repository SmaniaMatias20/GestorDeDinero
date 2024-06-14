using CapaEntidades;
using CapaEntidades.Enums;
using CapaServicios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlIngreso : UserControl
    {
        // Atributos
        private CS_Usuario _csUsuario; 
        private CS_Movimiento _csMovimiento;

        // Eventos
        public event EventHandler AceptarClick;

        // Propiedades
        public Usuario Usuario { get; set; }


        /// <summary>
        /// Constructor por defecto de la clase UserControlIngreso.
        /// Inicializa los componentes visuales y crea una nueva instancia de la clase CS_Usuario.
        /// </summary>
        public UserControlIngreso()
        {
            // Inicializa los componentes visuales del control de usuario
            InitializeComponent();
            // Crea una nueva instancia de la clase CS_Usuario para manejar la lógica relacionada con el usuario
            _csUsuario = new CS_Usuario();
            _csMovimiento = new CS_Movimiento();
        }

        /// <summary>
        /// Constructor con usuario
        /// </summary>
        /// <param name="usuario">El usuario actual</param>
        public UserControlIngreso(Usuario usuario) : this()
        {
            Usuario = usuario;
            // Limpia el textBoxIngreso 
            textBoxIngreso.Text = "";
            // Asigna el metodo para solamente poder ingresar numeros
            textBoxIngreso.KeyPress += CS_Config.textBox_KeyPress;

        }

        /// <summary>
        /// Maneja el evento TextChanged del textBoxIngreso
        /// </summary>
        private void textBoxIngreso_TextChanged(object sender, EventArgs e)
        {
            // Aquí puedes agregar código si deseas realizar alguna acción cuando cambia el texto del textBoxIngreso
        }

        /// <summary>
        /// Maneja el evento Click del botón BorrarIngreso para limpiar el textBoxIngreso
        /// </summary>
        private void buttonBorrarIngreso_Click(object sender, EventArgs e)
        {
            textBoxIngreso.Text = "";
        }

        /// <summary>
        /// Maneja el evento Click del botón AceptarIngreso para procesar el ingreso
        /// </summary>
        private void buttonAceptarIngreso_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que quieres realizar el ingreso?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Si el usuario hace clic en "Sí"
            if (result == DialogResult.Yes)
            {
                // Actualizar los fondos del usuario
                double movimientoValidado =_csUsuario.ActualizarFondos(Usuario.Nombre, textBoxIngreso.Text, ETipoMovimiento.Ingreso);

                // Registra el movimiento
                string mensaje = _csMovimiento.RegistrarMovimiento(Usuario.Id, movimientoValidado, ETipoMovimiento.Ingreso);

                // Notificar que los fondos han sido actualizados
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (mensaje == "Fondos actualizados correctamente")
                {
                    // Dispara el evento AceptarClick cuando se presiona el botón "Aceptar"
                    AceptarClick?.Invoke(this, EventArgs.Empty);
                }
                
            }



        }

       

    }
}
