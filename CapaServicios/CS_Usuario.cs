using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatos;
using CapaEntidades;
using CapaEntidades.Enums;

namespace CapaServicios
{
    public static class CS_Usuario
    {

        /// <summary>
        /// Valida las credenciales del usuario ingresado contra una lista de usuarios registrados.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario</param>
        /// <param name="clave">Clave del usuario</param>
        /// <returns>El usuario validado si las credenciales son válidas; de lo contrario, null.</returns>
        public static Usuario IniciarSesion(string nombreUsuario, string clave)
        {
            // Obtener la lista de usuarios desde la base de datos
            List<Usuario> listaDeUsuarios = CD_Usuario.ListarUsuarios();

            // Recorre la lista de usuarios para verificar las credenciales ingresadas
            foreach (Usuario usuario in listaDeUsuarios)
            {
                // Compara el nombre de usuario y la clave con todos los usuarios registrados 
                if (usuario.Nombre == nombreUsuario && usuario.Clave == clave)
                {
                    // Retorna el usuario
                    return usuario;
                }
            }
            // Retorna null
            return null;
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
        private static string ValidarNombreUsuario(string nombreUsuario)
        {
            // Constantes para mensajes de error
            const string ErrorNombreVacio = "Ingrese un nombre de usuario";
            const string ErrorLongitudNombre = "El nombre de usuario debe tener un mínimo de 10 caracteres y un máximo de 20";
            const string ErrorCaracteresNombre = "El nombre de usuario no debe contener espacios o caracteres especiales";

            // Verifica si el nombre de usuario está vacío o contiene solo espacios en blanco
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                // Retorna un mensaje de error
                return ErrorNombreVacio;
            }

            // Verifica la longitud del nombre de usuario
            if (nombreUsuario.Length > 20 || nombreUsuario.Length < 10)
            {
                // Retorna un mensaje de error
                return ErrorLongitudNombre;
            }

            // Verifica si el nombre de usuario contiene espacios o caracteres especiales
            if (nombreUsuario.Contains(" ") || !nombreUsuario.All(char.IsLetterOrDigit))
            {
                // Retorna un mensaje de error
                return ErrorCaracteresNombre;
            }

            // Si todas las validaciones pasan, retorna el nombre de usuario
            return nombreUsuario;
        }

