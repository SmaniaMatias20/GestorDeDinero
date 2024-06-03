
using CapaEntidades;
using CapaDatos;

namespace CapaServicios
{

    public class CS_Movimiento
    {
        // Atributos
        private CD_Movimiento cdMovimiento;

        public CS_Movimiento()
        {
            cdMovimiento = new CD_Movimiento();
        }

        public void RegistrarMovimiento(int idUsuario, double importe, string tipo) 
        {
            Movimiento movimiento = new Movimiento(tipo, importe);
            
            cdMovimiento.AgregarMovimiento(idUsuario, movimiento.Fecha, movimiento.Importe, movimiento.Tipo);
        }
    }
}
