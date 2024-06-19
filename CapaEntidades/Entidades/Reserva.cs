using System;

namespace CapaEntidades
{
    public class Reserva
    {
        // atributos
        private bool _modificacion = false; 

        // Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Importe { get; set; } 
        public string Fecha { get; set; }
        public bool Modificacion { get { return _modificacion; } set { _modificacion = value; } }

        /// <summary>
        /// Constructor de la clase Reserva.
        /// Inicializa una nueva instancia de Reserva con la fecha actual.
        /// </summary>
        public Reserva() 
        {
            // Obtiene la fecha y hora actuales.
            DateTime ahora = DateTime.Now;
            // Convierte la fecha y hora actual a formato de cadena "yyyy-MM-dd HH:mm:ss" y la asigna a la propiedad Fecha.
            Fecha = ahora.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Constructor sobrecargado de la clase Reserva.
        /// Inicializa una nueva instancia de Reserva con el nombre y el importe especificados,
        /// utilizando el constructor base para inicializar la fecha con la fecha y hora actuales.
        /// </summary>
        /// <param name="nombre">Nombre asociado a la reserva.</param>
        /// <param name="importe">Importe asociado a la reserva.</param>
        public Reserva(string nombre, double importe) : this()
        {
            // Asigna el nombre especificado a la propiedad Nombre de la reserva.
            Nombre = nombre;
            // Asigna el importe especificado a la propiedad Importe de la reserva.
            Importe = importe;
        }

        /// <summary>
        /// Constructor de la clase Reserva que inicializa el nombre, importe, fecha y ID de la reserva.
        /// </summary>
        /// <param name="nombre">Nombre de la reserva.</param>
        /// <param name="importe">Importe de la reserva.</param>
        /// <param name="fecha">Fecha de la reserva.</param>
        /// <param name="id">ID de la reserva.</param>
        public Reserva(string nombre, double importe, string fecha, int id) : this(nombre, importe)
        {
            // Asigna el nombre especificado a la propiedad Fecha de la reserva.
            Fecha = fecha;
            // Asigna el nombre especificado a la propiedad Id de la reserva.
            Id = id;    
        }

        /// <summary>
        /// Devuelve una representación de cadena del objeto Reserva.
        /// </summary>
        /// <returns>Una cadena que representa el objeto Reserva con sus propiedades ID, Nombre, Importe y Fecha.</returns>
        public override string ToString()
        {
            // Retorna una cadena formateada que incluye el ID, Nombre, Importe y Fecha de la reserva.
            return $"ID: {Id} - Nombre: {Nombre} - Importe: {Importe} - Fecha: {Fecha}";
        }




    }
}
