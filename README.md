# Kris - Science Competition Registration System

A comprehensive multi-step science competition registration application built with .NET 8 and Blazor Server. This system enables students to register for various science competitions through an intuitive web interface with robust data management and export capabilities.

## 🚀 Features

- **Multi-Step Registration Form**: Guided registration process with year/class/student selection
- **Student Management**: Complete student database with year and class organization
- **Competition Management**: Support for multiple science competitions and associations
- **Excel Export**: Export registration data to Excel files for reporting
- **Real-time Data**: Blazor Server for responsive user interface
- **Comprehensive Testing**: Full unit test coverage with detailed reports

## 🛠️ Technology Stack

- **Framework**: .NET 8
- **UI**: Blazor Server
- **Database**: SQLite with Entity Framework Core
- **Testing**: xUnit with code coverage
- **Export**: EPPlus for Excel generation
- **Logging**: Serilog

## 📊 Project Structure

```
src/
├── Apps/                          # Main application
│   ├── Data/                      # Database context and configuration
│   ├── Models/                    # Entity models and DTOs
│   ├── Services/                  # Business logic services
│   ├── Pages/                     # Blazor pages and components
│   ├── Migrations/                # Entity Framework migrations
│   └── wwwroot/                   # Static web assets
└── Tests/                         # Unit tests
    ├── RegistrationServiceTests.cs
    ├── EntitiesTests.cs
    └── RegistrationModelTests.cs
```

## 🏃‍♂️ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/huzaifah/kris.git
   cd kris
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Update the database**
   ```bash
   cd src/Apps
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run --project src/Apps/Kris.csproj
   ```

5. **Open your browser** and navigate to `http://localhost:5000`

## 🧪 Testing

### Running Unit Tests

```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Generate coverage report
reportgenerator -reports:"TestResults/*/coverage.cobertura.xml" -targetdir:"TestResults/CoverageReport" -reporttypes:Html
```

### Test Coverage

- **Total Tests**: 29 passing tests
- **Core Components**: 100% coverage of models, entities, and service layer
- **Line Coverage**: 4.8% overall (focused on business logic)
- **Method Coverage**: 54.2%

View detailed coverage reports at `TestResults/CoverageReport/index.html`

## 📋 Usage

### Registration Process

1. **Select Year of Study**: Choose the appropriate academic year
2. **Select Class**: Pick from available classes for the selected year
3. **Select Student**: Choose the student to register
4. **Choose Association**: Select the organizing association
5. **Select Competition**: Pick the competition to register for
6. **Submit**: Complete the registration

### Data Management

- **Students Page**: View all registered students organized by year and class
- **Export Data**: Generate Excel reports of registrations
- **Registration Overview**: View all registrations grouped by year and class

## 🗃️ Database Schema

### Core Entities

- **YearOfStudy**: Academic years (e.g., Form 6)
- **Class**: Classes within each year (e.g., 6 Bestari)
- **Student**: Individual student records
- **Association**: Organizing associations (e.g., Science Association)
- **Competition**: Available competitions
- **Registration**: Links students to competitions

### Entity Relationships

```
YearOfStudy (1) ──── (N) Class (1) ──── (N) Student
                                              │
                                              │ (N)
                                              │
                                         Registration
                                              │
                                              │ (N)
Association (1) ──── (N) Registration (N) ──── (1) Competition
```

## 🔧 Configuration

### Database Configuration

The application uses SQLite by default. The connection string is configured in `Program.cs`:

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=kris.db"));
```

### Logging Configuration

Serilog is configured for comprehensive logging:

```csharp
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));
```

## 📈 Performance & Monitoring

- **Async/Await**: All database operations use async patterns
- **Entity Framework**: Optimized queries with Include statements
- **In-Memory Testing**: Fast unit tests with EF InMemory provider
- **Logging**: Comprehensive logging for debugging and monitoring

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Development Guidelines

- Follow the existing code style (see `.github/CODE_STYLE.md`)
- Add unit tests for new features
- Update documentation as needed
- Ensure all tests pass before submitting PR

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Built with [Blazor Server](https://docs.microsoft.com/en-us/aspnet/core/blazor/)
- Database powered by [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- Excel export via [EPPlus](https://github.com/JanKallman/EPPlus)
- Testing with [xUnit](https://xunit.net/)

## 📞 Support

If you encounter any issues or have questions, please [open an issue](https://github.com/[your-username]/kris/issues) on GitHub.

---

**Built with ❤️ for Science Education**
