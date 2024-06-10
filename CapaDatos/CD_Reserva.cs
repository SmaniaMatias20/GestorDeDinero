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

        /// <summary>
        /// Agrega una nueva reserva a la base de datos con los valores proporcionados.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario que realiza la reserva.</param>
        /// <param name="fecha">La fecha de la reserva.</param>
        /// <param name="importe">El importe de la reserva.</param>
        /// <param name="nombre">El nombre de la reserva.</param>
        /// <exception cref="Exception">Lanza una excepción si ocurre un error durante la inserción de la reserva.</exception>
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
                // Manejo de excepciones: Lanzar una excepción si ocurre un error
                throw new Exception("Error al insertar la reserva");
            }
        }

        /// <summary>
        /// Elimina una reserva de la base de datos según el ID proporcionado.
        /// </summary>
        /// <param name="idReserva">El ID de la reserva a eliminar.</param>
        /// <exception cref="Exception">Lanza una excepción si ocurre un error durante la eliminación de la reserva.</exception>
        public void EliminarReserva(int idReserva)
        {
            try
            {
                // Establece una conexión con la base de datos
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    // Abre la conexión
                    conexionDB.Open();
                    // Define la consulta SQL para eliminar la reserva
                    string query = "DELETE FROM reserva WHERE id = @idReserva";
                    // Crea un comando SQL con la consulta y la conexión
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agrega el parámetro al comando
                        comando.Parameters.AddWithValue("@idReserva", idReserva);
                        // Ejecuta la consulta SQL y obtiene el número de filas afectadas
                        int filasAfectadas = comando.ExecuteNonQuery();
                    }
                }
            }
            catch 
            {
                // Lanza una excepción si ocurre un error
                throw new Exception("Error al eliminar la reserva");  
            }
        }

        /// <summary>
        /// Modifica una reserva en la base de datos con los nuevos valores proporcionados.
        /// </summary>
        /// <param name="idReserva">El ID de la reserva a modificar.</param>
        /// <param name="nuevoNombre">El nuevo nombre de la reserva.</param>
        /// <param name="nuevoImporte">El nuevo importe de la reserva.</param>
        /// <param name="nuevaFecha">La nueva fecha de la reserva.</param>
        /// <exception cref="Exception">Lanza una excepción si ocurre un error durante la modificación de la reserva.</exception>
        public void ModificarReserva(int idReserva, string nuevoNombre, double nuevoImporte, string nuevaFecha) 
        {
            try
            {
                // Establece una conexión con la base de datos
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    // Abre la conexión
                    conexionDB.Open();
                    // Define la consulta SQL para actualizar la reserva
                    string query = "UPDATE reserva SET nombre = @nuevoNombre, importe = @nuevoImporte, fecha = @nuevaFecha WHERE id = @idReserva";

                    // Crea un comando SQL con la consulta y la conexión
                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        // Agrega los parámetros al comando
                        comando.Parameters.AddWithValue("@idReserva", idReserva);
                        comando.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                        comando.Parameters.AddWithValue("@nuevoImporte", nuevoImporte);
                        comando.Parameters.AddWithValue("@nuevaFecha", nuevaFecha);
                        // Ejecuta la consulta SQL
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Lanza una excepción si ocurre un error
                throw new Exception("Error al modificar la reserva");
            }

        }
    }
}
