namespace Rental.Data.DataModels;

public class StreetDto
{
    public int Id { get; set; }
    public String Name { get; set; }
    public int CityId { get; set; }
    public String Zipcode { get; set; }
}