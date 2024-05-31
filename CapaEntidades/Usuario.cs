using System.Collections.Generic;


namespace CapaEntidades
{
    public class Usuario
    {
        // Propiedades
        public string NombreUsuario { get; set; }

        public string Clave { get; set; }

        public double FondosTotales { get; set; }

        public List<double> Reservas { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase Usuario sin parámetros.
        /// </summary>
        public Usuario() 
        {
            // Inicializa la lista de reservas del usuario
            Reservas = new List<double>();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Usuario con el nombre de usuario, clave y fondos totales especificados.
        /// </summary>
        /// <param name="nombreUsuario">El nombre de usuario del usuario.</param>
        /// <param name="clave">La clave del usuario.</param>
        /// <param name="fondosTotales">Los fondos totales del usuario.</param>
        public Usuario(string nombreUsuario, string clave, double fondosTotales) : this() 
        {
            // Asigna los valores proporcionados a las propiedades del usuario
            NombreUsuario = nombreUsuario;
            Clave = clave; 
            FondosTotales = fondosTotales; 
        }

        /// <summary>
        /// Comprueba si dos usuarios son iguales comparando sus nombres de usuario y claves.
        /// </summary>
        /// <param name="usuario">El primer usuario a comparar.</param>
        /// <param name="otroUsuario">El segundo usuario a comparar.</param>
        /// <returns>True si los usuarios son iguales, False en caso contrario.</returns>
        //public static bool operator ==(Usuario usuario, Usuario otroUsuario) 
        //{
        //    // Compara los nombres de usuario y claves de los dos usuarios
        //    return usuario.NombreUsuario == otroUsuario.NombreUsuario && usuario.Clave == otroUsuario.Clave;
        //}

        /// <summary>
        /// Comprueba si dos usuarios son diferentes comparando sus nombres de usuario y claves.
        /// </summary>
        /// <param name="usuario">El primer usuario a comparar.</param>
        /// <param name="otroUsuario">El segundo usuario a comparar.</param>
        /// <returns>True si los usuarios son diferentes, False en caso contrario.</returns>
        //public static bool operator !=(Usuario usuario, Usuario otroUsuario)
        //{
        //    // Retorna el resultado opuesto de la comparación de igualdad entre los usuarios
        //    return !(usuario == otroUsuario);
        //}


    }
}
