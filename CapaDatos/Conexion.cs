using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CapaDatos
{
    public static class Conexion
    {
        //private static string cadenaConexion = "Data Source=DESKTOP-HEJ5SS0\\SQLEXPRESS;Initial Catalog=GestorDeDineroDB;Integrated Security=True;";
        private static string cadenaConexion = ObtenerCadenaConexion();
        public static string Cadena { get; set; }


        /// <summary>
        /// Devuelve una nueva instancia de SqlConnection utilizando la cadena de conexión especificada.
        /// </summary>
        /// <returns>Una nueva instancia de SqlConnection.</returns>
        public static SqlConnection ObtenerConexion()
        {
            // Devuelve una nueva instancia de SqlConnection utilizando la cadena de conexión especificada.
            return new SqlConnection(cadenaConexion);
        }

        public static string ObtenerCadenaConexion()
        {
            // Leer la API key desde el archivo
            string filePath = "cadena_conexion.txt";
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath).Trim();
            }
            else
            {
                throw new FileNotFoundException("El archivo de la cadena de conexion no se encontró.");
            }
        }



    }

}   
