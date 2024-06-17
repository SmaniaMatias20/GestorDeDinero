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
        /// <param name="usuario">El objeto Usuario para quien se registrará el movimiento.</param>
        /// <param name="importeMovimiento">La cantidad del movimiento, que debe ser mayor a cero para ser válido.</param>
        /// <param name="tipo">El tipo de movimiento a registrar (Ingreso, Retiro, Reserva).</param>
        /// <returns>Un mensaje indicando el resultado de la operación y el objeto Usuario actualizado.</returns>
        public static (string, Usuario) RegistrarMovimiento(Usuario usuario, string importeMovimiento, ETipoMovimiento tipo) 
        {
            // Validar que el importe sea un valor numérico y mayor a cero
            var (validacionImporte, importe, mensaje) = CS_Config.ValidarTextBoxNumerico(importeMovimiento);
            if (!validacionImporte)
            {
                // Retorna mensaje de error si la validación falla
                return (mensaje, usuario);
            }
            // Verificar que el importe no exceda los fondos del usuario si es un Retiro
            if (importe > usuario.FondosTotales && tipo == ETipoMovimiento.Retiro)
            {
                // Retorna mensaje de error si los fondos son insuficientes
                return ("No puede ingresar un importe superior a los fondos", usuario);
            }

            // Crea una nueva instancia de Movimiento con el tipo y el importe especificados
            Movimiento movimiento = new Movimiento(tipo, importe);
            //Agrega el movimiento a la base de datos para el usuario especificado
            CD_Movimiento.AgregarMovimiento(usuario.Id, movimiento.Fecha, movimiento.Importe, movimiento.Tipo);
            // Actualizar los fondos del usuario
            usuario = CS_Usuario.ActualizarFondos(usuario.Nombre, importe, tipo);

            // Retorna el mensaje de éxito o cualquier mensaje asociado y el objeto Usuario actualizado
            return (mensaje, usuario);
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
