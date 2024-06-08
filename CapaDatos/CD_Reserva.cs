using CapaEntidades.Enums;
using CapaEntidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace CapaDatos
{
    public class CD_Reserva
    {
        // Atributos
        private Conexion conexion = new Conexion();

        /// <summary>
        /// Obtiene una lista de usuarios desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Usuario que contiene el nombre y la clave de cada usuario.</returns>
        public List<Reserva> ListarReservas(int idUsuario)
        {
            // Nuevo objeto de tipo lista de movimientos
            List<Reserva> lista = new List<Reserva>();

            try
            {
                // Abrir conexión
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();

                    // Consulta SQL para obtener los movimientos
                    string query = "SELECT id, nombre, importe, fecha FROM reserva WHERE id_usuario = @idUsuario";

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
                                // Crear una nueva instancia de Movimiento
                                Reserva reserva = new Reserva();

                                // Asignar los valores de las columnas del resultado a las propiedades del objeto Movimiento
                                reserva.Id = Convert.ToInt32(reader["id"]);
                                reserva.Nombre = Convert.ToString(reader["nombre"]);
                                reserva.Importe = Convert.ToDouble(reader["importe"]);
                                reserva.Fecha = Convert.ToString(reader["fecha"]);

                                // Agregar el movimiento a la lista
                                lista.Add(reserva);
                            }
                        }
                    }
                }
            }
            catch 
            {
                // Manejo de excepciones: Mostrar un mensaje de error en la consola
                throw new Exception("Error al listar las reservas");
            }

            // Devolver la lista de reservas
            return lista;
        }

        public void AgregarReserva(int idUsuario, string fecha, double importe, string nombre)
        {
            try
            {
                // Obtener la conexión
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();

                    // Consulta SQL para insertar un nuevo registro en la tabla movimiento
                    string query = "INSERT INTO reserva (nombre, importe, fecha, id_usuario) VALUES (@nombre, @importe, @fecha, @idUsuario);";

                    // Crear un comando SQL para ejecutar la consulta
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agregar los parámetros
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@importe", importe);
                        comando.Parameters.AddWithValue("@fecha", fecha);
                        comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                        // Ejecutar la consulta
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Manejo de excepciones: Mostrar un mensaje de error en la consola
                throw new Exception("Error al insertar la reserva");
            }
        }

        public void EliminarReserva(int idReserva)
        {
            try
            {
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    conexionDB.Open();

                    string query = "DELETE FROM reserva WHERE id = @idReserva";

                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        comando.Parameters.AddWithValue("@idReserva", idReserva);
                        int filasAfectadas = comando.ExecuteNonQuery();
                    }
                }
            }
            catch 
            {
                throw new Exception("Error al eliminar la reserva");  
            }
        }

        public void ModificarReserva(int idReserva, string nuevoNombre, double nuevoImporte, string nuevaFecha) 
        {
            try
            {
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    conexionDB.Open();
                    string query = "UPDATE reserva SET nombre = @nuevoNombre, importe = @nuevoImporte, fecha = @nuevaFecha WHERE id = @idReserva";

                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        comando.Parameters.AddWithValue("@idReserva", idReserva);
                        comando.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                        comando.Parameters.AddWithValue("@nuevoImporte", nuevoImporte);
                        comando.Parameters.AddWithValue("@nuevaFecha", nuevaFecha);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw new Exception("Error al modificar la reserva");
            }

        }
    }
}
