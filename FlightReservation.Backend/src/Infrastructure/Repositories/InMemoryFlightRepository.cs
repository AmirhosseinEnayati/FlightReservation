using FlightReservation.Domain.Entities;
using FlightReservation.Infrastructure.Persistence;

namespace FlightReservation.Infrastructure.Repositories;

public class InMemoryFlightRepository : IFlightRepository
{
    private readonly DataStore _store;

    public InMemoryFlightRepository()
    {
        _store = DataStore.Instance;
    }

    public Task<Flight?> GetByIdAsync(Guid id)
    {
        var flight = _store.Flights.FirstOrDefault(f => f.Id == id);
        return Task.FromResult(flight);
    }

    public Task<IEnumerable<Flight>> SearchAsync(string? fromCity, string? toCity, DateTime? departureDate)
    {
        var query = _store.Flights.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(fromCity))
            query = query.Where(f => f.Route.DepartureCity.Equals(fromCity, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(toCity))
            query = query.Where(f => f.Route.ArrivalCity.Equals(toCity, StringComparison.OrdinalIgnoreCase));

        if (departureDate.HasValue)
            query = query.Where(f => f.DepartureTime.Date == departureDate.Value.Date);

        return Task.FromResult(query);
    }
}
