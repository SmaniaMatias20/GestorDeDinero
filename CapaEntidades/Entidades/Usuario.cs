using CapaEntidades.Entidades;
using System.Collections.Generic;


namespace CapaEntidades
{
    public class Usuario
    {
        // Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public double FondosTotales { get; set; }
        public List<Reserva> Reservas { get; set; }
        public List<Movimiento> Movimientos { get; set; } 
        public List<Gasto> Gastos { get; set; } 


        /// <summary>
        /// Inicializa una nueva instancia de la clase Usuario sin parámetros.
        /// </summary>
        public Usuario() 
        {
            // Inicializa la lista de reservas del usuario
            Reservas = new List<Reserva>();
            Movimientos = new List<Movimiento>();
            Gastos = new List<Gasto>(); 
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Usuario con el nombre de usuario, clave y fondos totales especificados.
        /// </summary>
        /// <param name="nombreUsuario">El nombre de usuario del usuario.</param>
        /// <param name="clave">La clave del usuario.</param>
        /// <param name="fondosTotales">Los fondos totales del usuario.</param>
        public Usuario(string nombreUsuario, string clave, double fondosTotales) : this() 
        {
            // Asigna los valores proporcionados a las propiedades del usuario
            Nombre = nombreUsuario;
            Clave = clave; 
            FondosTotales = fondosTotales; 
        }

    }
}
