using CapaEntidades;
using CapaDatos;
using System.Collections.Generic;
using CapaEntidades.Enums;

namespace CapaServicios
{

    public class CS_Movimiento
    {
        // Atributos
        private CD_Movimiento _cdMovimiento;

        /// <summary>
        /// Inicializa una nueva instancia de la clase CS_Movimiento.
        /// </summary>
        public CS_Movimiento()
        {
            // Crea una nueva instancia de la clase CD_Movimiento
            _cdMovimiento = new CD_Movimiento();
        }

        /// <summary>
        /// Registra un movimiento para un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El identificador único del usuario para quien se registrará el movimiento.</param>
        /// <param name="importe">La cantidad del movimiento, que debe ser mayor a cero para ser válido.</param>
        /// <param name="tipo">El tipo de movimiento a registrar (Ingreso, Retiro, Reserva).</param>
        /// <returns>Un mensaje indicando el resultado de la operación.</returns>
        public string RegistrarMovimiento(int idUsuario, double importe, ETipoMovimiento tipo) 
        {
            // Crea una nueva instancia de Movimiento con el tipo y el importe especificados
            Movimiento movimiento = new Movimiento(tipo, importe);

            // Verifica si el importe es mayor a cero
            if (importe > 0)
            {
                // Agrega el movimiento a la base de datos para el usuario especificado
                _cdMovimiento.AgregarMovimiento(idUsuario, movimiento.Fecha, movimiento.Importe, movimiento.Tipo);
                // Devuelve un mensaje indicando que los fondos han sido actualizados correctamente
                return "Los fondos han sido actualizados correctamente";
            }
            else if (importe == 0)  // Verifica si el importe es igual a cero
            {
                // Devuelve un mensaje indicando que el importe debe ser mayor a cero
                return "Ingrese un importe mayor a 0(cero)";
            }
            else if (importe == -1)  // Maneja el caso en que el importe sea mayor a los fondos totales
            {
                // Devuelve un mensaje indicando que el importe debe ser menor a los fondos totales
                return "Debe ingresar un importe menor a los fondos totales";
            }
            else if (importe == -2)  // Maneja el caso en que el importe sea mayor a los fondos totales
            {
                // Devuelve un mensaje indicando que el importe debe ser menor a $1.000.000
                return "No se permiten transacciones de mas de $1.000.000";
            }
            else
            {
                return "Otro error";
            }
        }

        /// <summary>
        /// Obtiene una lista de movimientos asociados a un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El identificador único del usuario cuyos movimientos se desean obtener.</param>
        /// <returns>Una lista de movimientos asociados al usuario especificado.</returns>
        public List<Movimiento> ObtenerMovimientosPorId(int idUsuario) 
        {
            // Llama al método ListarMovimientos de la clase _cdMovimiento para obtener los movimientos del usuario especificado
            List<Movimiento> listaDeMovimientos = _cdMovimiento.ListarMovimientos(idUsuario);

            // Devuelve la lista de movimientos obtenidos
            return listaDeMovimientos;
        }

        /// <summary>
        /// Elimina un movimiento específico de la base de datos según su identificador.
        /// </summary>
        /// <param name="idMovimiento">El identificador único del movimiento que se desea eliminar.</param>
        public void EliminarMovimientoPorId(int idMovimiento) 
        {
            // Llama al método EliminarMovimiento de la clase _cdMovimiento para eliminar el movimiento especificado
            _cdMovimiento.EliminarMovimiento(idMovimiento);
        }

    }
}
