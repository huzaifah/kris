# Technical Specification

## 1. Overview
This application is a comprehensive science competition registration system with a multi-step registration process, student listing functionality, and Excel export capabilities. The app provides a guided registration experience with modern UI/UX in Malay language without requiring user authentication.

## 2. Architecture
- Built on .NET 8 Blazor Server architecture.
- Layered structure: UI (Blazor Components & Pages), Services (Business Logic), Data Access (Entity Framework), Models (Entities & DTOs).
- Organized by feature for scalability and maintainability.
- Default namespace for all classes starts with `Kris.`
- SQLite database for development with Entity Framework Core migrations.

## 3. Technology Stack
- .NET 8
- Blazor Server
- Entity Framework Core (SQLite for development)
- Bootstrap 5.3.0 (for responsive UI styling)
- Bootstrap Icons
- EPPlus (for Excel export functionality)
- xUnit & bUnit (for testing)
- Custom CSS theming with vibrant colors

## 4. Database Schema
### Entities:
- **YearOfStudy**: Form 1-4 with seeded data
- **Class**: Class names (Red, Blue, Yellow) linked to years with 48 pre-seeded students
- **Student**: Student records with names, linked to Year and Class
- **Association**: 5 predefined associations (Science Club, Innovation Society, etc.)
- **Competition**: Competition types (Rocket Game, Oven Heater)
- **Registration**: Main entity linking Student, Association, and Competition with timestamp

## 5. Implemented Features

### 5.1 Multi-Step Registration Process
- **Step 1**: Select Year of Study (Tingkatan) - Form 1 to Form 4
- **Step 2**: Select Class (Kelas) - filtered by selected year (Red/Blue/Yellow)
- **Step 3**: Select Student (Pelajar) and Association (Persatuan) - dropdowns populated from database
- **Step 4**: Select Competition (Pertandingan) - choose between available competitions
- **Enhanced Progress Bar**: Animated 3rem height progress indicator with step counter
- **Validation**: Server-side validation with Malay error messages at each step
- **Success Page**: Dedicated confirmation page with action buttons

### 5.2 User Interface & Experience
- **Modern Design**: Card-based layout with rounded corners and shadows
- **Vibrant Color Scheme**: Green primary (#4CAF50), with complementary colors
- **Responsive Layout**: Bootstrap 5.3.0 grid system for mobile compatibility
- **Malay Language**: Complete UI translation to Bahasa Malaysia
- **Visual Feedback**: Smooth animations, hover effects, and loading states
- **Navigation**: Clean navbar with science trophy icon and translated menu items

### 5.3 Data Management & Export
- **Registration Listing**: Grouped display by Year and Class with tabular format
- **Excel Export**: Two-tier export system using EPPlus:
  - Individual registration export from success page
  - Bulk export of all registrations from listing page
- **Professional Excel Formatting**: 
  - Themed headers with green background
  - Alternating row colors
  - Auto-fitted columns with borders
  - Malay column headers

### 5.4 Technical Implementation
- **Services Layer**: 
  - `RegistrationService`: Business logic and data access
  - `ExcelExportService`: Excel generation with professional formatting
- **Dependency Injection**: Proper service registration in Program.cs
- **JavaScript Integration**: File download functionality for Excel exports
- **Error Handling**: Comprehensive validation with user-friendly Malay messages
- **Database Migrations**: Complete migration history with seeded data

### 5.5 Navigation & User Flow
1. **Home/Registration** (Utama/Daftar): Multi-step registration form
2. **Success Page** (Kejayaan): Confirmation with export options
3. **View Registrations** (Lihat Pendaftaran): Complete listing with bulk export
4. **Seamless Flow**: Navigation between pages with proper state management

## 6. File Structure & Organization
```
Kris/
├── Data/
│   └── AppDbContext.cs                 # Entity Framework context
├── Models/
│   ├── Entities.cs                     # Database entities
│   └── RegistrationModel.cs            # Form model for registration
├── Services/
│   ├── RegistrationService.cs          # Business logic & data access
│   └── ExcelExportService.cs           # Excel export functionality
├── Pages/
│   ├── Register.razor                  # Multi-step registration form
│   ├── RegistrationSuccess.razor       # Success confirmation page
│   ├── Students.razor                  # Registration listing & export
│   └── _Host.cshtml                    # Main HTML host
├── Shared/
│   ├── MainLayout.razor                # Application layout
│   └── NavMenu.razor                   # Navigation component
├── wwwroot/css/
│   └── custom.css                      # Custom theming & animations
├── Migrations/                         # EF Core migration files
└── Tests/
    └── RegistrationServiceTests.cs     # Unit tests
```

## 7. Coding Standards & Best Practices
- **Blazor Component Structure**: Clear separation of markup, styling, and code-behind
- **Service Layer Pattern**: Business logic encapsulated in dedicated service classes
- **Dependency Injection**: Proper registration and injection of services
- **Error Handling**: Comprehensive validation with user-friendly messages
- **Responsive Design**: Mobile-first approach with Bootstrap grid system
- **Accessibility**: Proper form labels, ARIA attributes, and semantic HTML
- **Localization**: Complete Malay translation for Malaysian user base
- **Code Organization**: Feature-based folder structure for maintainability

## 8. Security & Validation
- **Server-Side Validation**: All user input validated on the server
- **SQL Injection Prevention**: Entity Framework parameterized queries
- **XSS Protection**: Blazor's built-in output encoding
- **Input Sanitization**: Proper validation of dropdown selections and form data
- **No Authentication Required**: Public registration system as per requirements

## 9. Performance Considerations
- **Database Optimization**: Efficient queries with proper relationships
- **Client-Side Caching**: Bootstrap and icons served from CDN
- **Lazy Loading**: Components loaded as needed
- **Optimized Exports**: Efficient Excel generation with memory management
- **Responsive Images**: Appropriate icon sizing and compression

## 10. Deployment & Configuration
- **Development**: SQLite database for easy local development
- **Production Ready**: Can be configured for SQL Server or other databases
- **Self-Contained Deployment**: All dependencies included
- **Azure App Service Compatible**: Ready for cloud deployment
- **Environment Configuration**: Proper separation of development and production settings

## 11. Testing Strategy
- **Unit Tests**: Service layer testing with xUnit
- **Component Tests**: Blazor component testing with bUnit
- **Integration Tests**: End-to-end registration flow testing
- **Manual Testing**: UI/UX validation and browser compatibility

## 12. Future Enhancements (Potential)
- **Admin Dashboard**: Management interface for competitions and students
- **Email Notifications**: Automatic confirmation emails
- **Reports & Analytics**: Registration statistics and insights
- **Multi-Language Support**: Additional language options
- **API Integration**: RESTful API for external integrations
- **Advanced Filtering**: Search and filter capabilities in listings

## 13. Dependencies & Packages
- **EPPlus**: Excel file generation and formatting
- **Entity Framework Core**: Database ORM and migrations
- **Bootstrap**: UI framework and responsive components
- **Bootstrap Icons**: Icon library for visual elements
- **Microsoft.AspNetCore.Components**: Blazor Server framework
- **bUnit & xUnit**: Testing frameworks for comprehensive coverage
