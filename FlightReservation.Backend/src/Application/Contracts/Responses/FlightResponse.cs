using FlightReservation.Domain.ValueObjects;

namespace FlightReservation.Application.Contracts.Responses;

public record FlightResponse(
    Guid Id,
    string FlightNumber,
    string Airline,
    FlightRoute Route,
    DateTime DepartureTime,
    DateTime ArrivalTime,
    int TotalSeats,
    int AvailableSeats,
    decimal BasePrice
);
