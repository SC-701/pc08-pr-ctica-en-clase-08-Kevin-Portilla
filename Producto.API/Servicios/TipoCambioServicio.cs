using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.TipoCambio;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Servicios
{
    public class TipoCambioServicio : ITipoCambioServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public TipoCambioServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<TipoCambio> ObtenerTipoCambio(DateTime fecha)
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointTipoCambio", "ObtenerTipoCambioVenta");
            var token = _configuracion.ObtenerValor("Token");

            var cliente = _httpClient.CreateClient("ServicioTipoCambio");
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var fechaFormateada = fecha.ToString("yyyy/MM/dd");
            var url = string.Format(endPoint, fechaFormateada);

            using var respuesta = await cliente.GetAsync(url);
            respuesta.EnsureSuccessStatusCode();

            var json = await respuesta.Content.ReadAsStringAsync();

            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<Response>(json, opciones);

            var valor = data?.Datos?.FirstOrDefault()?
                           .Indicadores?.FirstOrDefault()?
                           .Series?.FirstOrDefault()?
                           .ValorDatoPorPeriodo ?? 0m;

            return new TipoCambio { valorDatoPorPeriodo = valor };
        }
    }
}