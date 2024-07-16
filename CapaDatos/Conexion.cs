using System.Data.SqlClient;
using System.IO;

namespace CapaDatos
{
    public static class Conexion
    {
        // Atributos
        private static string _cadenaConexion = ObtenerCadenaConexion();

        /// <summary>
        /// Devuelve una nueva instancia de SqlConnection utilizando la cadena de conexión especificada.
        /// </summary>
        /// <returns>Una nueva instancia de SqlConnection.</returns>
        public static SqlConnection ObtenerConexion()
        {
            // Devuelve una nueva instancia de SqlConnection utilizando la cadena de conexión especificada.
            return new SqlConnection(_cadenaConexion);
        }

        /// <summary>
        /// Obtiene la cadena de conexión desde un archivo de texto.
        /// </summary>
        /// <returns>La cadena de conexión como una cadena de texto.</returns>
        /// <exception cref="FileNotFoundException">Se lanza si el archivo de la cadena de conexión no se encuentra.</exception>
        public static string ObtenerCadenaConexion()
        {
            // Leer la API key desde el archivo
            string filePath = "cadena_conexion.txt";
            // Verificar si el archivo existe en la ruta especificada
            if (File.Exists(filePath))
            {
                // Leer el contenido del archivo y devolverlo como una cadena de texto, eliminando cualquier espacio en blanco adicional
                return File.ReadAllText(filePath).Trim();
            }
            else
            {
                // Lanzar una excepción si el archivo no se encuentra
                throw new FileNotFoundException("El archivo de la cadena de conexion no se encontró.");
            }
        }



    }

}   
