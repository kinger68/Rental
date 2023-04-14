namespace Rental.Data.DataModels;

public class RenterDto
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int PropertyId { get; set; }
    public int CurrentAddressStreetId { get; set; }
}