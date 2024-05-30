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
        private Usuario _usuario = new Usuario();
        private CD_Usuario cdUsuario;

        // Propiedades
        public Usuario Usuario { get; set; }
         
        /// <summary>
        /// 
        /// </summary>
        public FormLogin()
        {
            InitializeComponent();
            cdUsuario = new CD_Usuario();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLogin_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxClave_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Maneja el evento de clic del botón Iniciar, validando las credenciales del usuario.
        /// Si las credenciales son correctas, muestra el formulario principal y registra el acceso del usuario.
        /// Si las credenciales son incorrectas, muestra un mensaje de error.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            if (ValidarUsuario())
            {
                // Crea una nueva instancia del formulario principal
                FormInicio formInicio = new FormInicio(Usuario);

                // Muestra el formulario principal
                formInicio.Show();

                // Registra el acceso del usuario actual
                RegistrarAccesoUsuario(textBoxUsuario.Text);

                // Oculta el formulario de inicio de sesión actual
                this.Hide();

                // Agrega un manejador para el evento de cierre del formulario principal
                formInicio.FormClosing += frm_closing;
            }
            else
            {
                // Muestra un mensaje de error si las credenciales son incorrectas
                MessageBox.Show("Error al ingresar el Usuario/Clave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de cierre del formulario, limpiando los campos de texto de usuario y clave, y mostrando el formulario actual.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento de cierre del formulario.</param>
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            // Limpia el contenido del cuadro de texto de usuario
            textBoxUsuario.Text = "";

            // Limpia el contenido del cuadro de texto de clave
            textBoxClave.Text = "";

            // Muestra el formulario actual
            this.Show();
        }

        /// <summary>
        /// Maneja el evento de clic del botón Borrar, limpiando los campos de texto de usuario y clave.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            // Limpia el contenido del cuadro de texto de usuario
            textBoxUsuario.Text = "";

            // Limpia el contenido del cuadro de texto de clave
            textBoxClave.Text = "";
        }

        /// <summary>
        /// Registra el acceso de un usuario en un archivo de log.
        /// </summary>
        /// <param name="nombreUsuario">El nombre del usuario cuyo acceso se va a registrar.</param>
        private void RegistrarAccesoUsuario(string nombreUsuario)
        {
            // Obtiene la ruta relativa del archivo de log
            string rutaRelativa = ObtenerRutaRelativa(@"C:\Users\Smania Matias\Desktop\Proyectos\GestorDeDinero\Usuarios.log");

            // Obtiene la fecha y hora actual en formato "yyyy-MM-dd HH:mm:ss"
            string fechaHoraActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Crea la cadena con la información del usuario y la fecha y hora de acceso
            string informacionUsuario = $"Usuario: {nombreUsuario}, Fecha y Hora de Acceso: {fechaHoraActual}";

            try
            {
                // Abre el archivo de log para escritura (en modo adjuntar) y escribe la información del usuario
                using (StreamWriter sw = new StreamWriter(rutaRelativa, true))
                {
                    sw.WriteLine(informacionUsuario);
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción al intentar escribir en el archivo
                MessageBox.Show($"Error al registrar el acceso del usuario: {ex.Message}");
            }
        }

        /// <summary>
        /// Valida las credenciales del usuario ingresado contra una lista de usuarios registrados.
        /// </summary>
        /// <returns>True si las credenciales son válidas; de lo contrario, false.</returns>
        private bool ValidarUsuario()
        {
            // Obtener la lista de usuarios desde la base de datos
            List<Usuario> listaDeUsuarios = cdUsuario.ListarUsuarios();

            // Recorre la lista de usuarios para verificar las credenciales ingresadas
            foreach (Usuario usuario in listaDeUsuarios)
            {
                if (usuario.NombreUsuario == textBoxUsuario.Text && usuario.Clave == textBoxClave.Text)
                {
                    //
                    Usuario = usuario;
                    // Si las credenciales coinciden, retorna true
                    return true;
                }
            }

            // Si ninguna credencial coincide, retorna false
            return false;
        }

        /// <summary>
        /// Obtiene la ruta relativa de un archivo dado su ruta absoluta.
        /// </summary>
        /// <param name="rutaAbsoluta">La ruta absoluta del archivo.</param>
        /// <returns>La ruta relativa desde el directorio base del proyecto o ejecutable hasta el archivo.</returns>
        private string ObtenerRutaRelativa(string rutaAbsoluta)
        {
            // Ruta del directorio base del proyecto o ejecutable
            string directorioBase = AppDomain.CurrentDomain.BaseDirectory;

            // Convertir las rutas a objetos Uri
            Uri uriArchivo = new Uri(rutaAbsoluta);
            Uri uriDirectorioBase = new Uri(directorioBase);

            // Calcular la ruta relativa
            Uri uriRelativa = uriDirectorioBase.MakeRelativeUri(uriArchivo);
            string rutaRelativa = Uri.UnescapeDataString(uriRelativa.ToString());

            // Convertir las barras diagonales a contrabarras si es necesario
            rutaRelativa = rutaRelativa.Replace('/', '\\');

            return rutaRelativa;
        }

    }
}
