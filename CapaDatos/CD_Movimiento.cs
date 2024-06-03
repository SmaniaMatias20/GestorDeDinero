

using CapaEntidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace CapaDatos
{
    public class CD_Movimiento
    {
        // Atributos
        private Conexion conexion = new Conexion();

        /// <summary>
        /// Obtiene una lista de usuarios desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Usuario que contiene el nombre y la clave de cada usuario.</returns>
        public List<Movimiento> ListarMovimientos(int idUsuario)
        {
            // Nuevo objeto de tipo lista de usuarios
            List<Movimiento> lista = new List<Movimiento>();

            try
            {
                // Abrir conexión
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();

                    // Consulta SQL para obtener los usuarios
                    string query = "SELECT id, tipo, importe, fecha FROM movimiento WHERE id_usuario == @idUsuario";

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
                                Movimiento movimiento = new Movimiento();

                                // Asignar los valores de las columnas del resultado a las propiedades del objeto Usuario
                                movimiento.Id = Convert.ToInt32(reader["id"]);
                                movimiento.Tipo = Convert.ToString(reader["tipo"]);
                                movimiento.Importe = Convert.ToDouble(reader["importe"]);
                                movimiento.Fecha = Convert.ToString(reader["fecha"]);

                                // Agregar los parámetros
                                comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                                // Agregar el usuario a la lista
                                lista.Add(movimiento);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: Mostrar un mensaje de error en la consola
                Console.WriteLine("Error al listar movimientos: " + ex.Message);
            }

            // Devolver la lista de usuarios
            return lista;
        }

        public void AgregarMovimiento(int idUsuario, string fecha, double importe, string tipo)
        {
            try
            {
                // Obtener la conexión
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();

                    // Consulta SQL para insertar un nuevo registro en la tabla movimiento
                    string query = "INSERT INTO movimiento (tipo, importe, fecha, id_usuario) VALUES (@tipo, @importe, @fecha, @idUsuario);";

                    // Crear un comando SQL para ejecutar la consulta
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agregar los parámetros
                        comando.Parameters.AddWithValue("@tipo", tipo);
                        comando.Parameters.AddWithValue("@importe", importe);
                        comando.Parameters.AddWithValue("@fecha", fecha);
                        comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                        // Ejecutar la consulta
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al agregar un nuevo movimiento: " + ex.Message);
            }
        }
    }
}
