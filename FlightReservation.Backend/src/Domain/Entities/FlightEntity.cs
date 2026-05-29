using FlightReservation.Domain.ValueObjects;

namespace FlightReservation.Domain.Entities;

public class Flight
{
    public Guid Id { get; set; }
    public string FlightNumber { get; set; } = string.Empty;
    public string Airline { get; set; } = string.Empty;
    public FlightRoute Route { get; set; } = new(string.Empty, string.Empty);
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int TotalSeats { get; set; }
    public int AvailableSeats { get; set; }
    public decimal BasePrice { get; set; }

    public Flight()
    {
        Id = Guid.NewGuid();
    }
}
