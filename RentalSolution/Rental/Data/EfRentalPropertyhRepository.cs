using Rental.Model;

namespace Rental.Data;

public class EfRentalRepository : IRentalPropertyRepository
{
    public Task<string> CreateOrUpdateRentalPropertyAsync(RentalProperty rentalPropertyToUpsert)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RentalProperty>> GetRentalPropertiesByCity(int cityId)
    {
        var rentalProperties =  Enumerable.Range(1, 3).Select(index => new RentalProperty()
            {
                Street = "123 Some Drive",
                City = "Waltham",
                State = "MA",
                ZipCode = "01803",
                Description = "A description of the property",
                RentAmount = 3000.23,
                Bedrooms = 3,
            })
            .ToArray();
        
        return rentalProperties.Select(rentalProperty => rentalProperty);
    }
}