using EL.RussIgrush.Katalog.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EL.RussIgrush.Katalog.Repository
{
    public class TipOtdelaRepository : ITipOtdelaRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = string.Empty;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public TipOtdelaRepository(HttpClient httpClient) { 
            _httpClient = httpClient;
            _url = $"http://24f.torov-lab.ru/api/TipOtdela/tipotdela_byotdel?id=";
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<TipOtdelaModel> GetTipOtdelaById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TipOtdelaModel>> GetTipOtdelaByOtdelId(int idOtdel)
        {
            List<TipOtdelaModel> list = new List<TipOtdelaModel>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return list;
            }
            try
            {
                var url = $"{_url}{idOtdel}";
                HttpResponseMessage response = await _httpClient.GetAsync($"https://24f.torov-lab.ru/api/TipOtdela/tipotdela_byotdel?id={idOtdel}");
                if (response.IsSuccessStatusCode)
                {
                    string contents = await response.Content.ReadAsStringAsync();
                    list = JsonSerializer.Deserialize<List<TipOtdelaModel>>(contents, _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }
            return list;
        }
    }
}
