namespace Rental.Model;

public class RentalProperty
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public int Bedrooms { get; set; }
    public double RentAmount;
    public string? Description { get; set; }
}