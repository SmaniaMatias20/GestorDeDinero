using CapaDatos;
using CapaEntidades.Enums;
using CapaEntidades;
using System.Collections.Generic;

namespace CapaServicios
{
    public class CS_Reserva
    {
        // Atributos
        private CD_Reserva _cdReserva;

        public CS_Reserva()
        {
            _cdReserva = new CD_Reserva();
        }

        public string RegistrarReserva(int idUsuario, double importe, string nombre)
        {
            Reserva reserva = new Reserva(nombre, importe);  
            if (importe > 0)
            {
                _cdReserva.AgregarReserva(idUsuario, reserva.Fecha, reserva.Importe, reserva.Nombre);
                return "Los fondos han sido actualizados correctamente";
            }
            else
            {
                return "Ingrese un importe distinto a 0(cero)";
            }
        }

        public List<Reserva> ObtenerReservasPorId(int idUsuario)
        {
            List<Reserva> listaDeReservas = _cdReserva.ListarReservas(idUsuario);

            return listaDeReservas;
        }

        public void EliminarReservaPorId(int idReserva)
        {
            _cdReserva.EliminarReserva(idReserva);
        }
    }
}
