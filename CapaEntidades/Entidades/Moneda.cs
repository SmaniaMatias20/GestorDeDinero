

namespace CapaEntidades.Entidades
{
    public class Moneda
    {
        // Propiedades
        public string Nombre { get; set; }
        public double Valor { get; set; }

        /// <summary>
        /// Constructor vacío de la clase Moneda.
        /// </summary>
        public Moneda()
        {
        }

        /// <summary>
        /// Constructor de la clase Moneda que inicializa el nombre y el valor de la moneda.
        /// </summary>
        /// <param name="nombre">El nombre de la moneda.</param>
        /// <param name="valor">El valor de la moneda.</param>
        public Moneda(string nombre, double valor)
        {
            Nombre = nombre;
            Valor = valor;
        }

        /// <summary>
        /// Devuelve una representación en formato de cadena de la moneda, mostrando su nombre y valor.
        /// </summary>
        /// <returns>Una cadena que representa la moneda en el formato "Nombre, Valor".</returns>
        public override string ToString()
        {
            return $"{Nombre}, {Valor}";
        }
    }
}
