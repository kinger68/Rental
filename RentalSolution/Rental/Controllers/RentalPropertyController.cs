using Microsoft.AspNetCore.Mvc;
using Rental.Model;
using Rental.Services;

namespace Rental.Controllers;

[ApiController]
[Route("[controller]")]
public class RentalPropertyController : ControllerBase
{
    private readonly IRentalPropertyService _rentalPropertyService;

    public RentalPropertyController(IRentalPropertyService rentalPropertyService)
    {
        _rentalPropertyService = rentalPropertyService;
    }

    [HttpGet]
    [Route("api/v1/rentalproperties")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RentalProperty>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetRentalProperties(
        [FromQuery] string city)
    {
        IEnumerable<RentalProperty> rentalProperties = await _rentalPropertyService.FindRentalProperties(city);
        return new JsonResult(rentalProperties);
    }
}