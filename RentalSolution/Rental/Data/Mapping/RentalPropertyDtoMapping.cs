using Rental.Data.DataModels;
using Rental.Model;

namespace Rental.Data.Mapping;

public static class RentalPropertyDtoMapping
{
    public static RentalPropertyDto ToDataModel(this RentalProperty domainModel, int streetId) 
    {
        RentalPropertyDto rentalPropertyDto = new RentalPropertyDto();
        rentalPropertyDto.Name = domainModel.Name;
        rentalPropertyDto.StreetId = streetId;
        rentalPropertyDto.Rent = domainModel.Rent;
        rentalPropertyDto.Bedrooms = domainModel.Bedrooms;
        rentalPropertyDto.Unit = domainModel.Unit;

        return rentalPropertyDto;
    }

    public static RentalProperty ToDomainModel(this RentalPropertyDto dataModel, string streetName)
    {
        RentalProperty rentalProperty = new RentalProperty();
        rentalProperty.Name = dataModel.Name;
        rentalProperty.Street = streetName;
        rentalProperty.Rent = dataModel.Rent;
        rentalProperty.Bedrooms = dataModel.Bedrooms;
        rentalProperty.Unit = dataModel.Unit;

        return rentalProperty;
    }
}