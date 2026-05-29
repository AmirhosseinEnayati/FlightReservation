# Backend Instructions

## Technology Stack

Use:
* .NET 10
* ASP.NET Core Web API
* Controller-based API
* Clean Architecture
* In-memory data storage

Do not use:
* Minimal APIs
* CQRS
* MediatR
* Entity Framework
* Database providers
* External messaging libraries

Keep the implementation simple and maintainable.

---

## Folder Structure

/FlightReservation.Backend/src
* API
  * Controllers
* Application
  * Services
  * Contracts
  * Validators
* Domain
  * Entities
  * ValueObjects
* Infrastructure
  * Repositories

Create new files in their correct layer.

Do not place business logic in the API layer.

---

## Architecture

Follow Clean Architecture with these layers:

### API

Responsible for:
* Controllers
* Request handling
* Response formatting
* HTTP status codes

Controllers must remain thin.

Controllers must not contain:
* Business logic
* Validation rules
* Data access logic

---

### Application

Responsible for:
* Business workflows
* Application services
* Validation orchestration

Examples:
* FlightService
* BookingService

---

### Domain

Responsible for:
* Core entities
* Domain rules
* Business constraints

Domain must remain framework-independent.

---

### Infrastructure

Responsible for:
* Repository implementations
* In-memory runtime storage

---

## Data Storage Rules

There is currently NO database.

Do not generate:
* DbContext
* Entity Framework
* Migrations
* SQL scripts
* ORM configuration

Use static in-memory collections.

Examples:
* List<Flight>
* List<Booking>
* List<Passenger>

Repositories should use these collections.

Data persistence only needs to exist during application runtime.

---

## Controller Rules

Use ASP.NET Core controllers.

Decorate controllers with:
* [ApiController]
* [Route]

Controllers should:
* Receive requests
* Delegate work to services
* Return IActionResult

Keep controller actions concise.

---

## Service Rules

Use service-based application logic.

Examples:
* FlightService
* BookingService

Service methods should be task-oriented.

Examples:
* SearchFlightsAsync()
* GetFlightByIdAsync()
* CreateBookingAsync()
* GetBookingByIdAsync()

Services should depend on repository abstractions.

---

## Repository Rules

Use repository interfaces.

Examples:
* IFlightRepository
* IBookingRepository

Implement using:
* InMemoryFlightRepository
* InMemoryBookingRepository

Repositories are responsible only for data access.

No business logic inside repositories.

---

## Validation

Use dedicated validator classes.

Validate:
* Required fields
* Existing flight references
* Passenger count
* Departure time restrictions
* Seat availability

Validation must happen before business execution.

---

## Coding Standards

Use:
* File-scoped namespaces
* Async/await
* Dependency injection
* Records for request/response DTOs

Prefer:
* Explicit naming
* Small focused classes
* Clear separation of concerns

Avoid:
* Static helper classes
* Large service classes
* Deep inheritance
* Over-engineering

---

## Naming Conventions

Controllers:
* FlightsController
* BookingsController

Services:
* FlightService
* BookingService

Repositories:
* IFlightRepository
* IBookingRepository
* InMemoryFlightRepository
* InMemoryBookingRepository

DTOs:
* CreateBookingRequest
* FlightSearchRequest
* BookingResponse

Entities:
* Flight
* Booking
* Passenger

---

## API Routes

Use RESTful routes.

Examples:

GET /api/flights/search
GET /api/flights/{id}
POST /api/bookings
GET /api/bookings/{id}

---

## Flight Reservation Domain Rules

A booking must:
* Include at least one passenger
* Reference an existing flight

A flight:
* Cannot be booked after departure time

Seats:
* Must not be double-booked

Bookings:
* Must generate unique identifiers

---

## API Responses

Use standard HTTP responses:
* 200 OK
* 201 Created
* 400 BadRequest
* 404 NotFound
* 409 Conflict

Return meaningful error messages.

---

## Testing

Use xUnit.

Create tests for:
* Services
* Validation
* Repository behavior

---

## Copilot Behavior Instructions

When generating backend code:

Always:
* Create controllers
* Create services
* Create repository abstractions
* Use in-memory list storage
* Follow clean architecture

Never:
* Generate Minimal APIs
* Introduce CQRS
* Add MediatR
* Add database infrastructure
* Place business logic in controllers