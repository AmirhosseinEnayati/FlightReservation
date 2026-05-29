namespace FlightReservation.Application.Contracts.Requests;

public record FlightSearchRequest(
    string? FromCity,
    string? ToCity,
    DateTime? DepartureDate
);
