using Rental.Data.DataModels;
using Rental.Model;

namespace Rental.Data.Mapping;

public static class RenterDtoMapping
{
    public static RenterDto ToDataModel(this Renter domainModel, int propertyId, int streetId) 
    {
        RenterDto renterDto = new RenterDto();
        renterDto.FirstName = domainModel.FirstName;
        renterDto.MiddleName = domainModel.MiddleName;
        renterDto.LastName = domainModel.LastName;
        renterDto.PropertyId = propertyId;
        renterDto.CurrentAddressStreetId = streetId;

        return renterDto;
    }

    public static Renter ToDomainModel(this RenterDto dataModel, string propertyName, string streetName)
    {
        Renter renter = new Renter();
        renter.FirstName = dataModel.FirstName;
        renter.MiddleName = dataModel.MiddleName;
        renter.LastName = dataModel.LastName;
        renter.CurrentAddress = streetName;
        renter.PropertyName = propertyName;

        return renter;
    }
}