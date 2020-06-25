using System;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using DailyMed.Blazor.Helpers;
using DailyMed.Blazor.Models;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace DailyMed.Blazor.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Datum>> GetDataAsync()
        {
            var data = new List<Datum>();
            var uri = new Uri(string.Format(Constants.BaseApi, string.Empty));

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var obj = JObject.Parse(content).SelectToken("data", true);
                    data = obj.ToObject<List<Datum>>();                   
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return data;
        }
    }
}
