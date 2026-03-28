using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;

namespace Flujo
{
    public class ProductoFlujo : IProductoFlujo
    {
        private IProductoDA _productoDA;
        private readonly IProductoReglas _productoReglas;
        public ProductoFlujo(IProductoDA productoDA, IProductoReglas productoReglas)
        {
            _productoDA = productoDA;
            _productoReglas = productoReglas;
        }
        public Task<Guid> Agregar(ProductoRequest producto)
        {
            return _productoDA.Agregar(producto);
        }

        public Task<Guid> Editar(Guid Id, ProductoRequest producto)
        {
            return _productoDA.Editar(Id, producto);
        }

        public Task<Guid> Eliminar(Guid Id)
        {
            return _productoDA.Eliminar(Id);
        }

        public Task<IEnumerable<ProductoResponse>> Obtener()
        {
            return _productoDA.Obtener();
        }

        public async Task<ProductoDetalleResponse> Obtener(Guid Id)
        {
            var producto = await _productoDA.Obtener(Id);
            if (producto == null) 
                return null;

            var precioUsd = await _productoReglas.CalcularPrecioUSD(producto.Precio);

            return new ProductoDetalleResponse
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.Stock,
                CodigoBarras = producto.CodigoBarras,
                Categoria = producto.Categoria,
                SubCategoria = producto.SubCategoria,
                PrecioUSD = precioUsd
            };
        }
    }
}
