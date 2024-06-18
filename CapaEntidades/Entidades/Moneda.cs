

namespace CapaEntidades.Entidades
{
    public class Moneda
    {
        public string Nombre { get; set; }
        public double Valor { get; set; }

        public Moneda() 
        { 
        }

        public Moneda(string nombre, double valor) 
        { 
            Nombre = nombre;    
            Valor = valor;  
        }

        public override string ToString()
        {
            return $"{Nombre}, {Valor}";
        }
    }
}
