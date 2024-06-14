using CapaDatos;
using CapaEntidades;
using System.Collections.Generic;
using System.Linq;

namespace CapaServicios
{
    public static class CS_Reserva
    {
        public static string RegistrarReserva(string nombre, double importe, int idUsuario)
        {   
            if (ValidarNombreDeReserva(nombre) == nombre)
            {

                if (ValidarImporteDeReserva(importe) == "Fondos actualizados correctamente")
                {
                    Reserva reserva = new Reserva(nombre, importe);

                    CD_Reserva.AgregarReserva(idUsuario, reserva.Fecha, reserva.Importe, reserva.Nombre);

                   

                    return ValidarImporteDeReserva(importe);
                }
                else
                {
                    return ValidarImporteDeReserva(importe);
                }
            }
            else
            {
                return ValidarNombreDeReserva(nombre);
            }
        }

        public static string RegistrarReserva(string nombre, double importe, Reserva reserva) 
        {

            if (ValidarNombreDeReserva(nombre) == nombre)
            {

                if (ValidarImporteDeReserva(importe) == "Fondos actualizados correctamente")
                {
                    CD_Reserva.ModificarReserva(reserva.Id, nombre, importe, reserva.Fecha);

                    return ValidarImporteDeReserva(importe);
                }
                else
                {
                    return ValidarImporteDeReserva(importe);
                }
            }
            else
            {
                return ValidarNombreDeReserva(nombre);
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


        private static string ValidarImporteDeReserva(double importe) 
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
                return "No se aceptan transacciones mayores a $1.000.000";
            }

        }

        private static string ValidarNombreDeReserva(string nombreReserva) 
        {
            if (nombreReserva == "" || nombreReserva == null)
            {
                return "Ingrese un nombre para su reserva";
            }
            else if (!nombreReserva.All(char.IsLetterOrDigit))
            {
                return "El nombre no debe contener caracteres especiales";
            }
            else if (nombreReserva.Length > 20 || nombreReserva.Length < 3)
            {
                return "El nombre debe contener entre 3 y 20 caracteres";
            }
            else
            {
                return nombreReserva;
            }

        }
    }
}
