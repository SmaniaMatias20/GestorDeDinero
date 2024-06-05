using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CapaDatos;
using CapaEntidades;

namespace CapaServicios
{
    public class CS_Usuario
    {
        // Atributos
        private CD_Usuario cdUsuario;

        public CS_Usuario()
        {
            // Inicializa una nueva instancia de CD_Usuario para acceder a la capa de datos.
            cdUsuario = new CD_Usuario();
            
        }

        /// <summary>
        /// Valida las credenciales del usuario ingresado contra una lista de usuarios registrados.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario</param>
        /// <param name="clave">Clave del usuario</param>
        /// <returns>El usuario validado si las credenciales son válidas; de lo contrario, null.</returns>
        public Usuario ValidarUsuarioIniciarSesion(string nombreUsuario, string clave)
        {
            // Obtener la lista de usuarios desde la base de datos
            List<Usuario> listaDeUsuarios = cdUsuario.ListarUsuarios();

            // Recorre la lista de usuarios para verificar las credenciales ingresadas
            foreach (Usuario usuario in listaDeUsuarios)
            {
                if (usuario.Nombre == nombreUsuario && usuario.Clave == clave)
                {
                    return usuario;
                }
            }

            return null;
        }

        public string RegistrarUsuario(string nombre, string clave, string segundaClave) 
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = nombre;
            usuario.Clave = clave;

            // Si el usuario no se encuentra registrado
            if (ValidarUsuarioRegistrarse(usuario))
            {
                if (ValidarNombreUsuario(usuario.Nombre) == usuario.Nombre)
                {
                    if (ValidarClave(usuario.Clave, segundaClave) == usuario.Clave)
                    {
                        cdUsuario.AgregarUsuario(usuario.Nombre, usuario.Clave);
                        return "Se registró exitosamente...";
                    }
                    else
                    {
                        return ValidarClave(usuario.Clave, segundaClave);
                    }
                }
                else
                {
                    return ValidarNombreUsuario(usuario.Nombre);
                }
            }
            else
            {
                return "Ya existe el Usuario registrado";
            }


        }

        /// <summary>
        /// Valida si un nuevo usuario puede registrarse.
        /// Verifica que el nombre de usuario no esté ya registrado en la base de datos.
        /// </summary>
        /// <param name="nuevoUsuario">El objeto Usuario que contiene los datos del nuevo usuario a registrar.</param>
        /// <returns>
        /// Devuelve true si el nombre de usuario no está en uso y el registro puede proceder; 
        /// de lo contrario, devuelve false.
        /// </returns>
        private bool ValidarUsuarioRegistrarse(Usuario nuevoUsuario) 
        {
            // Obtener la lista de usuarios desde la base de datos
            List<Usuario> listaDeUsuarios = cdUsuario.ListarUsuarios();

            // Recorre la lista de usuarios para verificar las credenciales ingresadas
            foreach (Usuario usuario in listaDeUsuarios)
            {
                // Comprueba si el nombre del nuevo usuario ya existe en la lista de usuarios.
                if (nuevoUsuario.Nombre == usuario.Nombre)
                {
                    // Si se encuentra un nombre de usuario coincidente, devuelve false indicando que el usuario no puede registrarse.
                    return false;
                }
            }

            // Si no se encuentra un nombre de usuario coincidente, devuelve true indicando que el usuario puede registrarse.
            return true;

        }

        /// <summary>
        /// Valida si el nombre de usuario cumple con los requisitos especificados.
        /// Verifica que la longitud del nombre de usuario esté entre 10 y 20 caracteres,
        /// que no contenga espacios ni caracteres especiales, y que solo contenga letras y números.
        /// </summary>
        /// <param name="nombreUsuario">El nombre de usuario a validar.</param>
        /// <returns>
        /// Devuelve true si el nombre de usuario cumple con los requisitos;
        /// de lo contrario, devuelve false.
        /// </returns>
        private string ValidarNombreUsuario(string nombreUsuario)
        {
            if (nombreUsuario == "")
            {
                return "Ingrese un nombre de Usuario";
            }
            else if (nombreUsuario.Length > 20 || nombreUsuario.Length < 10)
            {
                return "El nombre de Usuario debe tener un minimo de 10 caracteres y un maximo de 20";
            }
            else if (nombreUsuario.Contains(" ") || !nombreUsuario.All(char.IsLetterOrDigit)) 
            {
                return "El nombre de Usuario no debe contener espacios o caracteres especiales";
            }

            return nombreUsuario;
        }

        private string ValidarClave(string clave, string segundaClave)
        {
            if (clave == "" || segundaClave == "")
            {
                return "Debe ingresar las claves";
            }
            else if (clave != segundaClave)
            {
                return "Las claves no coinciden";
            }
            else if (clave.Length > 20 || clave.Length < 5)
            {
                return "La clave debe tener un minimo de 5 caracteres y un maximo de 20";
            }
            else if (clave.Contains(" ")) 
            {
                return "La clave no puede contener espacios";
            }

            return clave;
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
            Usuario usuarioEncontrado = listaDeUsuarios.Find(u => u.Nombre == usuario.Nombre);

            // Si encontramos al usuario, devolvemos sus fondos totales. De lo contrario, devolvemos 0.
            return usuarioEncontrado != null ? usuarioEncontrado.FondosTotales : 0;
        }

        /// <summary>
        /// Actualiza los fondos del usuario en la base de datos.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario cuyos fondos se actualizarán.</param>
        /// <param name="importe">Cantidad a agregar a los fondos actuales del usuario.</param>
        public void ActualizarFondos(string nombreUsuario, double importe, bool ingreso)
        {
            // Aquí puedes implementar la lógica para actualizar los fondos del usuario en la base de datos.
            // Por ahora, simularemos que actualizamos los fondos en la base de datos CD_Usuario.

            // Obtener el usuario desde la base de datos
            Usuario usuario = cdUsuario.ObtenerUsuarioPorNombre(nombreUsuario);

            // Si el usuario existe, actualizamos sus fondos
            if (usuario != null && ingreso)
            {
                usuario.FondosTotales += importe;
                cdUsuario.ActualizarUsuario(usuario); // Método para actualizar el usuario en la base de datos.
            }
            else if (usuario != null && !ingreso)
            {
                if (importe <= usuario.FondosTotales)
                {
                    usuario.FondosTotales -= importe;
                    cdUsuario.ActualizarUsuario(usuario); // Método para actualizar el usuario en la base de datos.   
                }
            }
            else 
            {
                throw new Exception("Usuario no encontrado.");
            }
        }

        public string FormatearMoneda(double cantidad)
        {
            // Obtiene el formato de número específico para la cultura de Argentina (es-AR)
            var nfi = new System.Globalization.CultureInfo("es-AR", false).NumberFormat;

            // Configura para que no se muestren decimales en el formato de moneda
            nfi.CurrencyDecimalDigits = 2;

            // Convierte la cantidad a una cadena con formato de moneda utilizando la configuración de formato
            return cantidad.ToString("C", nfi);
        }
    }
}
