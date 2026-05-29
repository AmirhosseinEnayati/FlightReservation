using FlightReservation.Application.Contracts.Requests;
using FlightReservation.Application.Contracts.Responses;
using FlightReservation.Infrastructure.Repositories;

namespace FlightReservation.Application.Services;

public class FlightService
{
    private readonly IFlightRepository _flightRepository;

    public FlightService(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<IEnumerable<FlightResponse>> SearchFlightsAsync(FlightSearchRequest request)
    {
        var flights = await _flightRepository.SearchAsync(
            request.FromCity,
            request.ToCity,
            request.DepartureDate
        );

        return flights.Select(f => new FlightResponse(
            f.Id,
            f.FlightNumber,
            f.Airline,
            f.Route,
            f.DepartureTime,
            f.ArrivalTime,
            f.TotalSeats,
            f.AvailableSeats,
            f.BasePrice
        ));
    }

    public async Task<FlightResponse?> GetFlightByIdAsync(Guid id)
    {
        var flight = await _flightRepository.GetByIdAsync(id);
        if (flight == null)
            return null;

        return new FlightResponse(
            flight.Id,
            flight.FlightNumber,
            flight.Airline,
            flight.Route,
            flight.DepartureTime,
            flight.ArrivalTime,
            flight.TotalSeats,
            flight.AvailableSeats,
            flight.BasePrice
        );
    }
}
