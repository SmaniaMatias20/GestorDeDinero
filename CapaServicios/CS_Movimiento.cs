
using CapaEntidades;
using CapaDatos;
using System.Collections.Generic;
using CapaEntidades.Enums;

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

        public string RegistrarMovimiento(int idUsuario, double importe, ETipoMovimiento tipo) 
        {
            Movimiento movimiento = new Movimiento(tipo, importe);
            if (importe > 0)
            {
                cdMovimiento.AgregarMovimiento(idUsuario, movimiento.Fecha, movimiento.Importe, movimiento.Tipo);
                return "Los fondos han sido actualizados correctamente";
            }
            else
            {
                return "Ingrese un importe distinto a 0(cero)";
            }
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
