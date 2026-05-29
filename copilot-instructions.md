## Project Overview
This is a flight reservation system.
The system supports:
- Flight search
- Flight detail
## Domain terminology
Use:
- Booking
- Passenger
- FlightSegment
- Reservation
## General Rules
- Keep frontend and backend contracts synchronized
- All timestamps are UTC
- Use consistent naming across layers
## Folder Structure
/FlightReservation.Backend
  /src
    /API
    /Application
    /Domain
    /Infrastructure
    /Tests
/FlightReservation.Frontend
  /src
    /app
    /components
    /features
    /services
    /types
## Coding standards
General:
- Write clean, readable, maintainable code
- Prefer explicit naming over abbreviations
- Keep functions focused and small
- Avoid duplication
Naming:
- Use PascalCase for classes
- Use camelCase for variables
- Use descriptive method names
- Use domain-specific terminology
Comments:
- Prefer self-documenting code
- Add comments only when intent is non-obvious
## Project Scope
Current implementation phase is backend-only.
Focus exclusively on:
- Backend API
Do not generate or modify:
- Frontend pages
- UI components

The frontend will be implemented in a later phase.
If a request affects both frontend and backend, implement backend only unless explicitly instructed otherwise.