        /// <summary>
        /// Valida las claves proporcionadas según ciertos criterios.
        /// </summary>
        /// <param name="clave">La primera clave a validar.</param>
        /// <param name="segundaClave">La segunda clave para comparar con la primera.</param>
        /// <returns>La clave validada si todas las condiciones se cumplen, o un mensaje de error si alguna validación falla.</returns>
        private static string ValidarClave(string clave, string segundaClave)
        {
            // Constantes para mensajes de error
            const string ErrorClavesVacias = "Debe ingresar las claves";
            const string ErrorClavesNoCoinciden = "Las claves no coinciden";
            const string ErrorLongitudClave = "La clave debe tener un mínimo de 5 caracteres y un máximo de 20";
            const string ErrorClaveConEspacios = "La clave no puede contener espacios";

            // Verifica si las claves están vacías o contienen solo espacios en blanco
            if (string.IsNullOrWhiteSpace(clave) || string.IsNullOrWhiteSpace(segundaClave))
            {
                // Retorna un mensaje de error
                return ErrorClavesVacias;
            }

            // Verifica si las claves coinciden
            if (clave != segundaClave)
            {
                // Retorna un mensaje de error
                return ErrorClavesNoCoinciden;
            }

            // Verifica la longitud de la clave
            if (clave.Length > 20 || clave.Length < 5)
            {
                // Retorna un mensaje de error
                return ErrorLongitudClave;
            }

            // Verifica si la clave contiene espacios
            if (clave.Contains(" "))
            {
                // Retorna un mensaje de error
                return ErrorClaveConEspacios;
            }

            // Si todas las validaciones pasan, retorna la clave
            return clave;
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="nombre">El nombre del usuario a registrar.</param>
        /// <param name="clave">La clave del usuario a registrar.</param>
        /// <param name="segundaClave">La segunda clave para confirmar la primera clave.</param>
        /// <returns>Un mensaje indicando el resultado del registro.</returns>
        public static string RegistrarUsuario(string nombre, string clave, string segundaClave)
        {
            // Crear una instancia de Usuario con el nombre y la clave proporcionados
            Usuario usuario = new Usuario
            {
                Nombre = nombre,
                Clave = clave
            };

            // Verificar si el usuario ya está registrado
            if (!ValidarUsuario(usuario))
            {
                // Si el usuario ya está registrado, retornar un mensaje de error
                return "Ya existe el Usuario registrado";
            }

            // Validar el nombre de usuario
            string validacionNombre = ValidarNombreUsuario(usuario.Nombre);

            if (validacionNombre != usuario.Nombre)
            {
                // Si la validación del nombre falla, retornar el mensaje de error correspondiente
                return validacionNombre;
            }

            // Validar la clave del usuario
            string validacionClave = ValidarClave(usuario.Clave, segundaClave);

            if (validacionClave != usuario.Clave)
            {
                // Si la validación de la clave falla, retornar el mensaje de error correspondiente
                return validacionClave;
            }

            // Agregar el usuario a la capa de datos
            CD_Usuario.AgregarUsuario(usuario.Nombre, usuario.Clave);
            // Retornar un mensaje indicando que el registro fue exitoso
            return "Se registró exitosamente...";
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
        private static bool ValidarUsuario(Usuario nuevoUsuario) 
        {
            // Obtener la lista de usuarios desde la base de datos
            List<Usuario> listaDeUsuarios = CD_Usuario.ListarUsuarios();

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
        /// Obtiene los fondos totales del usuario.
        /// </summary>
        /// <param name="usuario">El usuario del cual obtener los fondos totales.</param>
        /// <returns>Los fondos totales del usuario.</returns>
        public static double ObtenerFondosTotales(Usuario usuario)
        { 
            // Supongamos que la base de datos devuelve una lista de usuarios donde podemos buscar al usuario específico.
            List<Usuario> listaDeUsuarios = CD_Usuario.ListarUsuarios();

            // Buscamos al usuario específico en la lista
            Usuario usuarioEncontrado = listaDeUsuarios.Find(u => u.Nombre == usuario.Nombre);

            // Si encontramos al usuario, devolvemos sus fondos totales. De lo contrario, devolvemos 0.
            return usuarioEncontrado != null ? usuarioEncontrado.FondosTotales : 0;
        }

        /// <summary>
        /// Actualiza los fondos del usuario en la base de datos.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario cuyos fondos se actualizarán.</param>
        /// <param name="importe">Cantidad a agregar o retirar de los fondos actuales del usuario.</param>
        /// <param name="tipoMovimiento">El tipo de movimiento a realizar (Ingreso, Retiro, Reserva).</param>
        /// <returns>El importe validado que se ha agregado o retirado.</returns>
        /// <exception cref="Exception">Lanzada cuando el usuario no es encontrado.</exception>
        public static Usuario ActualizarFondos(string nombreUsuario, double importe, ETipoMovimiento tipoMovimiento)
        {
            // Obtener el usuario desde la base de datos
            Usuario usuario = CD_Usuario.ObtenerUsuarioPorNombre(nombreUsuario);

            // Si el usuario existe y el tipo de movimiento es Ingreso, actualizamos sus fondos sumando el importe validado
            if (usuario != null && tipoMovimiento == ETipoMovimiento.Ingreso)
            {
                // Sumar el importe al fondo total del usuario
                usuario.FondosTotales += importe;
                // Actualizar el usuario en la base de datos
                CD_Usuario.ActualizarFondos(usuario);
            }
            // Si el usuario existe y el tipo de movimiento es Retiro o Reserva, restamos el importe validado de los fondos
            else if (usuario != null && (tipoMovimiento == ETipoMovimiento.Retiro || tipoMovimiento == ETipoMovimiento.Reserva))
            {
                // Verificamos que el usuario tenga fondos suficientes antes de realizar la operación
                if (importe <= usuario.FondosTotales)
                {
                    // Restar el importe del fondo total del usuario
                    usuario.FondosTotales -= importe;
                    // Actualizar el usuario en la base de datos
                    CD_Usuario.ActualizarFondos(usuario);
                }

            }
            else 
            {
                // Si el usuario no es encontrado, lanzamos una excepción
                throw new Exception("Usuario no encontrado.");
            }

            // Retornar el usuario actualizado con los fondos modificados
            return usuario; 
        }

        public static string ActualizarUsuarioPorId(int idUsuario, string nuevoNombre, string nuevaClave, string segundaClave) 
        {
            // Validar el nombre de usuario
            string validacionNombre = ValidarNombreUsuario(nuevoNombre);
            //
            if (validacionNombre != nuevoNombre)
            {
                // Si la validación del nombre falla, retornar el mensaje de error correspondiente
                return validacionNombre;
            }

            // Validar la clave del usuario
            string validacionClave = ValidarClave(nuevaClave, segundaClave);
            //
            if (validacionClave != nuevaClave)
            {
                // Si la validación de la clave falla, retornar el mensaje de error correspondiente
                return validacionClave;
            }

            CD_Usuario.ActualizarUsuario(idUsuario, nuevoNombre, nuevaClave);
            return "Se actualizaron correctamente los datos del usuario";
        }

        public static string EliminarUsuarioPorId(int idUsuario) 
        {
            string mensaje = CD_Usuario.EliminarUsuario(idUsuario);
            return mensaje;
        }

    }
}
