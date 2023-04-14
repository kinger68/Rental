namespace Rental.Data.DataModels;

public class StreetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CityId { get; set; }
    public string Zipcode { get; set; }
}