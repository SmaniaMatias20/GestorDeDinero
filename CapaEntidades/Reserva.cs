

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



      
    }
}
