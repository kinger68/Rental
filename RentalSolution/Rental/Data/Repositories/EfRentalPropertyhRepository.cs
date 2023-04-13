using Rental.Data.DataModels;
using Rental.Model;

namespace Rental.Data;

public class EfRentalRepository : IRentalPropertyRepository
{
    public Task<string> CreateOrUpdateRentalPropertyAsync(RentalProperty rentalPropertyToUpsert)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RentalProperty>> GetRentalPropertiesByCity(string searchCity)
    {
        // This does the find by primary key. Could also search on the city that was passed in the query
        // City? c;
        // using (var cityContext = new CityContext(""))
        // {
        //     c = cityContext.Cities.Find(2);
        // }

        CityDto? city;
        using (var cityContext = new CityContext(""))
        {
            city = cityContext.Cities.Single(ci => ci.Name.Equals(searchCity));
        }
        
        List<StreetDto> streets;
        using (var streetContext = new StreetContext(""))
        {
            streets = streetContext.Streets.Where(street => street.CityId == city.Id).ToList();
        }

        foreach (StreetDto street in streets)
        {
            // Find all the rental properties on that street
        }

        // IEnumerable<RentalProperty> rentalProperties;
        // using (var rentalPropertyContext = new RentalPropertyContext(""))
        // {
        //     rentalProperties2 = rentalPropertyContext.RentalProperties.Select(rp => rp.Street.Equals())
        // }

        var rentalProperties =  Enumerable.Range(1, 3).Select(index => new RentalProperty()
            {
                Name = "Rental Property Name",
                Street = streets[0].Name,
                Unit = city.Name,
                Rent = 3000.23,
                Bedrooms = 3,
            })
            .ToArray();
        
        return rentalProperties.Select(rentalProperty => rentalProperty);
    }
}