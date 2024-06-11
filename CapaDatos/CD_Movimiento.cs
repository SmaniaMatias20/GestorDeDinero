﻿using CapaEntidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using CapaEntidades.Enums;

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
            // Nuevo objeto de tipo lista de movimientos
            List<Movimiento> lista = new List<Movimiento>();

            try
            {
                // Abrir conexión
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    // Abrir la conexión a la base de datos
                    conexionDB.Open();

                    // Consulta SQL para obtener los movimientos
                    string query = "SELECT id, tipo, importe, fecha FROM movimiento WHERE id_usuario = @idUsuario";

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
                                Movimiento movimiento = new Movimiento();

                                // Asignar los valores de las columnas del resultado a las propiedades del objeto Movimiento
                                movimiento.Id = Convert.ToInt32(reader["id"]);
                                if (Enum.TryParse(reader["tipo"].ToString(), out ETipoMovimiento tipoMovimiento))
                                {
                                    movimiento.Tipo = tipoMovimiento;
                                }
                                movimiento.Importe = Convert.ToDouble(reader["importe"]);
                                movimiento.Fecha = Convert.ToString(reader["fecha"]);

                                // Agregar el movimiento a la lista
                                lista.Add(movimiento);
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

            // Devolver la lista de movimientos
            return lista;
        }

        public void AgregarMovimiento(int idUsuario, string fecha, double importe, ETipoMovimiento tipo)
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
            catch 
            {
                // Manejo de excepciones
                throw new Exception("Error al agregar el movimiento");
            }
        }

        public void EliminarMovimiento(int idMovimiento)
        {
            try
            {
                using (SqlConnection conexionDB = conexion.ObtenerConexion())
                {
                    conexionDB.Open();

                    string query = "DELETE FROM movimiento WHERE id = @idMovimiento";

                    using (SqlCommand comando = new SqlCommand(query, conexionDB))
                    {
                        comando.Parameters.AddWithValue("@idMovimiento", idMovimiento);
                        int filasAfectadas = comando.ExecuteNonQuery();
                    }
                }
            }
            catch 
            {
                throw new Exception("Error al eliminar el movimiento");
            }
        }
    }
}
