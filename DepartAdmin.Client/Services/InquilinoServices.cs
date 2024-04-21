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

        

        public async Task<List<Inquilinos>> InquilinoList()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<Inquilinos>>>("api/Inquilino/List");

            if (result!.response)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
        public async Task<Inquilinos> Search(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<Inquilinos>>($"api/Inquilino/Searh/{id}");

            if (result!.response)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Save(Inquilinos inquilinos)
        {
            var result = await _http.PostAsJsonAsync("api/Inquilino/Save", inquilinos);
            var Response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (Response!.response)
                return Response.Valor!;
            else
                throw new Exception(Response.Mensaje);
        }

        public async Task<int> Edit(Inquilinos inquilinos)
        {
            var result = await _http.PutAsJsonAsync($"api/Inquilino/Edit/{inquilinos.UserId}", inquilinos);
            var Response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (Response!.response)
                return Response.Valor!;
            else
                throw new Exception(Response.Mensaje);
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _http.DeleteAsync($"api/Inquilino/Delete/{id}");
            var Response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (Response!.response)
                return Response.response!;
            else
                throw new Exception(Response.Mensaje);
        }
    }
}
