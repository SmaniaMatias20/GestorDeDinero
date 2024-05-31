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

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        

    }

}   
