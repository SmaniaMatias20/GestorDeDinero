using CapaDatos;
using CapaEntidades;
using CapaEntidades.Enums;
using System.Collections.Generic;
using System.Linq;

namespace CapaServicios
{
    public static class CS_Reserva
    {
        public static (bool, string) RegistrarReserva(Usuario usuario, string nombreReserva, string importeReserva)
        {
            double movimientoValidado = CS_Usuario.ActualizarFondos(usuario.Nombre, importeReserva, ETipoMovimiento.Reserva);

            var (nombreValido, mensajeNombre) = ValidarNombreDeReserva(nombreReserva);
            if (!nombreValido)
            {
                return (false, mensajeNombre);
            }

            var (importeValido, mensajeImporte) = ValidarImporteDeReserva(movimientoValidado);
            if (!importeValido)
            {
                return (false, mensajeImporte);
            }

            Reserva reserva = new Reserva(nombreReserva, movimientoValidado);
            CD_Reserva.AgregarReserva(usuario.Id, reserva.Fecha, reserva.Importe, reserva.Nombre);

            return (true, "Reserva registrada correctamente");
        }

        public static (bool, string) RegistrarReserva(Usuario usuario, string nombreReserva, string importeReserva, Reserva reserva)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            // Agrega el total de la reserva seleccionada y en la linea siguiente resta la nueva reserva /// modificar logica ////
            CS_Usuario.ActualizarFondos(usuario.Nombre, reserva.Importe.ToString(), ETipoMovimiento.Ingreso);
            // Actualiza los fondos del usuario
            double movimientoValidado = CS_Usuario.ActualizarFondos(usuario.Nombre, importeReserva, ETipoMovimiento.Reserva);
            /////////////////////////////////////////////////////////////////////////////////////////////////////     

            var (nombreValido, mensajeNombre) = ValidarNombreDeReserva(nombreReserva);
            if (!nombreValido)
            {
                return (false, mensajeNombre);
            }

            var (importeValido, mensajeImporte) = ValidarImporteDeReserva(movimientoValidado);
            if (!importeValido)
            {
                return (false, mensajeImporte);
            }

            CD_Reserva.ModificarReserva(reserva.Id, nombreReserva, movimientoValidado, reserva.Fecha);

            return (true, "Reserva modificada correctamente");
        }

        public static (bool, string) ValidarImporteDeReserva(double importe)
        {
            if (importe > 0 && importe <= 1000000)
            {
                return (true, "Fondos actualizados correctamente");
            }
            else if (importe == 0)
            {
                return (false, "Ingrese un importe mayor a 0 (cero)");
            }
            else if (importe < 0)
            {
                return (false, "Ingrese un importe mayor a los fondos totales");
            }
            else
            {
                return (false, "No se aceptan transacciones mayores a $1.000.000");
            }
        }

        public static (bool, string) ValidarNombreDeReserva(string nombreReserva)
        {
            if (string.IsNullOrEmpty(nombreReserva))
            {
                return (false, "Ingrese un nombre para su reserva");
            }
            else if (!nombreReserva.All(char.IsLetterOrDigit))
            {
                return (false, "El nombre no debe contener caracteres especiales");
            }
            else if (nombreReserva.Length < 3 || nombreReserva.Length > 20)
            {
                return (false, "El nombre debe contener entre 3 y 20 caracteres");
            }
            else
            {
                return (true, "OK");
            }
        }

        public static List<Reserva> ObtenerReservasPorId(int idUsuario)
        {
            List<Reserva> listaDeReservas = CD_Reserva.ListarReservas(idUsuario);

            return listaDeReservas;
        }

        public static void EliminarReservaPorId(int idReserva)
        {
            CD_Reserva.EliminarReserva(idReserva);
        }



    }
}
