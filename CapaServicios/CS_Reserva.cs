using CapaDatos;
using CapaEntidades;
using CapaEntidades.Enums;
using System.Collections.Generic;

namespace CapaServicios
{
    public static class CS_Reserva
    {
        /// <summary>
        /// Registra una nueva reserva para un usuario específico.
        /// </summary>
        /// <param name="usuario">El objeto Usuario para quien se registrará la reserva.</param>
        /// <param name="nombreReserva">El nombre de la reserva.</param>
        /// <param name="importeReserva">La cantidad de la reserva, que debe ser mayor a cero.</param>
        /// <returns>Un tuple indicando el éxito de la operación y un mensaje relacionado.</returns>
        public static (bool, string) RegistrarReserva(Usuario usuario, string nombreReserva, string importeReserva)
        {
            // Validar que el nombre de la reserva sea alfanumérico
            var (validacionNombre, nombre) = CS_Config.ValidarTextBoxAlfaNumerico(nombreReserva);
            // Validar que el importe sea un valor numérico y mayor a cero
            var (validacionImporte, importe, mensaje) = CS_Config.ValidarTextBoxNumerico(importeReserva);

            // Verificar si la validación del nombre falló
            if (!validacionNombre)
            {
                // Retornar la validación fallida junto con el nombre
                return (validacionNombre, nombre);
            }
            // Verificar si la validación del importe falló
            if (!validacionImporte)
            {
                // Retornar la validación fallida junto con el mensaje de error
                return (validacionImporte, mensaje);
            }
            // Verificar si el importe excede los fondos totales del usuario
            if (importe > usuario.FondosTotales)
            {
                // Retornar indicando que el importe es superior a los fondos disponibles
                return (false, "No puede ingresar un importe superior a los fondos");
            }

            // Crear una nueva instancia de Reserva
            Reserva reserva = new Reserva(nombre, importe);
            // Agregar la reserva a la base de datos
            CD_Reserva.AgregarReserva(usuario.Id, reserva.Fecha, reserva.Importe, reserva.Nombre);
            // Actualizar los fondos del usuario
            CS_Usuario.ActualizarFondos(usuario.Nombre, reserva.Importe, ETipoMovimiento.Reserva);
            // Retornar indicando que la reserva se registró correctamente
            return (true, "Reserva registrada correctamente");
        }

        /// <summary>
        /// Modifica una reserva existente para un usuario específico.
        /// </summary>
        /// <param name="usuario">El objeto Usuario para quien se modificará la reserva.</param>
        /// <param name="nombreReserva">El nuevo nombre de la reserva.</param>
        /// <param name="importeReserva">El nuevo importe de la reserva.</param>
        /// <param name="reserva">El objeto Reserva que será modificado.</param>
        /// <returns>Un tuple indicando el éxito de la operación y un mensaje relacionado.</returns>
        public static (bool, string) RegistrarReserva(Usuario usuario, string nombreReserva, string importeReserva, Reserva reserva)
        {
            // Restaurar los fondos originales al usuario antes de modificar la reserva
            CS_Usuario.ActualizarFondos(usuario.Nombre, reserva.Importe, ETipoMovimiento.Ingreso);

            // Validar que el nombre de la reserva sea alfanumérico
            var (validacionNombre, nombre) = CS_Config.ValidarTextBoxAlfaNumerico(nombreReserva);
            // Validar que el importe sea un valor numérico y mayor a cero
            var (validacionImporte, importe, mensaje) = CS_Config.ValidarTextBoxNumerico(importeReserva);

            // Verificar si la validación del nombre falló
            if (!validacionNombre)
            {
                // Retornar la validación fallida junto con el nombre
                return (validacionNombre, nombre);
            }
            // Verificar si la validación del importe falló
            if (!validacionImporte)
            {
                // Retornar la validación fallida junto con el mensaje de error
                return (validacionImporte, mensaje);
            }

            // Modificar la reserva existente en la base de datos
            CD_Reserva.ModificarReserva(reserva.Id, nombreReserva, importe, reserva.Fecha);
            // Actualizar los fondos del usuario con el nuevo importe de la reserva
            CS_Usuario.ActualizarFondos(usuario.Nombre, importe, ETipoMovimiento.Reserva);
            // Retornar indicando que la reserva se modificó correctamente
            return (true, "Reserva modificada correctamente");
        }

        /// <summary>
        /// Obtiene una lista de reservas para un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El identificador único del usuario.</param>
        /// <returns>Una lista de objetos Reserva.</returns>
        public static List<Reserva> ObtenerReservasPorId(int idUsuario)
        {
            // Obtener la lista de reservas desde la base de datos
            List<Reserva> listaDeReservas = CD_Reserva.ListarReservas(idUsuario);
            // Retorna la lista de reservas
            return listaDeReservas;
        }

        /// <summary>
        /// Elimina una reserva específica por su identificador único.
        /// </summary>
        /// <param name="idReserva">El identificador único de la reserva a eliminar.</param>
        public static void EliminarReservaPorId(int idReserva)
        {
            // Eliminar la reserva de la base de datos
            CD_Reserva.EliminarReserva(idReserva);
        }



    }
}
