using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.TipoCambio;

namespace Reglas
{
    public class ProductoReglas : IProductoReglas
    {
        private readonly ITipoCambioServicio _tipoCambioServicio;

        public ProductoReglas(ITipoCambioServicio tipoCambioServicio)
        {
            _tipoCambioServicio = tipoCambioServicio;
        }

        public async Task<decimal> CalcularPrecioUSD(decimal precioCRC)
        {
            TipoCambio tipoCambio = await _tipoCambioServicio.ObtenerTipoCambio(DateTime.Today);
            decimal precioUSD = precioCRC / tipoCambio.valorDatoPorPeriodo;
            return Math.Round(precioUSD, 2, MidpointRounding.AwayFromZero);
        }
    }
}
