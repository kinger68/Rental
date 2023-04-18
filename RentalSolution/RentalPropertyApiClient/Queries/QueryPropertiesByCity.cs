using System.Text.Json;

namespace RentalPropertyApiClient.Queries;

public class QueryPropertiesByCity
{
    public static async Task QueryByCity(HttpClient client, string city)
    {
        await using Stream stream = 
            await client.GetStreamAsync("RentalProperty/api/v1/findRentalByCity?city=" + city);

        var deserializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var rentalProperties = await JsonSerializer.DeserializeAsync<List<RentalProperty>>(stream, deserializeOptions);

        if (rentalProperties != null)
        {
            foreach (RentalProperty rentalProperty in rentalProperties)
            {
                Console.WriteLine(rentalProperty);
            }
        }
    }
}