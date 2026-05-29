# Flight Reservation Backend API

A clean, focused .NET 10 ASP.NET Core Web API for flight search and retrieval with in-memory storage.

## Overview

This backend provides two core operations:
- **Flight Search**: Find flights by departure city, arrival city, and/or date
- **Flight Detail**: Get detailed information about a specific flight

## Architecture

Built with Clean Architecture principles:

### 🏢 Domain Layer
- **Flight** entity with core flight information
- **Route** value object for departure/arrival cities
- Framework-independent domain logic

### 📱 Application Layer
- **FlightService**: Business logic for flight operations
- **DTOs**: Request/response contracts (FlightSearchRequest, FlightResponse)

### 🔧 Infrastructure Layer
- **DataStore**: Singleton in-memory storage
- **IFlightRepository**: Repository interface
- **InMemoryFlightRepository**: Repository implementation

### 🌐 API Layer
- **FlightsController**: REST endpoints for flight operations
- **Program.cs**: Dependency injection and middleware configuration

## API Endpoints

### Search Flights
```http
GET /api/flights/search?fromCity=NewYork&toCity=LosAngeles&departureDate=2025-01-15
```

**Query Parameters** (all optional):
- `fromCity`: Departure city name
- `toCity`: Arrival city name
- `departureDate`: Date in UTC format (YYYY-MM-DDTHH:mm:ssZ)

**Response**:
```json
[
  {
	"id": "550e8400-e29b-41d4-a716-446655440000",
	"flightNumber": "AA100",
	"airline": "American Airlines",
	"route": {
	  "departureCity": "New York",
	  "arrivalCity": "Los Angeles"
	},
	"departureTime": "2025-01-15T10:00:00Z",
	"arrivalTime": "2025-01-15T15:00:00Z",
	"totalSeats": 180,
	"availableSeats": 45,
	"basePrice": 299.99
  }
]
```

### Get Flight Details
```http
GET /api/flights/{id}
```

**Path Parameters**:
- `id`: Flight ID (GUID)

**Response**:
```json
{
  "id": "550e8400-e29b-41d4-a716-446655440000",
  "flightNumber": "AA100",
  "airline": "American Airlines",
  "route": {
	"departureCity": "New York",
	"arrivalCity": "Los Angeles"
  },
  "departureTime": "2025-01-15T10:00:00Z",
  "arrivalTime": "2025-01-15T15:00:00Z",
  "totalSeats": 180,
  "availableSeats": 45,
  "basePrice": 299.99
}
```

**Error Response** (404):
```json
{
  "message": "Flight not found."
}
```

## Getting Started

### Prerequisites
- .NET 10 SDK
- Visual Studio 2026 or compatible IDE

### Build
```powershell
dotnet build
```

### Run
```powershell
dotnet run --project FlightReservation.Backend/src/API/FlightReservation.API.csproj
```

The API will be available at `https://localhost:5001` with Swagger UI at `/swagger`

### Run Tests
```powershell
dotnet test FlightReservation.Backend/Tests/FlightReservation.Tests.csproj
```

## Sample Data

The application includes 5 pre-seeded flights:

| Flight | Airline | Route | Seats | Available | Price |
|--------|---------|-------|-------|-----------|-------|
| AA100 | American Airlines | NYC → LAX | 180 | 45 | $299.99 |
| UA500 | United Airlines | NYC → London | 250 | 28 | $599.99 |
| DL220 | Delta Airlines | Miami → LAX | 200 | 120 | $349.99 |
| SW150 | Southwest Airlines | Chicago → Denver | 150 | 0 | $199.99 |
| JB300 | JetBlue Airways | Boston → SFO | 160 | 85 | $449.99 |

## Key Features

✅ Simple, focused on core flight search and detail operations
✅ In-memory storage (no database required)
✅ Clean Architecture separation of concerns
✅ Full async/await implementation
✅ Comprehensive error handling
✅ Swagger documentation
✅ Unit and integration tests
✅ All timestamps in UTC

## Project Structure

```
FlightReservation.Backend/
├── src/
│   ├── API/
│   │   ├── Controllers/
│   │   │   └── FlightsController.cs
│   │   ├── Program.cs
│   │   └── appsettings.json
│   ├── Application/
│   │   ├── Services/
│   │   │   └── FlightService.cs
│   │   └── Contracts/
│   │       ├── Requests/
│   │       │   └── FlightSearchRequest.cs
│   │       └── Responses/
│   │           └── FlightResponse.cs
│   ├── Domain/
│   │   ├── Entities/
│   │   │   └── Flight.cs
│   │   └── ValueObjects/
│   │       └── Route.cs
│   └── Infrastructure/
│       ├── Persistence/
│       │   └── DataStore.cs
│       └── Repositories/
│           ├── IFlightRepository.cs
│           └── InMemoryFlightRepository.cs
└── Tests/
	└── FlightServiceTests.cs
```

## HTTP Status Codes

- `200 OK`: Successful flight search or retrieval
- `404 Not Found`: Flight not found by ID
- `500 Internal Server Error`: Server error

## Future Considerations

- Add database persistence layer
- Add caching for frequently searched routes
- Add flight filtering by airline or price range
- Add pagination for search results
- Add flight availability updates
- Add authentication and authorization
