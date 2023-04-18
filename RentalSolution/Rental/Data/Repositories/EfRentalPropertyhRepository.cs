using Org.BouncyCastle.Crypto.Engines;
using Rental.Data.DataModels;
using Rental.Data.Mapping;
using Rental.Model;

namespace Rental.Data;

public class EfRentalRepository : IRentalPropertyRepository
{
    private RentalPropertyContext _rentalPropertyContext;
    private CityContext _cityContext;

    public EfRentalRepository(RentalPropertyContext rentalPropertyContext, CityContext cityContext)
    {
        _rentalPropertyContext = rentalPropertyContext;
        _cityContext = cityContext;
    }

    public async Task<int> CreateOrUpdateRentalPropertyAsync(RentalProperty rentalPropertyToUpsert)
    {
        // Red Alert - Hard coded for now. Need Repository method to get streetId from name 
        int streetId = 3;
        
        // Utilize object extension to add converting to a data model
        RentalPropertyDto rentalPropertyDto = rentalPropertyToUpsert.ToDataModel(streetId);

        // Check if the property already exists, if so, modify it, otherwise create it
        await _rentalPropertyContext.AddAsync(rentalPropertyDto);
        await _rentalPropertyContext.SaveChangesAsync();
        return rentalPropertyDto.Id;
    }

    public async Task<IEnumerable<RentalProperty>> GetRentalPropertiesByCity(string searchCity)
    {
        CityDto? city;
        Boolean exists = _cityContext.Cities.Any(ci => ci.Name.Equals(searchCity));
        if (!exists)
        {
            return Enumerable.Empty<RentalProperty>();
        }
        city = _cityContext.Cities.Single(ci => ci.Name.Equals(searchCity));

        List<StreetDto> streets;
        using (var streetContext = new StreetContext(""))
        {
            streets = streetContext.Streets.Where(street => street.CityId == city.Id).ToList();
        }

        var rentalProperties = new List<RentalProperty>();
        IEnumerable<RentalPropertyDto> rProperties = new List<RentalPropertyDto>();
        foreach (StreetDto street in streets)
        {
            rProperties = _rentalPropertyContext.RentalProperties.Where(rp => rp.StreetId == street.Id);
            foreach (RentalPropertyDto rentalPropertyDto in rProperties)
            {
                RentalProperty rp = rentalPropertyDto.ToDomainModel(street.Name);
                rentalProperties.Add(rp);
            }
        }

        return rentalProperties.Select(rentalProperty => rentalProperty);
    }
}