using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsumerCatFactApi
{
    public class CatFactResponse
    {
        [JsonPropertyName("fact")]
        public string Fact { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            string apiUrl = "https://catfact.ninja/fact";

            using HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                CatFactResponse catFact = JsonSerializer.Deserialize<CatFactResponse>(jsonResponse);

                Console.WriteLine("Fato sobre Gatos:");
                Console.WriteLine(catFact.Fact);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao consumir a API: {e.Message}");
            }
        }
    }
}