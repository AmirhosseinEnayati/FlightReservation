using Xunit;
using FlightReservation.Application.Contracts.Requests;
using FlightReservation.Application.Services;
using FlightReservation.Domain.Entities;
using FlightReservation.Domain.ValueObjects;
using FlightReservation.Infrastructure.Persistence;
using FlightReservation.Infrastructure.Repositories;

namespace FlightReservation.Tests;

public class FlightServiceTests
{
    [Fact]
    public async Task SearchFlightsAsync_WithCriteria_ReturnsMatchingFlights()
    {
        // Arrange
        var dataStore = DataStore.Instance;
        dataStore.Flights.Clear();

        dataStore.Flights.Add(new Flight
        {
            FlightNumber = "AA100",
            Airline = "American Airlines",
            Route = new FlightRoute("New York", "Los Angeles"),
            DepartureTime = DateTime.UtcNow.AddDays(2),
            ArrivalTime = DateTime.UtcNow.AddDays(2).AddHours(5),
            TotalSeats = 180,
            AvailableSeats = 45,
            BasePrice = 299.99m
        });

        var repository = new InMemoryFlightRepository();
        var service = new FlightService(repository);

        // Act
        var results = await service.SearchFlightsAsync(new FlightSearchRequest("New York", "Los Angeles", null));

        // Assert
        Assert.Single(results);
        Assert.Equal("AA100", results.First().FlightNumber);
    }

    [Fact]
    public async Task SearchFlightsAsync_WithNoMatches_ReturnsEmptyList()
    {
        // Arrange
        var dataStore = DataStore.Instance;
        dataStore.Flights.Clear();

        var repository = new InMemoryFlightRepository();
        var service = new FlightService(repository);

        // Act
        var results = await service.SearchFlightsAsync(new FlightSearchRequest("Unknown", "Nowhere", null));

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public async Task GetFlightByIdAsync_WithValidId_ReturnsFlight()
    {
        // Arrange
        var dataStore = DataStore.Instance;
        dataStore.Flights.Clear();

        var flight = new Flight
        {
            FlightNumber = "UA500",
            Airline = "United Airlines",
            Route = new FlightRoute("New York", "London"),
            DepartureTime = DateTime.UtcNow.AddDays(3),
            ArrivalTime = DateTime.UtcNow.AddDays(4).AddHours(2),
            TotalSeats = 250,
            AvailableSeats = 28,
            BasePrice = 599.99m
        };
        dataStore.Flights.Add(flight);

        var repository = new InMemoryFlightRepository();
        var service = new FlightService(repository);

        // Act
        var result = await service.GetFlightByIdAsync(flight.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("UA500", result!.FlightNumber);
        Assert.Equal("United Airlines", result.Airline);
    }

    [Fact]
    public async Task GetFlightByIdAsync_WithInvalidId_ReturnsNull()
    {
        // Arrange
        var dataStore = DataStore.Instance;
        dataStore.Flights.Clear();

        var repository = new InMemoryFlightRepository();
        var service = new FlightService(repository);

        // Act
        var result = await service.GetFlightByIdAsync(Guid.NewGuid());

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task SearchFlightsAsync_FiltersByDate_ReturnsMatchingFlights()
    {
        // Arrange
        var dataStore = DataStore.Instance;
        dataStore.Flights.Clear();

        var tomorrow = DateTime.UtcNow.AddDays(1);

        dataStore.Flights.Add(new Flight
        {
            FlightNumber = "DL220",
            Airline = "Delta Airlines",
            Route = new FlightRoute("Miami", "Los Angeles"),
            DepartureTime = tomorrow,
            ArrivalTime = tomorrow.AddHours(5),
            TotalSeats = 200,
            AvailableSeats = 120,
            BasePrice = 349.99m
        });

        dataStore.Flights.Add(new Flight
        {
            FlightNumber = "SW150",
            Airline = "Southwest Airlines",
            Route = new FlightRoute("Miami", "Los Angeles"),
            DepartureTime = DateTime.UtcNow.AddDays(2),
            ArrivalTime = DateTime.UtcNow.AddDays(2).AddHours(5),
            TotalSeats = 150,
            AvailableSeats = 50,
            BasePrice = 199.99m
        });

        var repository = new InMemoryFlightRepository();
        var service = new FlightService(repository);

        // Act
        var results = await service.SearchFlightsAsync(new FlightSearchRequest("Miami", "Los Angeles", tomorrow));

        // Assert
        Assert.Single(results);
        Assert.Equal("DL220", results.First().FlightNumber);
    }
}
