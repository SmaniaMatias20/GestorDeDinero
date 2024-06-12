
using CapaDatos;
using CapaEntidades;
using CapaEntidades.Entidades;
using CapaEntidades.Enums;
using System;
using System.Collections.Generic;

namespace CapaServicios
{
    public class CS_Gasto
    {
        // Atributos
        private CD_Gasto _cdGasto;


        /// <summary>
        /// 
        /// </summary>
        public CS_Gasto() 
        { 
            //
            _cdGasto = new CD_Gasto();
        }

        /// <summary>
        /// Obtiene una lista de movimientos asociados a un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El identificador único del usuario cuyos movimientos se desean obtener.</param>
        /// <returns>Una lista de movimientos asociados al usuario especificado.</returns>
        public List<Gasto> ObtenerGastosPorId(int idUsuario)
        {
            // Llama al método ListarMovimientos de la clase _cdMovimiento para obtener los movimientos del usuario especificado
            List<Gasto> listaGastos = _cdGasto.ListarGastos(idUsuario);

            // Devuelve la lista de movimientos obtenidos
            return listaGastos;
        }

        public string RegistrarGasto(int idUsuario, double importe, string tipo, string fecha, string pago, string descripcion)
        {
            if (tipo == "")
            {
                tipo = "Otros";
            }


            if (Enum.TryParse(tipo, out ETipoGasto tipoGasto) && Enum.TryParse(pago, out ETipoPago tipoPago))
            {
                if (descripcion == "")
                {
                    descripcion = "Sin descripción";  
                }


                Gasto gasto = new Gasto(tipoGasto, importe, tipoPago, descripcion, fecha);

                _cdGasto.AgregarGasto(idUsuario, gasto.Fecha, gasto.Importe, gasto.Tipo, gasto.Pago, gasto.Descripcion);

                return "Gasto registrado";
            }


            return "No se pudo registrar el gasto";
        }



        public void EliminarGastoPorId(int idGasto)
        {
            _cdGasto.EliminarGasto(idGasto);
        }
    }
}
