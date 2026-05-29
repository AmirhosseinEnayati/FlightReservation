using FlightReservation.Application.Services;
using FlightReservation.Infrastructure.Repositories;
using FlightReservation.Infrastructure.Persistence;
using FlightReservation.Domain.Entities;
using FlightReservation.Domain.ValueObjects;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddSingleton<IFlightRepository, InMemoryFlightRepository>();
builder.Services.AddScoped<FlightService>();

var app = builder.Build();

// Seed sample flights
var dataStore = DataStore.Instance;
if (!dataStore.Flights.Any())
{
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

    dataStore.Flights.Add(new Flight
    {
        FlightNumber = "UA500",
        Airline = "United Airlines",
        Route = new FlightRoute("New York", "London"),
        DepartureTime = DateTime.UtcNow.AddDays(3),
        ArrivalTime = DateTime.UtcNow.AddDays(4).AddHours(2),
        TotalSeats = 250,
        AvailableSeats = 28,
        BasePrice = 599.99m
    });

    dataStore.Flights.Add(new Flight
    {
        FlightNumber = "DL220",
        Airline = "Delta Airlines",
        Route = new FlightRoute("Miami", "Los Angeles"),
        DepartureTime = DateTime.UtcNow.AddDays(1),
        ArrivalTime = DateTime.UtcNow.AddDays(1).AddHours(5),
        TotalSeats = 200,
        AvailableSeats = 120,
        BasePrice = 349.99m
    });

    dataStore.Flights.Add(new Flight
    {
        FlightNumber = "SW150",
        Airline = "Southwest Airlines",
        Route = new FlightRoute("Chicago", "Denver"),
        DepartureTime = DateTime.UtcNow.AddDays(2),
        ArrivalTime = DateTime.UtcNow.AddDays(2).AddHours(2),
        TotalSeats = 150,
        AvailableSeats = 0,
        BasePrice = 199.99m
    });

    dataStore.Flights.Add(new Flight
    {
        FlightNumber = "JB300",
        Airline = "JetBlue Airways",
        Route = new FlightRoute("Boston", "San Francisco"),
        DepartureTime = DateTime.UtcNow.AddDays(4),
        ArrivalTime = DateTime.UtcNow.AddDays(4).AddHours(5),
        TotalSeats = 160,
        AvailableSeats = 85,
        BasePrice = 449.99m
    });
}

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
