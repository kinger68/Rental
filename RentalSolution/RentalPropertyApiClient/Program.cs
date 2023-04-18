
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
            client.BaseAddress = new Uri("http://localhost:5295/");

            Console.WriteLine("Rental properties by City using REST API prior to creating new property");
            await QueryPropertiesByCity.QueryByCity(client, "Boston");
            await CreateRentalProperty.createRentalProperty(client);

            Console.WriteLine("\n\nRental properties by City using REST API after to creating new property");
            await QueryPropertiesByCity.QueryByCity(client, "Boston");
        }
    }
}