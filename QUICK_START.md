# Quick Start Guide - Flight Reservation Backend

## 🚀 Getting Started

### Prerequisites
- .NET 10.0 SDK installed
- Visual Studio 2026 or VS Code with C# extension
- Git (optional)

### Run the Application

1. **Navigate to the project directory**
   ```bash
   cd FlightReservation.Backend
   ```

2. **Build the project**
   ```bash
   dotnet build
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Access the API**
   - Swagger UI: https://localhost:5001/swagger/index.html
   - API Base URL: https://localhost:5001/api

### Run Tests

```bash
dotnet test
```

Expected output: **5 passed** tests

---

## 📡 API Endpoints

### Search Flights
```
GET /api/flights/search
```

**Query Parameters:**
- `fromCity` (optional): Departure city name
- `toCity` (optional): Arrival city name  
- `departureDate` (optional): Date in format `YYYY-MM-DD`

**Examples:**
```bash
# Get all flights
curl "https://localhost:5001/api/flights/search"

# Search by route
curl "https://localhost:5001/api/flights/search?fromCity=New%20York&toCity=Los%20Angeles"

# Search by date
curl "https://localhost:5001/api/flights/search?departureDate=2024-01-15"

# Combined search
curl "https://localhost:5001/api/flights/search?fromCity=New%20York&toCity=London&departureDate=2024-01-15"
```

**Response (200 OK):**
```json
[
  {
	"id": "123e4567-e89b-12d3-a456-426614174000",
	"flightNumber": "AA100",
	"airline": "American Airlines",
	"route": {
	  "departureCity": "New York",
	  "arrivalCity": "Los Angeles"
	},
	"departureTime": "2024-01-15T08:00:00Z",
	"arrivalTime": "2024-01-15T13:00:00Z",
	"totalSeats": 180,
	"availableSeats": 45,
	"basePrice": 299.99
  }
]
```

---

### Get Flight Details
```
GET /api/flights/{id}
```

**Path Parameter:**
- `id` (required): Flight GUID

**Example:**
```bash
curl "https://localhost:5001/api/flights/123e4567-e89b-12d3-a456-426614174000"
```

**Response (200 OK):**
```json
{
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "flightNumber": "AA100",
  "airline": "American Airlines",
  "route": {
	"departureCity": "New York",
	"arrivalCity": "Los Angeles"
  },
  "departureTime": "2024-01-15T08:00:00Z",
  "arrivalTime": "2024-01-15T13:00:00Z",
  "totalSeats": 180,
  "availableSeats": 45,
  "basePrice": 299.99
}
```

**Response (404 Not Found):**
```json
{
  "message": "Flight not found."
}
```

---

## 🗂️ Project Structure

```
FlightReservation.Backend/
├── src/
│   ├── API/                    # HTTP layer
│   │   ├── Controllers/
│   │   ├── Program.cs
│   │   └── appsettings.json
│   ├── Application/            # Business logic
│   │   ├── Services/
│   │   └── Contracts/
│   ├── Domain/                 # Core entities
│   │   ├── Entities/
│   │   └── ValueObjects/
│   └── Infrastructure/         # Data access
│       ├── Repositories/
│       └── Persistence/
├── Tests/                      # Unit tests
└── README.md
```

---

## 🧪 Testing

The project includes 5 comprehensive unit tests:

1. **Search with matching criteria** ✓
2. **Search with no matches** ✓
3. **Search filtered by date** ✓
4. **Get flight by valid ID** ✓
5. **Get flight by invalid ID** ✓

Run all tests:
```bash
dotnet test
```

---

## 📊 Sample Data

5 flights pre-loaded at startup:

| Flight | Route | Available | Price |
|--------|-------|-----------|-------|
| AA100 | NYC → LAX | 45/180 | $299.99 |
| UA500 | NYC → LDN | 28/250 | $599.99 |
| DL220 | MIA → LAX | 120/200 | $349.99 |
| SW150 | CHI → DEN | 0/150 | $199.99 |
| JB300 | BOS → SFO | 85/160 | $449.99 |

---

## 🔧 Development

### Architecture
- **Clean Architecture** with separated layers
- **Dependency Injection** for testability
- **Repository Pattern** for data access abstraction
- **Unit tests** with xUnit framework
- **Swagger/OpenAPI** documentation

### Key Technologies
- **.NET 10.0** - Latest framework
- **ASP.NET Core** - Web framework
- **xUnit** - Testing framework
- **Swashbuckle** - Swagger/OpenAPI

---

## 📝 Build Status

✅ **Build**: Successful (0 errors)  
✅ **Tests**: 5/5 passing  
✅ **Warnings**: 3 (harmless version resolution)  

---

## 🤝 Next Steps

1. **Explore the API** - Use Swagger UI to test endpoints
2. **Review the code** - Check the architecture and implementation
3. **Run tests** - Verify everything works correctly
4. **Read documentation** - See IMPLEMENTATION_SUMMARY.md for detailed info

---

## ⚡ Troubleshooting

### Port already in use
If port 5001 is already in use, the API will automatically use a different port. Check the console output for the actual URL.

### SSL Certificate warnings
For local development, you can disable HTTPS verification or accept the self-signed certificate.

### Restore issues
```bash
dotnet clean
dotnet restore
dotnet build
```

---

## 📚 Additional Resources

- [IMPLEMENTATION_SUMMARY.md](IMPLEMENTATION_SUMMARY.md) - Complete implementation details
- [README.md](FlightReservation.Backend/README.md) - Full project documentation
- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)

---

**Ready to fly! 🛫**
