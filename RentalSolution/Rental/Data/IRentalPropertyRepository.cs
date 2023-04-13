using Rental.Model;

namespace Rental.Data;

public interface IRentalPropertyRepository
{
    // Not adding a delete of a rental property, only a way to mark it as inactive
    // Maybe want to maintain history of past units a renter has been for example
    Task<string> CreateOrUpdateRentalPropertyAsync(RentalProperty rentalPropertyToUpsert);
    Task<IEnumerable<RentalProperty>> GetRentalPropertiesByCity(string city);
}