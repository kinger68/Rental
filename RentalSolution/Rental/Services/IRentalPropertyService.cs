using Rental.Model;

namespace Rental.Services;

public interface IRentalPropertyService
{
    Task<IEnumerable<RentalProperty>> FindRentalProperties(string city);
}