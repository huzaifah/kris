# Kris Science Competition Registration System - Sequence Diagrams

This directory contains sequence diagrams documenting the registration flow of the Kris Science Competition Registration System.

## Diagrams Available

### 1. High-Level Registration Flow (`sequence-diagram-registration-high-level.puml`)
- **Purpose**: Overview of the complete registration process
- **Audience**: Project stakeholders, business analysts, documentation
- **Key Elements**:
  - 4-step registration process overview
  - Main actors and components
  - Error handling patterns
  - Key business rules (duplicate prevention)

### 2. Detailed Registration Flow (`sequence-diagram-registration-flow.puml`)
- **Purpose**: Technical implementation details of the registration process
- **Audience**: Developers, system architects, technical reviewers
- **Key Elements**:
  - Step-by-step UI interactions
  - Database queries and operations
  - Validation logic at each step
  - Entity relationships and data flow
  - Navigation and error handling
  - Specific method calls and parameters

## Registration Process Overview

The Kris system implements a 4-step registration process:

1. **Step 1: Year of Study Selection** (`Tingkatan`)
   - User selects from Form 1-4
   - Loads available classes for next step

2. **Step 2: Class Selection** (`Kelas`)
   - User selects class (Red/Blue/Yellow) filtered by year
   - Loads students and associations for next step

3. **Step 3: Student & Association Selection** (`Pelajar & Persatuan`)
   - User selects specific student from the class
   - User selects association/club membership
   - Loads available competitions for final step

4. **Step 4: Competition Selection & Submission** (`Pertandingan`)
   - User selects science competition
   - System validates and submits registration
   - Prevents duplicate registrations
   - Redirects to success page with details

## Key Technical Features

- **Progressive Data Loading**: Each step loads only relevant data based on previous selections
- **Client-Side Validation**: Immediate feedback for required field validation
- **Server-Side Validation**: Comprehensive validation before database operations
- **Duplicate Prevention**: Database-level uniqueness constraint on StudentId
- **Entity Relationships**: Proper navigation properties for data integrity
- **Error Handling**: Malay language error messages for user-friendly experience
- **State Management**: Maintains form state during navigation

## Viewing the Diagrams

These PlantUML diagrams can be viewed using:

1. **VS Code with PlantUML Extension**:
   - Install the PlantUML extension
   - Open the `.puml` files
   - Use `Alt+D` to preview

2. **Online PlantUML Editor**:
   - Copy the content to [PlantUML Online](http://www.plantuml.com/plantuml/uml/)
   - Generate SVG/PNG exports

3. **PlantUML CLI**:
   ```bash
   # Install PlantUML
   brew install plantuml  # macOS
   
   # Generate diagrams
   plantuml sequence-diagram-registration-flow.puml
   plantuml sequence-diagram-registration-high-level.puml
   ```

## Database Schema Context

The registration process interacts with these main entities:
- `YearOfStudy` → `Class` → `Student` (hierarchical relationship)
- `Association` (independent selection)
- `Competition` (independent selection)
- `Registration` (final entity linking all selections)

## Error Scenarios Covered

1. **Validation Errors**: Missing selections at each step
2. **Duplicate Registration**: Student already registered prevention
3. **Data Not Found**: Invalid entity references
4. **Network Errors**: Database connection issues (handled by framework)

## Related Files

- **Main Registration Component**: `src/Apps/Pages/Register.razor`
- **Registration Service**: `src/Apps/Services/RegistrationService.cs`
- **Data Model**: `src/Apps/Models/RegistrationModel.cs`
- **Database Context**: `src/Apps/Data/AppDbContext.cs`
- **Entity Models**: `src/Apps/Models/Entities.cs`
- **Success Page**: `src/Apps/Pages/RegistrationSuccess.razor`
- **Test Coverage**: `src/Tests/RegistrationModelTests.cs`
