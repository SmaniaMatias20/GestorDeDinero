using System;
using System.Collections.Generic;
using CapaEntidades;
using System.Data.SqlClient;

namespace CapaDatos
{
    public static class CD_Usuario
    {
        /// <summary>
        /// Método para agregar un nuevo usuario a la base de datos.
        /// </summary>
        /// <param name="nombre">El nombre del usuario.</param>
        /// <param name="clave">La clave del usuario.</param>
        public static void AgregarUsuario(string nombre, string clave) 
        {
            try
            {
                // Abrir conexión
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();

                    // Consulta SQL para obtener los usuarios
                    string query = "INSERT INTO usuario (nombre, clave, caja) VALUES (@Nombre, @Clave, 0)";

                    // Crear un comando SQL para ejecutar la consulta
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {

                        // Agregar los parámetros
                        comando.Parameters.AddWithValue("@Nombre", nombre);
                        comando.Parameters.AddWithValue("@Clave", clave);

                        // Ejecutar la consulta
                        comando.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception e)
            {
                // Lanza una nueva excepción con un mensaje específico
                throw new Exception("Error al agregar el usuario" + e.Message);
            }

        }


        /// <summary>
        /// Obtiene una lista de usuarios desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Usuario que contiene el nombre y la clave de cada usuario.</returns>
        public static List<Usuario> ListarUsuarios()
        {
            // Nuevo objeto de tipo lista de usuarios
            List<Usuario> lista = new List<Usuario>();

            try
            {
                // Abrir conexión
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();

                    // Consulta SQL para obtener los usuarios
                    string query = "SELECT id, nombre, clave, caja FROM usuario";

                    // Crear un comando SQL para ejecutar la consulta
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Ejecutar la consulta y obtener los resultados en un SqlDataReader
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            // Recorrer los resultados y agregar los usuarios a la lista
                            while (reader.Read())
                            {
                                // Crear una nueva instancia de Usuario
                                Usuario usuario = new Usuario();

                                // Asignar los valores de las columnas del resultado a las propiedades del objeto Usuario
                                usuario.Id = Convert.ToInt32(reader["id"]); 
                                usuario.Nombre = Convert.ToString(reader["nombre"]);
                                usuario.Clave = Convert.ToString(reader["clave"]);
                                usuario.FondosTotales = Convert.ToDouble(reader["caja"]);

                                // Agregar el usuario a la lista
                                lista.Add(usuario);
                            }
                        }
                    }
                }
            }
            catch (Exception e) 
            {
                // Lanza una nueva excepción con un mensaje específico
                throw new Exception("Error al listar los usuarios" + e.Message);  
            }

            // Devuelve la lista de usuarios
            return lista;
        }

        /// <summary>
        /// Método para actualizar los datos de un usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">El objeto Usuario que contiene los datos actualizados.</param>
        public static void ActualizarUsuario(Usuario usuario)
        {
            // Bloque try-catch para manejar excepciones.
            try
            {
                // Utiliza una conexión a la base de datos obtenida desde el método Conexion.ObtenerConexion().
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    // Abre la conexión a la base de datos.
                    conexionDB.Open();
                    // Define la consulta SQL para actualizar los datos del usuario.
                    string query = "UPDATE Usuario SET caja = @FondosTotales WHERE nombre = @NombreUsuario";
                    // Crea un comando SQL con la consulta y la conexión a la base de datos.
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agrega los parámetros al comando SQL para prevenir inyección de SQL.
                        comando.Parameters.AddWithValue("@FondosTotales", usuario.FondosTotales);
                        comando.Parameters.AddWithValue("@NombreUsuario", usuario.Nombre);
                        // Ejecuta el comando SQL para actualizar los datos.
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e) 
            {
                throw new Exception("Error al actualizar el usuario" + e.Message);
            }
        }

        /// <summary>
        /// Método para obtener un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="nombreUsuario">El nombre del usuario que se quiere obtener.</param>
        /// <returns>Un objeto Usuario con los datos del usuario si se encuentra; de lo contrario, null.</returns>
        public static Usuario ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            // Inicializa el objeto usuario como null.
            Usuario usuario = null;
            // Bloque try-catch para manejar excepciones.
            try
            {
                // Utiliza una conexión a la base de datos obtenida desde el método Conexion.ObtenerConexion().
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    // Abre la conexión a la base de datos.
                    conexionDB.Open();
                    // Define la consulta SQL para obtener los datos del usuario.
                    string query = "SELECT nombre, clave, caja FROM Usuario WHERE nombre = @NombreUsuario";
                    // Crea un comando SQL con la consulta y la conexión a la base de datos.
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agrega el parámetro @NombreUsuario al comando SQL para prevenir inyección de SQL.
                        comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        // Ejecuta la consulta y obtiene un lector de datos.
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            // Verifica si se encontró un registro.
                            if (reader.Read())
                            {
                                // Si se encontró un registro, crea una nueva instancia del objeto Usuario.
                                usuario = new Usuario();
                                // Asigna los valores del lector de datos a las propiedades del objeto Usuario.
                                usuario.Nombre = Convert.ToString(reader["nombre"]);
                                usuario.Clave = Convert.ToString(reader["clave"]);
                                usuario.FondosTotales = Convert.ToDouble(reader["caja"]);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Lanza una nueva excepción con un mensaje específico
                throw new Exception("Error al obtener el usuario" + e.Message);
            }
            // Retorna el usuario
            return usuario;
        }

    }

}

