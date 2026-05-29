using FlightReservation.Domain.Entities;

namespace FlightReservation.Infrastructure.Persistence;

public sealed class DataStore
{
    private static readonly Lazy<DataStore> _lazy = new(() => new DataStore());
    public static DataStore Instance => _lazy.Value;

    private DataStore()
    {
        Flights = new List<Flight>();
    }

    public List<Flight> Flights { get; }
}
