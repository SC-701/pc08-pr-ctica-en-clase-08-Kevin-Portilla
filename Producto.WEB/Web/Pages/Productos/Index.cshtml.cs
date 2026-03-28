using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Net;

namespace Web.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguracion _configuracion;
        public IList<ProductoResponse> productos { get; set; } = default!;

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGet()
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerProductos");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);
            Console.WriteLine("ENDPOINT => " + endpoint);

            var respuesta = await cliente.SendAsync(solicitud);

            if (respuesta.StatusCode == HttpStatusCode.NoContent)
            {
                productos = new List<ProductoResponse>();
                return;
            }

            respuesta.EnsureSuccessStatusCode();

            var resultado = await respuesta.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(resultado))
            {
                productos = new List<ProductoResponse>();
                return;
            }

            var opciones = new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true };

            productos = JsonSerializer.Deserialize<List<ProductoResponse>>(resultado, opciones);
            Console.WriteLine("ENDPOINT => " + endpoint);
        }
    }
}