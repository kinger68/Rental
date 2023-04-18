
using System.Net.Http.Headers;
using RentalPropertyApiClient.Queries;

namespace RentalPropertyApiClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Rental Property Client");

            await QueryPropertiesByCity.QueryByCity(client, "Boston");
        }
    }
}