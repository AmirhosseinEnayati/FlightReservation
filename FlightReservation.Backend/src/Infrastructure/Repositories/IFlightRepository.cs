using FlightReservation.Domain.Entities;

namespace FlightReservation.Infrastructure.Repositories;

public interface IFlightRepository
{
    Task<IEnumerable<Flight>> SearchAsync(string? fromCity, string? toCity, DateTime? departureDate);
    Task<Flight?> GetByIdAsync(Guid id);
}
