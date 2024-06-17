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
            var (validacionNombre, nombre) = CS_Config.ValidarTextBoxAlfaNumerico(nombreReserva);
            var (validacionImporte, importe, mensaje) = CS_Config.ValidarTextBoxNumerico(importeReserva);

            if (!validacionNombre)
            {
                return (validacionNombre, nombre);
            }
            if (!validacionImporte)
            {
                return (validacionImporte, mensaje);
            }


            Reserva reserva = new Reserva(nombre, importe);
            CD_Reserva.AgregarReserva(usuario.Id, reserva.Fecha, reserva.Importe, reserva.Nombre);

            CS_Usuario.ActualizarFondos(usuario.Nombre, reserva.Importe, ETipoMovimiento.Reserva);

            return (true, "Reserva registrada correctamente");
        }

        public static (bool, string) RegistrarReserva(Usuario usuario, string nombreReserva, string importeReserva, Reserva reserva)
        {
            CS_Usuario.ActualizarFondos(usuario.Nombre, reserva.Importe, ETipoMovimiento.Ingreso);

            var (validacionNombre, nombre) = CS_Config.ValidarTextBoxAlfaNumerico(nombreReserva);
            var (validacionImporte, importe, mensaje) = CS_Config.ValidarTextBoxNumerico(importeReserva);

            if (!validacionNombre)
            {
                return (validacionNombre, nombre);
            }
            if (!validacionImporte)
            {
                return (validacionImporte, mensaje);
            }


            CD_Reserva.ModificarReserva(reserva.Id, nombreReserva, importe, reserva.Fecha);
            CS_Usuario.ActualizarFondos(usuario.Nombre, importe, ETipoMovimiento.Reserva);

            return (true, "Reserva modificada correctamente");
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
