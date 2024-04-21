using DepartAdmin.DAL.Entities;
using System.Net.Http.Json;

namespace DepartAdmin.Client.Services
{
    public class InquilinoServices : IInquilinoServices
    {
        private readonly HttpClient _http;

        public InquilinoServices(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Inquilino>> InquilinoList()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<Inquilino>>>("api/Inquilino/List");

            if (result!.response)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
