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
        /// Constructor de la clase Gasto.
        /// </summary>
        public Gasto() 
        {
        }

        /// <summary>
        /// Constructor de la clase Gasto que inicializa los campos con los valores proporcionados.
        /// </summary>
        /// <param name="tipoGasto">El tipo de gasto.</param>
        /// <param name="importe">El importe del gasto.</param>
        /// <param name="metodoPago">El método de pago del gasto.</param>
        /// <param name="descripcion">La descripción del gasto.</param>
        /// <param name="fecha">La fecha del gasto.</param>
        public Gasto(ETipoGasto tipoGasto, double importe, ETipoPago metodoPago, string descripcion, string fecha) : this()
        {
            // Inicializa los campos del objeto Gasto con los valores proporcionados
            Tipo = tipoGasto;
            Importe = importe;
            Pago = metodoPago;
            Descripcion = descripcion;
            Fecha = fecha;
        }

        /// <summary>
        /// Retorna una representación en formato de cadena del objeto Gasto.
        /// </summary>
        /// <returns>Una cadena que representa el objeto Gasto en el formato "Id-Tipo-Importe-Pago-Descripcion-Fecha".</returns>
        public override string ToString()
        {
            // Retorna una cadena que contiene la representación del objeto Gasto en el formato especificado
            return $"{Id}-{Tipo}-{Importe}-{Pago}-{Descripcion}-{Fecha}";
        }

    }
}
