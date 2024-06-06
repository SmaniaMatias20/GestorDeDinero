

using CapaEntidades.Enums;
using System;

namespace CapaEntidades
{
    public class Reserva
    {
        // Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Importe { get; set; } 
        public string Fecha { get; set; }
        public Reserva() 
        {
            DateTime ahora = DateTime.Now;
            Fecha = ahora.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public Reserva(string nombre, double importe) : this()
        {
            Nombre = nombre;
            Importe = importe;
        }

        public override string ToString()
        {
            return $"ID: {Id} - Nombre: {Nombre} - Importe: {Importe} - Fecha: {Fecha}";
        }




    }
}
