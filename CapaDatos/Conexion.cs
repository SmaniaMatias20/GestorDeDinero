using System.Data.SqlClient;


namespace CapaDatos
{
    public class Conexion
    {
        private string cadenaConexion = "Data Source=DESKTOP-HEJ5SS0\\SQLEXPRESS;Initial Catalog=GestorDeDineroDB;Integrated Security=True;";


        public Conexion() 
        {
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        


    }
}
