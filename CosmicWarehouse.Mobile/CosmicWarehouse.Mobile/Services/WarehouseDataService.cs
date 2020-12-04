using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CosmicWarehouse.Mobile.Models;
using Newtonsoft.Json;

namespace CosmicWarehouse.Mobile.Services
{
    public class WarehouseDataService
    {
        const string BASE_URL = "http://localhost:5001";

        private HttpClient _client;

        public async Task<IEnumerable<Warehouse>> GetWarehouses()
        {
            using (_client = new HttpClient())
            {
                Uri uri = new Uri($"{BASE_URL}/Warehouse/GetAllWarehouses");
                HttpResponseMessage response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Warehouse>>(content);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}