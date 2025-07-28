# Inventory Management System

## Overview

This is a simple inventory management web application built with ASP.NET Core, SQLite, and Razor Pages. It features:

- Full CRUD operations on inventory items via REST API and Razor UI
- Basic HTTP authentication (static admin:password)
- Integration with OpenAI GPT-3.5 Turbo for employee chat queries about inventory
- Tailwind CSS styled UI with JavaScript-based interaction
- Search and filter functionality for items
- API documented and testable via Swagger

---

## Getting Started

### Prerequisites

- .NET 7 SDK or later installed
- SQLite (database file created automatically)
- OpenAI API key (sent via email)
- [DotEnv.Net](https://github.com/tonerdo/dotnet-env) package installed for `.env` support (optional)

### Setup

1. Clone or download the repository.
2. Create a `.env` file in the root directory with the following content:

   ```env
   OPEN_AI_KEY=your_openai_api_key_here
   dotnet build
dotnet run
 The app will run on https://localhost:{port}.

Authentication
The app uses basic HTTP authentication for API requests.

Username: admin

Password: password

For API testing (e.g. Swagger), you must send the header:

makefile
Copy
Edit
Authorization: Basic YWRtaW46cGFzc3dvcmQ=
(YWRtaW46cGFzc3dvcmQ= is Base64 for admin:password)

API Documentation
Swagger UI is available in development mode at:

bash
Copy
Edit
https://localhost:{port}/swagger
You can test all endpoints including:

Item CRUD

Search items

Chat with OpenAI about inventory (POST /api/item/ask)

UI Features
Inventory Listing: Search by name or category with buttons to view, edit, or delete items.

Create/Edit Pages: Forms for creating or updating items.

Chat Box: Simple chat interface where employees can ask inventory questions powered by OpenAI.

Known Issues / Testing Notes
Some UI features might have intermittent issues due to client-side JavaScript or CORS settings.

You can always fallback to test the API endpoints directly via Swagger.

AI chat is fully functional in the UI and via API.

Basic HTTP authentication is required for all API calls; ensure to include the correct header in any tool you use.

Project Structure
Pages/ — Razor pages for UI (Index, Create, Edit, View)

Controllers/ — API endpoints

Services/ — OpenAI integration and business logic

Repository/ — Data access layer

Data/ — EF Core DbContext and models

Usage
Browse to the homepage to see and manage inventory items.

Use the search inputs to filter items.

Click "Add New" to create items.

Use "View" and "Edit" buttons for item details and updates.

Use the chat box at the bottom of the homepage to ask questions about the current inventory.

If any UI action fails, use Swagger to manually test API endpoints.
