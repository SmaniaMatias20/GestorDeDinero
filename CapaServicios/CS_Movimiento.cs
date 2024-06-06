using CapaEntidades;
using CapaDatos;
using System.Collections.Generic;
using CapaEntidades.Enums;

namespace CapaServicios
{

    public class CS_Movimiento
    {
        // Atributos
        private CD_Movimiento _cdMovimiento;

        public CS_Movimiento()
        {
            _cdMovimiento = new CD_Movimiento();
        }

        public string RegistrarMovimiento(int idUsuario, double importe, ETipoMovimiento tipo) 
        {
            Movimiento movimiento = new Movimiento(tipo, importe);
            if (importe > 0)
            {
                _cdMovimiento.AgregarMovimiento(idUsuario, movimiento.Fecha, movimiento.Importe, movimiento.Tipo);
                return "Los fondos han sido actualizados correctamente";
            }
            else
            {
                return "Ingrese un importe distinto a 0(cero)";
            }
        }

        public List<Movimiento> ObtenerMovimientosPorId(int idUsuario) 
        { 
            List<Movimiento> listaDeMovimientos = _cdMovimiento.ListarMovimientos(idUsuario);  

            return listaDeMovimientos;
        }

        public void EliminarMovimientoPorId(int idMovimiento) 
        {
            _cdMovimiento.EliminarMovimiento(idMovimiento);
        }

    }
}
