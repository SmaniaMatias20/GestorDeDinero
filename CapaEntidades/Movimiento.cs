using System;
using CapaEntidades.Enums;

namespace CapaEntidades
{
    public class Movimiento
    {
        public int Id { get; set; }

        public ETipoMovimiento Tipo { get; set; }

        public double Importe { get; set; }

        public string Fecha { get; set; }


        public Movimiento() 
        {
            DateTime ahora = DateTime.Now;
            Fecha = ahora.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public Movimiento(ETipoMovimiento tipo, double importe) : this()
        {
            Tipo = tipo;    
            Importe = importe;  
        }

        public override string ToString()
        {
            return $"ID: {Id} - Tipo: {Tipo} - Importe: {Importe} - Fecha: {Fecha}";
        }
    }
}
