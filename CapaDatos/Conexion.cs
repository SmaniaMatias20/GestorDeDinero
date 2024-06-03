using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CapaDatos
{
    public class Conexion
    {
        private string cadenaConexion = "Data Source=DESKTOP-HEJ5SS0\\SQLEXPRESS;Initial Catalog=GestorDeDineroDB;Integrated Security=True;";

        [JsonPropertyName("cadena")]
        public string Cadena { get; set; }

        public Conexion()
        {
        }

        /// <summary>
        /// Devuelve una nueva instancia de SqlConnection utilizando la cadena de conexión especificada.
        /// </summary>
        /// <returns>Una nueva instancia de SqlConnection.</returns>
        public SqlConnection ObtenerConexion()
        {
            // Devuelve una nueva instancia de SqlConnection utilizando la cadena de conexión especificada.
            return new SqlConnection(cadenaConexion);
        }

        

    }

}   
