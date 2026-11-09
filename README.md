# CollaboRate

CollaboRate is a Windows desktop collaboration application for small project teams. It brings project groups, membership management, peer evaluations, tasks, meetings, group chat, and notifications together in one client, backed by an ASP.NET Core Web API and SQL Server database.

## Features

- **Accounts and sessions:** register and sign in, retain a refresh-token session locally, and restore the last selected group.
- **Project groups:** create and edit groups, invite or add members, handle join requests, manage Admin and Member roles, and browse available groups.
- **Peer evaluations:** submit ratings for group members and view current and average scores.
- **Task coordination:** create tasks, assign members, set deadlines, search/filter task lists, update completion status, and delete tasks.
- **Meeting scheduling:** create, update, browse, and cancel group meetings.
- **Group communication:** view and search paginated message history and send group messages.
- **Notifications:** view and mark group notifications as read, configure push/email preferences, and receive live updates and Windows toast notifications.
- **Live updates:** SignalR hubs notify connected clients about chat, notification, group, task, meeting, and evaluation changes.

## Repository layout

```text
Application/CollaboRate/
  CollaboRate.sln                 Windows desktop solution
  CollaboRate/                    C# WinForms client, forms, DTOs, services, and resources
  MigrationBackup/                Database migration backup files
  packages/                       Restored/vendor NuGet package files
Server/CollaboRateAPIServer/
  CollaboRateAPIServer.sln        ASP.NET Core API solution
  CollaboRateAPIServer/
    Controllers/                  REST API endpoints
    Data/                         Entity Framework Core DbContext
    Dtos/                         API request/response types
    Hubs/                         SignalR real-time endpoints
    Interceptors/                 Notification broadcasts after database saves
    Models/                       Database entities
    Program.cs                    API startup and service/hub registration
Documentation/
  CollaboRate SQL Queries.sql     SQL Server schema and indexes
  Potential database schema.txt  Earlier schema proposal
  *.docx, *.pdf                   Design, system, and use-case documentation
```

The desktop client is a .NET Framework 4.7.2 Windows Forms application. It calls the ASP.NET Core API over HTTP and uses SignalR for live events. The API uses Entity Framework Core with SQL Server; its `AppDbContext` maps users, groups and memberships, ratings, meetings, tasks and assignments, messages, notifications, and user settings. `NotificationInterceptor` broadcasts notification-recipient records over the notification hub after changes are saved.

## Technology stack

- **Client:** C# / Windows Forms, .NET Framework 4.7.2
- **Server:** C# / ASP.NET Core Web API, .NET 8
- **Data:** SQL Server and Entity Framework Core 9
- **Real-time:** ASP.NET Core SignalR
- **API exploration:** Swagger / Swashbuckle (enabled in Development)
- **Client libraries:** SignalR client, System.Text.Json, Windows toast notifications, SATA UI Framework

## Prerequisites

- Windows for the desktop application.
- Visual Studio with the **.NET desktop development** workload and .NET Framework 4.7.2 targeting support.
- .NET 8 SDK for the API.
- A SQL Server database and permission to create/use its schema.

## Database setup

1. Create a SQL Server database.
2. Review and run [`Documentation/CollaboRate SQL Queries.sql`](Documentation/CollaboRate%20SQL%20Queries.sql) against it to create the tables, constraints, indexes, and full-text search objects used by the application.
3. Set the API connection string using a local secret or environment variable. Do not commit credentials. For example, in PowerShell:

   ```powershell
   $env:ConnectionStrings__DefaultConnection = "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;Encrypt=True"
   ```

   The API reads the `ConnectionStrings:DefaultConnection` configuration value. Prefer a secret manager or deployment secret store over putting credentials in source-controlled configuration.

## Build and run

### Start the API

From the repository root, set the connection string as shown above, then run:

```powershell
dotnet restore .\Server\CollaboRateAPIServer\CollaboRateAPIServer.sln
dotnet run --project .\Server\CollaboRateAPIServer\CollaboRateAPIServer\CollaboRateAPIServer.csproj
```

Swagger is registered for the Development environment. The API maps REST controllers and SignalR hubs at `/chathub`, `/notificationHub`, `/hubs/groups`, `/hubs/evaluations`, `/hubs/tasks`, and `/hubs/meetings`.

### Build and run the desktop client

Open `Application/CollaboRate/CollaboRate.sln` in Visual Studio, restore NuGet packages, select **Debug** or **Release**, and build/run the `CollaboRate` project. The client currently uses the hosted API URL `https://collaborateapi.runasp.net` in its source (`Program.cs` and the forms). To use a locally running API, update the client API base URL configuration in those files to match the local API address before launching the client.

## API areas

The API is organized around these controller families:

- `AuthController` — login and refresh-token operations.
- `UsersController` — user registration, lookup, updates, and account deletion.
- `GroupsController` — groups, group members, roles, and membership requests.
- `RatingsController` — member rating summaries and batch rating updates.
- `TasksController` — task creation, assignment, filtering, completion, and deletion.
- `MeetingsController` — meeting scheduling and changes.
- `GroupMessagesController` — message history and sending.
- `NotificationsController` and `UserSettingsController` — notification retrieval/read state and notification preferences.

Controllers use the `api/[controller]` route convention. See the controller source and `CollaboRateAPIServer.http` for request details and sample calls.

## Documentation and tests

The `Documentation` directory includes SQL scripts, a proposed schema, a data model, system documentation, and use-case documentation. No dedicated automated test project is present in the repository at this time.

