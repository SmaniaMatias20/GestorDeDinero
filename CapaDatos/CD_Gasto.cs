using CapaEntidades.Enums;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using CapaEntidades.Entidades;

namespace CapaDatos
{
    public static class CD_Gasto
    {
        /// <summary>
        /// Obtiene una lista de usuarios desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Usuario que contiene el nombre y la clave de cada usuario.</returns>
        public static List<Gasto> ListarGastos(int idUsuario)
        {
            // Nuevo objeto de tipo lista de gastos
            List<Gasto> lista = new List<Gasto>();

            try
            {
                // Abrir conexión
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();

                    // Consulta SQL para obtener los gastos
                    string query = "SELECT id, tipo, importe, pago, descripcion, fecha FROM gasto WHERE id_usuario = @idUsuario";

                    // Crear un comando SQL para ejecutar la consulta
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agregar el parámetro al comando SQL
                        comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                        // Ejecutar la consulta y obtener los resultados en un SqlDataReader
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            // Recorrer los resultados y agregar los movimientos a la lista
                            while (reader.Read())
                            {
                                // Crear una nueva instancia de Gasto
                                Gasto gasto = new Gasto();

                                // Asignar los valores de las columnas del resultado a las propiedades del objeto Gasto
                                gasto.Id = Convert.ToInt32(reader["id"]);
                                if (Enum.TryParse(reader["tipo"].ToString(), out ETipoGasto tipoGasto))
                                {
                                    gasto.Tipo = tipoGasto;
                                }
                                gasto.Importe = Convert.ToDouble(reader["importe"]);
                                if (Enum.TryParse(reader["pago"].ToString(), out ETipoPago tipoPago))
                                {
                                    gasto.Pago = tipoPago;
                                }
                                gasto.Descripcion = Convert.ToString(reader["descripcion"]);
                                gasto.Fecha = Convert.ToString(reader["fecha"]);

                                // Agregar el gasto a la lista
                                lista.Add(gasto);
                            }
                        }
                    }
                }
            }
            catch
            {
                // Manejo de excepciones: Mostrar un mensaje de error en la consola
                throw new Exception("Entra aca");
            }

            // Devolver la lista de gastos
            return lista;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Gasto> ListarGastos(List<SqlParameter> parametros, string query)
        {
            // Nuevo objeto de tipo lista de gastos
            List<Gasto> lista = new List<Gasto>();

            try
            {
                // Abrir conexión
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();

                    // Crear un comando SQL para ejecutar la consulta
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agregar los parámetros al comando SQL
                        comando.Parameters.AddRange(parametros.ToArray());

                        // Ejecutar la consulta y obtener los resultados en un SqlDataReader
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            // Recorrer los resultados y agregar los movimientos a la lista
                            while (reader.Read())
                            {
                                // Crear una nueva instancia de Gasto
                                Gasto gasto = new Gasto
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Importe = Convert.ToDouble(reader["importe"]),
                                    Descripcion = Convert.ToString(reader["descripcion"]),
                                    Fecha = Convert.ToString(reader["fecha"])
                                };

                                // Asignar los valores de las columnas del resultado a las propiedades del objeto Gasto
                                if (Enum.TryParse(reader["tipo"].ToString(), out ETipoGasto tipoGasto))
                                {
                                    //
                                    gasto.Tipo = tipoGasto;
                                }
                                if (Enum.TryParse(reader["pago"].ToString(), out ETipoPago tipoPago))
                                {
                                    //
                                    gasto.Pago = tipoPago;
                                }

                                // Agregar el gasto a la lista
                                lista.Add(gasto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: Mostrar un mensaje de error en la consola
                throw new Exception("Error al listar los gastos.", ex);
            }

            // Devolver la lista de gastos
            return lista;
        }

        /// <summary>
        /// Agrega un nuevo gasto a la base de datos.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario asociado al gasto.</param>
        /// <param name="fecha">La fecha del gasto.</param>
        /// <param name="importe">El importe del gasto.</param>
        /// <param name="tipo">El tipo de gasto.</param>
        /// <param name="pago">El método de pago del gasto.</param>
        /// <param name="descripcion">La descripción del gasto.</param>
        /// <exception cref="Exception">Se lanza una excepción si ocurre un error durante la inserción del gasto en la base de datos.</exception>
        public static void AgregarGasto(int idUsuario, string fecha, double importe, ETipoGasto tipo, ETipoPago pago, string descripcion)
        {
            try
            {
                // Obtener la conexión
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();

                    // Consulta SQL para insertar un nuevo registro en la tabla gasto
                    string query = "INSERT INTO gasto (tipo, importe, fecha, id_usuario, pago, descripcion) VALUES (@tipo, @importe, @fecha, @idUsuario, @pago, @descripcion);";

                    // Crear un comando SQL para ejecutar la consulta
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agregar los parámetros
                        comando.Parameters.AddWithValue("@tipo", tipo.ToString());
                        comando.Parameters.AddWithValue("@importe", importe);
                        comando.Parameters.AddWithValue("@fecha", fecha);
                        comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                        comando.Parameters.AddWithValue("@pago", pago.ToString());
                        comando.Parameters.AddWithValue("@descripcion", descripcion);

                        // Ejecutar la consulta
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Si ocurre un error, se lanza una excepción con un mensaje descriptivo
                throw new Exception("Error al agregar el gasto");
            }
        }

        /// <summary>
        /// Elimina un gasto de la base de datos dado su ID.
        /// </summary>
        /// <param name="idGasto">El ID del gasto que se desea eliminar.</param>
        /// <exception cref="Exception">Se lanza una excepción si ocurre un error durante la eliminación del gasto en la base de datos.</exception>
        public static void EliminarGasto(int idGasto)
        {
            try
            {
                // Obtener la conexión a la base de datos
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();
                    // Consulta SQL para eliminar el registro de la tabla gasto
                    string query = "DELETE FROM gasto WHERE id = @idGasto";
                    // Crear un comando SQL para ejecutar la consulta de eliminación
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agregar el parámetro del ID del gasto a la consulta
                        comando.Parameters.AddWithValue("@idGasto", idGasto);
                        // Ejecutar la consulta para eliminar el gasto de la base de datos
                        int filasAfectadas = comando.ExecuteNonQuery();
                    }
                }
            }
            catch 
            {
                // Si ocurre un error, se lanza una excepción con un mensaje descriptivo
                throw new Exception("Error al eliminar un gasto");
            }
        }

        /// <summary>
        /// Obtiene un gasto de la base de datos dado su ID.
        /// </summary>
        /// <param name="idGasto">El ID del gasto que se desea obtener.</param>
        /// <returns>El objeto Gasto correspondiente al ID especificado.</returns>
        /// <exception cref="Exception">Se lanza una excepción si ocurre un error durante la obtención del gasto en la base de datos.</exception>
        public static Gasto ObtenerGasto(int idGasto)
        {
            try
            {
                // Obtiene la conexión a la base de datos
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    // Abre la conexión a la base de datos
                    conexionDB.Open();
                    // Consulta SQL para seleccionar el registro del gasto con el ID especificado
                    string query = "SELECT * FROM gasto WHERE id = @idGasto";
                    // Crea un comando SQL para ejecutar la consulta de selección
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agrega el parámetro del ID del gasto a la consulta
                        comando.Parameters.AddWithValue("@idGasto", idGasto);
                        // Ejecuta la consulta de selección y obtener los resultados
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            // Verifica si se encontró un gasto con el ID especificado
                            if (reader.Read())
                            {
                                // Crea un objeto Gasto y asignar sus propiedades con los valores obtenidos de la base de datos
                                Gasto gasto = new Gasto()
                                {
                                    Id = (int)reader["id"],
                                    Tipo = (ETipoGasto)Enum.Parse(typeof(ETipoGasto), reader["tipo"].ToString()),
                                    Importe = (double)reader["importe"],
                                    Pago = (ETipoPago)Enum.Parse(typeof(ETipoPago), reader["pago"].ToString()),
                                    Descripcion = reader["descripcion"].ToString(),
                                    Fecha = reader["fecha"].ToString()
                                };
                                // Asigna otros campos de la entidad Gasto según sea necesario
                                return gasto;
                            }
                            else
                            {
                                // Si ocurre un error, se lanza una excepción con un mensaje descriptivo
                                throw new Exception("Gasto no encontrado");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error, se lanza una excepción con un mensaje descriptivo
                throw new Exception("Error al obtener el gasto por ID: " + ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un gasto en la base de datos con los nuevos valores proporcionados.
        /// </summary>
        /// <param name="gasto">El objeto Gasto con los nuevos valores.</param>
        /// <exception cref="Exception">Se lanza una excepción si ocurre un error durante la actualización del gasto en la base de datos.</exception>
        public static void ActualizarGasto(Gasto gasto)
        {
            try
            {
                // Obtener la conexión a la base de datos
                using (SqlConnection conexionDB = Conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();
                    // Consulta SQL para actualizar el registro del gasto con el ID especificado
                    string query = "UPDATE gasto SET tipo = @tipo, importe = @importe, pago = @pago, descripcion = @descripcion, fecha = @fecha WHERE id = @idGasto";
                    // Crear un comando SQL para ejecutar la consulta de actualización
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agregar los parámetros con los nuevos valores del gasto
                        comando.Parameters.AddWithValue("@idGasto", gasto.Id);
                        comando.Parameters.AddWithValue("@tipo", gasto.Tipo.ToString());
                        comando.Parameters.AddWithValue("@importe", gasto.Importe);
                        comando.Parameters.AddWithValue("@pago", gasto.Pago.ToString());
                        comando.Parameters.AddWithValue("@descripcion", gasto.Descripcion);
                        comando.Parameters.AddWithValue("@fecha", gasto.Fecha);
                        // Ejecutar la consulta de actualización
                        int filasAfectadas = comando.ExecuteNonQuery();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error, se lanza una excepción con un mensaje descriptivo
                throw new Exception("Error al actualizar el gasto: " + ex.Message);
            }
        }

        
    }
}
