using System;
using CapaEntidades.Enums;

namespace CapaEntidades
{
    public class Movimiento
    {
        // Propiedades
        public int Id { get; set; }
        public ETipoMovimiento Tipo { get; set; }
        public double Importe { get; set; }
        public string Fecha { get; set; }

        /// <summary>
        /// Constructor de la clase Movimiento.
        /// Inicializa una nueva instancia de Movimiento con la fecha actual.
        /// </summary>
        public Movimiento() 
        {
            // Obtiene la fecha y hora actuales.
            DateTime ahora = DateTime.Now;
            // Convierte la fecha y hora actual a formato de cadena "yyyy-MM-dd HH:mm:ss" y la asigna a la propiedad Fecha.
            Fecha = ahora.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Constructor sobrecargado de la clase Movimiento.
        /// Inicializa una nueva instancia de Movimiento con el tipo de movimiento y el importe especificados,
        /// utilizando el constructor base para inicializar la fecha con la fecha y hora actuales.
        /// </summary>
        /// <param name="tipo">Tipo de movimiento (Ingreso, Retiro, Reserva).</param>
        /// <param name="importe">Importe del movimiento.</param>
        public Movimiento(ETipoMovimiento tipo, double importe) : this()
        {
            // Asigna el tipo de movimiento especificado al objeto Movimiento.
            Tipo = tipo;
            // Asigna el importe especificado al objeto Movimiento.
            Importe = importe;  
        }

        /// <summary>
        /// Devuelve una representación de cadena del objeto Movimiento.
        /// </summary>
        /// <returns>Una cadena que representa el objeto Movimiento con sus propiedades ID, Tipo, Importe y Fecha.</returns>
        public override string ToString()
        {
            // Retorna una cadena formateada que incluye el ID, Tipo, Importe y Fecha del movimiento.
            return $"ID: {Id} - Tipo: {Tipo} - Importe: {Importe} - Fecha: {Fecha}";
        }
    }
}
