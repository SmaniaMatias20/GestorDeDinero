
using CapaEntidades;
using CapaDatos;
using System.Collections.Generic;

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

        public List<Movimiento> ObtenerMovimientosPorId(int idUsuario) 
        { 
            List<Movimiento> listaDeMovimientos = cdMovimiento.ListarMovimientos(idUsuario);  

            return listaDeMovimientos;
        }

        public void EliminarMovimientoPorId(int idMovimiento) 
        {
            cdMovimiento.EliminarMovimiento(idMovimiento);
        }

    }
}
