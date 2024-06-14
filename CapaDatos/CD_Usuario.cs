using System;
using System.Collections.Generic;
using CapaEntidades;
using System.Data.SqlClient;
using System.Collections;

namespace CapaDatos
{
    public static class CD_Usuario
    {
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
            catch (Exception ex)
            {
                // Manejo de excepciones: Mostrar un mensaje de error en la consola
                Console.WriteLine("Error al agregar usuario: " + ex.Message);
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
            catch (Exception ex)
            {
                // Manejo de excepciones: Mostrar un mensaje de error en la consola
                Console.WriteLine("Error al listar usuarios: " + ex.Message);
            }

            // Devolver la lista de usuarios
            return lista;
        }

        /// <summary>
        /// Actualiza los fondos totales de un usuario en la base de datos.
        /// </summary>
        /// <param name="idUsuario">ID del usuario cuyos fondos se van a actualizar.</param>
        /// <param name="nuevosFondos">Nuevos fondos del usuario.</param>
        public static void ActualizarFondos(string nombreUsuario, double nuevosFondos)
        {
            try
            {
                // Obtener la conexión
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();

                    // Consulta SQL para actualizar los fondos del usuario
                    string query = "UPDATE Usuario SET fondos = @NuevosFondos WHERE nombre = @NombreUsuario";

                    // Crear un comando SQL para ejecutar la consulta
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agregar los parámetros
                        comando.Parameters.AddWithValue("@NuevosFondos", nuevosFondos);
                        comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                        // Ejecutar la consulta
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al actualizar los fondos del usuario: " + ex.Message);
            }
        }

        public static void ActualizarFondosPorNombre(string nombreUsuario, double nuevosFondos)
        {
            try
            {
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    conexionDB.Open();
                    string query = "UPDATE Usuario SET fondos = @NuevosFondos WHERE nombre = @NombreUsuario";
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        comando.Parameters.AddWithValue("@NuevosFondos", nuevosFondos);
                        comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar los fondos del usuario: " + ex.Message);
            }
        }

        public static void ActualizarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    conexionDB.Open();
                    string query = "UPDATE Usuario SET caja = @FondosTotales WHERE nombre = @NombreUsuario";
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        comando.Parameters.AddWithValue("@FondosTotales", usuario.FondosTotales);
                        comando.Parameters.AddWithValue("@NombreUsuario", usuario.Nombre);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar los datos del usuario: " + ex.Message);
            }
        }

        public static Usuario ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            Usuario usuario = null;
            try
            {
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    conexionDB.Open();
                    string query = "SELECT nombre, clave, caja FROM Usuario WHERE nombre = @NombreUsuario";
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new Usuario();
                                usuario.Nombre = Convert.ToString(reader["nombre"]);
                                usuario.Clave = Convert.ToString(reader["clave"]);
                                usuario.FondosTotales = Convert.ToDouble(reader["caja"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el usuario por nombre: " + ex.Message);
            }
            return usuario;
        }

    }
}

