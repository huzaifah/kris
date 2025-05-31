# .NET 8 Blazor Server Coding Standards & Best Practices

## 1. Project Structure
- Organize by feature, not by type (e.g., group related components, services, and models).
- Use folders like `/Components`, `/Pages`, `/Services`, `/Models`, `/wwwroot`.
- For each new class, the default namespace shall start with `Kris.` (e.g., `namespace Kris.FeatureName`).

### Directory Structure
```
Kris/
├── Kris.sln
├── src/
│   ├── Apps/
│   │   ├── Kris.csproj (Main Blazor Server Application)
│   │   ├── Program.cs
│   │   ├── Data/
│   │   ├── Models/
│   │   ├── Pages/
│   │   ├── Services/
│   │   ├── Shared/
│   │   ├── wwwroot/
│   │   └── Migrations/
│   └── Tests/
│       ├── Kris.Tests.csproj (Unit Test Project)
│       ├── EntitiesTests.cs
│       ├── RegistrationModelTests.cs
│       └── RegistrationServiceTests.cs
└── TestResults/
```

## 2. Naming Conventions
- Use PascalCase for classes, components, and public members.
- Use camelCase for private fields and local variables.
- Suffix Blazor components with `.razor`.
- Use `I` prefix for interfaces (e.g., `IUserService`).

## 3. Components
- Keep components small and focused.
- Use `@code` blocks for logic, avoid code-behind unless complexity requires.
- Use parameters for parent-child communication.
- Prefer `EventCallback` for event handling.

## 4. Dependency Injection
- Register services in `Program.cs` using appropriate lifetimes (`Scoped` for most services).
- Inject services via constructor or `[Inject]` attribute.

## 5. Async & Data Access
- Use `async`/`await` for all I/O operations.
- Never block on async code (`.Result`, `.Wait()`).
- Use `CancellationToken` where appropriate.

## 6. UI & Styling
- Use CSS isolation (`Component.razor.css`) for component styles.
- Prefer Bootstrap or a consistent UI framework.
- Avoid inline styles.

## 7. Error Handling
- Use try-catch for external calls (API, DB).
- Show user-friendly error messages.
- Log errors using a logging framework.

## 8. Security
- Use built-in authentication/authorization.
- Never trust client input; always validate on server.
- Protect sensitive data and secrets.

## 9. Testing
- Write unit tests for services and logic.
- Use bUnit for component testing.
- Keep tests in a separate `src/Tests/` project following the solution structure above.
- Use xUnit for unit testing framework.
- Include code coverage reporting with coverlet.

## 10. General Best Practices
- Use nullable reference types (`#nullable enable`).
- Use `var` for local variables when type is obvious.
- Keep methods short and single-purpose.
- Document public APIs with XML comments.
- Use Git for version control and meaningful commit messages.
