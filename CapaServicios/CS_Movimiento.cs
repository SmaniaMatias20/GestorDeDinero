using CapaEntidades;
using CapaDatos;
using System.Collections.Generic;
using CapaEntidades.Enums;

namespace CapaServicios
{

    public static class CS_Movimiento
    {

        /// <summary>
        /// Registra un movimiento para un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El identificador único del usuario para quien se registrará el movimiento.</param>
        /// <param name="importe">La cantidad del movimiento, que debe ser mayor a cero para ser válido.</param>
        /// <param name="tipo">El tipo de movimiento a registrar (Ingreso, Retiro, Reserva).</param>
        /// <returns>Un mensaje indicando el resultado de la operación.</returns>
        public static string RegistrarMovimiento(int idUsuario, double importe, ETipoMovimiento tipo) 
        {
            if (ValidarImporteDeMovimiento(importe) == "Fondos actualizados correctamente")
            {
                // Crea una nueva instancia de Movimiento con el tipo y el importe especificados
                Movimiento movimiento = new Movimiento(tipo, importe);
                //Agrega el movimiento a la base de datos para el usuario especificado
                CD_Movimiento.AgregarMovimiento(idUsuario, movimiento.Fecha, movimiento.Importe, movimiento.Tipo);
                // Devuelve un mensaje indicando que los fondos han sido actualizados correctamente
                return ValidarImporteDeMovimiento(importe);
            }
            else
            {
                return ValidarImporteDeMovimiento(importe);
            }
        }

        private static string ValidarImporteDeMovimiento(double importe) 
        {
            if (importe > 0)
            {
                return "Fondos actualizados correctamente";
            }
            else if (importe == 0)
            {
                return "Ingrese un importe mayor a 0(cero)";
            }
            else if (importe == -1)
            {
                return "Ingrese un importe menor a los fondos totales";
            }
            else
            {
                return "No se aceptan transacciones mayores a $5.000.000";
            }

        }

        /// <summary>
        /// Obtiene una lista de movimientos asociados a un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El identificador único del usuario cuyos movimientos se desean obtener.</param>
        /// <returns>Una lista de movimientos asociados al usuario especificado.</returns>
        public static List<Movimiento> ObtenerMovimientosPorId(int idUsuario) 
        {
            // Llama al método ListarMovimientos de la clase _cdMovimiento para obtener los movimientos del usuario especificado
            List<Movimiento> listaDeMovimientos = CD_Movimiento.ListarMovimientos(idUsuario);

            // Devuelve la lista de movimientos obtenidos
            return listaDeMovimientos;
        }

        /// <summary>
        /// Elimina un movimiento específico de la base de datos según su identificador.
        /// </summary>
        /// <param name="idMovimiento">El identificador único del movimiento que se desea eliminar.</param>
        public static void EliminarMovimientoPorId(int idMovimiento) 
        {
            // Llama al método EliminarMovimiento de la clase _cdMovimiento para eliminar el movimiento especificado
            CD_Movimiento.EliminarMovimiento(idMovimiento);
        }

    }
}
