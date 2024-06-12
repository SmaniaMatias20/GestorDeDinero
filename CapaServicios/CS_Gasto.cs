using CapaDatos;
using CapaEntidades.Entidades;
using CapaEntidades.Enums;
using System;
using System.Collections.Generic;

namespace CapaServicios
{
    public class CS_Gasto
    {
        // Atributos
        private CD_Gasto _cdGasto;

        /// <summary>
        /// Constructor de la clase CS_Gasto.
        /// </summary>
        public CS_Gasto() 
        {
            // Inicializa la instancia de CD_Gasto para manejar las operaciones de acceso a datos
            _cdGasto = new CD_Gasto();
        }

        /// <summary>
        /// Obtiene una lista de movimientos asociados a un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El identificador único del usuario cuyos movimientos se desean obtener.</param>
        /// <returns>Una lista de movimientos asociados al usuario especificado.</returns>
        public List<Gasto> ObtenerGastosPorId(int idUsuario)
        {
            // Llama al método ListarMovimientos de la clase _cdMovimiento para obtener los movimientos del usuario especificado
            List<Gasto> listaGastos = _cdGasto.ListarGastos(idUsuario);

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
        public string RegistrarGasto(int idUsuario, string importe, string tipo, string fecha, string pago, string descripcion, bool estadoModificacion, int idGasto)
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
        private string ValidarGasto(int idUsuario, string importe, string tipo, string fecha, string pago, string descripcion, bool estadoModificacion, int idGasto) 
        {
            // Verifica si el importe está vacío
            if (importe == "")
            {
                return "Ingrese un importe";
            }
            // Verifica si el tipo de gasto está vacío
            if (tipo == "")
            {
                return "Ingrese un tipo de gasto";
            }
            // Verifica si el método de pago está vacío
            if (pago == "")
            {
                return "Ingrese un metodo de pago";
            }
            // Si la descripción está vacía, la asigna como "Sin descripción"
            if (descripcion == "")
            {
                descripcion = "Sin descripción";
            }
            // Intenta convertir los strings de tipo y pago en enumeraciones
            if (Enum.TryParse(tipo, out ETipoGasto tipoGasto) && Enum.TryParse(pago, out ETipoPago tipoPago))
            {
                // Crea un nuevo objeto Gasto con los datos proporcionados
                Gasto gasto = new Gasto(tipoGasto, double.Parse(importe), tipoPago, descripcion, fecha);
                // Si no se está modificando un gasto existente
                if (!estadoModificacion)
                {
                    // Agrega el gasto a la capa de acceso a datos
                    _cdGasto.AgregarGasto(idUsuario, gasto.Fecha, gasto.Importe, gasto.Tipo, gasto.Pago, gasto.Descripcion);
                    return "Gasto registrado";
                }
                else
                {
                    // Establece el ID del gasto y lo actualiza en la capa de acceso a datos
                    gasto.Id = idGasto;
                    // Actualiza la lista de gastos
                    _cdGasto.ActualizarGasto(gasto);
                    // Retorna un mensaje
                    return "Gasto modificado";
                }
            }
            // Retorna un mensaje
            return "No se pudo registrar el gasto";
        }

        /// <summary>
        /// Obtiene un gasto específico por su ID.
        /// </summary>
        /// <param name="idGasto">El ID del gasto que se desea obtener.</param>
        /// <returns>El objeto Gasto correspondiente al ID especificado.</returns>
        public Gasto ObtenerGastoPorId(int idGasto) 
        {
            // Utiliza la instancia de CD_Gasto para obtener el gasto por su ID
            return _cdGasto.ObtenerGasto(idGasto);
        }

        /// <summary>
        /// Elimina un gasto específico por su ID.
        /// </summary>
        /// <param name="idGasto">El ID del gasto que se desea eliminar.</param>
        public void EliminarGastoPorId(int idGasto)
        {
            // Utiliza la instancia de CD_Gasto para eliminar el gasto por su ID
            _cdGasto.EliminarGasto(idGasto);
        }
    }
}
