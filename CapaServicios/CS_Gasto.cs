using CapaDatos;
using CapaEntidades.Entidades;
using CapaEntidades.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CapaServicios
{
    public static class CS_Gasto
    {
        /// <summary>
        /// Obtiene una lista de movimientos asociados a un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El identificador único del usuario cuyos movimientos se desean obtener.</param>
        /// <returns>Una lista de movimientos asociados al usuario especificado.</returns>
        public static List<Gasto> ObtenerGastosPorId(int idUsuario)
        {
            // Llama al método ListarMovimientos de la clase _cdMovimiento para obtener los movimientos del usuario especificado
            List<Gasto> listaGastos = CD_Gasto.ListarGastos(idUsuario);

            // Devuelve la lista de movimientos obtenidos
            return listaGastos;
        }

        /// <summary>
        /// Registra un nuevo gasto o modifica uno existente, según los parámetros proporcionados.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario asociado al gasto.</param>
        /// <param name="importe">El importe del gasto.</param>
        /// <param name="tipo">El tipo de gasto.</param>
        /// <param name="fecha">La fecha del gasto.</param>
        /// <param name="pago">El método de pago del gasto.</param>
        /// <param name="descripcion">La descripción del gasto.</param>
        /// <param name="estadoModificacion">Indica si se está modificando un gasto existente.</param>
        /// <param name="idGasto">El ID del gasto que se está modificando, si es aplicable.</param>
        /// <returns>Un mensaje que indica si la operación de registro o modificación fue exitosa o si hubo algún error.</returns>
        public static string RegistrarGasto(int idUsuario, string importe, string tipo, string fecha, string pago, string descripcion, bool estadoModificacion, int idGasto)
        {
            // Realiza la validación del gasto
            string mensaje = ValidarGasto(idUsuario, importe, tipo, fecha, pago, descripcion, estadoModificacion, idGasto);

            // Retorna el mensaje resultante de la validación
            return mensaje;
        }


        /// <summary>
        /// Valida los datos de un gasto y realiza la operación de registro o modificación según sea necesario.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario asociado al gasto.</param>
        /// <param name="importe">El importe del gasto.</param>
        /// <param name="tipo">El tipo de gasto.</param>
        /// <param name="fecha">La fecha del gasto.</param>
        /// <param name="pago">El método de pago del gasto.</param>
        /// <param name="descripcion">La descripción del gasto.</param>
        /// <param name="estadoModificacion">Indica si se está modificando un gasto existente.</param>
        /// <param name="idGasto">El ID del gasto que se está modificando, si es aplicable.</param>
        /// <returns>Un mensaje que indica el resultado de la operación de registro o modificación.</returns>
        private static string ValidarGasto(int idUsuario, string importe, string tipo, string fecha, string pago, string descripcion, bool estadoModificacion, int idGasto)
        {
            // Mensajes de error
            const string ErrorImporte = "Ingrese un importe";
            const string ErrorTipo = "Ingrese un tipo de gasto";
            const string ErrorPago = "Ingrese un método de pago";
            const string ErrorProceso = "Error al procesar el gasto";
            const string ErrorRegistro = "No se pudo registrar el gasto. Tipo o método de pago inválido";

            // Verifica si los campos requeridos están vacíos
            if (string.IsNullOrWhiteSpace(importe)) return ErrorImporte;
            if (string.IsNullOrWhiteSpace(tipo)) return ErrorTipo;
            if (string.IsNullOrWhiteSpace(pago)) return ErrorPago;

            // Si la descripción está vacía, la asigna como "Sin descripción"
            if (string.IsNullOrWhiteSpace(descripcion)) descripcion = "Sin descripción";

            // Intenta convertir los strings de tipo y pago en enumeraciones
            if (Enum.TryParse(tipo, out ETipoGasto tipoGasto) && Enum.TryParse(pago, out ETipoPago tipoPago))
            {
                // Verifica si el importe es un número válido
                var (validacion, importeValidado, mensaje) = CS_Config.ValidarTextBoxNumerico(importe);
                if (!validacion)
                {
                    return mensaje;
                }

                // Crea un nuevo objeto Gasto con los datos proporcionados
                Gasto gasto = new Gasto(tipoGasto, importeValidado, tipoPago, descripcion, fecha);

                try
                {
                    // Si no está en estado de modificacion 
                    if (!estadoModificacion)
                    {
                        // Agrega el gasto a la capa de acceso a datos
                        CD_Gasto.AgregarGasto(idUsuario, gasto.Fecha, gasto.Importe, gasto.Tipo, gasto.Pago, gasto.Descripcion);
                        // Retorna un mensaje
                        return "Gasto registrado";
                    }
                    else
                    {
                        // Establece el ID del gasto y lo actualiza en la capa de acceso a datos
                        gasto.Id = idGasto;
                        // Actualiza el gasto
                        CD_Gasto.ActualizarGasto(gasto);
                        // Retorna un mensaje
                        return "Gasto modificado";
                    }
                }
                catch (Exception ex)
                {
                    // Retorna un mensaje de la excepcion capturada
                    return $"{ErrorProceso}: {ex.Message}";
                }
            }
            // Retorna un mensaje de error
            return ErrorRegistro;
        }

        /// <summary>
        /// Obtiene un gasto específico por su ID.
        /// </summary>
        /// <param name="idGasto">El ID del gasto que se desea obtener.</param>
        /// <returns>El objeto Gasto correspondiente al ID especificado.</returns>
        public static Gasto ObtenerGastoPorId(int idGasto) 
        {
            // Utiliza la instancia de CD_Gasto para obtener el gasto por su ID
            return CD_Gasto.ObtenerGasto(idGasto);
        }

        /// <summary>
        /// Elimina un gasto específico por su ID.
        /// </summary>
        /// <param name="idGasto">El ID del gasto que se desea eliminar.</param>
        public static void EliminarGastoPorId(int idGasto)
        {
            // Utiliza la instancia de CD_Gasto para eliminar el gasto por su ID
            CD_Gasto.EliminarGasto(idGasto);
        }

        /// <summary>
        /// Busca y retorna una lista de gastos filtrados según los criterios proporcionados.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario cuyos gastos se desean consultar.</param>
        /// <param name="importeMin">El importe mínimo de los gastos a incluir en la consulta (opcional).</param>
        /// <param name="importeMax">El importe máximo de los gastos a incluir en la consulta (opcional).</param>
        /// <param name="tipoGasto">El tipo de gasto a filtrar (opcional).</param>
        /// <param name="metodoPago">El método de pago a filtrar (opcional).</param>
        /// <returns>Una lista de objetos <see cref="Gasto"/> que cumplen con los criterios de búsqueda.</returns>
        /// <remarks>
        /// Este método construye una consulta SQL utilizando los parámetros proporcionados
        /// y luego llama a <see cref="CD_Gasto.ListarGastos"/> para ejecutar la consulta y retornar los resultados.
        /// </remarks>
        public static List<Gasto> BuscarGastoFiltrado(int idUsuario, string importeMin, string importeMax, string tipoGasto, string metodoPago) 
        {
            // Construye la consulta SQL con los filtros proporcionados y obtener la lista de parámetros SQL.
            string query = ConstruirConsultaGasto(idUsuario, importeMin, importeMax, tipoGasto, metodoPago, out List<SqlParameter> parametros);
            // Ejecuta la consulta utilizando CD_Gasto.ListarGastos y retornar los resultados.
            return CD_Gasto.ListarGastos(parametros, query);
        }

        /// <summary>
        /// Construye una consulta SQL para filtrar gastos de un usuario específico según varios criterios.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario cuyos gastos se desean consultar.</param>
        /// <param name="importeMin">El importe mínimo de los gastos a incluir en la consulta (opcional).</param>
        /// <param name="importeMax">El importe máximo de los gastos a incluir en la consulta (opcional).</param>
        /// <param name="tipoGasto">El tipo de gasto a filtrar (opcional).</param>
        /// <param name="metodoPago">El método de pago a filtrar (opcional).</param>
        /// <param name="parametros">Salida. Lista de parámetros SQL para la consulta construida.</param>
        /// <returns>Una cadena con la consulta SQL construida.</returns>
        /// <remarks>
        /// Este método construye dinámicamente una consulta SQL basada en los parámetros proporcionados.
        /// Los parámetros opcionales que no se especifican se omiten de la consulta.
        /// Los parámetros se agregan a una lista de parámetros SQL, que se retorna a través del parámetro de salida `parametros`.
        /// </remarks>
        private static string ConstruirConsultaGasto(int idUsuario, string importeMin, string importeMax, string tipoGasto, string metodoPago, out List<SqlParameter> parametros)
        {
            // Inicializa la lista de parámetros
            parametros = new List<SqlParameter>();
            // Construye la consulta básica con el ID del usuario
            StringBuilder query = new StringBuilder("SELECT id, tipo, importe, pago, descripcion, fecha FROM gasto WHERE id_usuario = @idUsuario");
            parametros.Add(new SqlParameter("@idUsuario", idUsuario));

            // Validar y agregar el filtro de importe mínimo
            if (!string.IsNullOrWhiteSpace(importeMin) && double.TryParse(importeMin, out double importeMinParsed))
            {
                query.Append(" AND importe >= @importeMin");
                parametros.Add(new SqlParameter("@importeMin", importeMinParsed));
            }

            // Validar y agregar el filtro de importe máximo
            if (!string.IsNullOrWhiteSpace(importeMax) && double.TryParse(importeMax, out double importeMaxParsed))
            {
                query.Append(" AND importe <= @importeMax");
                parametros.Add(new SqlParameter("@importeMax", importeMaxParsed));
            }

            // Validar y agregar el filtro de tipo de gasto
            if (!string.IsNullOrWhiteSpace(tipoGasto))
            {
                query.Append(" AND tipo = @tipoGasto");
                parametros.Add(new SqlParameter("@tipoGasto", tipoGasto));
            }

            // Validar y agregar el filtro de método de pago
            if (!string.IsNullOrWhiteSpace(metodoPago))
            {
                query.Append(" AND pago = @metodoPago");
                parametros.Add(new SqlParameter("@metodoPago", metodoPago));
            }
            // Retorna la consulta SQL construida como una cadena
            return query.ToString();
        }
    }
}
