using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using NearEarthObjects.Models;

namespace NearEarthObjects.Services
{
    public class NearEarthObjectService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.nasa.gov/neo/rest/v1/";
        private readonly string _apiKey;

        public NearEarthObjectService()
        {
            _httpClient = new HttpClient();
            _apiKey = Environment.GetEnvironmentVariable("NASA_API_KEY") 
                      ?? throw new InvalidOperationException("NASA_API_KEY environment variable is not set.");
        }

        public async Task<List<NearEarthObject>> GetNearEarthObjectsAsync(string startDate, string endDate)
        {
            var url = $"{BaseUrl}feed?start_date={startDate}&end_date={endDate}&api_key={_apiKey}";

            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var neoResponse = JsonSerializer.Deserialize<NeoApiResponse>(jsonResponse, options);

                return neoResponse?.NearEarthObjects.Values.SelectMany(x => x).ToList() ?? new List<NearEarthObject>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error fetching data: {ex.Message}");
            }
        }
    }

    public class NeoApiResponse
    {
        [JsonPropertyName("near_earth_objects")]
        public Dictionary<string, List<NearEarthObject>> NearEarthObjects { get; set; }
    }
}