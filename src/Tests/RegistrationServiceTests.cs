using Microsoft.EntityFrameworkCore;
using Kris.Data;
using Kris.Models;
using Kris.Services;

namespace Kris.Tests;

public class RegistrationServiceTests
{
    private AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var context = new AppDbContext(options);

        // Seed test data
        SeedTestData(context);

        return context;
    }

    private void SeedTestData(AppDbContext context)
    {
        // Add test years of study
        var yearOfStudy = new YearOfStudy { Id = 1, Name = "Tingkatan 6" };
        context.YearsOfStudy.Add(yearOfStudy);

        // Add test classes
        var class1 = new Class { Id = 1, Name = "6 Bestari", YearOfStudyId = 1 };
        var class2 = new Class { Id = 2, Name = "6 Cemerlang", YearOfStudyId = 1 };
        context.Classes.AddRange(class1, class2);

        // Add test associations
        context.Associations.AddRange(
            new Association { Id = 1, Name = "Persatuan Sains" },
            new Association { Id = 2, Name = "Persatuan Matematik" }
        );

        // Add test competitions
        context.Competitions.AddRange(
            new Competition { Id = 1, Name = "Karnival Rekacipta dan Inovasi SMAPK 2025" },
            new Competition { Id = 2, Name = "Pertandingan Matematik Kebangsaan" }
        );

        // Add test students
        context.Students.AddRange(
            new Student { Id = 1, Name = "Ahmad Ali", YearOfStudyId = 1, ClassId = 1 },
            new Student { Id = 2, Name = "Siti Fatimah", YearOfStudyId = 1, ClassId = 2 },
            new Student { Id = 3, Name = "Muhammad Hassan", YearOfStudyId = 1, ClassId = 1 }
        );

        context.SaveChanges();
    }

    [Fact]
    public async Task GetYearsAsync_ReturnsAllYears()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var service = new RegistrationService(context);

        // Act
        var years = await service.GetYearsAsync();

        // Assert
        Assert.NotNull(years);
        Assert.Single(years);
        Assert.Contains(years, y => y.Name == "Tingkatan 6");
    }

    [Fact]
    public async Task GetClassesByYearAsync_ReturnsClassesForGivenYear()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var service = new RegistrationService(context);

        // Act
        var classes = await service.GetClassesByYearAsync(1);

        // Assert
        Assert.NotNull(classes);
        Assert.Equal(2, classes.Count);
        Assert.Contains(classes, c => c.Name == "6 Bestari");
        Assert.Contains(classes, c => c.Name == "6 Cemerlang");
    }

    [Fact]
    public async Task GetStudentsByClassAsync_ReturnsStudentsForGivenYearAndClass()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var service = new RegistrationService(context);

        // Act
        var students = await service.GetStudentsByClassAsync(1, 1);

        // Assert
        Assert.NotNull(students);
        Assert.Equal(2, students.Count);
        Assert.Contains(students, s => s.Name == "Ahmad Ali");
        Assert.Contains(students, s => s.Name == "Muhammad Hassan");
    }

    [Fact]
    public async Task GetAssociationsAsync_ReturnsAllAssociations()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var service = new RegistrationService(context);

        // Act
        var associations = await service.GetAssociationsAsync();

        // Assert
        Assert.NotNull(associations);
        Assert.Equal(2, associations.Count);
        Assert.Contains(associations, a => a.Name == "Persatuan Sains");
        Assert.Contains(associations, a => a.Name == "Persatuan Matematik");
    }

    [Fact]
    public async Task GetCompetitionsAsync_ReturnsAllCompetitions()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var service = new RegistrationService(context);

        // Act
        var competitions = await service.GetCompetitionsAsync();

        // Assert
        Assert.NotNull(competitions);
        Assert.Equal(2, competitions.Count);
        Assert.Contains(competitions, c => c.Name == "Karnival Rekacipta dan Inovasi SMAPK 2025");
        Assert.Contains(competitions, c => c.Name == "Pertandingan Matematik Kebangsaan");
    }

    [Fact]
    public async Task RegisterAsync_ValidRegistration_CreatesRegistration()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var service = new RegistrationService(context);
        var model = new RegistrationModel
        {
            YearOfStudyId = 1,
            ClassId = 1,
            StudentId = 1,
            AssociationId = 1,
            CompetitionId = 1
        };

        // Act
        var registration = await service.RegisterAsync(model);

        // Assert
        Assert.NotNull(registration);
        Assert.Equal(1, registration.StudentId);
        Assert.Equal(1, registration.AssociationId);
        Assert.Equal(1, registration.CompetitionId);
        Assert.True(registration.Id > 0);
        Assert.True(registration.RegistrationDate > DateTime.MinValue);

        // Verify it was saved to database
        var savedRegistration = await context.Registrations
            .Include(r => r.Student)
            .Include(r => r.Association)
            .Include(r => r.Competition)
            .FirstOrDefaultAsync(r => r.Id == registration.Id);
        Assert.NotNull(savedRegistration);
        Assert.NotNull(savedRegistration.Student);
        Assert.NotNull(savedRegistration.Association);
        Assert.NotNull(savedRegistration.Competition);
    }

    [Fact]
    public async Task RegisterAsync_InvalidStudent_ThrowsException()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var service = new RegistrationService(context);
        var model = new RegistrationModel
        {
            YearOfStudyId = 1,
            ClassId = 1,
            StudentId = 999, // Non-existent student
            AssociationId = 1,
            CompetitionId = 1
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => service.RegisterAsync(model));
        Assert.Equal("Student not found", exception.Message);
    }

    [Fact]
    public async Task RegisterAsync_InvalidAssociation_ThrowsException()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var service = new RegistrationService(context);
        var model = new RegistrationModel
        {
            YearOfStudyId = 1,
            ClassId = 1,
            StudentId = 1,
            AssociationId = 999, // Non-existent association
            CompetitionId = 1
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => service.RegisterAsync(model));
        Assert.Equal("Association not found", exception.Message);
    }

    [Fact]
    public async Task RegisterAsync_InvalidCompetition_ThrowsException()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var service = new RegistrationService(context);
        var model = new RegistrationModel
        {
            YearOfStudyId = 1,
            ClassId = 1,
            StudentId = 1,
            AssociationId = 1,
            CompetitionId = 999 // Non-existent competition
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => service.RegisterAsync(model));
        Assert.Equal("Competition not found", exception.Message);
    }

    [Fact]
    public async Task GetRegistrationsGroupedAsync_ReturnsGroupedRegistrations()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var service = new RegistrationService(context);

        // Add registrations
        context.Registrations.AddRange(
            new Registration { StudentId = 1, AssociationId = 1, CompetitionId = 1, RegistrationDate = DateTime.Now },
            new Registration { StudentId = 2, AssociationId = 2, CompetitionId = 2, RegistrationDate = DateTime.Now },
            new Registration { StudentId = 3, AssociationId = 1, CompetitionId = 1, RegistrationDate = DateTime.Now }
        );
        await context.SaveChangesAsync();

        // Act
        var groupedRegistrations = await service.GetRegistrationsGroupedAsync();

        // Assert
        Assert.NotNull(groupedRegistrations);
        Assert.Single(groupedRegistrations); // Only one year of study
        Assert.True(groupedRegistrations.ContainsKey("Tingkatan 6"));

        var yearGroup = groupedRegistrations["Tingkatan 6"];
        Assert.Equal(2, yearGroup.Count); // Two classes
        Assert.True(yearGroup.ContainsKey("6 Bestari"));
        Assert.True(yearGroup.ContainsKey("6 Cemerlang"));

        var class1Registrations = yearGroup["6 Bestari"];
        Assert.Equal(2, class1Registrations.Count); // 2 students from class 1

        var class2Registrations = yearGroup["6 Cemerlang"];
        Assert.Single(class2Registrations); // 1 student from class 2
    }

    [Fact]
    public async Task GetRegistrationsGroupedAsync_EmptyDatabase_ReturnsEmptyDictionary()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var service = new RegistrationService(context);

        // Clear all registrations
        context.Registrations.RemoveRange(context.Registrations);
        await context.SaveChangesAsync();

        // Act
        var groupedRegistrations = await service.GetRegistrationsGroupedAsync();

        // Assert
        Assert.NotNull(groupedRegistrations);
        Assert.Empty(groupedRegistrations);
    }

    [Fact]
    public async Task RegisterAsync_DuplicateRegistration_ThrowsException()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var service = new RegistrationService(context);
        var model = new RegistrationModel
        {
            YearOfStudyId = 1,
            ClassId = 1,
            StudentId = 1,
            AssociationId = 1,
            CompetitionId = 1
        };

        // First registration should succeed
        await service.RegisterAsync(model);

        // Act & Assert - Second registration should fail
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => service.RegisterAsync(model));
        Assert.Equal("Student already registered", exception.Message);
    }

    [Fact]
    public async Task RegisterAsync_DifferentStudents_ShouldSucceed()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var service = new RegistrationService(context);
        
        var model1 = new RegistrationModel
        {
            YearOfStudyId = 1,
            ClassId = 1,
            StudentId = 1,
            AssociationId = 1,
            CompetitionId = 1
        };

        var model2 = new RegistrationModel
        {
            YearOfStudyId = 1,
            ClassId = 1,
            StudentId = 2, // Different student
            AssociationId = 1,
            CompetitionId = 1
        };

        // Act
        var registration1 = await service.RegisterAsync(model1);
        var registration2 = await service.RegisterAsync(model2);

        // Assert
        Assert.NotNull(registration1);
        Assert.NotNull(registration2);
        Assert.NotEqual(registration1.StudentId, registration2.StudentId);
        Assert.Equal(1, registration1.StudentId);
        Assert.Equal(2, registration2.StudentId);
    }
}
