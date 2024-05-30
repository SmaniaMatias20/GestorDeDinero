using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlInicio : UserControl
    {
        // Atributos
        private Usuario _usuario = new Usuario();
        private CD_Usuario cdUsuario;

        // Propiedades
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia del UserControlInicio.
        /// </summary>
        public UserControlInicio()
        {
            InitializeComponent();
            cdUsuario = new CD_Usuario();

        }

        /// <summary>
        /// Inicializa una nueva instancia del UserControlInicio con un usuario específico.
        /// </summary>
        /// <param name="usuario">El usuario cuyos datos se mostrarán en el control.</param>
        public UserControlInicio(Usuario usuario) : this() 
        { 
            // Asigna el valor del usuario
            Usuario = usuario;

            // Muestra el valor en la caja
            ActualizarValorEnCaja();
            
        }

        /// <summary>
        /// Maneja el evento de clic del botón Movimiento.
        /// Abre el formulario de movimientos solo si no está abierto actualmente.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonMovimiento_Click(object sender, EventArgs e)
        {
            // Verifica si el formulario de movimientos no está abierto actualmente
            if (Application.OpenForms["formMovimientos"] == null)
            {
                // Crea una nueva instancia del formulario de movimientos y lo muestra
                FormMovimientos formMovimientos = new FormMovimientos(Usuario);
                formMovimientos.Show();

                // Maneja el evento FormClosed del formulario de movimientos
                formMovimientos.FormClosed += FormMovimientos_FormClosed;

                // Desactiva el formulario padre (formInicio)
                this.Enabled = false;
                
            }


        }

        /// <summary>
        /// Maneja el evento de cierre del formulario de movimientos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento de cierre del formulario.</param>
        private void FormMovimientos_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Re-activa el UserControl
            this.Enabled = true;

            // Actualiza el valor en la caja
            ActualizarValorEnCaja();
        }

        /// <summary>
        /// Actualiza el valor de la caja con los fondos totales del usuario actual.
        /// </summary>
        private void ActualizarValorEnCaja()
        {
            // Obtener la lista de usuarios desde la base de datos
            List<Usuario> listaDeUsuarios = cdUsuario.ListarUsuarios();


            // Recorre cada usuario en la lista de usuarios
            foreach (Usuario usuario in listaDeUsuarios)
            {
                // Comprueba si el usuario actual coincide con el usuario de este control
                if (Usuario == usuario)
                {
                    // Actualiza los fondos totales del usuario actual con los fondos del usuario encontrado
                    Usuario.FondosTotales = usuario.FondosTotales;

                    // Asigna los fondos totales del usuario a la caja
                    labelCaja.Text = $"${Usuario.FondosTotales}";
                    break;
                }
            }

        }
    }
}
