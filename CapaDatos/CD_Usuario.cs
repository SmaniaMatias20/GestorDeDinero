using System;
using System.Collections.Generic;
using CapaEntidades;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Usuario
    {
        // Atributos
        private Conexion conexion = new Conexion();


        /// <summary>
        /// Obtiene una lista de usuarios desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Usuario que contiene el nombre y la clave de cada usuario.</returns>
        public List<Usuario> ListarUsuarios()
        {
            // Nuevo objeto de tipo lista de usuarios
            List<Usuario> lista = new List<Usuario>();

            try
            {
                // Abrir conexión
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();

                    // Consulta SQL para obtener los usuarios
                    string query = "SELECT nombre, clave, fondos FROM usuario";

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
                                usuario.NombreUsuario = Convert.ToString(reader["nombre"]);
                                usuario.Clave = Convert.ToString(reader["clave"]);
                                usuario.FondosTotales = Convert.ToDouble(reader["fondos"]);

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
        public void ActualizarFondos(string nombreUsuario, double nuevosFondos)
        {
            try
            {
                // Obtener la conexión
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
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

        public void ActualizarFondosPorNombre(string nombreUsuario, double nuevosFondos)
        {
            try
            {
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
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

        public void ActualizarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    conexionDB.Open();
                    string query = "UPDATE Usuario SET fondos = @FondosTotales WHERE nombre = @NombreUsuario";
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        comando.Parameters.AddWithValue("@FondosTotales", usuario.FondosTotales);
                        comando.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar los datos del usuario: " + ex.Message);
            }
        }

        public Usuario ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            Usuario usuario = null;
            try
            {
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    conexionDB.Open();
                    string query = "SELECT nombre, clave, fondos FROM Usuario WHERE nombre = @NombreUsuario";
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new Usuario();
                                usuario.NombreUsuario = Convert.ToString(reader["nombre"]);
                                usuario.Clave = Convert.ToString(reader["clave"]);
                                usuario.FondosTotales = Convert.ToDouble(reader["fondos"]);
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

