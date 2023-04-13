using Rental.Data;
using Rental.Model;

namespace Rental.Services;

public class RentalPropertyService : IRentalPropertyService
{
    private IRentalPropertyRepository _rentalPropertyRepository;
    
    public RentalPropertyService(IRentalPropertyRepository rentalPropertyRepository)
    {
        _rentalPropertyRepository = rentalPropertyRepository;
    }
    
    public async Task<IEnumerable<RentalProperty>> FindRentalProperties(string city)
    {
        // Get the city_id for the specified city
        int cityId = 1;
        var rentalProperties = await _rentalPropertyRepository.GetRentalPropertiesByCity(cityId);

        return rentalProperties.Select(rentalProperty => rentalProperty);
    }
}