using Rental.Data.DataModels;
using Rental.Data.Mapping;
using Rental.Model;

namespace Rental.Data;

public class EfRentalRepository : IRentalPropertyRepository
{
    // Map RentalProperty to DTO object
    private RentalPropertyDto mapRentalPropertyDto(RentalProperty rpDto)
    {
        RentalPropertyDto rentalPropertyDto = new RentalPropertyDto();
        rentalPropertyDto.Name = rpDto.Name;
        rentalPropertyDto.Rent = rpDto.Rent;
        rentalPropertyDto.Bedrooms = rpDto.Bedrooms;
        rentalPropertyDto.Unit = rpDto.Unit;

        return rentalPropertyDto;
    }
    
    public async Task<int> CreateOrUpdateRentalPropertyAsync(RentalProperty rentalPropertyToUpsert)
    {
        using (var rentalPropertyContext = new RentalPropertyContext(""))
        {
            // Red Alert - Hard coded for now. Need Repository method to get streetId from name 
            int streetId = 3;
            
            // Utilize object extension to add converting to a data model
            RentalPropertyDto rentalPropertyDto = rentalPropertyToUpsert.ToDataModel(streetId);

            // Check if the property already exists, if so, modify it, otherwise create it
            await rentalPropertyContext.AddAsync(rentalPropertyDto);
            await rentalPropertyContext.SaveChangesAsync();
            return rentalPropertyDto.Id;
        }
    }

    public async Task<IEnumerable<RentalProperty>> GetRentalPropertiesByCity(string searchCity)
    {
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

        var rentalProperties = new List<RentalProperty>();
        IEnumerable<RentalPropertyDto> rProperties = new List<RentalPropertyDto>();
        foreach (StreetDto street in streets)
        {
            using (var rentalPropertyContext = new RentalPropertyContext(""))
            {
                rProperties = rentalPropertyContext.RentalProperties.Where(rp => rp.StreetId == street.Id);
                foreach (RentalPropertyDto rentalPropertyDto in rProperties)
                {
                    RentalProperty rp = rentalPropertyDto.ToDomainModel(street.Name);
                    rentalProperties.Add(rp);
                }              
            }
        }

        return rentalProperties.Select(rentalProperty => rentalProperty);
    }
}