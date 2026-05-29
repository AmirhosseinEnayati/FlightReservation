using FlightReservation.Application.Contracts.Requests;
using FlightReservation.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightsController : ControllerBase
{
    private readonly FlightService _flightService;

    public FlightsController(FlightService flightService)
    {
        _flightService = flightService;
    }

    /// <summary>
    /// Search for available flights
    /// </summary>
    /// <param name="fromCity">Departure city (optional)</param>
    /// <param name="toCity">Arrival city (optional)</param>
    /// <param name="departureDate">Departure date in UTC (optional)</param>
    /// <returns>List of matching flights</returns>
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Search(
        [FromQuery] string? fromCity,
        [FromQuery] string? toCity,
        [FromQuery] DateTime? departureDate)
    {
        var request = new FlightSearchRequest(fromCity, toCity, departureDate);
        var flights = await _flightService.SearchFlightsAsync(request);
        return Ok(flights);
    }

    /// <summary>
    /// Get flight details by ID
    /// </summary>
    /// <param name="id">Flight ID</param>
    /// <returns>Flight details</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var flight = await _flightService.GetFlightByIdAsync(id);
        if (flight == null)
            return NotFound(new { message = "Flight not found." });

        return Ok(flight);
    }
}
