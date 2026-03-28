namespace Abstracciones.Interfaces.Reglas
{
    public interface IProductoReglas
    {
        Task<decimal> CalcularPrecioUSD(decimal precioCRC);
    }
}
