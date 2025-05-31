using Kris.Models;

namespace Kris.Tests;

public class EntitiesTests
{
    [Fact]
    public void YearOfStudy_DefaultProperties_SetCorrectly()
    {
        // Arrange & Act
        var yearOfStudy = new YearOfStudy();

        // Assert
        Assert.Equal(0, yearOfStudy.Id);
        Assert.Equal(string.Empty, yearOfStudy.Name);
        Assert.NotNull(yearOfStudy.Classes);
        Assert.NotNull(yearOfStudy.Students);
        Assert.Empty(yearOfStudy.Classes);
        Assert.Empty(yearOfStudy.Students);
    }

    [Fact]
    public void Class_DefaultProperties_SetCorrectly()
    {
        // Arrange & Act
        var classEntity = new Class();

        // Assert
        Assert.Equal(0, classEntity.Id);
        Assert.Equal(string.Empty, classEntity.Name);
        Assert.Equal(0, classEntity.YearOfStudyId);
        Assert.Null(classEntity.YearOfStudy);
        Assert.NotNull(classEntity.Students);
        Assert.Empty(classEntity.Students);
    }

    [Fact]
    public void Student_DefaultProperties_SetCorrectly()
    {
        // Arrange & Act
        var student = new Student();

        // Assert
        Assert.Equal(0, student.Id);
        Assert.Equal(string.Empty, student.Name);
        Assert.Equal(0, student.YearOfStudyId);
        Assert.Null(student.YearOfStudy);
        Assert.Equal(0, student.ClassId);
        Assert.Null(student.Class);
        Assert.NotNull(student.Registrations);
        Assert.Empty(student.Registrations);
    }

    [Fact]
    public void Association_DefaultProperties_SetCorrectly()
    {
        // Arrange & Act
        var association = new Association();

        // Assert
        Assert.Equal(0, association.Id);
        Assert.Equal(string.Empty, association.Name);
        Assert.NotNull(association.Registrations);
        Assert.Empty(association.Registrations);
    }

    [Fact]
    public void Competition_DefaultProperties_SetCorrectly()
    {
        // Arrange & Act
        var competition = new Competition();

        // Assert
        Assert.Equal(0, competition.Id);
        Assert.Equal(string.Empty, competition.Name);
        Assert.NotNull(competition.Registrations);
        Assert.Empty(competition.Registrations);
    }

    [Fact]
    public void Registration_DefaultProperties_SetCorrectly()
    {
        // Arrange & Act
        var registration = new Registration();

        // Assert
        Assert.Equal(0, registration.Id);
        Assert.Equal(0, registration.StudentId);
        Assert.Null(registration.Student);
        Assert.Equal(0, registration.AssociationId);
        Assert.Null(registration.Association);
        Assert.Equal(0, registration.CompetitionId);
        Assert.Null(registration.Competition);
        Assert.True(registration.RegistrationDate > DateTime.MinValue);
    }

    [Fact]
    public void Registration_SetProperties_ReturnsCorrectValues()
    {
        // Arrange
        var studentId = 1;
        var associationId = 2;
        var competitionId = 3;
        var registrationDate = DateTime.Now;

        // Act
        var registration = new Registration
        {
            StudentId = studentId,
            AssociationId = associationId,
            CompetitionId = competitionId,
            RegistrationDate = registrationDate
        };

        // Assert
        Assert.Equal(studentId, registration.StudentId);
        Assert.Equal(associationId, registration.AssociationId);
        Assert.Equal(competitionId, registration.CompetitionId);
        Assert.Equal(registrationDate, registration.RegistrationDate);
    }

    [Fact]
    public void Student_WithRelatedEntities_NavigationPropertiesWork()
    {
        // Arrange
        var yearOfStudy = new YearOfStudy { Id = 1, Name = "Form 6" };
        var classEntity = new Class { Id = 1, Name = "6A", YearOfStudyId = 1, YearOfStudy = yearOfStudy };
        var student = new Student
        {
            Id = 1,
            Name = "John Doe",
            YearOfStudyId = 1,
            YearOfStudy = yearOfStudy,
            ClassId = 1,
            Class = classEntity
        };

        // Act & Assert
        Assert.Equal(yearOfStudy, student.YearOfStudy);
        Assert.Equal(classEntity, student.Class);
        Assert.Equal("Form 6", student.YearOfStudy.Name);
        Assert.Equal("6A", student.Class.Name);
    }
}