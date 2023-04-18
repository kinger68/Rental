
using System.Net.Http.Json;
using System.Text;

namespace RentalPropertyApiClient.Queries;

public class CreateRentalProperty
{
    public static async Task createRentalProperty(HttpClient client)
    {
        RentalProperty rp =
            new RentalProperty("SomeNewRentalPlace", "Canterbury Street", 1010.15, 2, "Unit 8");
        var response = await client.PostAsJsonAsync("RentalProperty/api/v1/createRentalProperty", rp);
    }
}