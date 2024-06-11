using CapaEntidades.Enums;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using CapaEntidades.Entidades;

namespace CapaDatos
{
    public class CD_Gasto
    {
        // Atributos
        private Conexion conexion = new Conexion();


        /// <summary>
        /// Obtiene una lista de usuarios desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Usuario que contiene el nombre y la clave de cada usuario.</returns>
        public List<Gasto> ListarGastos(int idUsuario)
        {
            // Nuevo objeto de tipo lista de gastos
            List<Gasto> lista = new List<Gasto>();

            try
            {
                // Abrir conexión
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
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

        public void AgregarGasto(int idUsuario, string fecha, double importe, ETipoGasto tipo, ETipoPago pago, string descripcion)
        {
            try
            {
                // Obtener la conexión
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();

                    // Consulta SQL para insertar un nuevo registro en la tabla gasto
                    string query = "INSERT INTO gasto (tipo, importe, fecha, id_usuario, pago, descripcion) VALUES (@tipo, @importe, @fecha, @idUsuario, @pago, @descripcion);";

                    // Crear un comando SQL para ejecutar la consulta
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agregar los parámetros
                        comando.Parameters.AddWithValue("@tipo", tipo);
                        comando.Parameters.AddWithValue("@importe", importe);
                        comando.Parameters.AddWithValue("@fecha", fecha);
                        comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                        comando.Parameters.AddWithValue("@pago", pago);
                        comando.Parameters.AddWithValue("@descripcion", descripcion);

                        // Ejecutar la consulta
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Manejo de excepciones
                throw new Exception("Error al agregar el gasto");
            }
        }

        public void EliminarGasto(int idGasto)
        {
            try
            {
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    conexionDB.Open();

                    string query = "DELETE FROM gasto WHERE id = @idGasto";

                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        comando.Parameters.AddWithValue("@idGasto", idGasto);
                        int filasAfectadas = comando.ExecuteNonQuery();
                    }
                }
            }
            catch 
            {
                throw new Exception("Error al eliminar un gasto");
            }
        }
    }
}
