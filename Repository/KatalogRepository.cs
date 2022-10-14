using EL.RussIgrush.Katalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;

namespace EL.RussIgrush.Katalog.Repository
{
    public class KatalogRepository : IKatalogrepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = string.Empty;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public KatalogRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _url = $"http://24f.torov-lab.ru/api/TipOtdela/tipotdela_byotdel?id=";
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public Task<IEnumerable<KatalogModel>> GetAllKatalog()
        {
            throw new NotImplementedException();
        }

        public async Task<KatalogModel> GetKatalogById(int id)
        {
            KatalogModel model = new KatalogModel();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return model;
            }
            try
            {
                var url = $"{_url}{id}";
                HttpResponseMessage response = await _httpClient.GetAsync($"https://24f.torov-lab.ru/api/Katalog/katalog_details?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    string contents = await response.Content.ReadAsStringAsync();
                    model = JsonSerializer.Deserialize<KatalogModel>(contents, _jsonSerializerOptions);
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
            return model;
        }

        public async Task<IEnumerable<KatalogModel>> GetKatalogByTipId(int idTip)
        {
            List<KatalogModel> list = new List<KatalogModel>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return list;
            }
            try
            {
                var url = $"{_url}{idTip}";
                HttpResponseMessage response = await _httpClient.GetAsync($"https://24f.torov-lab.ru/api/Katalog/katalog_tipotdel?idtip={idTip}");
                if (response.IsSuccessStatusCode)
                {
                    string contents = await response.Content.ReadAsStringAsync();
                    list = JsonSerializer.Deserialize<List<KatalogModel>>(contents, _jsonSerializerOptions);
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
