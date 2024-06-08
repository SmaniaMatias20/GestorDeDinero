using CapaDatos;
using CapaEntidades;
using System.Collections.Generic;
using System.Linq;

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

        public string RegistrarReserva(string nombre, double importe, int idUsuario = 0, int idReserva = 0, bool modificar = false)
        {   
            if (ValidarNombreDeReserva(nombre) == nombre)
            {

                if (ValidarImporteDeReserva(importe) == "Fondos actualizados correctamente")
                {
                    Reserva reserva = new Reserva(nombre, importe);
                    if (!modificar)
                    {
                        _cdReserva.AgregarReserva(idUsuario, reserva.Fecha, reserva.Importe, reserva.Nombre);
                    }
                    else 
                    { 
                        _cdReserva.ModificarReserva(idReserva, reserva.Nombre, reserva.Importe, reserva.Fecha);
                    }


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

        public List<Reserva> ObtenerReservasPorId(int idUsuario)
        {
            List<Reserva> listaDeReservas = _cdReserva.ListarReservas(idUsuario);

            return listaDeReservas;
        }

        public void EliminarReservaPorId(int idReserva)
        {
            _cdReserva.EliminarReserva(idReserva);
        }


        private string ValidarImporteDeReserva(double importe) 
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

        private string ValidarNombreDeReserva(string nombreReserva) 
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
