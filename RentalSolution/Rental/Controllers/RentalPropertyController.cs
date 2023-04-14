using Microsoft.AspNetCore.Http.HttpResults;
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
    [Route("api/v1/findRentalByCity")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RentalProperty>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetRentalPropertiesByCity(
        [FromQuery] string city)
    {
        IEnumerable<RentalProperty> rentalProperties = await _rentalPropertyService.FindRentalProperties(city);
        return new JsonResult(rentalProperties);
    }

    [HttpPost]
    [Route("api/v1/createRentalProperty")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RentalProperty>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateRentalProperty(
        [FromBody] RentalProperty rentalProperty)
    {
        int rentalPropertyId = await _rentalPropertyService.CreateRentalProperty(rentalProperty);
        return Ok(rentalProperty);
    }
    
    [HttpPost]
    [Route("api/v1/createRenter")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RentalProperty>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateRenter(
        [FromBody] RentalProperty rentalProperty)
    {
        int rentalPropertyId = await _rentalPropertyService.CreateRentalProperty(rentalProperty);
        return Ok(rentalProperty);
    }
}