using CapaEntidades.Enums;
using System;

namespace CapaEntidades.Entidades
{
    public class Gasto
    {
        // Propiedades
        public int Id { get; set; }
        public ETipoGasto Tipo { get; set; }
        public double Importe { get; set; } 
        public ETipoPago Pago { get; set; }
        public string Descripcion { get; set; } 
        public string Fecha { get; set; }   

        /// <summary>
        /// 
        /// </summary>
        public Gasto() 
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoGasto"></param>
        /// <param name="importe"></param>
        /// <param name="metodoPago"></param>
        /// <param name="descripcion"></param>
        public Gasto(ETipoGasto tipoGasto, double importe, ETipoPago metodoPago, string descripcion, string fecha) : this()
        {
            Tipo = tipoGasto;
            Importe = importe;
            Pago = metodoPago;
            Descripcion = descripcion;
            Fecha = fecha;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //
            return $"{Id}-{Tipo}-{Importe}-{Pago}-{Descripcion}-{Fecha}";
        }

    }
}
