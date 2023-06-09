namespace Rental.Model;

public class RentalProperty
{
    public string Name { get; set; }
    public string Street { get; set; }
    public double Rent { get; set; }
    public int Bedrooms { get; set; }
    public string? Unit { get; set; }
}