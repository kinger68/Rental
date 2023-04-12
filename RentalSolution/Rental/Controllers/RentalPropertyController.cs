using Microsoft.AspNetCore.Mvc;
using Rental.Model;

namespace Rental.Controllers;

[ApiController]
[Route("[controller]")]
public class RentalPropertyController : ControllerBase
{
    private readonly ILogger<RentalPropertyController> _logger;

    public RentalPropertyController(ILogger<RentalPropertyController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetRentalProperty")]
    public IEnumerable<RentalProperty> Get()
    {
        return Enumerable.Range(1, 3).Select(index => new RentalProperty()
            {
                Street = "123 Some Drive",
                City = "Waltham",
                State = "MA",
                ZipCode = "01803",
                Description = "A description of the property",
                RentAmount = 3000.23,
                Bedrooms = 3,
            })
            .ToArray();
    }
}