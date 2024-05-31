using System;
using System.Collections.Generic;
using System.IO;
using CapaDatos;
using CapaEntidades;

namespace CapaServicios
{
    public class CS_Usuario
    {
        private CD_Usuario cdUsuario;

        public CS_Usuario()
        {
            cdUsuario = new CD_Usuario();
        }

        /// <summary>
        /// Valida las credenciales del usuario ingresado contra una lista de usuarios registrados.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario</param>
        /// <param name="clave">Clave del usuario</param>
        /// <returns>El usuario validado si las credenciales son válidas; de lo contrario, null.</returns>
        public Usuario ValidarUsuario(string nombreUsuario, string clave)
        {
            // Obtener la lista de usuarios desde la base de datos
            List<Usuario> listaDeUsuarios = cdUsuario.ListarUsuarios();

            // Recorre la lista de usuarios para verificar las credenciales ingresadas
            foreach (Usuario usuario in listaDeUsuarios)
            {
                if (usuario.NombreUsuario == nombreUsuario && usuario.Clave == clave)
                {
                    return usuario;
                }
            }

            return null;
        }

        /// <summary>
        /// Registra el acceso de un usuario en un archivo de log.
        /// </summary>
        /// <param name="nombreUsuario">El nombre del usuario cuyo acceso se va a registrar.</param>
        public void RegistrarAccesoUsuario(string nombreUsuario)
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
                throw new Exception($"Error al registrar el acceso del usuario: {ex.Message}");
            }
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

        /// <summary>
        /// Obtiene los fondos totales del usuario.
        /// </summary>
        /// <param name="usuario">El usuario del cual obtener los fondos totales.</param>
        /// <returns>Los fondos totales del usuario.</returns>
        public double ObtenerFondosTotales(Usuario usuario)
        {
            // Podrías obtener los fondos totales directamente desde la base de datos o implementar lógica adicional aquí.
            // Por ahora, simularemos que obtenemos los fondos totales desde la base de datos.

            // Supongamos que la base de datos devuelve una lista de usuarios donde podemos buscar al usuario específico.
            List<Usuario> listaDeUsuarios = cdUsuario.ListarUsuarios();

            // Buscamos al usuario específico en la lista
            Usuario usuarioEncontrado = listaDeUsuarios.Find(u => u.NombreUsuario == usuario.NombreUsuario);

            // Si encontramos al usuario, devolvemos sus fondos totales. De lo contrario, devolvemos 0.
            return usuarioEncontrado != null ? usuarioEncontrado.FondosTotales : 0;
        }

        /// <summary>
        /// Actualiza los fondos del usuario en la base de datos.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario cuyos fondos se actualizarán.</param>
        /// <param name="ingreso">Cantidad a agregar a los fondos actuales del usuario.</param>
        public void ActualizarFondos(string nombreUsuario, double ingreso)
        {
            // Aquí puedes implementar la lógica para actualizar los fondos del usuario en la base de datos.
            // Por ahora, simularemos que actualizamos los fondos en la base de datos CD_Usuario.

            // Obtener el usuario desde la base de datos
            Usuario usuario = cdUsuario.ObtenerUsuarioPorNombre(nombreUsuario);

            // Si el usuario existe, actualizamos sus fondos
            if (usuario != null)
            {
                usuario.FondosTotales += ingreso;
                cdUsuario.ActualizarUsuario(usuario); // Método para actualizar el usuario en la base de datos.
            }
            else
            {
                throw new Exception("Usuario no encontrado.");
            }
        }
    }
}
