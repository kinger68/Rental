namespace Rental.Data.DataModels;

public class RentalPropertyDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string StreetId { get; set; }
    public double Rent { get; set; }
    public int Bedrooms { get; set; }
    public string? Unit { get; set; }
}