

namespace CapaEntidades.Enums
{
    /// <summary>
    /// Enumeración que define los tipos de movimientos financieros disponibles.
    /// </summary>
    public enum ETipoMovimiento
    {
        Ingreso,    // Representa un movimiento de ingreso de dinero.
        Retiro,     // Representa un movimiento de retiro de dinero.
        Reserva      // Representa un movimiento de reserva de dinero.
    }

    /// <summary>
    /// Enumeración que define los tipos de gastos disponibles.
    /// </summary>
    public enum ETipoGasto
    {
        Alquiler,           // Gasto relacionado con el alquiler de vivienda o local.
        Servicios,          // Gasto en servicios públicos como luz, agua, gas, etc.
        Transporte,         // Gasto en transporte público o privado.
        Alimentacion,       // Gasto en alimentos y productos de alimentación.
        Ropa,               // Gasto en prendas de vestir y accesorios.
        Entretenimiento,    // Gasto destinado a actividades de entretenimiento.
        Vacaciones,         // Gasto asociado a viajes y vacaciones.
        Hobbies,            // Gasto en actividades recreativas o pasatiempos.
        Electronica,        // Gasto en dispositivos electrónicos y tecnológicos.
        Salud,              // Gasto relacionado con la salud y cuidado personal.
        Educacion,          // Gasto en educación y formación académica.
        Ahorro,             // Gasto destinado a ahorros o inversiones.
        Deudas,             // Gasto destinado al pago de deudas.
        Mantenimiento,      // Gasto en mantenimiento de vivienda, vehículos, etc.
        Mobiliario,         // Gasto en muebles y equipamiento del hogar.
        Regalos,            // Gasto en regalos y obsequios.
        Mascotas,           // Gasto relacionado con el cuidado de mascotas.
        Otros               // Otros tipos de gastos no especificados en las categorías anteriores.
    }

    /// <summary>
    /// Enumeración que define los tipos de pago disponibles.
    /// </summary>
    public enum ETipoPago
    {
        Efectivo,        // Tipo de pago en efectivo.
        Credito,         // Tipo de pago con tarjeta de crédito.
        Debito,          // Tipo de pago con tarjeta de débito.
        Transferencia,   // Tipo de pago por transferencia bancaria.
        MercadoPago      // Tipo de pago mediante MercadoPago.
    }

}
