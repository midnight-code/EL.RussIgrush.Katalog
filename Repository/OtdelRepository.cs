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
    public class OtdelRepository : IOtdelRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = string.Empty;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        public OtdelRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _url = $"https://24f.torov-lab.ru/api/Otdel/otdel";
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<IEnumerable<OtdelModel>> GetAllOtdel()
        {
            List<OtdelModel> list = new List<OtdelModel>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return list;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}");
                if (response.IsSuccessStatusCode)
                {
                    string contents = await response.Content.ReadAsStringAsync();
                    list = JsonSerializer.Deserialize<List<OtdelModel>>(contents, _jsonSerializerOptions);
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

        public Task<OtdelModel> GetOtdelById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
